using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelTools = Microsoft.Office;
using Audits;
using System.Windows;
using Audits.Database;
using System.Data.OleDb;
using System.Reflection;
using Audits.Infastructure;
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace Audits.Interop
{
    public class Importer<T> where T : class, new()
    {
        private IEnumerable<DataRow> _data;
        private PropertyInfo[] _properties;
        private DataTable _dataTable;
        private HashSet<T> _objectCollection;
        private IImport<T> _import;
        private ICollection<T> _dataOut;
        private CancellationTokenSource _cancelToken;
        private ProgressReporter _reporter;

        private const string CN_STRING_XLS = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR=Yes;'";
        private const string CN_STRING_XLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;'";

        public Importer()
        {
            /*No arg constructor */
            _import = new Import<T>()
            {
                AddDate = DateTime.Now,
                ImportMonth = (byte)DateTime.Now.Month,
                ImportYear = DateTime.Now.Year,
                UpdateDate = DateTime.Now,
                SheetID = 0
            };

            _cancelToken = new CancellationTokenSource();
            _reporter = new ProgressReporter();
            _properties = typeof(T).GetProperties();
            _objectCollection = new HashSet<T>();
        }
        public ICollection<T> ObjectCollection
        {
            get { return _objectCollection; }
        }
        public string FilePath { get; set; }
        public ISheet Sheet { get; set; }
        public bool SaveImport { get; set; }
        private Action ProgressAction { get; set; }
        public IImport<T> Import
        {
            get { return _import; }
            set { _import = value; }
        }
        public DataTable DataTable
        {
            get { return _dataTable; }
        }
        public IEnumerable<DataRow> DataRows
        {
            get { return _data; }
        }
        private void SaveImportToDatabase()
        {
            Import<T> temp = new Import<T>().Where("import_month ={0} AND import_year={1}".Format(_import.ImportMonth, _import.ImportYear)).FirstOrDefault();
            if (temp == null)
            {
                _import.Add();
            }
            else
            {
                _import = temp;
            }
        }
 
        public void SetProgressAction(Action action)
        {
            ProgressAction = action;
            _reporter.ReportAction = ProgressAction;
        }

        public string GetFilePath()
        {
            OpenFileDialog fd = new OpenFileDialog();
            string[] files;

            fd.Title = "Select Excel File to Import.";
            fd.Multiselect = false;

            Nullable<bool> result = fd.ShowDialog();

            if (result == true)
            {
                files = fd.FileNames;
                this.FilePath = files[0];
                _import.FilePath = FilePath;
            }

            return this.FilePath;
        }

        public void ImportExcel(bool addAll = false)
        {
            SaveImportToDatabase();

            _dataOut = new HashSet<T>();
            ICollection<T> obj = new HashSet<T>();
            string cnString = GetCnString();

            _data = GetData(cnString, Sheet.Name);

            CreateObjects();
            if (this.SaveImport == true)
            {
                SaveCollection();
            }
        }

        private void CreateObjects()
        {
            long i = 1;
            _data.Each(r =>
            {
                if (i > Sheet.DataRowStart - 1)
                {
                    if (r.ItemArray[0] is DBNull) return;

                    T temp = new T();

                    _properties.Each(p =>
                    {
                        ISheetColumn col = Sheet.SheetColumns.FirstOrDefault(sc => sc.TableMap == p.Name);

                        if (col != null && col.Import == true && col.ObjSkip == false)
                        {
                            object val = r.Field<object>(col.Name);
                            if (val is DBNull || val == null)
                            {
                                if (p.PropertyType.IsNumeric())
                                {
                                    val = 0;
                                }
                                else { val = string.Empty; }
                            }
                            p.SetValue(temp, Convert.ChangeType(val, p.PropertyType));
                        }
                    });
                    if (typeof(IImportable).IsAssignableFrom(typeof(T))) { (temp as IImportable).import_id = _import.ImportID; }
                    _objectCollection.Add(temp);
                }
                i++;
            });
        }

        private string GetCnString()
        {
            string cnString = string.Empty;
            string ext = Path.GetExtension(FilePath);

            if (ext == ".xlsx")
            {
                cnString = string.Format(CN_STRING_XLSX, FilePath);
            }
            else if (ext == ".xls")
            {
                cnString = string.Format(CN_STRING_XLS, FilePath);
            }
            return cnString;
        }
        private IEnumerable<DataRow> GetData(string cn, string sheet)
        {
            OleDbConnection cnObj = new OleDbConnection(cn);
            try
            {
                cnObj.Open();
            }
            catch (Exception err) { MessageBox.Show("File is currently unavailable: " + err.Message); return null; }
            string sht = string.Empty;

            DataTable wrkSh = cnObj.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow dr in wrkSh.Rows)
            {
                sht = dr.Field<string>("TABLE_NAME");
                if (!sht.Contains("Sheet") && !sht.Contains("Instruction"))
                {
                    break;
                }
            }
            string sql = "SELECT * FROM [" + sht + "]";

            var adapter = new OleDbDataAdapter(sql, cn);

            var ds = new DataSet();

            adapter.Fill(ds, "dataTable");
            _dataTable = ds.Tables["dataTable"];

            return ds.Tables["dataTable"].AsEnumerable();
        }
        private void SaveCollection()
        {
            string sql = "INSERT INTO " + typeof(T).Name.SanitizeTypeName() + " (" + GetFields() + ") VALUES (" + GetFieldHolders() + ")";

            OleDbCommand cmd;
            OleDbConnection cn;

            CreateCommand(out cn, out cmd);

            OleDbTransaction trn = cn.BeginTransaction();
            cmd.Transaction = trn;

            _objectCollection.Each(o =>
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                FillValues(ref cmd, o);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception) { }
            });
            trn.Commit();
            cn.Close();
            _reporter.ReportProgress(ProgressAction);
        }
        private void CreateCommand(out OleDbConnection cn, out OleDbCommand cmd)
        {
            cn = new OleDbConnection();
            string cnSt = DataSeverConnection.Instance.Connection.ConnectionString;
            cn.ConnectionString = cnSt;

            cn.OpenAsync();
            cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            cmd.Connection = cn;
        }
        private void FillValues(ref OleDbCommand cmd, T obj)
        {

            foreach (PropertyInfo p in _properties)
            {
                ISheetColumn col = Sheet.SheetColumns.FirstOrDefault(sc => sc.TableMap == p.Name);
                if (col != null && col.Import == true)
                {
                    object val = p.GetValue(obj);
                    if (val is DBNull)
                    {
                        if (p.PropertyType.IsNumeric())
                        {
                            val = 0;
                        }
                        else { val = string.Empty; }
                    }

                    cmd.Parameters.AddWithValue("@" + col.TableMap, val);
                }
            }
        }
        private string GetFields()
        {
            string output = string.Empty;

            Sheet.SheetColumns.Each(s =>
            {
                if (s.Import == true)
                {
                    output += s.TableMap + ",";
                }
            });
            return output.Substring(0, output.Length - 1);
        }
        private string GetFieldHolders()
        {
            string output = string.Empty;
            Sheet.SheetColumns.Each(p =>
            {
                if (p.Import == true)
                    output += "@" + p.TableMap + ",";
            });
            return output.Substring(0, output.Length - 1);
        }
    }
}

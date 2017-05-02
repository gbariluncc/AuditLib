using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using Audits.Infastructure;
using System.Windows;

namespace Audits.Database
{
    public abstract class DatabaseObject<T> : ViewBase, IDatabaseObject<T> where T : class, new()
    {
        public static ICollection<T> Where<T>(string sqlWhere) where T : class, new()
        {
            T obj = new T();

            string tblName = typeof(T).Name;
            int idx = tblName.IndexOf("`");
            if (idx > 0) { tblName = tblName.Substring(0, idx); }

            string sqlSelect = "SELECT * FROM [" + tblName + "]";

            return Extensions.GetDataCollection<T>(sqlSelect, sqlWhere, DataSeverConnection.Instance);
            //DataSeverConnection.Instance.Connection.Close();
        }
        public virtual void Update() 
        {
            try
            {
                string[] keys = GetPrimaryKeyColumns();
                string tblName = typeof(T).Name;
                int idx = tblName.IndexOf("'");
                if (idx > 0) { tblName = tblName.Substring(0, idx); }
                string sql = "SELECT * FROM [" + typeof(T).Name + "] WHERE " + GetSQLCriteria(GetPrimaryKeys(keys));

                ADODB.Recordset rs = DataSeverConnection.Instance.Recordset(sql, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

                FillRecordset(false, rs, keys);
                rs.Update();
            }
            catch (Exception err) { MessageBox.Show("Error Updating Database: " + err.Message); }
        }
        public bool NeedsToSave { get; set; }

        public static ICollection<T> FillFromDataTable(DataTable dt)
        {
            HashSet<T> list = new HashSet<T>();
            //PropertyInfo[] properties = typeof(T).GetProperties();

            dt.Rows.OfType<DataRow>().EachAsync(r =>
            {
                T temp = r.CopyDataRowToObject<T>();
                /*T temp = new T();

                dt.Columns.OfType<DataColumn>().Each(c =>
                {
                    properties.Each(p => 
                    {
                        if (p.Name.ToLower() == c.ColumnName.ToLower())
                        {
                            object value = r[c];
                            try
                            {
                                p.SetValue(temp, Convert.ChangeType(value, p.PropertyType));
                            }
                            catch (Exception) { }
                        }
                    });
                });*/
                list.AddAsync(temp);
            });

            return list;
        }
        public virtual void Add(bool addAll = false, ProgressReporter pg = null) 
        {
            //lock (DataSeverConnection.Instance.Connection)
            //{
            try
            {
                string sql = "SELECT * FROM [" + typeof(T).Name.SanitizeTypeName() + "]";
                ADODB.Recordset rs = DataSeverConnection.Instance.Recordset(sql, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
                string[] keys = GetPrimaryKeyColumns();

                try
                {
                    rs.AddNew();
                    FillRecordset(addAll, rs, keys);
                    rs.Update();
                }
                catch (Exception) { return; }
                if (addAll == false)
                {
                    keys.Each(k =>
                    {
                        int pos = rs.GetFieldPosition(k);
                        PropertyInfo temp = typeof(T).GetProperty(k);
                        object val = rs.Fields[pos].Value;
                        temp.SetValue(this, Convert.ChangeType(val, temp.PropertyType));
                    });
                }
                rs.Close();
                NeedsToSave = false;
                if (pg != null) { pg.ReportProgress(pg.ReportAction); }
            }
            catch (Exception err) { MessageBox.Show("Error adding to Database: " + err.Message); }
            //}
        }
        public virtual void AddAsync(bool addAll = false, ProgressReporter pg = null)
        {
            Task.Factory.StartNew(() => this.Add(addAll,pg));
            //Task t = new Task(() => this.Add(addAll));
            //t.Start();
        }
        public virtual void UpdateAsync()
        {
            Task.Factory.StartNew(() => this.Update());
            NeedsToSave = false;
            //Task t = new Task(() => this.Update());
            //t.Start();
        }
        private void FillRecordset(bool addAll, ADODB.Recordset rs, string[] keys)
        {
            for (int i = 0; i < rs.Fields.Count; i++)
            {
                if (!keys.Contains(rs.Fields[i].Name) || addAll == true)
                {
                    PropertyInfo p = typeof(T).GetProperty(rs.Fields[i].Name);

                    if (p != null)
                    {
                        rs.Fields[i].Value = p.GetValue(this);
                    }

                    /*PropertyInfo temp = GetPropertyByName(rs.Fields[i].Name);
                    try
                    {
                        rs.Fields[i].Value = temp.GetValue(this);
                    }
                    catch (Exception) { }/*/
                }
            }
        }
        public virtual void Delete() 
        { 
            this.DeleteData(); 
        }
        public static void ClearTable()
        {
            string sql = "DELETE * FROM [" + typeof(T).Name + "]";
            object rowsAff;

            DataSeverConnection.Instance.Connection.Execute(sql, out rowsAff);
        }
        private void DeleteData()
        {
            List<PropertyInfo> keys = GetPrimaryKeys(GetPrimaryKeyColumns());
            object rowsAff;

            string sql = "DELETE * FROM [" + typeof(T).Name + "] WHERE " + GetSQLCriteria(keys);

            DataSeverConnection.Instance.Connection.Execute(sql, out rowsAff);
        }
        private string GetSQLCriteria(List<PropertyInfo> keys)
        {
            string criteria = string.Empty;

            if (keys.Count == 0) return criteria;

            keys.Each(k =>
            {
                string temp = k.Name + "=";
                if (k.PropertyType == typeof(string))
                {
                    temp += "'" + k.GetValue(this) + "'";
                }
                else if (k.PropertyType == typeof(DateTime))
                {
                    temp += "#" + k.GetValue(this) + "#";
                }
                else { temp += k.GetValue(this); }

                criteria += temp + " AND ";
            });

            return criteria.Substring(0, criteria.Length - 5);
        }
        private string[] GetPrimaryKeyColumns()
        {
            string tableName = typeof(T).Name.SanitizeTypeName();

            using (OleDbConnection cn = new OleDbConnection(DataSeverConnection.Instance.Connection.ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + tableName + "]", cn))
                {
                    cn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
                    var schemaTable = reader.GetSchemaTable();
                    var keyQuery = (
                            from T in schemaTable.AsEnumerable()
                            where T.Field<bool>("IsKey")
                            select T.Field<string>("ColumnName")).ToArray();

                    return keyQuery;
                }
            }
        }
        private List<PropertyInfo> GetPrimaryKeys(string[] keyColumns)
        {
            List<PropertyInfo> temp = new List<PropertyInfo>();

            keyColumns.Each(k =>
            {
                PropertyInfo p = typeof(T).GetProperty(k);

                if (p != null)
                {
                    temp.Add(p);
                }
            });

            return temp;
        }
        private Dictionary<string, PropertyInfo> GetPrimaryKeyDictionary()
        {
            Dictionary<string, PropertyInfo> keys = new Dictionary<string, PropertyInfo>();

            string[] keyCol = GetPrimaryKeyColumns();

            keyCol.Each(k =>
            {
                PropertyInfo temp = typeof(T).GetProperty(k);

                if (temp != null)
                {
                    keys.Add(temp.Name, temp);
                }
            });

            return keys;
        }
       /* private List<PropertyInfo> GetPrimaryKeys()
        {
            List<PropertyInfo> returnKeys = new List<PropertyInfo>();

            /*typeof(T).Properties().Each(p =>
            {
                var attr = (DatabaseAttribute)p.GetCustomAttribute(typeof(DatabaseAttribute), false);
                if (Attribute.IsDefined(p, typeof(DatabaseAttribute)) && attr.IsPrimary)
                {
                    returnKeys.Add(p);
                }
            });
            keys.Each(k => returnKeys.Add(GetPropertyByName(k)));

            return returnKeys;
        }*/
        /*private PropertyInfo GetPropertyByName(string name)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo p in properties)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }*/


        public DBObjectState ObjectState
        {
            get
            {
                return DBObjectState.StateObjectUnchanged;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

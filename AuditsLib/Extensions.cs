using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using Audits.Database;
using Audits.Database.DatabaseObjects;
using Audits.Database.DMSObjects;
using System.Windows.Data;
using System.ComponentModel;
using Audits.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections;

namespace Audits
{
    public static class Extensions
    {
        static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
        public static void RemoveAll<T, F>(this IDictionary<T, F> source, T value) where F : class
        {
            foreach (var s in source.Where(kv => kv.Key.Equals(value)).ToList())
            {
                source.Remove(s.Key);
            }
        }
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            try
            {
                return new ObservableCollection<T>(source);
            }
            catch (Exception err) { MessageBox.Show("Extension: ToObservableCollectin -" + err.Message); return null; }
        }
        public static void SaveAll<T>(this ICollection<T> source) where T : class, new()
        {
            source.Each(e =>
                {
                    if (e is DatabaseObject<T>)
                    {
                        (e as DatabaseObject<T>).Add();
                    }
                });
        }
        public static void FillCommandParams<T>(this OleDbCommand source, T dataObject) where T : class
        {
            int i = 0;

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo p in properties)
            {
                var attr = (DatabaseAttribute)p.GetCustomAttribute(typeof(DatabaseAttribute), false);

                if (Attribute.IsDefined(p, typeof(DatabaseAttribute)) && (attr.IsDBField && !attr.IsReadOnly))
                {
                    source.Parameters[i].Value = p.GetValue(dataObject) ?? DBNull.Value;
                    i++;
                }
            }
        }
        public static OleDbCommand GetCommand<T>(this T source, OleDbConnection cn, OleDbTransaction tran) where T : class
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;

            string sql = @"INSERT INTO " + typeof(T).Name.SanitizeTypeName() + " ({0}) VALUES ({1})";
            string flds = string.Empty;
            string holders = string.Empty;

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo p in properties)
            {
                var attr = (DatabaseAttribute)p.GetCustomAttribute(typeof(DatabaseAttribute), false);

                if (Attribute.IsDefined(p, typeof(DatabaseAttribute)) && (attr.IsDBField && !attr.IsReadOnly))
                {
                    flds += p.Name + ",";
                    holders += "?,";

                    cmd.Parameters.Add("?", attr.DataType, attr.FieldSize);
                }
            }

            flds = flds.Substring(0, flds.Length - 1);
            holders = holders.Substring(0, holders.Length - 1);

            sql = string.Format(sql, flds, holders);

            cmd.CommandText = sql;
            cmd.Prepare();

            return cmd;
        }

        public static T CopyDataRowToObject<T>(this DataRow row) where T : class, new()
        {
            T item = new T();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attr = (DataColumnAttribute)property.GetCustomAttribute(typeof(DataColumnAttribute), false);
                if (Attribute.IsDefined(property, typeof(DataColumnAttribute)) && attr.IsDataColumn)
                {
                    if(row[property.Name] != DBNull.Value)
                    {
                        var propType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        property.SetValue(item, Convert.ChangeType(row[property.Name], propType), new object[0]);
                    }
                }
            }

            return item;
        }
        public static List<T> TableToList<T>(this DataTable source) where T : class, new()
        {
            List<T> ret = new List<T>();

            foreach (DataRow rw in source.Rows)
            {
                T item = new T();

                foreach (DataColumn col in source.Columns)
                {
                    PropertyInfo p = typeof(T).GetProperty(col.ColumnName);

                    if (p != null && rw[col] != DBNull.Value)
                    {
                        var propType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                        p.SetValue(item, Convert.ChangeType(rw[col], propType), new object[0]);
                    }
                }
                ret.Add(item);
            }
            return ret;
        }

        public static void LoadAddressesAsync(this IGroup source)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => source.EmailAddresses.EachAsync(a => { IEmailAddress add = a.EmailAddress; }));
        }
        public static IList<IEmailGroup> GetRecipients(this ICollection<IEmailGroup> source, EmailAddressType emailType)
        {
            return source.Where(s => s.EmailTypeID == (int)emailType).ToList<IEmailGroup>();
        }
        public static void AddRecipients(this Outlook.MailItem mail, IList<IEmailGroup> addresses, Outlook.OlMailRecipientType type)
        {
            addresses.EachAsync(a =>
            {
                Outlook.Recipient rcp = mail.Recipients.Add(a.EmailAddress.Address);
                rcp.Type = (int)type;
            });
            /*foreach (string address in addresses)
            {
                Outlook.Recipient rcp = mail.Recipients.Add(address);
                rcp.Type = (int)type;
            }*/
        }
        public static string MakeHtmlTableRow(this IPO source)
        {
            string row = string.Format(Resources.PORow,
                                        source.Number,
                                        source.Vendor,
                                        source.ShipFromVBU,
                                        source.ScheduledArrival.ToShortDateString(),
                                        source.LandedDate,
                                        source.SCAC,
                                        source.TrailerID,
                                        source.GetHoldReasonString());

            return row;
        }
        public static string GetHoldReasonString(this IPO source)
        {
            if(source.RequestItem == null){ return "Audit"; }

            IHoldReason hr = source.GetHoldReason();
            if (hr == null) return "Hold Reason Unknown";

            return hr.ReasonText;
        }
        public static IHoldReason GetHoldReason(this IPO source)
        {
            string sql = string.Format("source_id={0} AND is_safety={1}", source.RequestItem.Request.Project.SourceID, source.RequestItem.Request.IsSafety);

            IHoldReasonMap map = new HoldReasonMap().Where(sql).FirstOrDefault();
            if (map == null) return null;
            else return map.HoldReason;
        }
        public static IList<IEmailGroup> GetRecipients(this IGroup source, EmailAddressType emailType)
        {
            return source.EmailAddresses.GetRecipients(emailType);
        }
        public static List<List<T>> GetAllCombos<T>(this IList<T> source)
        {
            List<List<T>> result = new List<List<T>>();

            result.Add(new List<T>());
            result.Last().Add(source[0]);
            if (source.Count == 1)
            {
                return result;
            }

            List<List<T>> tailCombos = GetAllCombos(source.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(source[0]);
                result.Add(new List<T>(combo));
            });

            return result;
        }
        public static string GetSQLCriteriaForVBU(this int source, int location)
        {
            string qryBase = Resources.SelectPOBase;
            qryBase = string.Format(qryBase, location, source);

            return qryBase;
        }
        public static string GetSQLCriteriaForPO(this IList<long> source, int location, int vbu)
        {
            string subQryBase = Resources.POItmSubQryBase;
            string subQrys = string.Empty;
            string qryStart = "SELECT SubQry0.E058_PO_NBR FROM ";
            string qryEnd = string.Empty;
            string qryCrit = string.Empty;
            string vbuCrit = string.Empty;

            if (vbu > 0)
            {
                vbuCrit = string.Format("AND LOWES.W002_PO_DAL_DTL.P028_VND_NBR={0}", vbu);
            }

            for (int i = 0; i < source.Count; i++)
            {
                subQrys += "(" + string.Format(subQryBase, source[i], location,vbuCrit) + ") AS SubQry" + i + ",";

                if(string.IsNullOrEmpty(qryCrit))
                {
                    qryCrit += "SubQry" + i + ".E058_PO_NBR";
                }
                else
                {

                    string temp = qryCrit;
                    qryCrit = "SubQry" + i + ".E058_PO_NBR ";
                    qryEnd += qryCrit + "=" + temp + " AND ";
                }
            }

            qryStart += subQrys.Substring(0,subQrys.Length -1) + (qryEnd.Length > 0 ? " WHERE " + qryEnd.Substring(0,qryEnd.Length -5) : string.Empty);

            return qryStart;
            /*if (source.Count == 0) return string.Empty;

            string sql = "LOWES.W001_PO_DAL_HDR.RCP_CD_TXT='N' AND LOWES.W002_PO_DAL_DTL.RCV_QTY=0 AND LOWES.W001_PO_DAL_HDR.T063_LCT_NBR={0}";
            sql = string.Format(sql, location);
            
            string statement = " AND LOWES.W002_PO_DAL_DTL.T024_ITM_NBR={0}";

            source.Each(e =>
            {
                sql += string.Format(statement, e);
            });

            sql = string.Format(Resources.GetPOsFromItemList, sql);

            return sql;
            //return Resources.GetPOsFromItemList;*/
        }

        public static ICollection<IPO> GetPOsFromList(this IList<long> source)
        {
            HashSet<IPO> pos = new HashSet<IPO>();

            source.Each(p => pos.Add(new PO(p)));

            return pos;
        }
        public static ICollection<IPO> GetPOsFromList(this IList<int> source)
        {
            HashSet<IPO> pos = new HashSet<IPO>();

            source.Each(p => pos.Add(new PO(p)));

            return pos;
        }
        public static ICollection<IPO> GetPOsFromList(this ADODB.Recordset rs, int position = 0)
        {
            HashSet<IPO> pos = new HashSet<IPO>();

            rs.Each(e =>
            {
                pos.Add(new PO((long)rs.Fields[position].Value));
            });

            return pos;
        }
        
        public static void SaveAllAsync<T>(this ICollection<T> source) where T : class, new()
        {
            source.Each(e =>
            {
                if (e is DatabaseObject<T>)
                {
                    (e as DatabaseObject<T>).AddAsync();
                }
            });
        }
        public static bool InstancePropertiesEqual<T>(this T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignore);

                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (!ignoreList.Contains(p.Name))
                    {
                        object selfValue = type.GetProperty(p.Name).GetValue(self, null);
                        object toValue = type.GetProperty(p.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {

                            var test = Convert.ChangeType(selfValue, selfValue.GetType());
                            var test2 = Convert.ChangeType(toValue, toValue.GetType());

                            bool testval = test.IsInstanceOfHashSet();

                            //Commented out this seciont because I don't think I need it - I may need to 
                            if (test is HashSet<IRequestItem>)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            //selfValue.Equals(toValue);
                        }
                    }
                }
                return true;
            }
            return self == to;
        }
        public static bool IsInstanceOfHashSet(this object source)
        {
            if (source == null) return false;
            return source.GetType() == typeof(HashSet<>);
        }
        public static bool HashsetIsEqual<T>(this HashSet<T> source, HashSet<T> compare)
        {
            if (!(compare is HashSet<T>)) return false;
            return source.SetEquals(compare);
        }
        public static ICollection<PropertyInfo> Properties<T>(this T source) where T : class
        {
            return typeof(T).GetProperties();
        }
        public static DateTime FromNow(this long seconds)
        {
            return DateTime.Now.AddSeconds(seconds);
        }
        public static void Copy<T>(this T source, T from) where T : class
        {
            PropertyInfo[] propertiesFrom = typeof(T).GetProperties();
            PropertyInfo[] propertiesTo = typeof(T).GetProperties();

            for (int i = 0; i < propertiesFrom.Count(); i++)
            {
                try
                {
                    propertiesTo[i].SetValue(source, propertiesFrom[i].GetValue(from));
                }
                catch (Exception) { }
            }
        }
        public static ICollection<T> Filter<T>(this ICollection<T> source, Predicate<object> filter)
        {
            ICollectionView col = CollectionViewSource.GetDefaultView(source) as ListCollectionView;
            HashSet<T> data = new HashSet<T>();

            col.Filter = filter;

            foreach (T temp in col)
            {
                data.Add(temp);
            }

            var flt = (Predicate<object>)null;
            col.Filter = flt;

            return data;
        }
        public static void FilterInPlace<T>(this ICollection<T> source, Predicate<object> filter)
        {
            ICollectionView col = CollectionViewSource.GetDefaultView(source) as ListCollectionView;
            col.Filter = filter;
        }
        public static Int32 Days(this Int32 source)
        {
            return source * 24 * 60 * 60;
        }
        public static string Format(this string source, object value)
        {
            return string.Format(source, value);
        }
        public static string Format(this string source, object value1, object value2)
        {
            return string.Format(source, value1, value2);
        }
        public static void AddOnUI<T>(this ICollection<T> collection, T item)
        {
            Action<T> addMethod = collection.Add;
            Application.Current.Dispatcher.BeginInvoke(addMethod, item);
        }
        public static void RemoveOnUI<T>(this ICollection<T> collection, T item)
        {
            Func<T,bool> removeMethod = collection.Remove;
            Application.Current.Dispatcher.BeginInvoke(removeMethod, item);
        }
        public static void AddBatchOnUI<T>(this ICollection<T> collection, ICollection<T> source)
        {

        }
        public static ObservableCollection<T> ToObservableCollection<T, F>(this IEnumerable<F> source) where T : new()
        {
            try
            {
                ObservableCollection<T> rCol = new ObservableCollection<T>();
                foreach (F temp in source)
                {
                    Type classType = typeof(T);
                    ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { temp.GetType() });
                    T classInstace = (T)classConstructor.Invoke(new object[] { temp });

                    rCol.Add(classInstace);
                }

                return rCol;
            }
            catch (Exception err) { MessageBox.Show("Conversion error: " + err.Message); return null; }
        }
        public static IIterationArgs Each<T>(this IEnumerable<T> source, IIterationArgs command) where T : class
        {
            foreach (T itm in source)
            {
                command.Execute(itm);
            }

            return command;
        }
        public static void AddAsync<T>(this ICollection<T> source, T obj) where T : class
        {
            try
            {
                _rw.EnterUpgradeableReadLock();
                try
                {
                    _rw.EnterWriteLock();
                    source.Add(obj);
                }
                finally { _rw.ExitWriteLock(); }
            } finally { _rw.ExitUpgradeableReadLock(); }
        }
        public static ICollection<T> Where<T>(this IDatabaseObject<T> source, string sqlstatement) where T : class, new()
        {
            string tblName = typeof(T).Name;
            int idx = tblName.IndexOf("`");
            if (idx > 0) { tblName = tblName.Substring(0, idx); }

            string sql = "SELECT * FROM [" + tblName + "]";
            ICollection<T> retVal = GetDataCollection<T>(sql, sqlstatement, DataSeverConnection.Instance);
            //DataSeverConnection.Instance.Connection.Close();

            return retVal;
        }
        public static string SanitizeTypeName(this string source)
        {
            int idx = source.IndexOf("`");
            if (idx > 0) { return source.Substring(0, idx); }
            else { return source; }
        }
        public static ICollection<T> GetDMSObjects<T>(this IDMSObject<T> source, string sqlstatement) where T :class, new()
        {
            ICollection<T> retVal = GetDataCollection<T>(sqlstatement, "", DMSConnection.GetInstance());
           // DMSConnection.GetInstance().Connection.Close();
            return retVal;
        }
        public static ICollection<T> GetAll<T>(this IDatabaseObject<T> source) where T : class, new()
        {
            string sql = "SELECT * FROM [" + typeof(T).Name + "]";
            ICollection<T> retVal = GetDataCollection<T>(sql, "", DataSeverConnection.Instance);
            //DataSeverConnection.Instance.Connection.Close();

            return retVal;
        }
        public static void CopyFromDMS<T>(this IDMSObject<T> source, string sqlStatement) where T : class
        {
            ADODB.Recordset rs = DMSConnection.GetInstance().Recordset(sqlStatement);
            if (rs == null) return;
            if (rs.BOF && rs.EOF) return;

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < rs.Fields.Count; i++)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == rs.Fields[i].Name)
                    {
                        object value = rs.Fields[i].Value;
                        if (value is DBNull) { value = -1; }
                        property.SetValue(source, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
        }
        public static T ConvertToObject<T>(this string source, char delimiter) where T : class, new()
        {
            T obj = new T();

            int lasIdx = source.LastIndexOf(delimiter);
            if (lasIdx == source.Length) source = source.Substring(0, source.Length - 1);

            string[] fields = source.Split(delimiter);

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo p in properties)
            {
                var attr = (DataColumnAttribute)p.GetCustomAttribute(typeof(DataColumnAttribute), false);
                if (Attribute.IsDefined(p, typeof(DataColumnAttribute)) && attr.IsDataColumn)
                {
                    string val = fields[attr.ColumnPosition].Trim();
                    
                    if (!string.IsNullOrEmpty(val))
                    {
                        try
                        {
                            var propType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                            p.SetValue(obj, Convert.ChangeType(val, propType), new object[0]);
                        }
                        catch (Exception err) { Console.WriteLine("Error adding property: " + p.Name + " - " + err.Message); }
                    }
                }
            }

            return obj;
        }
        public static ICollection<T> GetDataCollection<T>(string sqlstatement, string whereClause, DatabaseConnection cn) where T : class, new()
        {
            string w = whereClause.Length == 0 ? string.Empty : " WHERE " + whereClause;
            string sql = sqlstatement + w;

            ADODB.Recordset rs = cn.Recordset(sql);
            Type type = typeof(T);

            ICollection<T> retV = CopyFromRS<T>(rs);

            rs.Close();
            //cn.Connection.Close();

            return retV;
        }
        public static int GetFieldPosition(this ADODB.Recordset source, string name)
        {
            for (int i = 0; i < source.Fields.Count; i++)
            {
                if (source.Fields[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }
        public static void AddData<T>(this IDatabaseObject<T> source)where T : class
        {
            string name = typeof(T).Name;
            string sql = "[" + name + "]";

            ADODB.Recordset rs = DataSeverConnection.Instance.Recordset(sql, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
            rs.AddNew();

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < rs.Fields.Count; i++)
            {
                PropertyInfo property = null;

                properties.Each(f =>
                {
                    if(f.Name == rs.Fields[i].Name){
                        property = f;
                        return;
                    }
                });

                rs.Fields[i].Value = property.GetValue(source);
            }
            rs.Update();
            rs.Close();
        }
        public static void DeleteData<T>(this IDatabaseObject<T> source) where T : class
        {
            string[] keys = GetPrimaryKeyColumns(typeof(T).Name);

        }
        
        private static string[] GetPrimaryKeyColumns(string tableName)
        {
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
        public static void Each(this ADODB.Recordset source, Action<ADODB.Recordset> method)
        {
            if (!(source.BOF && source.EOF))
            {
                do
                {
                    method(source);
                    source.MoveNext();
                } while (!source.EOF);
            }
        }
        public static ICollection<T> Copy<T>(this ADODB.Recordset source)where T : class, new()
        {
            return CopyFromRS<T>(source);
        }
        public static T Load<T>(this T source, ADODB.Recordset rs) where T : class, new()
        {
            return CopyFromRS<T>(rs).FirstOrDefault();
        }
        public static ICollection<T> Load<T>(this ADODB.Recordset source) where T : class, new()
        {
            return CopyFromRS<T>(source).ToHashSet<T>();
        }
        public static T LoadRecord<T>(this T source, ADODB.Recordset rs) where T : class
        {
            return CreateObject<T>(source, rs);
        }
        private static ICollection<T> CopyFromRS<T>(ADODB.Recordset rs) where T : class, new()
        {
            HashSet<T> list = new HashSet<T>();
            if (rs == null) return list;

            if (!(rs.BOF && rs.EOF))
            {
                do
                {
                    /*ThreadPool.QueueUserWorkItem(_ =>
                        {
                            AddObjectToList(list, rs);
                        });*/
                    T obj = CreateObject<T>(rs);
                    list.Add(obj);
                    rs.MoveNext();
                } while (!rs.EOF);
            }
            
            return list;
        }
        private static void AddObjectToList<T>(ICollection<T> list, ADODB.Recordset rs) where T : class, new()
        {
                 try
                    {
                        try
                        {
                            if (rs.EOF) return;

                            _rw.EnterUpgradeableReadLock();
                            T obj = CreateObject<T>(rs);
                            if(!(rs.EOF)) rs.MoveNext();
                            _rw.EnterWriteLock();
                            if (obj == null) return;
                            list.Add(obj);
                        }
                        finally
                        {
                            _rw.ExitWriteLock();
                        }
                    }
                 finally
                 {
                     _rw.ExitUpgradeableReadLock();
                 }
        }
        private static T CreateObject<T>(T source, ADODB.Recordset rs) where T : class
        {
            try
            {
                lock (rs)
                {
                    if (rs.BOF && rs.EOF) return null;

                    PropertyInfo[] properties = typeof(T).GetProperties();
                    for (int i = 0; i < rs.Fields.Count; i++)
                    {
                        PropertyInfo p = typeof(T).GetProperty(rs.Fields[i].Name);

                        if (p != null)
                        {
                            object value = rs.Fields[i].Value;
                            p.SetValue(source, Convert.ChangeType(value, p.PropertyType));
                        }
                    }
                }

                return source;
            }
            catch (Exception err) { MessageBox.Show("Erorr creating object: " + err.Message + " " + err.InnerException.Message); return null; }
        }
        private static T CreateObject<T>(ADODB.Recordset rs) where T : class, new()
        {
            try
            {
                lock (rs)
                {
                    if (rs.BOF && rs.EOF) return null;

                    PropertyInfo[] properties = typeof(T).GetProperties();
                    T temp = new T();

                    for (int i = 0; i < rs.Fields.Count; i++)
                    {
                        PropertyInfo p = typeof(T).GetProperty(rs.Fields[i].Name);
                        object value = rs.Fields[i].Value;

                        if (value is DBNull)
                        {
                            if (p.PropertyType.IsNumeric())
                            {
                                value = 0;
                            }
                            else { value = string.Empty; }
                        }

                        if (p != null)
                        {
                            var propType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                            p.SetValue(temp, Convert.ChangeType(value, propType), new object[0]);
                        }
                        
                        /*foreach (PropertyInfo property in properties)
                        {
                            if (property.Name == rs.Fields[i].Name)
                            {
                                object value = rs.Fields[i].Value;

                                if (value is DBNull)
                                {
                                    if (property.PropertyType.IsNumeric())
                                    {
                                        value = 0;
                                    }
                                    else { value = string.Empty; }
                                }

                                property.SetValue(temp, Convert.ChangeType(value, property.PropertyType));
                            }
                        }*/
                    }
                    return temp;
                }
            }
            catch (Exception err) { MessageBox.Show("Error CreateObject: " + err.Message); return null; }
        }
        public static void CopyFromRS<T>(this ICollection<T> source, ADODB.Recordset rs)where T : class, new()
        {
            source = CopyFromRS<T>(rs);

        }

        public static object Each<T>(this IEnumerable<T> source, Func<T, object> method)
        {
            object v = null;
            foreach (T itm in source)
            {
                v = method(itm);
            }
            return v;
        }
        public static void EachAsync<T>(this IEnumerable<T> source, Action<T> method) where T: class
        {
            Parallel.ForEach(source, (itm) =>
            {
                method(itm);
            });
            
        }
        public static async System.Threading.Tasks.Task ForEachAsync<T>(this List<T> source, Func<T, System.Threading.Tasks.Task> method)
        {
            foreach (var value in source)
            {
                await method(value);
            }
        }
        public static bool IsNumeric(this Type type)
        {
            if (type == null)
            {
                return false;
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if ( type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumeric(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }

        public static void Each<T>(this IEnumerable<T> source, Action<T> method)
        {
            foreach (T itm in source)
            {
                method(itm);
            }
        }
        public static void CloseAsync(this ADODB.Recordset rs)
        {
            new Thread(() => rs.Close());
        }
        public static void CloseAsync(this ADODB.Connection cn)
        {
            new Thread(() => cn.Close());
        }
    }
 
    public interface IIterationArgs
    {
        void Execute(object temp);
        object Results { get; }
    }
    public enum EmailAddressType
    {
        To = 1,
        CC = 2,
        BCC = 3
    }
    public enum HoldType
    {
        VendorVisit,
        Audit,
        POReview,
        SpecialProject
    }
}

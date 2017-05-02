using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.Data;
using System.Data.OleDb;
using Audits;

namespace Audits.Database.DataAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {

        public ICollection<T> GetAll()
        {
            HashSet<T> list = new HashSet<T>();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            string name = typeof(T).Name;
            PropertyInfo[] properties = typeof(T).GetProperties();

            string sql = "SELECT * FROM [" + name + "]";
            ADODB.Recordset rs = DataSeverConnection.Instance.Recordset(sql);

            da.Fill(ds, rs, name);

            //rs.Close();

            ds.Tables[name].Rows.OfType<DataRow>().EachAsync(r => 
            {
                T temp = new T();
                ds.Tables[name].Columns.OfType<DataColumn>().Each(c =>
                {
                    properties.Each(p =>
                    {
                        if (p.Name == c.ColumnName)
                        {
                            object value = r[c];
                            try
                            {
                                p.SetValue(temp, Convert.ChangeType(value, p.PropertyType));
                            }
                            catch (Exception) { }
                        }
                    });
                });
                list.AddAsync(temp);
            });

            /*if (!(rs.BOF && rs.EOF))
            {
                do
                {
                    T temp = new T();
                    for (int i = 0; i < rs.Fields.Count; i++)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.Name == rs.Fields[i].Name)
                            {
                                object value = rs.Fields[i].Value;
                                try
                                {
                                    property.SetValue(temp, Convert.ChangeType(value, property.PropertyType));
                                }
                                catch (Exception) { }
                            }
                        }
                        list.Add(temp);
                    }
                    rs.MoveNext();
                } while (!rs.EOF);
            }
            
            rs.Close();*/
            //DataSeverConnection.Instance.Connection.Close();

            rs = null;
            return list;
        }
        private string GetPropertyName<T>(Expression<Func<T>> propertyExpression)where T : class
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
        public T GetSingle(Func<T, bool> where)
        {
            T item = new T();

            item = GetAll().FirstOrDefault(where);

            return item;
        }

        public void Add(params T[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params T[] items)
        {
            throw new NotImplementedException();
        }

        public void Remove(params T[] items)
        {
            throw new NotImplementedException();
        }
    }
}

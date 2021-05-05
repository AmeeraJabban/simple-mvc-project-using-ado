using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace sqlConnectionDAL
{
    public class ConnectionClassServer
    {
        public string CS;
        public IList<T> getAll<T>(String sql)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dataTableToList<T>(dt);
                }
            }

        }
        public T getByID<T>(int ID, string sql)
        {
            T student;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    student = dataTableToList<T>(dt, ID).FirstOrDefault();
                }
            }
            return student;
        }
        public void Add(string sql)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Edit(string sql)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string sql)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<T> Search<T>(string sql)
        {
            IList<T> studentDALs;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    studentDALs = dataTableToList<T>(dt);
                }

                return studentDALs;
            }
        }
        public static List<T> dataTableToList<T>(DataTable dt, int? ID = null)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }
        public string getConnectionStrings(string dbname)
        {
            CS = ConfigurationManager.ConnectionStrings[dbname].ConnectionString;
            return CS;
        }

    }


}

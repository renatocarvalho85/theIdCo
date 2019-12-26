using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.DataAccess
{
    public static class DataAccess
    {
        public static string GetconnectionString(string connectionName = "MaggieCardConnection")

        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(String sql)
        {
            return null;
            //using (IDbConnection cnn = new SqlConnection(GetconnectionString()))
            //{
            //    return cnn.Query<T>(sql).ToList();
            //}
        }

        public static int SaveData<T>(string sql, T data)
        {
            return 0;
            //using (IDbConnection cnn = new SqlConnection(GetconnectionString()))
            //{
            //    return cnn.Execute(sql, data);
            //}
        }


    }
}

using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Application.Common.Utility
{
    public static class QueryExtension
    {
        /// <summary>
        /// Ejecutar consulta
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string query, string connectionString)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var dlist = db.Query(query, commandType: CommandType.Text);
                var json = JsonConvert.SerializeObject(dlist);
                return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            }
        }

        /// <summary>
        /// Ejecutar procedimiento almacenado con parametros
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static List<dynamic> ExecuteSP(string query, object values, string connectionString)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var dlist = db.Query(query, values, commandType: CommandType.StoredProcedure).ToList();
                return dlist;
            }
        }

        /// <summary>
        /// Ejecutar procedimiento almacenado sin parametros
        /// </summary>
        /// <param name="querySp"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static List<dynamic> ExecuteSP(string querySp, string connectionString)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var dlist = db.Query(querySp, commandType: CommandType.StoredProcedure).ToList();
                return dlist;
            }
        }

        /// <summary>
        /// Ejecutar consulta multiple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static List<T> ExecuteQueryMultiple<T>(string query, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var temp = conn.QueryMultiple(query, commandType: CommandType.Text);
                return temp.Read<T>().AsList<T>();
            }
        }
    }
}

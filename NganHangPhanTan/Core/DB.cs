using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NganHangPhanTan.Core
{
    public static class DB
    {
        // Kết nối “hiện tại” theo chi nhánh người dùng chọn
        public static string CurrentDbKey { get; private set; } = "NGANHANG";
        public static string UserName { get; private set; }
        public static string Password { get; private set; }

        public static void UseConnection(string dbKey, string user, string pass)
        {
            CurrentDbKey = dbKey;
            UserName = user;
            Password = pass;
        }

        private static string BuildConnString()
        {
            var cs = ConfigurationManager.ConnectionStrings[CurrentDbKey]?.ConnectionString
                     ?? throw new Exception("Missing connection string key: " + CurrentDbKey);
            var builder = new SqlConnectionStringBuilder(cs)
            {
                UserID = UserName,
                Password = Password
            };
            return builder.ConnectionString;
        }

        public static SqlConnection GetOpenConnection()
        {
            var conn = new SqlConnection(BuildConnString());
            conn.Open();
            return conn;
        }

        public static DataTable Query(string sqlOrSp, CommandType type, params SqlParameter[] prms)
        {
            using (var conn = GetOpenConnection())
            using (var cmd = new SqlCommand(sqlOrSp, conn) { CommandType = type })
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                using (var da = new SqlDataAdapter(cmd))
                {
                    var tb = new DataTable();
                    da.Fill(tb);
                    return tb;
                }
            }
        }

        public static int Exec(string sp, params SqlParameter[] prms)
        {
            using (var conn = GetOpenConnection())
            using (var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure })
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecScalar(string sp, params SqlParameter[] prms)
        {
            using (var conn = GetOpenConnection())
            using (var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure })
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteScalar();
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NganHangPhanTan.Core
{
    public static class DB
    {
        // 3 database
        public static string dbTongHop = "NGANHANG";
        public static string dbBenThanh = "NGANHANG_BENTHANH";
        public static string dbTanDinh = "NGANHANG_TANDINH";

        // ✅ Kết nối hiện tại
        private static SqlConnection _currentConnection;

        // ✅ Thông tin đăng nhập
        public static string username = "";
        public static string password = "";
        public static string chiNhanh = "";

        // ✅ Thông tin quyền người dùng
        public static string userRole = "";
        public static string userCMND = "";
        public static string displayRole = "";

        // ✅ THÊM METHOD NÀY
        public static SqlConnection GetCurrentConnection()
        {
            if (_currentConnection == null || _currentConnection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("Chưa có kết nối đến database. Vui lòng đăng nhập lại.");
            }
            return _currentConnection;
        }

        // ✅ Tạo kết nối theo chi nhánh và user hiện tại
        public static void UseConnection(string dbKey, string user, string pass)
        {
            try
            {
                // Đóng connection cũ nếu có
                if (_currentConnection != null && _currentConnection.State == ConnectionState.Open)
                {
                    _currentConnection.Close();
                }

                string serverName = @"PC\MSSQLSERVER1"; // Server của bạn
                string connStr = $"Server={serverName};Database={dbKey};User Id={user};Password={pass};TrustServerCertificate=True;Connection Timeout=30;";

                _currentConnection = new SqlConnection(connStr);
                _currentConnection.Open();

                // Lưu thông tin đăng nhập
                username = user;
                password = pass;

                // Xác định chi nhánh
                if (dbKey.Contains("BENTHANH"))
                    chiNhanh = "BENTHANH";
                else if (dbKey.Contains("TANDINH"))
                    chiNhanh = "TANDINH";
                else
                    chiNhanh = "NGANHANG";
            }
            catch (SqlException ex)
            {
                throw new Exception($"Không thể kết nối đến {dbKey}: {ex.Message}");
            }
        }

        // ✅ Query với Text hoặc StoredProcedure
        public static DataTable Query(string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, GetCurrentConnection()))
                {
                    cmd.CommandType = cmdType;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi SQL Query: {ex.Message}");
            }
        }

        // ✅ Execute Stored Procedure không trả về dữ liệu
        public static void Exec(string spName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(spName, GetCurrentConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi thực thi SP {spName}: {ex.Message}");
            }
        }

        // ✅ Query Stored Procedure trả về DataTable
        public static DataTable QueryStoredProcedure(string spName, params SqlParameter[] parameters)
        {
            return Query(spName, CommandType.StoredProcedure, parameters);
        }

        // ✅ Đóng kết nối
        public static void CloseConnection()
        {
            if (_currentConnection != null && _currentConnection.State == ConnectionState.Open)
            {
                _currentConnection.Close();
            }
        }
    }
}
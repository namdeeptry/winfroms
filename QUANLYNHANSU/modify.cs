using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QUANLYNHANSU
{

    class modify
    {
        SqlDataAdapter dataAdapter;
        public modify()
        { }
        public DataTable getchamCong()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from chamcong";

            using (SqlConnection sql = Connection.getConnection())
            {
                sql.Open();
                dataAdapter = new SqlDataAdapter(query, sql);
                dataAdapter.Fill(dataTable);
                sql.Close();
            }
            return dataTable;
        }
        public DataTable getluong()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from bangluong";

            using (SqlConnection sql = Connection.getConnection())
            {
                sql.Open();
                dataAdapter = new SqlDataAdapter(query, sql);
                dataAdapter.Fill(dataTable);
                sql.Close();
            }
            return dataTable;
        }
        public DataTable getkhenthuongkyluat()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from khenthuongkyluat";

            using (SqlConnection sql = Connection.getConnection())
            {
                sql.Open();
                dataAdapter = new SqlDataAdapter(query, sql);
                dataAdapter.Fill(dataTable);
                sql.Close();
            }
            return dataTable;
        }
        public DataTable getnhanvien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from nhanvien";

            using (SqlConnection sql = Connection.getConnection())
            {
                sql.Open();
                dataAdapter = new SqlDataAdapter(query, sql);
                dataAdapter.Fill(dataTable);
                sql.Close();
            }
            return dataTable;
        }
    
}
}

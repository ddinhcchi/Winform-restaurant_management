using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class DataProvider
    {
        //singleton pattern (khởi tạo duy nhất)
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => instance = value;
        }

        private DataProvider() { }

        //chuỗi kết nối
        private string connectionSTR = "Data Source=MSI;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

        //truy vấn bảng dữ liệu (có thể có nhiều tham số truy vấn hoặc có thể không có tham số truy vấn)
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            //khởi tạo bảng mới
            DataTable data = new DataTable();

            //khởi tạo đối tượng kết nối mới và truy vấn dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                //mở kết nối
                connection.Open();

                //khởi tạo command mới với câu query trên connection
                SqlCommand command = new SqlCommand(query, connection);

                //thêm các tham số được truyền vào vào command
                if (parameter != null)
                {
                    //tách từng tham số ra bằng dấu cách
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    //vòng lặp thêm tham số vào command
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                //lấy kết quả sau khi truy vấn
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //đổ kết quả vào bảng data
                adapter.Fill(data);

                //đóng kết nối
                connection.Close();
            }

            return data;
        }

        //trả về số dòng thành công sau khi truy vấn
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            //khởi tạo đối tượng kết nối mới và truy vấn dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public void ExcuteNonQuery(string sql, CommandType type, SqlParameter[] paras)
        {
            SqlConnection sqlcon = new SqlConnection(connectionSTR);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = sql;
            cmd.CommandType = type;

            if (paras != null)//có tham số
                cmd.Parameters.AddRange(paras);

            cmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        //trả về cột đầu tiên của dòng đầu tiền sau khi truy vấn
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}

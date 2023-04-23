using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CrudMySQL.myClass
{
    class DB
    {
        public MySqlConnection conn;

        public DB()
        {
            string server = "localhost";
            string user = "root";
            string database = "employees";
            string pass = "root";
            string port = "3306";

            string connStr = "server=" + server + ";" +
                    "user=" + user + ";" +
                    "database=" + database + ";" +
                    "port=" + port + ";" +
                    "password=" + pass + "";

            conn = new MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL DB...");
        }
    }

    // Perform database operations here
    class CRUD : DB
    {
        //PROPERTIES
        public int id_status { set; get; }
        public string status { set; get; }

        //READ PROPERTIES
        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        //CREATE function
        public void Create_data()
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = @"INSERT INTO employees.status (id_status, status) VALUES (@id_status,@status)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@id_status", MySqlDbType.VarChar).Value = id_status;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

                cmd.ExecuteNonQuery();
                Console.WriteLine("insert a new record.");
                conn.Close();
            }
        }

        //UPDATE function
        public void Update_data()
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())

            {
                cmd.CommandText = @"UPDATE employees.status SET status = @status WHERE id_status = @id_status";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@id_status", MySqlDbType.VarChar).Value = id_status;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                cmd.ExecuteNonQuery();
                using (MySqlDataReader reader = cmd.ExecuteReader())

                    if (reader.RecordsAffected == 0)
                    {
                        Console.WriteLine("No exist user DB 1");
                        MessageBox.Show("No exist user Form 1");
                    }
                    else
                    {
                        Console.WriteLine("updated a new record db");
                        MessageBox.Show("updated a new record Form 1");
                    }
                conn.Close();
            }
        }

        //DELETE function
        public void Delete_data()
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = @"DELETE FROM employees.status WHERE id_status = @id_status";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@id_status", MySqlDbType.VarChar).Value = id_status;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted a record.");
                conn.Close();
            }
        }

        //READ function
        public void Read_data()
        {
            dt.Clear();
            string sql = "SELECT * FROM employees.status";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, conn);
            mda.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
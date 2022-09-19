using System.Data;
using System.Data.SQLite;
using System.Windows;
using System;
using System.IO;

namespace Sqlite3_Study
{
    class Program
    {
        private static string DBpath = @"D:\TEST\database.db";
        private static string dataSource;
        private SQLiteDataAdapter adpt;

        private SQLiteConnection conn;
        public string Status {get;set; }
        public bool Connection { get; set; }
        public DataTable DT { get; set; }
        public DataSet DS { get; set; }

        public Program()
        {
            conn = null;
            Status = "";
            Connection = false;
            DT = new DataTable();
            DS = new DataSet();
        }

        static void Main(string[] args)
        {
            dataSource = $@"Data Source={DBpath}";
        }

        /// <summary>
        /// DB Connect 
        /// </summary>
        /// <param name="path"></param>
        public void ConnectDB(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    conn = new SQLiteConnection($"Data Source={path}; Version3;");
                }
                else
                {
                    SQLiteConnection.CreateFile(path);
                    conn = new SQLiteConnection($"Data Source={path}; Version3;");
                }

                Connection = true;
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                Connection = false;
            }

            conn.Open();


        }

        /// <summary>
        /// Quert 실행
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteNonQuery(string sql)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                int result = command.ExecuteNonQuery();

                Status = "Affected rows : " + result.ToString();
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet SelectAll(string table)
        {
            try
            {
                DataSet ds = new DataSet();

                string sql = "";
                adpt = new SQLiteDataAdapter(sql, dataSource);
                adpt.Fill(ds, table);

                if (ds.Tables.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            
        }

        public void Insert(string table, string value)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dataSource))
                {
                    conn.Open();
                    string sql = $"INSERT INTO {table} VALUES ({value})";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }
    }
}

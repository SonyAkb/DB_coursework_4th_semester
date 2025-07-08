using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseworkDB
{
    public class Database 
    {
        private MySqlConnection connection;

        public List<string> availableTables;
        public List<string> availableViews;

        public string  connectionString;

        private string userName;
        public List<string> CurrentPrivileges  { get; set; } 

        public Database(): this(ConfigurationManager.AppSettings["DB_SERVER"],
                                ConfigurationManager.AppSettings["DB_DATABASE"],
                                ConfigurationManager.AppSettings["DB_USERROOT"],
                                ConfigurationManager.AppSettings["DB_PASSWORDROOT"])
        {  }

        public Database(string serverNow, string databaseNew, string userNew, string passwordNew)
        {
            try
            {
                connectionString = $"Server={serverNow};Database={databaseNew};Uid={userNew};Pwd={passwordNew};";
                connection = new MySqlConnection(connectionString);
                userName = userNew;
                CurrentPrivileges = new List<string>();

                GetTablesАvailableUser();
                GetViewАvailableUser();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"{ex}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Database(string user, string password) : this(ConfigurationManager.AppSettings["DB_SERVER"],
                                ConfigurationManager.AppSettings["DB_DATABASE"],
                                user, password)
        {  }

        public bool NewConnection(string user, string password) //меняю пользователя
        {
            try
            {
                connection.ConnectionString = $"Server={ConfigurationManager.AppSettings["DB_SERVER"]};Database={ConfigurationManager.AppSettings["DB_DATABASE"]};Uid={user};Pwd={password};" ;
                userName = user;

                if (GetTablesАvailableUser())
                {
                    GetViewАvailableUser();
                }

                
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUser(string username, string password, out string actualRole)
        {
            actualRole = null;
            string query = "SELECT role FROM users WHERE username = @username AND password = @password";

            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return false;
                if(!NewConnection(username, password))
                {
                    return false;
                }
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); 

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public bool GetTablesАvailableUser()
        {
            return ExecuteSafe(() =>
            {
                List<string> result = new List<string>();

                string query = $"SELECT table_schema AS database_name, table_name " +
                                $"FROM information_schema.tables " +
                                $" WHERE table_schema = DATABASE() " +
                                $" AND table_type = 'BASE TABLE'" +
                                $"ORDER BY table_name;";
            
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection) ;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(1));
                    }
                }
            
                availableTables = new List<string> (result);
                return true;
            }, $"Ошибка получения данных");
        }

        public List<string> GetTables()
        {
            return availableTables;
        }

        public List<string> GetViews()
        {
            return availableViews;
        }

        public bool GetViewАvailableUser()
        {
            return ExecuteSafe(() =>
            {
                List<string> result = new List<string>();

                string query = @"SELECT table_schema AS database_name, table_name AS view_name
                            FROM information_schema.tables 
                            WHERE table_schema = DATABASE() 
                            AND table_type = 'VIEW'
                            ORDER BY view_name;";
            
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(1));
                    }
                }

                availableViews = new List<string> (result);
                return true;
            }, $"Ошибка получения данных");
        }

        public List<string> GetListDataFromTable(string nameTable, int column = 1)
        {
            return ExecuteSafe(() =>
            {
                List<string> result = new List<string>();
                string query = $"SELECT * FROM {nameTable}";

                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(column));
                    }
                }
                result.Sort();
                return result;
            }, $"Ошибка получения данных из таблицы {nameTable}");
        }

        public Func<DataTable> GetTableViewDataFunction(string tableName, Func<List<string>> TableCurrent)
        {
            if (!TableCurrent().Contains(tableName))// Проверяем, что таблица есть в списке доступных
                throw new ArgumentException("Таблица не доступна");
            if (!IsValidTableName(tableName))
                throw new ArgumentException("Некорректное имя таблицы");
            return () =>
            {
                return ExecuteSafe(() =>
                {
                    DataTable table = new DataTable();
                    string query = $"SELECT * FROM {tableName}";


                    NeedData.DB.RightsForCurrentTable(tableName);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);

                    ChangeImageSize(table);
                    return table;
                }, $"Ошибка получения данных из таблицы {tableName}");
            };
        }

        private static bool ChangeImageSize(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                if (column.DataType == typeof(byte[])) // если есть BLOB-колонка
                {  
                    foreach (DataRow row in table.Rows)// обработываю как изображение
                    {
                        if (row[column] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])row[column];
                            try
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    System.Drawing.Image originalImage = System.Drawing.Image.FromStream(ms);

                                    int maxWidth = 150; // можно настроить - максимальные размеры для уменьшения
                                    int maxHeight = 150; // можно настроить

                                    
                                    double ratioX = (double)maxWidth / originalImage.Width;//новые размерыпо пропорциям
                                    double ratioY = (double)maxHeight / originalImage.Height;
                                    double ratio = Math.Min(ratioX, ratioY);

                                    int newWidth = (int)(originalImage.Width * ratio);
                                    int newHeight = (int)(originalImage.Height * ratio);

                                    Bitmap resizedImage = new Bitmap(newWidth, newHeight);// уменьшенное изображение
                                    using (Graphics g = Graphics.FromImage(resizedImage))
                                    {
                                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                        g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                                    }

                                    using (MemoryStream msOut = new MemoryStream()) // обратно в byte[]
                                    {
                                        resizedImage.Save(msOut, originalImage.RawFormat);
                                        row[column] = msOut.ToArray();
                                    }

                                    originalImage.Dispose();
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool IsValidTableName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(c => char.IsLetterOrDigit(c) || c == '_');
        }

        public DataTable GetOrdersWithStatus(string status)
        {
            string query = "SELECT * FROM v_orders_with_status WHERE StatusName = @status";
            return ExecuteSafe(() =>
            {
                DataTable table = new DataTable();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                return table;
            }, $"Ошибка получения заказов по статусу");
        }

        public DataTable GetRegionWarehouseStock(string region)
        {
            string query = "SELECT * FROM v_region_warehouse_stock WHERE RegionName = @region";
            return ExecuteSafe(() =>
            {
                DataTable table = new DataTable();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@region", region);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                return table;
            }, $"Ошибка получения остатков по региону");
        }

        public DataTable GetTopCustomersLastQuarter(int months)// Реализация запроса для v_top_customers_last_quarter
        {
            string query = $"SELECT * FROM v_top_customers_last_quarter WHERE OrderDate BETWEEN DATE_SUB(CURRENT_DATE, INTERVAL {months} MONTH) AND CURRENT_DATE";
            return ExecuteQuery(query);
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            return ExecuteSafe(() =>
            {
                using (MySqlConnection conn = new MySqlConnection(NeedData.DB.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
            
                return table;
            }, $"Ошибка выполнения запроса:");
        }

        public bool RightsForCurrentTable(string curTable)
        {

            if (!IsValidTableName(curTable))
                throw new ArgumentException("Некорректное значение");
            return ExecuteSafe(() =>
            {
                string tableQuery = $@"
                SELECT PRIVILEGE_TYPE 
                FROM INFORMATION_SCHEMA.TABLE_PRIVILEGES 
                WHERE TABLE_SCHEMA = '{ConfigurationManager.AppSettings["DB_DATABASE"]}' 
                AND GRANTEE = CONCAT('''', '{userName}', '''@''', '{ConfigurationManager.AppSettings["DB_SERVER"]}', '''')
                AND TABLE_NAME = '{curTable}'";
                
                string schemaQuery = $@"
                SELECT PRIVILEGE_TYPE 
                FROM INFORMATION_SCHEMA.SCHEMA_PRIVILEGES 
                WHERE TABLE_SCHEMA = '{ConfigurationManager.AppSettings["DB_DATABASE"]}' 
                AND GRANTEE = CONCAT('''', '{userName}', '''@''', '{ConfigurationManager.AppSettings["DB_SERVER"]}', '''')"; // Если табличных привилегий нет, проверяем привилегии уровня базы данных
                connection.Open();
                CurrentPrivileges.Clear();
                MySqlCommand cmd = new MySqlCommand(tableQuery, connection) ;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CurrentPrivileges.Add(reader.GetString(0));
                    }
                }
                if (CurrentPrivileges.Count == 0)
                {
                    using (cmd = new MySqlCommand(schemaQuery, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Добавляем только те привилегии уровня БД, которые применимы к таблицам
                            string priv = reader.GetString(0);
                            if (priv == "SELECT" || priv == "INSERT" || priv == "UPDATE" ||
                                priv == "DELETE" || priv == "REFERENCES" || priv == "INDEX" ||
                                priv == "ALTER" || priv == "CREATE VIEW" || priv == "TRIGGER")
                            {
                                CurrentPrivileges.Add(priv);
                            }
                        }
                    }
                }
                return true;
            }, $"Ошибка получения прав для таблицы {curTable}");
        }

        private T ExecuteSafe<T>(Func<T> action, string errorMessage = "Ошибка операции")
        {
            try
            {
                return action();
            }
            catch (MySqlException ex)
            {
                CustomMessageBox.Show($"{errorMessage}\nКод ошибки: {ex.Number}", "Ошибка MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"{errorMessage}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using MySql.Data.MySqlClient;

namespace RFID_Import_Retail.Model
{
    class Database
    {
        string host = @"localhost";
        string databasename = "rfid";
        int port = 3306;
        string username = "urfid";
        string password = "123456";
        MySqlConnection con;

        public Database()
        {
            string conStringLocal = @"Server=" + host + ";Database=" + databasename + ";port=" + port + ";User Id=" + username + ";password=" + password + ";Allow User Variables=True";
            con = new MySqlConnection(conStringLocal);
            con.Open();

        }

        public DataTable loadData(string s)
        {
            try
            {
                MySqlCommand cmdSelect = new MySqlCommand(@s, con);
                MySqlDataAdapter daSelect = new MySqlDataAdapter(cmdSelect);
                DataTable tableSelect = new DataTable("mytable");
                daSelect.Fill(tableSelect);
                return tableSelect;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("there was an MySql issue when load Database: " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was another issue when load Database: " + ex.ToString());
            }
            return null;
        }

        public string getLastInsertedValue()
        {
            DataTable dt = loadData("SELECT SCOPE_IDENTITY() as ID");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID"].ToString();
            }
            return "";
        }

        public int executeDatabase(string s)
        {
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = s;
            //return command.ExecuteNonQuery();
            try
            {
                MySqlCommand command = con.CreateCommand();
                command.CommandText = s;
                return command.ExecuteNonQuery();
                //string ss = s.Replace("'", "");
                //insertHitory(@"Insert into History values('" + @ss + "')");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("there was an MySql issue when execute Database: " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was another issue when execute Database: " + ex.ToString());
            }
            return -1;
        }

        public void executeDataSet(string procName, DataTable datatable)
        {
            //MySqlcon as MySqlConnection  
            MySqlCommand command = new MySqlCommand(procName, con);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@DatatableType", MySqlDbType.Structured).Value = datatable;
            command.Parameters.AddWithValue("@DatatableType", datatable);
            command.ExecuteNonQuery();
        }

        public void insertHitory(string s)
        {
            try
            {
                MySqlCommand command = con.CreateCommand();
                command.CommandText = s;
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("there was an MySql issue when insert Hitory: " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was another issue when insert Hitory: " + ex.ToString());
            }
        }
    }
}

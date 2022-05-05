using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RFID_Import_Retail.View.Notification;
using System.Data;

namespace RFID_Import_Retail.Controller
{
    class Global
    {
        //defind class
        private static Model.Database conn = new Model.Database();
        private static Controller.Common func = new Controller.Common();
        //static variable
        public static string EmpName = "";
        public static string EmpId = "";
        public static int IdLog = 0;

        public static bool AuthorityLogin(string account, string password, string mode)
        {
            if (account != "" && (password) != "")
            {
                String query = "";
                if (mode == "USER")
                {
                    query = String.Format(@"select employee_id, name, password from Employee where username = '{0}'", account);
                }
                else
                {
                    query = String.Format(@"select employee_id, name, password from Employee where username = '{0}'", account);
                }
                DataTable dtContent = new DataTable();
                dtContent = conn.loadData(query);
                if (dtContent != null && dtContent.Rows.Count > 0)
                {
                    if ((dtContent.Rows[0]["password"]).ToString() == Controller.EncryptDecrypt.Encrypt(password))
                    {
                        DateTime dtNow = DateTime.Now;
                        EmpName = (dtContent.Rows[0]["name"]).ToString();
                        EmpId = (dtContent.Rows[0]["employee_id"]).ToString();
                        //IdLog = Convert.ToInt32(conn.getLastInsertedValue());
                        return true;
                    }
                    else
                    {
                        MyMessageBox.ShowMessage("Incorrect password");
                    }
                }
                else
                {
                    MyMessageBox.ShowMessage("User Account doesn't exist");
                }
            }
            else
            {
                MyMessageBox.ShowMessage("Please! Enter full infomation");
            }
            return false;
        }

        public static void destroy()
        {
            EmpName = "";
            EmpId = "";
            IdLog = 0;
        }
    }
}

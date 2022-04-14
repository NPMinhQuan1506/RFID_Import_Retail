using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.View.Notification
{
    class MyMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessage(string message, string caption, System.Windows.Forms.MessageBoxButtons button, System.Windows.Forms.MessageBoxIcon icon){
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.DialogResult.None;
            switch (button)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using(frmMessageOK msgOK = new frmMessageOK())
                    {
                        msgOK.Text = caption;
                        msgOK.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                msgOK.MessageIcon = Properties.Resources.Information;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                msgOK.MessageIcon = Properties.Resources.Question;
                                break;
                        }
                        dialogResult = msgOK.ShowDialog();
                    }
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    using (frmMessageYesNo msgYesNo = new frmMessageYesNo())
                    {
                        msgYesNo.Text = caption;
                        msgYesNo.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                msgYesNo.MessageIcon = Properties.Resources.Information;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                msgYesNo.MessageIcon = Properties.Resources.Question;
                                break;
                        }
                        dialogResult = msgYesNo.ShowDialog();
                    }
                    break;
            }
            return dialogResult;
        }

        public static System.Windows.Forms.DialogResult ShowMessage(string message)
        {
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.DialogResult.None;
            using (frmMessageOK msgOK = new frmMessageOK())
            {
                msgOK.MessageIcon = Properties.Resources.Information;
                msgOK.Message = message;
                dialogResult = msgOK.ShowDialog();
            }
            return dialogResult;
        }
    }
}


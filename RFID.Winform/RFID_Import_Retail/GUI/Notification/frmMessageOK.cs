﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RFID_Import_Retail.GUI.Notification
{
    public partial class frmMessageOK : DevExpress.XtraEditors.XtraForm
    {

        #region //Define Variable
        //Move Panel
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        #endregion

        #region //Contructor
        public frmMessageOK()
        {
            InitializeComponent();
        }
        #endregion

        #region //Get & Set Element 
        public Image MessageIcon
        {
            get { return peNotifyIcon.Image; }
            set { peNotifyIcon.Image = value; }
        }

        public string Message
        {
            get { return lbMessage.Text; }
            set { lbMessage.Text = value; }
        }
        #endregion

        #region //Close Button
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region //Rounded Border Form 
        private void frmMessageOK_Resize(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }

        private void frmMessageOK_Shown(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }
        #endregion

        #region // Move Panel
        private void pnHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point screenPoint = PointToScreen(e.Location);
                Location = new Point(screenPoint.X - this.startPoint.X, screenPoint.Y - this.startPoint.Y);
            }
        }
        #endregion
    }
}
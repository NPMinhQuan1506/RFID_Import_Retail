﻿using DevExpress.XtraBars;
using RFID_Import_Retail.Core;
using RFID_Import_Retail.GUI.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace RFID_Import_Retail.GUI
{
    public partial class frmMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
        private static Core.Common func = new Core.Common();
        public frmMenu()
        {
            for (int i = 0; i < 70; i++)
            {
                Thread.Sleep(70);
            }
            InitializeComponent();
            lbName.Text = "Quân Nguyễn";
           
        }

 

        private void aceProduct_Click(object sender, EventArgs e)
        {
            setImageCurrentPage("aceProduct");
            pnContainer.Controls.Clear();
            GUI.Product.ctrProductList ctr = new GUI.Product.ctrProductList();
            ctr.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(ctr);
        }

     
        private void aceImport_Click(object sender, EventArgs e)
        {
            setImageCurrentPage("aceImport");
            pnContainer.Controls.Clear();
            GUI.Imports.ctrImportsList ctr = new GUI.Imports.ctrImportsList();
            ctr.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(ctr);
        }

      

        private void setImageCurrentPage(string namePage)
        {
            this.lbCurrentListIcon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject(namePage + ".ImageOptions.SvgImage")));
        }
  

        private void frmMenu_Load(object sender, EventArgs e)
        {
            setImageCurrentPage("aceImport");
            pnContainer.Controls.Clear();
            GUI.Imports.ctrImportsList ctr = new GUI.Imports.ctrImportsList();
            ctr.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(ctr);
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if(Global.IdLog != 0)
            //{
            //    DateTime dtNow = DateTime.Now;
            //    string query_log = String.Format(@"Update Employee_log set ThoiGianDangXuat = '{0}', TrangThai = 0 where id = {1}", func.DateTimeToString(dtNow), Core.Global.IdLog);
            //    conn.executeDatabase(query_log);
            //    Core.Global.destroy();
            //}  
        }
    }
}

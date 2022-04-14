

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using RFID_Import_Retail.View.Notification;

namespace RFID_Import_Retail.View.Product
{
    public partial class frmProductDetail : DevExpress.XtraEditors.XtraForm
    {
        #region //Define Class and Variable

        Controller.Common func = new Controller.Common();
        Model.Database conn = new Model.Database();
        //Validation Rule
        Controller.Validation.ValueEmpty_Contain valueE_ContainRule = new Controller.Validation.ValueEmpty_Contain();
        Controller.Validation.ValidEmpty_Contain validE_ContainRule = new Controller.Validation.ValidEmpty_Contain();
        Controller.Validation.Empty_Contain empty_ContainRule = new Controller.Validation.Empty_Contain();
        Controller.Validation.Value_Contain value_ContainRule = new Controller.Validation.Value_Contain();
        Controller.Validation.Valid_Contain valid_ContainRule = new Controller.Validation.Valid_Contain();
        //Delegate Add Order
        public delegate void CallImportForm();
        public CallImportForm cif;
        bool isAddImport = false;
        //defind variable
        String id = "", dtNow = "";
        //Move Panel
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        #endregion

        #region //Contructor
        public frmProductDetail()
        {
            InitializeComponent();
            dtNow = func.DateTimeToString(DateTime.Now);
        }

        public frmProductDetail(string _id) : this()
        {
            this.id = _id;
            loadData();
            txtSKU.ReadOnly = true;
        }

        public frmProductDetail(bool isAddImport = true) : this()
        {
            this.isAddImport = isAddImport;
        }
        #endregion

        #region //Load Data For Updating Event
        private void loadData()
        {
            if (this.id != "")
            {

                DataTable dtContent = new DataTable();
                string query = String.Format(@"select * from product_line_id", this.id);
                dtContent = conn.loadData(query);
                if (dtContent.Rows.Count > 0)
                {
                    txtSKU.Text = (dtContent.Rows[0]["product_line_id"]).ToString();
                    txtProductName.Text = (dtContent.Rows[0]["name"]).ToString();
                    spNumberStock.EditValue = Convert.ToUInt32((dtContent.Rows[0]["stock"]));
                    spPrice.EditValue = Convert.ToDecimal((dtContent.Rows[0]["price"]));
                }
            }
        }
        #endregion

        #region //Validation
        private bool doValidate()
        {
            vali.SetValidationRule(txtSKU, empty_ContainRule);
            vali.SetValidationRule(txtProductName, validE_ContainRule);
            return (vali.Validate());
        }
        #endregion

        #region //Save Data
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (doValidate())
            {

                // Event Add Data
                if (this.id == "")
                {
                    if (checkExistence())
                    {
                        string query = String.Format(@"Insert into productline(product_line_id, name, price, stock) 
                                                                              values(N'{0}', N'{1}', {2}, {3})", 
                                                                                        txtSKU.Text, 
                                                                                        txtProductName.Text, 
                                                                                        (decimal)spPrice.EditValue, 
                                                                                        Convert.ToInt32(spNumberStock.Value));
                        conn.executeDatabase(query);
                        MyMessageBox.ShowMessage("Insert product successfully!");
                        if (isAddImport && cif != null)
                        {
                            cif();
                        }
                        this.Close();
                        return;
                    }
                    else
                    {
                        MyMessageBox.ShowMessage("Product ID has existed!");
                    }

                }
                // Event Update Data
                else
                {
                    string query = String.Format(@"Update productline set name = N'{0}', price = {1}, stock = {2} where product_line_id = '{3}", 
                                                                                        txtProductName.Text,
                                                                                        (decimal)spPrice.EditValue,
                                                                                        Convert.ToInt32(spNumberStock.Value),
                                                                                        txtSKU.Text);
                    MyMessageBox.ShowMessage("Update data successfully!");
                    this.Close();
                }
            }
        }

        #endregion

        #region //Check existence data
        private bool checkExistence()
        {
            string query = String.Format("select count(product_line_id) as count1 from productline where product_line_id = '{0}'", txtSKU.Text);
            DataTable dt = new DataTable();
            dt = conn.loadData(query);
            if ((int)(dt.Rows[0]["count1"]) > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region //Clear Value of Control
        private void lbClear_Click(object sender, EventArgs e)
        {
            if(this.id == "")
            {
                txtSKU.Text = String.Empty;
            }
            txtProductName.Text = String.Empty;
            spNumberStock.EditValue = null;
            spPrice.EditValue = null;
        }
        #endregion

        #region //Close Button
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region //Rounded Border Form 
        private void frmProductDetail_Resize(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }

        private void frmProductDetail_Shown(object sender, EventArgs e)
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

        private void lbClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbClear_Click_1(object sender, EventArgs e)
        {

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
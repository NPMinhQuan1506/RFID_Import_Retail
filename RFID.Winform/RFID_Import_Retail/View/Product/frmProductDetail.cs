

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
                string query = String.Format(@"select * from Product Where is_enable = 1 and product_line_id = '{0}'", this.id);
                dtContent = conn.loadData(query);
                if (dtContent.Rows.Count > 0)
                {
                    txtSKU.Text = (dtContent.Rows[0]["product_line_id"]).ToString();
                    txtProductName.Text = (dtContent.Rows[0]["name"]).ToString();
                    txtType.Text = (dtContent.Rows[0]["type"]).ToString();
                    spPrice.EditValue = Convert.ToDecimal((dtContent.Rows[0]["price"]));
                    spMinStock.EditValue = Convert.ToUInt32((dtContent.Rows[0]["min_stock_quantity"]));
                    spStock.EditValue = Convert.ToUInt32((dtContent.Rows[0]["stock_quantity"]));
                    cbbUnit.EditValue = (dtContent.Rows[0]["unit"]).ToString();
                    mmeDescription.Text = (dtContent.Rows[0]["description"]).ToString();
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
                        string query = String.Format(@"Insert into Product(product_line_id, name, type, price, min_stock_quantity, stock_quantity, unit, description, is_enable, created_date) 
                                                                              values('{0}', N'{1}', N'{2}', {3}, {4}, {5}, N'{6}', N'{7}', '1', '{8}')",
                                                                                   txtSKU.Text,
                                                                                   txtProductName.Text,
                                                                                   txtType.Text,
                                                                                   (decimal)spPrice.EditValue,
                                                                                   Convert.ToInt32(spMinStock.Value),
                                                                                   Convert.ToInt32(spStock.Value),
                                                                                   cbbUnit.EditValue.ToString(),
                                                                                   mmeDescription.Text,
                                                                                   dtNow);
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
                    string query = String.Format(@"Update Product set name = N'{0}',
                                                                          type = N'{1}', 
                                                                          price  = {2}, 
                                                                          min_stock_quantity = {3}, 
                                                                          stock_quantity = {4}, 
                                                                          unit  = N'{5}', 
                                                                          description = N'{6}', 
                                                                          modified_date = '{7}'
                                                   Where product_line_id = '{8}'",
                                                                          txtProductName.Text,
                                                                          txtType.Text,
                                                                          (decimal)spPrice.EditValue,
                                                                          Convert.ToInt32(spMinStock.Value),
                                                                          Convert.ToInt32(spStock.Value),
                                                                          cbbUnit.EditValue.ToString(),
                                                                          mmeDescription.Text,
                                                                          dtNow,
                                                                          txtSKU.Text);
                    conn.executeDatabase(query);
                    MyMessageBox.ShowMessage("Update data successfully!");
                    this.Close();
                }
            }
        }

        #endregion

        #region //Check existence data
        private bool checkExistence()
        {
            string query = String.Format("select count(product_line_id) as count1 from Product where product_line_id = '{0}'", txtSKU.Text);
            DataTable dt = new DataTable();
            dt = conn.loadData(query);
            if (Convert.ToInt16(dt.Rows[0]["count1"]) > 0)
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
            spPrice.EditValue = null;
            txtType.Text = "";
            spMinStock.EditValue = null;
            spStock.EditValue = null;
            cbbUnit.EditValue = null;
            mmeDescription.Text = "";
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


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
using RFID_Import_Retail.GUI.Notification;
using RFID_Import_Retail.BUS;

namespace RFID_Import_Retail.GUI.Product
{
    public partial class frmProductDetail : DevExpress.XtraEditors.XtraForm
    {
        #region //Define Class and Variable

        Core.Common func = new Core.Common();
        //Validation Rule
        Core.Validation.ValueEmpty_Contain valueE_ContainRule = new Core.Validation.ValueEmpty_Contain();
        Core.Validation.ValidEmpty_Contain validE_ContainRule = new Core.Validation.ValidEmpty_Contain();
        Core.Validation.Empty_Contain empty_ContainRule = new Core.Validation.Empty_Contain();
        Core.Validation.Value_Contain value_ContainRule = new Core.Validation.Value_Contain();
        Core.Validation.Valid_Contain valid_ContainRule = new Core.Validation.Valid_Contain();
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
        private async void loadData()
        {
            if (this.id != "")
            {

                DataTable dtContent = new DataTable();
                dtContent = await ProductBUS.Instance.loadDataById(this.id);
                if (dtContent.Rows.Count > 0)
                {
                    txtSKU.Text = (dtContent.Rows[0]["SKU"]).ToString();
                    txtProductName.Text = (dtContent.Rows[0]["Name"]).ToString();
                    txtType.Text = (dtContent.Rows[0]["Type"]).ToString();
                    spNumberStock.EditValue = Convert.ToUInt32((dtContent.Rows[0]["StockNumber"]));
                    spMinNumberStock.EditValue = Convert.ToUInt32((dtContent.Rows[0]["MinStockNumber"]));

                    cbbUnit.EditValue = (dtContent.Rows[0]["Unit"]).ToString();
                    spPrice.EditValue = Convert.ToDecimal((dtContent.Rows[0]["Price"]));

                    mmeDescription.Text = (dtContent.Rows[0]["Description"]).ToString();
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
                        ProductBUS.Instance.create(
                                                   txtSKU.Text,
                                                   txtProductName.Text,
                                                   txtType.Text,
                                                   (decimal)spPrice.EditValue,
                                                   Convert.ToInt32(spNumberStock.Value),
                                                   Convert.ToInt32(spMinNumberStock.Value),
                                                   cbbUnit.EditValue.ToString(),
                                                   mmeDescription.Text
                                                  );
                        MyMessageBox.ShowMessage("Thêm Dữ Liệu Thành Công!");
                        if (isAddImport && cif != null)
                        {
                            cif();
                        }
                        this.Close();
                        return;
                    }
                    else
                    {
                        MyMessageBox.ShowMessage("Mã Sản Phẩm Đã Tồn Tại!");
                    }

                }
                // Event Update Data
                else
                {
                    ProductBUS.Instance.update(
                                               txtSKU.Text,
                                               txtProductName.Text,
                                               txtType.Text,
                                               (decimal)spPrice.EditValue,
                                               Convert.ToInt32(spNumberStock.Value),
                                               Convert.ToInt32(spMinNumberStock.Value),
                                               (string)cbbUnit.EditValue,
                                               mmeDescription.Text
                                              );
                    MyMessageBox.ShowMessage("Sửa Dữ Liệu Thành Công!");
                    this.Close();
                }
            }
        }

        #endregion

        #region //Check existence data
        private bool checkExistence()
        {
            //string query = String.Format("select count(SKU)  as count from SanPham where SKU = '{0}'", txtSKU.Text);
            //DataTable dt = new DataTable();
            //dt = conn.loadData(query);
            //if ((int)(dt.Rows[0]["count"]) > 0)
            //{
            //    return false;
            //}
            return true;
        }
        #endregion

        #region //Clear Value of Control
        private void lbClear_Click(object sender, EventArgs e)
        {
            txtProductName.Text = String.Empty;
            txtType.EditValue = "";
            spNumberStock.EditValue = null;
            spMinNumberStock.EditValue = null;

            cbbUnit.EditValue = null;
            spPrice.EditValue = null;

            mmeDescription.Text = String.Empty;
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
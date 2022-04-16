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
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
using RFID_Import_Retail.Controller;

namespace RFID_Import_Retail.View.Imports
{
    public partial class frmImportsDetail : DevExpress.XtraEditors.XtraForm
    {
        #region //Define Class and Variable

        Controller.Common func = new Controller.Common();
        Model.Database conn = new Model.Database();
        //Validation Rule
        Controller.Validation.Empty_Contain empty_ContainRule = new Controller.Validation.Empty_Contain();
        //defind variable
        String ImpID = "", dtNow = "";
        string emptyGridText = "Empty Data";
        DataTable dtCart;
        //Move Panel
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        #endregion

        #region //Contructor
        public frmImportsDetail()
        {
            InitializeComponent();
            loadDataProduct();
            initDatatable();
            ImpID = InitImportID();
            dtNow = func.DateTimeToString(DateTime.Now);
        }
        #endregion

        #region //Load Product CardView
        private async void loadDataProduct()
        {
            string query = @"select * from productline";
            DataTable dtContent = new DataTable();
            dtContent = conn.loadData();
            if (dtContent.Rows.Count > 0)
            {
                gcProduct.DataSource = dtContent;
            }
        }
        #endregion

        #region //Init Datatable Cart
        private void initDatatable()
        {
            dtCart = new DataTable();

            DataColumn dc = new DataColumn("ImportId", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("SKU", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("Product", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("Amount", typeof(int));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("ImportPrice", typeof(Decimal));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("TotalPrice", typeof(Decimal));
            dtCart.Columns.Add(dc);
        }
        #endregion

        #region //Setup Import Grid

        //Create Serial No For GridView
        private void gvImport_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == NO)
            {
                if (e.RowHandle > -1)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        //Setup Text Align For Grid Column
        private void gvImport_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "NO")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            if (e.Column.Name == "ImportsName")
            {
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }
        }

        //Setup notify text when grid is nullable data
        private void gvImport_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            Rectangle emptyGridTextBounds;
            int offsetFromTop = 10;
            e.DefaultDraw();
            Size size = e.Appearance.CalcTextSize(e.Cache, emptyGridText, e.Bounds.Width).ToSize();
            int x = (e.Bounds.Width - size.Width) / 2;
            int y = e.Bounds.Y + offsetFromTop;
            emptyGridTextBounds = new Rectangle(new Point(x, y), size);
            e.Appearance.DrawString(e.Cache, emptyGridText, emptyGridTextBounds, Brushes.Gray);
        }
        #endregion

        #region //Validation
        private bool doValidate()
        {
            //return (vali.Validate());
            if (dtCart.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region //Save Data
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (doValidate())
            {
                var total = gvImport.Columns["TotalPrice"].SummaryItem.SummaryValue; 
                var totalImport = gvImport.Columns["Amount"].SummaryItem.SummaryValue;
                BUS.ImportsBUS.Instance.create(ImpID, "EMP001", Convert.ToInt32(totalImport), - 1, Convert.ToDecimal(total), mmeNote.Text);

                //Insert Detail
                //dtCart.Columns.Remove("Product");
                //dtCart.Columns.Remove("TotalPrice");
                //conn.executeDataSet("uspInsertImportDetails", dtCart);

                //update stocknumber
                foreach (DataRow dr_update in dtCart.Rows) // search whole table
                {

                    //String query1 = String.Format(@"UPDATE SanPham SET SoLuongTon = SoLuongTon + {0} WHERE SKU = '{1}'",
                    //                                            (int)dr_update["SoLuong"], dr_update["SKU"].ToString());
                    //conn.executeDatabase(query1);


                }
                MyMessageBox.ShowMessage("Thêm Dữ Liệu Thành Công!");
                this.Close();
            }
            else
            {
                MyMessageBox.ShowMessage("Vui Lòng Điền Thông Tin Đủ Và Hợp Lệ!");
            }
        }

        private void insertDetail(string impId, string proId, int amount, decimal impPrice)
        {
            BUS.ImportDetailBUS.Instance.create(impId, proId, amount, impPrice,0);
        }

        private string InitImportID()
        {
            //string query = @"select top 1 MaPN from PhieuNhap order by MaPN desc";
            DataTable dtContent = new DataTable();
            //dtContent = conn.loadData(query);
            if (dtContent.Rows.Count > 0)
            {
                string OldID = (dtContent.Rows[0]["ImportId"]).ToString();
                if (OldID.Length > 2)
                {
                    return Regex.Replace(OldID, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
                }

            }
            return "";
        }
        #endregion

        #region //Add Product

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product.frmProductDetail frm = new Product.frmProductDetail(true);
            frm.cif = new Product.frmProductDetail.CallImportForm(loadDataProduct);
            frm.ShowDialog();
        }
        #endregion

        #region //Handle Cart
        //Add Product into cart
        private void btnAddCart_Click(object sender, EventArgs e)
        {
            String product_id = getID();
            AddToCart(product_id);
        }

        private async void AddToCart(string ID)
        {

            DataRow dataRow = await getProduct(ID);
            DataRow dr = dtCart.NewRow();
            string strSKU = dataRow["SKU"].ToString();
            if (checkExistenceCart(strSKU))
            {
                dr[0] = ImpID;
                dr[1] = strSKU;
                dr[2] = dataRow["Product"].ToString();
                dr[3] = 1;
                dr[4] = 100;
                dr[5] = Convert.ToDecimal(((int)dr[3] * (Decimal)dr[4]));

                dtCart.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow dr_update in dtCart.Rows) // search whole table
                {
                    if (dr_update["SKU"].ToString() == strSKU)
                    {
                        int amount = 0;
                        if (dr_update["Amount"] != null)
                        {
                            amount = (int)dr_update["Amount"];
                        }

                        dr_update["Amount"] = amount + 1;
                        dr_update["TotalPrice"] = Convert.ToDecimal(((int)dr_update["Amount"] * (Decimal)dr_update["ImportPrice"]));
                        break;
                    }
                }
            }
            gcImport.DataSource = dtCart;
            //int Position = 0;
            //dtCart.Rows.InsertAt(dr, Position);
        }

        private async Task<DataRow> getProduct(string strSKU)
        {
            DataTable dtContent = new DataTable();
            dtContent = await BUS.ProductBUS.Instance.loadDataById(strSKU);
            if (dtContent.Rows.Count > 0)
            {
                return dtContent.Rows[0];
            }
            return null;
        }

        //Update data of cart
        private void spAmount_EditValueChanged(object sender, EventArgs e)
        {
            string strSKU = "";
            int amount = 0;
            if (gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU) != null)
            {
                strSKU = gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU).ToString();
            }
            SpinEdit s = sender as SpinEdit;
            amount = Convert.ToInt32(s.Text);
            foreach (DataRow dr_update in dtCart.Rows) // search whole table
            {
                if (dr_update["SKU"].ToString() == strSKU)
                {
                    dr_update["Amount"] = amount;
                    dr_update["TotalPrice"] = Convert.ToDecimal(((int)dr_update["Amount"] * (Decimal)dr_update["ImportPrice"]));
                    break;
                }
            }
            gcImport.DataSource = dtCart;
        }

        private void spPrice_EditValueChanged(object sender, EventArgs e)
        {
            string strSKU = "";
            decimal price = 0;
            if (gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU) != null)
            {
                strSKU = gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU).ToString();
            }
            SpinEdit s = sender as SpinEdit;
            price = (decimal)s.EditValue;
            foreach (DataRow dr_update in dtCart.Rows) // search whole table
            {
                if (dr_update["SKU"].ToString() == strSKU)
                {
                    dr_update["ImportPrice"] = price;
                    dr_update["TotalPrice"] = Convert.ToDecimal(((int)dr_update["Amount"] * (Decimal)dr_update["ImportPrice"]));
                    break;
                }
            }
            gcImport.DataSource = dtCart;
        }

        //Delete product in cart
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSKU = "";
            if (gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU) != null)
            {
                strSKU = gvImport.GetRowCellValue(gvImport.FocusedRowHandle, ImpSKU).ToString();
            }
            foreach (DataRow dr_update in dtCart.Rows) // search whole table
            {
                if (dr_update["SKU"].ToString() == strSKU)
                {
                    dr_update.Delete();
                    break;
                }
            }
            dtCart.AcceptChanges();
            gcImport.DataSource = dtCart;
        }

        #endregion

        #region //Get Id
        private string getID()
        {
            string ID = "";
            if (lvProduct.GetRowCellValue(lvProduct.FocusedRowHandle, "SKU") != null)
            {
                ID = lvProduct.GetRowCellValue(lvProduct.FocusedRowHandle, "SKU").ToString();
            }
            return ID;
        }
        #endregion

        #region //Check existence data
        private bool checkExistenceCart(string strSKU)
        {
            //return false if it exists record
            bool check = !dtCart.AsEnumerable().Any(x => x.Field<string>("SKU") == strSKU);
            return check;
        }
        #endregion

        #region //Clear Value of Control
        private void lbClear_Click(object sender, EventArgs e)
        {

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
        private void frmImportsDetail_Resize(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }

        private void frmImportsDetail_Shown(object sender, EventArgs e)
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
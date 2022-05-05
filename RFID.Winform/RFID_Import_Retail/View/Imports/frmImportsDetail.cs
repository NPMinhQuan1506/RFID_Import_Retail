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
        String GrnID = "", dtNow = "";
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
            GrnID = InitImportID();
            dtNow = func.DateTimeToString(DateTime.Now);
        }
        #endregion

        #region //Load Product CardView
        private void loadDataProduct()
        {
            string query = @"select * from Product Where is_enable = 1";
            DataTable dtContent = new DataTable();
            dtContent = conn.loadData(query);
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

            DataColumn dc = new DataColumn("GRN_ID", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("SKU", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("Product", typeof(String));
            dtCart.Columns.Add(dc);

            dc = new DataColumn("Amount", typeof(int));
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
                String strNote = mmeNote.EditValue == null ? "New GRN" : mmeNote.EditValue.ToString();
                var totalExpectedAmount = gvImport.Columns["Amount"].SummaryItem.SummaryValue;
                //BUS.ImportsBUS.Instance.create(GrnID, "EMP001", Convert.ToInt32(totalImport), - 1, Convert.ToDecimal(total), mmeNote.Text);
                string query = String.Format(@"Insert Into GoodsReceiptNote ( grn_id,
                                                                        employee_id,
                                                                        created_time, 
                                                                        total_expected_quantity, 
                                                                        total_actual_quantity, 
                                                                        note) values( '{0}', '{1}', '{2}', {3}, -1, N'{4}');", 
                                                                        GrnID, Global.EmpId, dtNow, Convert.ToInt32(totalExpectedAmount), strNote);
                conn.executeDatabase(query);
                //Insert Detail
                dtCart.Columns.Remove("Product");
                //conn.executeDataSet("uspInsertImportDetails", dtCart);

                //update stocknumber
                saveDetail();
                MyMessageBox.ShowMessage("Insert data successfully!");
                this.Close();
            }
            else
            {
                MyMessageBox.ShowMessage("Please, Fill validation data!");
            }
        }

        private void saveDetail()
        {
            StringBuilder queryInsert = new StringBuilder("INSERT INTO GoodsReceiptNoteDetail (grn_id, product_line_id, expected_quantity) VALUES");
            String queryUpdate = "";
            List<String> Rows = new List<String>();
            foreach (DataRow dr_update in dtCart.Rows) // search whole table
            {

                Rows.Add(String.Format(@"('{0}', '{1}', {2})",GrnID, dr_update["SKU"].ToString(), Convert.ToInt32(dr_update["Amount"])));
                queryUpdate += String.Format(@"UPDATE Product SET stock_quantity = stock_quantity + {0} WHERE product_line_id = '{1}';", 
                                                    Convert.ToInt32(dr_update["Amount"]), 
                                                    dr_update["SKU"].ToString());
            }
            queryInsert.Append(string.Join(",", Rows));
            queryInsert.Append(";");
            string query = queryInsert.ToString() + queryUpdate;
            conn.executeDatabase(query);
        }

        private string InitImportID()
        {
            string query = @"select grn_id from GoodsReceiptNote order by grn_id desc limit 1";
            DataTable dtContent = new DataTable();
            dtContent = conn.loadData(query);
            if (dtContent.Rows.Count > 0)
            {
                string OldID = (dtContent.Rows[0]["grn_id"]).ToString();
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

        private void AddToCart(string ID)
        {

            DataRow dataRow = getProduct(ID);
            DataRow dr = dtCart.NewRow();
            string strSKU = dataRow["product_line_id"].ToString();
            if (checkExistenceCart(strSKU))
            {
                dr[0] = GrnID;
                dr[1] = strSKU;
                dr[2] = dataRow["name"].ToString();
                dr[3] = 1;

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
                        if (checkProductRFID(strSKU, amount + 1) == 0)
                        {
                            amount++;
                        }
                        else
                        {
                            amount = handleMappingQuantityException(strSKU, amount + 1);
                        }
                        dr_update["Amount"] = amount;
                        break;
                    }
                }
            }
            gcImport.DataSource = dtCart;
            //int Position = 0;
            //dtCart.Rows.InsertAt(dr, Position);
        }

        private DataRow getProduct(string strSKU)
        {
            DataTable dtContent = new DataTable();
            string query = String.Format(@"Select * from Product Where product_line_id = '{0}' and is_enable = 1", strSKU);
            dtContent = conn.loadData(query);
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
            if (checkProductRFID(strSKU, amount) == 0)
            {
                foreach (DataRow dr_update in dtCart.Rows) // search whole table
                {
                    if (dr_update["SKU"].ToString() == strSKU)
                    {
                        dr_update["Amount"] = amount;
                        break;
                    }
                }
                gcImport.DataSource = dtCart;
            }
            else
            {
              amount = handleMappingQuantityException(strSKU, amount);
            }
            s.EditValue = amount;
        }

        private int checkProductRFID(string productId, int amount)
        {
            String query = String.Format("select count(product_line_id) as count1 from ProductRFID where product_line_id = '{0}' and is_checked = 0", productId);
            DataTable dt = new DataTable();
            dt = conn.loadData(query);
            int count = Convert.ToInt16(dt.Rows[0]["count1"]);
            if (amount > count)
            {
                return count;
            }
            return 0;
        }

        private int handleMappingQuantityException(string strSKU, int amount)
        {
            MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
            DialogResult Result = MyMessageBox.ShowMessage("Exceeding the amount of mapping! Do you want to continue?", "Notification!", Bouton, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                Result = MyMessageBox.ShowMessage("Do you want to map using an excel file?", "Notification!", Bouton, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    mapRFIDByExcel();
                }
                else if (Result == DialogResult.No)
                {
                    amount = checkProductRFID(strSKU, amount);
                    MyMessageBox.ShowMessage("So let's map it with a RFID reader!");
                }
            }
            else if (Result == DialogResult.No)
            {
                amount = checkProductRFID(strSKU, amount);
                MyMessageBox.ShowMessage("Quantity don't change!");
            }
            return amount;
        }

        private void mapRFIDByExcel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel (2010) (.xlsx)|*.xlsx|Excel (1997-2003)(.xls)|*.xls|CSV file (.csv)|*.csv" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    DataTable dtMyExcel = Controller.MyExcel.GetDataTableFromExcel(fileName);
                    System.Data.DataView view = new System.Data.DataView(dtMyExcel);
                    System.Data.DataTable master = view.ToTable("MyTableMaster", false, "rfid", "product_line_id", "mapping_time");
                    saveProductRFID(master);
                    MyMessageBox.ShowMessage("Mapping successfully!");
                }
            }
        }

        private void saveProductRFID(DataTable dtMapping)
        {
            StringBuilder queryInsert = new StringBuilder("INSERT INTO ProductRFID (rfid, product_line_id, mapping_time) VALUES");
            List<String> Rows = new List<String>();
            foreach (DataRow dr_mapping in dtMapping.Rows) // search whole table
            {

                Rows.Add(String.Format(@"('{0}', '{1}', '{2}')", dr_mapping["rfid"].ToString(), dr_mapping["product_line_id"].ToString(), dtNow));
            }
            queryInsert.Append(string.Join(",", Rows));
            queryInsert.Append(";");
            conn.executeDatabase(queryInsert.ToString());
        }

        private void spPrice_EditValueChanged(object sender, EventArgs e)
        {
  
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
            if (lvProduct.GetRowCellValue(lvProduct.FocusedRowHandle, "product_line_id") != null)
            {
                ID = lvProduct.GetRowCellValue(lvProduct.FocusedRowHandle, "product_line_id").ToString();
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
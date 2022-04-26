using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using RFID_Import_Retail.View.Notification;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace RFID_Import_Retail.View.Product
{
    public partial class ctrProductList : DevExpress.XtraEditors.XtraUserControl
    {
        #region //Define Class and Variable

        //defind class
        Controller.Common func = new Controller.Common();
        Model.Database conn = new Model.Database();
        //defind variable
        string query = "";
        string emptyGridText = "Empty Data";

        //defind datatable
        DataTable dtMaster = new DataTable();

        #endregion

        #region //Contructor

        public ctrProductList()
        {
            InitializeComponent();

            string placehoder = txtSearch.Properties.NullText;
            func.createPlaceHolderControl(txtSearch, placehoder);
        }

        #endregion

        #region //Setup GridView
        //Create Serial No For GridView
        private void gvProduct_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
        private void gvProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "NO")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            if (e.Column.Name == "ProductName")
            {
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }
        }


        private void gvProduct_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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

        #region //Create
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetail frm = new frmProductDetail();
            frm.ShowDialog();
            loadData();
        }
        #endregion

        #region //Read

        private void gcProduct_Load(object sender, EventArgs e)
        {
            loadData();
            //gvProduct.DataController.AllowIEnumerableDetails = true;
        }

        private void loadData()
        {
            query = @"Select * from Product Where is_enable = '1'";
            dtMaster = conn.loadData(query);
            gcProduct.DataSource = dtMaster;
        }

        private void loadData(string _query)
        {
            dtMaster = conn.loadData(_query);
            gcProduct.DataSource = dtMaster;
        }
        #endregion

        #region //Update
        private void btnEdit_Click(object sender, EventArgs e)
        {
            update();
        }

        private void gvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (gvProduct.FocusedColumn.Name != "NO")
            {
                update();
            }
        }

        private void update()
        {
            if (getID() != "")
            {
                string ID = getID();
                frmProductDetail frm = new frmProductDetail(ID);
                frm.ShowDialog();
                loadData();
            }
        }

        #endregion

        #region //Delete

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (getID() != "")
            {
                string ID = getID();
                MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
                DialogResult Result = MyMessageBox.ShowMessage("Are you sure delete this product?", "Notification!", Bouton, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    delete(ID);
                }
                else if (Result == DialogResult.No)
                {
                    MyMessageBox.ShowMessage("Data has still existed!");
                }
            }
        }

        private void delete(string ID)
        {
            if (checkConstraints(ID))
            {
                string query = String.Format("Update Product set is_enable = '0' Where product_line_id = '{0}'", ID);
                conn.executeDatabase(query);
                MyMessageBox.ShowMessage("Delete data successfully!");
                loadData();
            }
            else
            {
                MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
                DialogResult Result = MyMessageBox.ShowMessage(@"Warning! This Product's Data Binding Exist.
                                                                Do you want to continue?", "Notification!", Bouton, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    string query = String.Format("Update Product set is_enable = 0 Where product_line_id = '{0}'", ID);
                    conn.executeDatabase(query);
                    MyMessageBox.ShowMessage("Delete data successfully!");
                    loadData();
                }
                else if (Result == DialogResult.No)
                {
                    MyMessageBox.ShowMessage("Data has still existed!");
                }
            }
        }

        private bool checkConstraints(string ID)
        {
            string query = String.Format(@"select count(pt.product_line_id) as count1
                                                    from ProductRFID as pt
                                            where pt.product_line_id = '{0}'", ID);
            DataTable dt = new DataTable();
            dt = conn.loadData(query);
            if (Convert.ToInt16(dt.Rows[0]["count1"]) > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region //Get Id
        private string getID()
        {

            if (gvProduct.GetRowCellValue(gvProduct.FocusedRowHandle, SKU) != null)
            {
                string ID = gvProduct.GetRowCellValue(gvProduct.FocusedRowHandle, SKU).ToString();
                return ID;
            }
            return "";
        }
        #endregion

        #region //Search and Filter

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.EditValue = String.Empty;
            }
            search();
        }

        private void cbbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            //Add datatable if searching value is null, datatable will return "Search data doesn't exist"
            if (txtSearch.EditValue != null)
            {
                string searchInfo = Regex.Replace(txtSearch.EditValue.ToString(), @"[\']+", "").Trim();
                string field = "";
                switch (cbbField.Text)
                {
                    case "Product Id":
                        field = "product_line_id";
                        break;
                    default:
                        field = cbbField.Text.ToLower().Replace(" ", "");
                        break;
                }
                if (searchInfo != txtSearch.Properties.NullText && !string.IsNullOrWhiteSpace(searchInfo))
                {
                    int index = cbbField.SelectedIndex;
                    if (index != 0)
                    {
                        string querySearch = String.Format(@"{0} and {1} like N'%{2}%'", query, field, searchInfo);
                        loadData(querySearch);
                    }
                    else
                    {
                        String querySearch = String.Format(@"{0} and CONCAT('',  
                                                                    product_line_id, 
                                                                    name,
                                                                    price) like N'%{1}%'", query, searchInfo);
                        loadData(querySearch);
                    }
                }
                else
                {
                    loadData();
                }
            }


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
        }
        #endregion

        #region //Import and Export Data File
        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel (2010) (.xlsx)|*.xlsx|Excel (1997-2003)(.xls)|*.xls|CSV file (.csv)|*.csv" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    DataTable dtMyExcel = Controller.MyExcel.GetDataTableFromExcel(fileName);
                    System.Data.DataView view = new System.Data.DataView(dtMyExcel);
                    System.Data.DataTable master = view.ToTable("MyTableMaster", false, "product_line_id", "name", "price", "unit", "min_stock_quantity", "stock_quantity", "type", "description");
                    ConvertColumnType(ref master, "price", typeof(decimal));
                    //conn.executeDataSet("uspInsertProducts", master);
                }
            }
            loadData();
        }

        public void ConvertColumnType(ref DataTable dt, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "_new", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = dt.Columns[columnName].Ordinal;
                dt.Columns.Add(dc);
                dc.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                foreach (DataRow dr in dt.Rows)
                {
                    if (newType == typeof(DateTime))
                    {
                        var x = dr[columnName].ToString();
                        DateTime dtTemp = DateTime.ParseExact(dr[columnName].ToString(), "dd/MM/yyyy", null);
                        dr[dc.ColumnName] = func.DateTimeToString(dtTemp);
                        //Convert.ChangeType(dr[columnName], newType);
                    }
                    else
                    {

                        if (dr[columnName] != DBNull.Value)
                        {
                            dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType);
                        }

                    }
                }


                // Remove the old column
                dt.Columns.Remove(columnName);

                // Give the new column the old column's name
                dc.ColumnName = columnName;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            DateTime dtNow = DateTime.Now;
            saveDialog.FileName = "Report_Products_" + dtNow.Day.ToString() + "_" + dtNow.Month.ToString() + "_" + dtNow.Year.ToString()
                                                     + "_" + dtNow.Hour.ToString() + "_" + dtNow.Minute.ToString() + "_" + dtNow.Second.ToString();
            saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |Excel (1997-2003)(.xls)|*.xls|RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = saveDialog.FileName;
                string fileExtenstion = new FileInfo(exportFilePath).Extension;

                switch (fileExtenstion)
                {
                    case ".xls":
                        gvProduct.OptionsPrint.PrintDetails = true;
                        gvProduct.OptionsPrint.ExpandAllDetails = true;
                        XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                        opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvProduct.ExportToXlsx(exportFilePath, opt);
                        Process.Start(exportFilePath);
                        break;
                    case ".xlsx":
                        gvProduct.OptionsPrint.PrintDetails = true;
                        gvProduct.OptionsPrint.ExpandAllDetails = true;
                        XlsxExportOptionsEx opt1 = new XlsxExportOptionsEx();
                        opt1.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvProduct.ExportToXlsx(exportFilePath, opt1);
                        Process.Start(exportFilePath);
                        break;
                    case ".rtf":
                        gvProduct.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        gvProduct.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        gvProduct.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        gvProduct.ExportToMht(exportFilePath);
                        break;
                    default:
                        break;
                }

                if (File.Exists(exportFilePath))
                {
                    try
                    {
                        //Try to open the file and let windows decide how to open it.
                        System.Diagnostics.Process.Start(exportFilePath);
                    }
                    catch
                    {
                        String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                    MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        #endregion
    }
}


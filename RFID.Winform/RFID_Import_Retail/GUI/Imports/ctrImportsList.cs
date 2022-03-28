using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RFID_Import_Retail.GUI.Notification;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Office.Utils;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;

namespace RFID_Import_Retail.GUI.Imports
{
    public partial class ctrImportsList : DevExpress.XtraEditors.XtraUserControl
    {
        #region //Define Class and Variable

        //defind class
        Core.Common func = new Core.Common();
        //defind variable
        string query = "";
        string emptyGridText = "Không có dữ liệu";

        //defind datatable
        DataTable dtMaster = new DataTable();
        DataTable dtDetail = new DataTable();
        //defind generate instance 

        //private static ctrImportsList _instance;

        //public static ctrImportsList instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new ctrImportsList();
        //        }
        //        return _instance;
        //    }
        //}
        #endregion

        #region //Contructor

        public ctrImportsList()
        {
            InitializeComponent();

            string placehoder = txtSearch.Properties.NullText;
            func.createPlaceHolderControl(txtSearch, placehoder);
        }

        #endregion

        #region //Setup GridView
        //Create Serial No For GridView
        private void gvImports_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
        private void gvImports_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
        private void gvImports_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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
            frmImportsDetail frm = new frmImportsDetail();
            frm.ShowDialog();
            loadData();
        }
        #endregion

        #region //Read

        private void gcImports_Load(object sender, EventArgs e)
        {

            loadData();
            gvImports.DataController.AllowIEnumerableDetails = true;
        }

        private async void loadData()
        {
            //loadData Master
            dtMaster = await BUS.ImportsBUS.Instance.loadData();
            //loadDataDetail
            dtDetail = await BUS.ImportDetailBUS.Instance.loadData();
            gcImports.DataSource = dtMaster;
        }

        // If Master don't have Detail, a plus is enable
        private void gvImports_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            if (gvImports.GetRowCellValue(e.RowHandle, ImportID) != null)
            {
                string ID = gvImports.GetRowCellValue(e.RowHandle, ImportID).ToString();
                e.IsEmpty = !dtDetail.AsEnumerable().Any(x => x.Field<string>("ImportId") == ID);
            }
        }

        //LoadData Detail
        private void gvImports_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            if (gvImports.GetRowCellValue(e.RowHandle, ImportID) != null)
            {
                string ID = gvImports.GetRowCellValue(e.RowHandle, ImportID).ToString();
                e.ChildList = GetBatchFromItem(ID);
                gvDetail.ViewCaption = "Chi Tiết Phiếu Nhập " + ID;
            }
        }

        DataView GetBatchFromItem(string ID)
        {
            DataView dv = new DataView(dtDetail);
            dv.RowFilter = String.Format(@"[ImportId] = '{0}'", ID);
            return dv;
        }

        //Set 1: Detail
        private void gvImports_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        //Set Relationship
        private void gvImports_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Detail";
        }
        #endregion

        #region //Update
        private void btnEdit_Click(object sender, EventArgs e)
        {
            update();
        }

        private void gvImports_DoubleClick(object sender, EventArgs e)
        {
            if (gvImports.FocusedColumn.Name != "NO")
            {
                update();
            }
        }

        private void update()
        {
            //if (getID(gvImports, "MaPN") != "")
            //{
            //    string ID = getID(gvImports, "MaPN");
            //    frmImportsDetail frm = new frmImportsDetail(ID);
            //    frm.ShowDialog();
            //    loadData();
            //}
        }

        #endregion

        #region //Delete

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvImports.FocusedColumn.Name == "Delete")
            {
                if (getID("MaPN") != "")
                {
                    string ID = getID("MaPN");
                    MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
                    DialogResult Result = MyMessageBox.ShowMessage("Bạn Có Chắc Xóa Phiếu Nhập Này Không?", "Thông Báo!", Bouton, MessageBoxIcon.Question);

                    if (Result == DialogResult.Yes)
                    {
                        delete(ID);
                    }
                    else if (Result == DialogResult.No)
                    {
                        MyMessageBox.ShowMessage("Dữ liệu vẫn tồn tại!");
                    }
                }
            }
            else if (gvDetail.FocusedColumn.Name == "DetailDelete")
            {
                string ImportsID = getID("MaPN");
                string SKU = getID("SKU");

                MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
                DialogResult Result = MyMessageBox.ShowMessage("Bạn Có Chắc Xóa Chi Tiết Phiếu Nhập Này Không?", "Thông Báo!", Bouton, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    if (checkConstraints(ImportsID) > 1)
                    {
                        delete(ImportsID, SKU);
                    }
                    else if (checkConstraints(ImportsID) == 1)
                    {
                        delete(ImportsID);
                    }
                }
                else if (Result == DialogResult.No)
                {
                    MyMessageBox.ShowMessage("Dữ liệu vẫn tồn tại!");
                }
            }
        }

        private void delete(string ID)
        {
            string query_del = String.Format("Update ChiTietPhieuNhap Set HienThi = 0 Where MaPN = '{0}';", ID);
            query_del += String.Format("Update PhieuNhap Set HienThi = 0 Where MaPN = '{0}'; ", ID);

            MyMessageBox.ShowMessage("Xóa Dữ Liệu Thành Công!");
            loadData();
        }

        private void delete(string ImportsID, string SKU)
        {
            string query_del = String.Format("Update ChiTietPhieuNhap Set HienThi = 0 Where MaPN = '{0}' and SKU = '{1}';", ImportsID, SKU);
            MyMessageBox.ShowMessage("Xóa Dữ Liệu Thành Công!");
            loadData();
        }

        private int checkConstraints(string ID)
        {
            string query = String.Format("select count(MaPN)  as count from ChiTietPhieuNhap where MaPN = '{0}'", ID);
            DataTable dt = new DataTable();
            return (int)(dt.Rows[0]["count"]);
        }
        #endregion

        #region //Get Id
        private string getID(string fieldName)
        {
            string ID = "";
            var view = gcImports.FocusedView as GridView;
            if (view.GetFocusedRowCellValue(fieldName) != null)
            {
                ID = view.GetFocusedRowCellValue(fieldName).ToString();
            }
            return ID;
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
                string field = func.removeUnicode((cbbField.Text).Replace("Phiếu Nhập", "PN"))
                                                                  .Replace(" ", "");
                if (searchInfo != txtSearch.Properties.NullText && !string.IsNullOrWhiteSpace(searchInfo))
                {
                    int index = cbbField.SelectedIndex;
                    if (index != 0)
                    {
                        //string querySearch = "";
                        if (field == "SanPham")
                        {
                            //querySearch = String.Format(@"Select * from ({0}) as t where t.MaPN In  (select MaPN from ChiTietPhieuNhap as ct
																			         //                       inner join SanPham as sp on ct.SKU = sp.SKU
																			         //                       where ct.HienThi = 1 and TenSP like N'%{1}%')",
                            //                                                                                 query, searchInfo);
                        }
                        else
                        {
                            //querySearch = String.Format(@"Select * from ({0}) as t where t.{1} like N'%{2}%'", query, field, searchInfo);
                        }

                      
                    }
                    else
                    {
                        //String querySearch = String.Format(@"Select * from ({0}) as t where CONCAT('',  
                        //                                                                            MaPN, 
                        //                                                                            t.NhaCungCap,
                        //                                                                            t.NhanVien) like N'%{1}%' 
                        //                                                                     or t.MaPN In  (select MaPN from ChiTietPhieuNhap as ct
																			     //                           inner join SanPham as sp on ct.SKU = sp.SKU
																			     //                           where ct.HienThi = 1 and TenSP like N'%{1}%')",
                        //                                                                                     query, searchInfo);
                        //loadData(querySearch);
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
        private void btnInport_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel (2010) (.xlsx)|*.xlsx|Excel (1997-2003)(.xls)|*.xls|CSV file (.csv)|*.csv" })
            //{
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string fileName = openFileDialog.FileName;
            //        DataTable dtMyExcel = Controller.MyExcel.GetDataTableFromExcel(fileName);
            //        System.Data.DataView view = new System.Data.DataView(dtMyExcel);
            //        System.Data.DataTable master = view.ToTable("MyTableMaster", false, "MaPN", "ISBN", "TenPN", "MaNCC", "MaHT", "MaTL", "NgonNgu", "PhienBan",
            //            "SoLuongTon", "TonToiThieu", "DonViTinh", "GiaBan", "DanhGia", "MoTa");
            //        ConvertColumnType(ref master, "DanhGia", typeof(float));
            //        conn.executeDataSet("uspInsertImportss", master);
            //        System.Data.DataTable detail = view.ToTable("MyTableDetail", false, "ISBN", "MaNXB", "MaTG", "NamXuatBanDauTien", "NamXuatBanMoiNhat", "SoTrang");


            //        ConvertColumnType(ref detail, "NamXuatBanDauTien", typeof(DateTime));
            //        ConvertColumnType(ref detail, "NamXuatBanMoiNhat", typeof(DateTime));
            //        conn.executeDataSet("uspInsertImportsDetails", detail);
            //    }
            //}
            //loadData();
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
            saveDialog.FileName = "Report_Imports_" + dtNow.Day.ToString() + "_" + dtNow.Month.ToString() + "_" + dtNow.Year.ToString()
                                                     + "_" + dtNow.Hour.ToString() + "_" + dtNow.Minute.ToString() + "_" + dtNow.Second.ToString();
            saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |Excel (1997-2003)(.xls)|*.xls|RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = saveDialog.FileName;
                string fileExtenstion = new FileInfo(exportFilePath).Extension;

                switch (fileExtenstion)
                {
                    case ".xls":
                        gvImports.OptionsPrint.PrintDetails = true;
                        gvImports.OptionsPrint.ExpandAllDetails = true;
                        XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                        opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvImports.ExportToXlsx(exportFilePath, opt);
                        Process.Start(exportFilePath);
                        break;
                    case ".xlsx":
                        gvImports.OptionsPrint.PrintDetails = true;
                        gvImports.OptionsPrint.ExpandAllDetails = true;
                        XlsxExportOptionsEx opt1 = new XlsxExportOptionsEx();
                        opt1.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvImports.ExportToXlsx(exportFilePath, opt1);
                        Process.Start(exportFilePath);
                        break;
                    case ".rtf":
                        gvImports.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        gvImports.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        gvImports.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        gvImports.ExportToMht(exportFilePath);
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

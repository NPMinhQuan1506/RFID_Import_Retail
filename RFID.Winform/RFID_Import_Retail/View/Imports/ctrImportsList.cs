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
using RFID_Import_Retail.View.Notification;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Office.Utils;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;

namespace RFID_Import_Retail.View.Imports
{
    public partial class ctrImportsList : DevExpress.XtraEditors.XtraUserControl
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
        DataTable dtDetail = new DataTable();
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
            if (e.Column != Check && e.Column != Delete)
            {
                if(Convert.ToInt32(dtMaster.Rows[e.RowHandle]["total_actual_quantity"]) >= Convert.ToInt32(dtMaster.Rows[e.RowHandle]["total_expected_quantity"]))
                {
                    e.Appearance.BackColor = Color.FromArgb(136, 198, 237);
                    e.Appearance.ForeColor = Color.FromArgb(0, 0, 20);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
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
            if (e.Column == Check )
            {
                if(Convert.ToInt32(dtMaster.Rows[e.RowHandle]["total_actual_quantity"]) >= Convert.ToInt32(dtMaster.Rows[e.RowHandle]["total_expected_quantity"]))
                {
                    //e.Column.OptionsColumn.ReadOnly = true;
                    //e.Column.OptionsColumn.AllowEdit = false;
                    //e.Column.OptionsColumn.AllowFocus = true;
                    //e.Column.ColumnEdit.ReadOnly = true;
                }
                else
                {

                }
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

        private void loadData()
        {
            //loadData Master
            query = @"Select grn.*, e.name as employee from GoodsReceiptNote as grn
                        Inner join Employee as e on grn.employee_id = e.employee_id
                        where grn.is_enable = 1 ";

            dtMaster = conn.loadData(query + "order by grn.created_time ASC");
            //loadDataDetail
            string query1 = @"Select d.*, p.name as product_name
                                    From GoodsReceiptNoteDetail as d
                                    Inner Join Product as p 
                                    On d.product_line_id = p.product_line_id";
            dtDetail = conn.loadData(query1);
            gcImports.DataSource = dtMaster;
        }

        private void loadData(string _query)
        {
            DataTable dtContent = new DataTable();
            dtContent = conn.loadData(_query);
            gcImports.DataSource = dtContent;
        }

        // If Master don't have Detail, a plus is enable
        private void gvImports_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            if (gvImports.GetRowCellValue(e.RowHandle, ID) != null)
            {
                string ID = gvImports.GetRowCellValue(e.RowHandle, this.ID).ToString();
                e.IsEmpty = !dtDetail.AsEnumerable().Any(x => x.Field<string>("grn_id") == ID);
            }
        }

        //LoadData Detail
        private void gvImports_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            if (gvImports.GetRowCellValue(e.RowHandle, ID) != null)
            {
                string ID = gvImports.GetRowCellValue(e.RowHandle, this.ID).ToString();
                e.ChildList = GetBatchFromItem(ID);
                gvDetail.ViewCaption = "Import Detail " + ID;
            }
        }

        DataView GetBatchFromItem(string ID)
        {
            DataView dv = new DataView(dtDetail);
            dv.RowFilter = String.Format(@"[grn_id] = '{0}'", ID);
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
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (gvImports.FocusedColumn.Name == "Check" && Convert.ToInt32(getID("total_actual_quantity")) < Convert.ToInt32(getID("total_expected_quantity")))
            {
                update();
            }
        }

        private void gvImports_DoubleClick(object sender, EventArgs e)
        {
            if (gvImports.FocusedColumn.Name != "NO" && Convert.ToInt32(getID("total_actual_quantity")) < Convert.ToInt32(getID("total_expected_quantity")))
            {
                update();
            }
        }

        private void update()
        {
            if (getID("grn_id") != "")
            {
                string ID = getID("grn_id");
                frmCheckImport frm = new frmCheckImport(ID);
                frm.ShowDialog();
                loadData();
            }
        }

        #endregion

        #region //Delete

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvImports.FocusedColumn.Name == "Delete")
            {
                if (getID("grn_id") != "")
                {
                    string ID = getID("grn_id");
                    MessageBoxButtons Bouton = MessageBoxButtons.YesNo;
                    DialogResult Result = MyMessageBox.ShowMessage("Are you sure delete this import?", "Notification!", Bouton, MessageBoxIcon.Question);
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
        }

        private void delete(string ID)
        {
            string query_del = String.Format("Update GoodsReceiptNote set is_enable = '0' Where grn_id = '{0}';", ID);
            conn.executeDatabase(query_del);

            MyMessageBox.ShowMessage("Delete data successfully!");
            loadData();
        }

        private int checkConstraints(string ID)
        {
            string query = String.Format("Select count(grn_id)  as count1 from GoodsReceiptNoteDetail where grn_id = '{0}'", ID);
            DataTable dt = new DataTable();
            return (int)(dt.Rows[0]["count1"]);
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
                string field = "";
                switch (cbbField.Text)
                {
                    case "Product Name":
                        field = "name";
                        break;
                    default:
                        field = cbbField.Text.ToLower().Replace(" ", "_");
                        break;
                }
                if (searchInfo != txtSearch.Properties.NullText && !string.IsNullOrWhiteSpace(searchInfo))
                {
                    int index = cbbField.SelectedIndex;
                    if (index != 0)
                    {
                        string querySearch = "";
                        if (field == "name")
                        {
                            querySearch = String.Format(@"Select * From ({0}) as t Where t.grn_id In (Select d.grn_id
                                                                                                                From GoodsReceiptNoteDetail as d
                                                                                                                Inner Join Product as p 
                                                                                                                On d.product_line_id = p.product_line_id
																			                                    Where p.name Like N'%{1}%')",
                                                                                                             query, searchInfo);
                        }
                        else if (field == "employee")
                        {
                            querySearch = String.Format(@"Select * From ({0}) as t Where t.employee Like N'%{1}%')",
                                                                                                             query, searchInfo);
                        }
                        else
                        {
                            querySearch = String.Format(@"Select * From ({0}) as t where t.{1} like N'%{2}%'", query, field, searchInfo);
                        }

                        loadData(querySearch);
                    }
                    else
                    {
                        String querySearch = String.Format(@"Select * From ({0}) as t Where CONCAT('',  
                                                                                                    t.grn_id, 
                                                                                                    t.created_time,
                                                                                                    t.note,
                                                                                                    t.employee) Like N'%{1}%' 
                                                                                             or t.product_line_id In  (Select d.grn_id
                                                                                                                        From GoodsReceiptNoteDetail as d
                                                                                                                        Inner Join Product as p 
                                                                                                                        On d.product_line_id = p.product_line_id
																			                                            Where p.name Like N'%{1}%')",
                                                                                                             query, searchInfo);
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
        private void btnInport_Click(object sender, EventArgs e)
        {

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

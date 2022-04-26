

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
using DevExpress.XtraGrid.Views.Grid;

namespace RFID_Import_Retail.View.Imports
{
    public partial class frmCheckImport : DevExpress.XtraEditors.XtraForm
    {
        #region //Define Class and Variable

        Controller.Common func = new Controller.Common();
        Model.Database conn = new Model.Database();
        string emptyGridText = "Empty Data";
        //defind variable
        String grnId = "", dtNow = "";
        private volatile bool isWorking = false;
        //defind datatable
        DataTable dtMaster = new DataTable();
        DataTable dtDetail = new DataTable();
        //Move Panel
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        #endregion

        #region //Contructor
        public frmCheckImport()
        {
            InitializeComponent();
            dtNow = func.DateTimeToString(DateTime.Now);
        }

        public frmCheckImport(string grnId) : this()
        {
            this.grnId = grnId;
            isWorking = true;
            loadData();
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

        #region //Read

        private void gcImports_Load(object sender, EventArgs e)
        {
            gvImports.DataController.AllowIEnumerableDetails = true;
            loadData();
        }

        private async void loadData()
        {
            string query = String.Format(@"Update GoodsReceiptNote set total_actual_quantity = 0 Where grn_id = '{0}' and total_actual_quantity = -1", grnId);
            conn.executeDatabase(query);
            while (isWorking)
            {
                await Task.Delay(1000);
                //loadData Master
                //dtMaster = await BUS.ImportsBUS.Instance.loadDataById(grnId);
                query = String.Format(@"Select * from GoodsReceiptNote Where grn_id = '{0}'", grnId);
                dtMaster = conn.loadData(query);
                txtExpectedQuantity.Text = (dtMaster.Rows[0]["total_expected_quantity"]).ToString();
                txtActualImport.Text = (dtMaster.Rows[0]["total_actual_quantity"]).ToString();
                //loadDataDetail
                //dtDetail = await BUS.ImportDetailBUS.Instance.loadDataById(grnId);
                query = String.Format(@"Select g.*, p.name as product_name from GoodsReceiptNoteDetail as g 
                                        Inner Join Product as p on g.product_line_id = p.product_line_id 
                                        Where g.grn_id = '{0}'", grnId);
                dtDetail = conn.loadData(query);
                gcImports.DataSource = dtDetail;
            }
        }


        private void txtActualImport_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtActualImport.Text) >= Convert.ToInt32(txtExpectedQuantity.Text))
            {
                isWorking = false;
                MyMessageBox.ShowMessage("Checked product completely!");

            }
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

        #region //Close Button
        private void lbClose_Click(object sender, EventArgs e)
        {
            isWorking = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isWorking = false;
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
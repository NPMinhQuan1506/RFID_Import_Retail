namespace RFID_Import_Retail.View.Product
{
    partial class frmProductDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductDetail));
            this.pnHeader = new DevExpress.XtraEditors.PanelControl();
            this.lbClear = new DevExpress.XtraEditors.LabelControl();
            this.lbClose = new DevExpress.XtraEditors.LabelControl();
            this.pnFooter = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSKU = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vali = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.spNumberStock = new DevExpress.XtraEditors.SpinEdit();
            this.spPrice = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNumberStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.lbClear);
            this.pnHeader.Controls.Add(this.lbClose);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.pnHeader.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(386, 59);
            this.pnHeader.TabIndex = 0;
            this.pnHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseDown);
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            this.pnHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseUp);
            // 
            // lbClear
            // 
            this.lbClear.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lbClear.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClear.Appearance.Options.UseFont = true;
            this.lbClear.Appearance.Options.UseForeColor = true;
            this.lbClear.Appearance.Options.UseTextOptions = true;
            this.lbClear.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbClear.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbClear.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbClear.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbClear.ImageOptions.Image")));
            this.lbClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbClear.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClear.Location = new System.Drawing.Point(294, 12);
            this.lbClear.Name = "lbClear";
            this.lbClear.Size = new System.Drawing.Size(30, 30);
            this.lbClear.TabIndex = 3;
            this.lbClear.Click += new System.EventHandler(this.lbClear_Click);
            // 
            // lbClose
            // 
            this.lbClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lbClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClose.Appearance.Options.UseFont = true;
            this.lbClose.Appearance.Options.UseForeColor = true;
            this.lbClose.Appearance.Options.UseTextOptions = true;
            this.lbClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbClose.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbClose.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbClose.ImageOptions.Image")));
            this.lbClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbClose.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClose.Location = new System.Drawing.Point(330, 12);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(30, 30);
            this.lbClose.TabIndex = 2;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnCancel);
            this.pnFooter.Controls.Add(this.btnSave);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 406);
            this.pnFooter.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.pnFooter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(386, 83);
            this.pnFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(246, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(46, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 45);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(12, 101);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSKU.Properties.Appearance.Options.UseFont = true;
            this.txtSKU.Properties.AutoHeight = false;
            this.txtSKU.Size = new System.Drawing.Size(362, 38);
            this.txtSKU.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 21);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Product ID";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(15, 160);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 21);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(12, 187);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProductName.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtProductName.Properties.AutoHeight = false;
            this.txtProductName.Size = new System.Drawing.Size(362, 38);
            this.txtProductName.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            this.openFileDialog1.FileName = "Anh_San_Pham";
            this.openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            // 
            // spNumberStock
            // 
            this.spNumberStock.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spNumberStock.Location = new System.Drawing.Point(12, 343);
            this.spNumberStock.Name = "spNumberStock";
            this.spNumberStock.Properties.AutoHeight = false;
            this.spNumberStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spNumberStock.Properties.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spNumberStock.Properties.IsFloatValue = false;
            this.spNumberStock.Properties.Mask.EditMask = "N00";
            this.spNumberStock.Properties.MaxValue = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spNumberStock.Size = new System.Drawing.Size(362, 38);
            this.spNumberStock.TabIndex = 36;
            // 
            // spPrice
            // 
            this.spPrice.EditValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Location = new System.Drawing.Point(12, 260);
            this.spPrice.Name = "spPrice";
            this.spPrice.Properties.AutoHeight = false;
            this.spPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spPrice.Properties.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Properties.Mask.EditMask = "n0";
            this.spPrice.Properties.MaxValue = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.spPrice.Properties.MinValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Size = new System.Drawing.Size(362, 38);
            this.spPrice.TabIndex = 38;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 316);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 21);
            this.labelControl1.TabIndex = 43;
            this.labelControl1.Text = "Stock";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(12, 231);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(90, 21);
            this.labelControl15.TabIndex = 43;
            this.labelControl15.Text = "Price (VNĐ)";
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 489);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spPrice);
            this.Controls.Add(this.spNumberStock);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Sản Phẩm";
            this.Shown += new System.EventHandler(this.frmProductDetail_Shown);
            this.Resize += new System.EventHandler(this.frmProductDetail_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNumberStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnHeader;
        private DevExpress.XtraEditors.PanelControl pnFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.TextEdit txtSKU;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vali;
        private DevExpress.XtraEditors.SpinEdit spNumberStock;
        private DevExpress.XtraEditors.SpinEdit spPrice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lbClear;
        private DevExpress.XtraEditors.LabelControl lbClose;
    }
}
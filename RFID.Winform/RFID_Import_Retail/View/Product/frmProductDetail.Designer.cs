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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vali = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            this.cbbUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spPrice = new DevExpress.XtraEditors.SpinEdit();
            this.spMinStock = new DevExpress.XtraEditors.SpinEdit();
            this.spStock = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtSKU = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).BeginInit();
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
            this.pnHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(635, 76);
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
            this.lbClear.Location = new System.Drawing.Point(539, 13);
            this.lbClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbClear.Name = "lbClear";
            this.lbClear.Size = new System.Drawing.Size(35, 38);
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
            this.lbClose.Location = new System.Drawing.Point(582, 13);
            this.lbClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(35, 38);
            this.lbClose.TabIndex = 2;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnCancel);
            this.pnFooter.Controls.Add(this.btnSave);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 557);
            this.pnFooter.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.pnFooter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(635, 106);
            this.pnFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(445, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 58);
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
            this.btnSave.Location = new System.Drawing.Point(54, 22);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 58);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(13, 80);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 28);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Product ID";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(326, 80);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 28);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Name";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            this.openFileDialog1.FileName = "Anh_San_Pham";
            this.openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(326, 193);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(111, 28);
            this.labelControl15.TabIndex = 43;
            this.labelControl15.Text = "Price (VNĐ)";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(13, 229);
            this.txtType.Margin = new System.Windows.Forms.Padding(4);
            this.txtType.Name = "txtType";
            this.txtType.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtType.Properties.Appearance.Options.UseFont = true;
            this.txtType.Properties.AutoHeight = false;
            this.txtType.Size = new System.Drawing.Size(291, 49);
            this.txtType.TabIndex = 66;
            // 
            // cbbUnit
            // 
            this.cbbUnit.EditValue = "";
            this.cbbUnit.Location = new System.Drawing.Point(487, 229);
            this.cbbUnit.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.cbbUnit.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbUnit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.cbbUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.cbbUnit.Properties.Appearance.Options.UseFont = true;
            this.cbbUnit.Properties.Appearance.Options.UseForeColor = true;
            this.cbbUnit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(202)))), ((int)(((byte)(203)))));
            this.cbbUnit.Properties.AppearanceReadOnly.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.cbbUnit.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbUnit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.cbbUnit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cbbUnit.Properties.AppearanceReadOnly.Options.UseBorderColor = true;
            this.cbbUnit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbbUnit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cbbUnit.Properties.AutoHeight = false;
            this.cbbUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbUnit.Properties.Items.AddRange(new object[] {
            "Pieces (PCE)",
            "Pair (PR)",
            "Sets (SET)",
            "Dozen (DZN)"});
            this.cbbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbbUnit.Size = new System.Drawing.Size(130, 49);
            this.cbbUnit.TabIndex = 65;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(13, 196);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 28);
            this.labelControl6.TabIndex = 64;
            this.labelControl6.Text = "Type";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(487, 194);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(40, 28);
            this.labelControl14.TabIndex = 61;
            this.labelControl14.Text = "Unit";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(326, 303);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(96, 28);
            this.labelControl12.TabIndex = 62;
            this.labelControl12.Text = "Min Stock";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(13, 303);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 28);
            this.labelControl5.TabIndex = 63;
            this.labelControl5.Text = "Stock";
            // 
            // spPrice
            // 
            this.spPrice.EditValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Location = new System.Drawing.Point(326, 229);
            this.spPrice.Margin = new System.Windows.Forms.Padding(4);
            this.spPrice.Name = "spPrice";
            this.spPrice.Properties.AutoHeight = false;
            this.spPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spPrice.Properties.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Properties.MaskSettings.Set("mask", "n0");
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
            this.spPrice.Size = new System.Drawing.Size(155, 49);
            this.spPrice.TabIndex = 59;
            // 
            // spMinStock
            // 
            this.spMinStock.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMinStock.Location = new System.Drawing.Point(326, 338);
            this.spMinStock.Margin = new System.Windows.Forms.Padding(4);
            this.spMinStock.Name = "spMinStock";
            this.spMinStock.Properties.AutoHeight = false;
            this.spMinStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spMinStock.Properties.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spMinStock.Properties.IsFloatValue = false;
            this.spMinStock.Properties.MaskSettings.Set("mask", "N00");
            this.spMinStock.Properties.MaxValue = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spMinStock.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMinStock.Size = new System.Drawing.Size(291, 49);
            this.spMinStock.TabIndex = 58;
            // 
            // spStock
            // 
            this.spStock.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spStock.Location = new System.Drawing.Point(13, 338);
            this.spStock.Margin = new System.Windows.Forms.Padding(4);
            this.spStock.Name = "spStock";
            this.spStock.Properties.AutoHeight = false;
            this.spStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spStock.Properties.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spStock.Properties.IsFloatValue = false;
            this.spStock.Properties.MaskSettings.Set("mask", "N00");
            this.spStock.Properties.MaxValue = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spStock.Size = new System.Drawing.Size(291, 49);
            this.spStock.TabIndex = 57;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(13, 406);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(109, 28);
            this.labelControl7.TabIndex = 56;
            this.labelControl7.Text = "Description";
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(13, 440);
            this.mmeDescription.Margin = new System.Windows.Forms.Padding(4);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mmeDescription.Properties.Appearance.Options.UseFont = true;
            this.mmeDescription.Size = new System.Drawing.Size(604, 111);
            this.mmeDescription.TabIndex = 55;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(326, 116);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProductName.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtProductName.Properties.AutoHeight = false;
            this.txtProductName.Size = new System.Drawing.Size(291, 49);
            this.txtProductName.TabIndex = 53;
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(13, 116);
            this.txtSKU.Margin = new System.Windows.Forms.Padding(4);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSKU.Properties.Appearance.Options.UseFont = true;
            this.txtSKU.Properties.AutoHeight = false;
            this.txtSKU.Size = new System.Drawing.Size(291, 49);
            this.txtSKU.TabIndex = 51;
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 663);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.cbbUnit);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.spPrice);
            this.Controls.Add(this.spMinStock);
            this.Controls.Add(this.spStock);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.mmeDescription);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Sản Phẩm";
            this.Shown += new System.EventHandler(this.frmProductDetail_Shown);
            this.Resize += new System.EventHandler(this.frmProductDetail_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vali)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnHeader;
        private DevExpress.XtraEditors.PanelControl pnFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vali;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lbClear;
        private DevExpress.XtraEditors.LabelControl lbClose;
        private DevExpress.XtraEditors.TextEdit txtType;
        private DevExpress.XtraEditors.ComboBoxEdit cbbUnit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spPrice;
        private DevExpress.XtraEditors.SpinEdit spMinStock;
        private DevExpress.XtraEditors.SpinEdit spStock;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.TextEdit txtSKU;
    }
}
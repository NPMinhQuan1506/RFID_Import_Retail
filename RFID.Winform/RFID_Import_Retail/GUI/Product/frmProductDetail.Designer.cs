namespace RFID_Import_Retail.GUI.Product
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
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vali = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.spNumberStock = new DevExpress.XtraEditors.SpinEdit();
            this.spMinNumberStock = new DevExpress.XtraEditors.SpinEdit();
            this.spPrice = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.cbbUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNumberStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinNumberStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
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
            this.pnHeader.Size = new System.Drawing.Size(544, 59);
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
            this.lbClear.Location = new System.Drawing.Point(457, 12);
            this.lbClear.Name = "lbClear";
            this.lbClear.Size = new System.Drawing.Size(30, 30);
            this.lbClear.TabIndex = 3;
            this.lbClear.Click += new System.EventHandler(this.lbClear_Click_1);
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
            this.lbClose.Location = new System.Drawing.Point(493, 12);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(30, 30);
            this.lbClose.TabIndex = 2;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click_1);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnCancel);
            this.pnFooter.Controls.Add(this.btnSave);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 465);
            this.pnFooter.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.pnFooter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(544, 83);
            this.pnFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(345, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(88, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 45);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
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
            this.txtSKU.Size = new System.Drawing.Size(246, 38);
            this.txtSKU.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 21);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mã Sản Phẩm";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(277, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(107, 21);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Tên Sản Phẩm";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(277, 101);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProductName.Properties.Appearance.Options.UseFont = true;
            this.txtProductName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProductName.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtProductName.Properties.AutoHeight = false;
            this.txtProductName.Size = new System.Drawing.Size(246, 38);
            this.txtProductName.TabIndex = 4;
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(12, 354);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mmeDescription.Properties.Appearance.Options.UseFont = true;
            this.mmeDescription.Size = new System.Drawing.Size(511, 87);
            this.mmeDescription.TabIndex = 10;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 327);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 21);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Mô Tả";
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
            this.spNumberStock.Location = new System.Drawing.Point(12, 274);
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
            this.spNumberStock.Size = new System.Drawing.Size(246, 38);
            this.spNumberStock.TabIndex = 36;
            // 
            // spMinNumberStock
            // 
            this.spMinNumberStock.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMinNumberStock.Location = new System.Drawing.Point(277, 274);
            this.spMinNumberStock.Name = "spMinNumberStock";
            this.spMinNumberStock.Properties.AutoHeight = false;
            this.spMinNumberStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spMinNumberStock.Properties.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spMinNumberStock.Properties.IsFloatValue = false;
            this.spMinNumberStock.Properties.Mask.EditMask = "N00";
            this.spMinNumberStock.Properties.MaxValue = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spMinNumberStock.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMinNumberStock.Size = new System.Drawing.Size(246, 38);
            this.spMinNumberStock.TabIndex = 37;
            // 
            // spPrice
            // 
            this.spPrice.EditValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spPrice.Location = new System.Drawing.Point(277, 189);
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
            this.spPrice.Size = new System.Drawing.Size(131, 38);
            this.spPrice.TabIndex = 38;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 247);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 21);
            this.labelControl1.TabIndex = 43;
            this.labelControl1.Text = "Số Lượng Tồn";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 163);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 21);
            this.labelControl6.TabIndex = 46;
            this.labelControl6.Text = "Thể Loại";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(277, 247);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(104, 21);
            this.labelControl12.TabIndex = 43;
            this.labelControl12.Text = "Tồn Tối Thiểu";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(413, 162);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(90, 21);
            this.labelControl14.TabIndex = 43;
            this.labelControl14.Text = "Đơn Vị Tính";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(277, 161);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(110, 21);
            this.labelControl15.TabIndex = 43;
            this.labelControl15.Text = "Giá Bán (VNĐ)";
            // 
            // cbbUnit
            // 
            this.cbbUnit.EditValue = "";
            this.cbbUnit.Location = new System.Drawing.Point(413, 189);
            this.cbbUnit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            "Cái",
            "Lô",
            "Bộ"});
            this.cbbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbbUnit.Size = new System.Drawing.Size(110, 38);
            this.cbbUnit.TabIndex = 49;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(12, 189);
            this.txtType.Name = "txtType";
            this.txtType.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtType.Properties.Appearance.Options.UseFont = true;
            this.txtType.Properties.AutoHeight = false;
            this.txtType.Size = new System.Drawing.Size(246, 38);
            this.txtType.TabIndex = 50;
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 548);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.cbbUnit);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spPrice);
            this.Controls.Add(this.spMinNumberStock);
            this.Controls.Add(this.spNumberStock);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.mmeDescription);
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
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNumberStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinNumberStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
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
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vali;
        private DevExpress.XtraEditors.SpinEdit spNumberStock;
        private DevExpress.XtraEditors.SpinEdit spMinNumberStock;
        private DevExpress.XtraEditors.SpinEdit spPrice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ComboBoxEdit cbbUnit;
        private DevExpress.XtraEditors.LabelControl lbClear;
        private DevExpress.XtraEditors.LabelControl lbClose;
        private DevExpress.XtraEditors.TextEdit txtType;
    }
}
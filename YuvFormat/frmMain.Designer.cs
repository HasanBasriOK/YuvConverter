namespace YuvFormat
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAyarlar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDosyaSec = new DevExpress.XtraEditors.SimpleButton();
            this.txtDosyaDizin = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.btnOynat = new DevExpress.XtraEditors.SimpleButton();
            this.btnDurdur = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaDizin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnAyarlar);
            this.groupControl1.Controls.Add(this.btnDosyaSec);
            this.groupControl1.Controls.Add(this.txtDosyaDizin);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1042, 130);
            this.groupControl1.TabIndex = 0;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.Location = new System.Drawing.Point(924, 32);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(106, 23);
            this.btnAyarlar.TabIndex = 2;
            this.btnAyarlar.Text = "Settings";
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Image = ((System.Drawing.Image)(resources.GetObject("btnDosyaSec.Image")));
            this.btnDosyaSec.Location = new System.Drawing.Point(462, 33);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(106, 23);
            this.btnDosyaSec.TabIndex = 1;
            this.btnDosyaSec.Text = "Choose File";
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // txtDosyaDizin
            // 
            this.txtDosyaDizin.Enabled = false;
            this.txtDosyaDizin.Location = new System.Drawing.Point(12, 35);
            this.txtDosyaDizin.Name = "txtDosyaDizin";
            this.txtDosyaDizin.Size = new System.Drawing.Size(432, 20);
            this.txtDosyaDizin.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Location = new System.Drawing.Point(91, 145);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(809, 362);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 2;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcControl1.VlcLibDirectory")));
            this.vlcControl1.VlcMediaplayerOptions = null;
            // 
            // btnOynat
            // 
            this.btnOynat.Image = ((System.Drawing.Image)(resources.GetObject("btnOynat.Image")));
            this.btnOynat.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnOynat.Location = new System.Drawing.Point(91, 514);
            this.btnOynat.Name = "btnOynat";
            this.btnOynat.Size = new System.Drawing.Size(320, 61);
            this.btnOynat.TabIndex = 3;
            this.btnOynat.Text = "Play";
            this.btnOynat.Click += new System.EventHandler(this.btnOynat_Click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.Image = ((System.Drawing.Image)(resources.GetObject("btnDurdur.Image")));
            this.btnDurdur.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDurdur.Location = new System.Drawing.Point(580, 514);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new System.Drawing.Size(320, 61);
            this.btnDurdur.TabIndex = 3;
            this.btnDurdur.Text = "Pause";
            this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 587);
            this.Controls.Add(this.btnDurdur);
            this.Controls.Add(this.btnOynat);
            this.Controls.Add(this.vlcControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yuv Converter";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaDizin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDosyaDizin;
        private DevExpress.XtraEditors.SimpleButton btnDosyaSec;
        private DevExpress.XtraEditors.SimpleButton btnAyarlar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private DevExpress.XtraEditors.SimpleButton btnOynat;
        private DevExpress.XtraEditors.SimpleButton btnDurdur;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
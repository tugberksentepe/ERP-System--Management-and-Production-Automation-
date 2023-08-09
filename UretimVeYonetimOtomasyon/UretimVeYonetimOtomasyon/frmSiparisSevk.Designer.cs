namespace UretimVeYonetimOtomasyon
{
    partial class frmSiparisSevk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSiparisSevk));
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbtnSiparisRapor = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gControlSiparis = new DevExpress.XtraGrid.GridControl();
            this.gViewSiparis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gControlUrunler = new DevExpress.XtraGrid.GridControl();
            this.gViewUrunler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbtnSevkEmri = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSiparis)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLookUpEdit1.Location = new System.Drawing.Point(12, 26);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(220, 20);
            this.searchLookUpEdit1.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // sbtnSiparisRapor
            // 
            this.sbtnSiparisRapor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSiparisRapor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtnSiparisRapor.ImageOptions.Image")));
            this.sbtnSiparisRapor.Location = new System.Drawing.Point(386, 13);
            this.sbtnSiparisRapor.Name = "sbtnSiparisRapor";
            this.sbtnSiparisRapor.Size = new System.Drawing.Size(158, 46);
            this.sbtnSiparisRapor.TabIndex = 1;
            this.sbtnSiparisRapor.Text = "Müşteri Sipariş Raporu";
            this.sbtnSiparisRapor.Click += new System.EventHandler(this.sbtnSiparisRapor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gControlSiparis);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sevke Hazır Sipariş Listesi";
            // 
            // gControlSiparis
            // 
            this.gControlSiparis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlSiparis.Location = new System.Drawing.Point(3, 22);
            this.gControlSiparis.MainView = this.gViewSiparis;
            this.gControlSiparis.Name = "gControlSiparis";
            this.gControlSiparis.Size = new System.Drawing.Size(529, 135);
            this.gControlSiparis.TabIndex = 0;
            this.gControlSiparis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewSiparis});
            // 
            // gViewSiparis
            // 
            this.gViewSiparis.GridControl = this.gControlSiparis;
            this.gViewSiparis.Name = "gViewSiparis";
            this.gViewSiparis.OptionsView.ShowGroupPanel = false;
            this.gViewSiparis.Click += new System.EventHandler(this.gViewSiparis_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gControlUrunler);
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seçili Siparişin İçeriği";
            // 
            // gControlUrunler
            // 
            this.gControlUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlUrunler.Location = new System.Drawing.Point(3, 22);
            this.gControlUrunler.MainView = this.gViewUrunler;
            this.gControlUrunler.Name = "gControlUrunler";
            this.gControlUrunler.Size = new System.Drawing.Size(529, 197);
            this.gControlUrunler.TabIndex = 0;
            this.gControlUrunler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewUrunler});
            // 
            // gViewUrunler
            // 
            this.gViewUrunler.GridControl = this.gControlUrunler;
            this.gViewUrunler.Name = "gViewUrunler";
            this.gViewUrunler.OptionsView.ShowGroupPanel = false;
            // 
            // sbtnSevkEmri
            // 
            this.sbtnSevkEmri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSevkEmri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtnSevkEmri.ImageOptions.Image")));
            this.sbtnSevkEmri.Location = new System.Drawing.Point(386, 476);
            this.sbtnSevkEmri.Name = "sbtnSevkEmri";
            this.sbtnSevkEmri.Size = new System.Drawing.Size(158, 46);
            this.sbtnSevkEmri.TabIndex = 1;
            this.sbtnSevkEmri.Text = "Siparişi Sevk Et";
            this.sbtnSevkEmri.Click += new System.EventHandler(this.sbtnSevkEmri_Click);
            // 
            // frmSiparisSevk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sbtnSevkEmri);
            this.Controls.Add(this.sbtnSiparisRapor);
            this.Controls.Add(this.searchLookUpEdit1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSiparisSevk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sipariş Sevk";
            this.Load += new System.EventHandler(this.frmSiparisSevk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSiparis)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton sbtnSiparisRapor;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gControlSiparis;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewSiparis;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gControlUrunler;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewUrunler;
        private DevExpress.XtraEditors.SimpleButton sbtnSevkEmri;
    }
}
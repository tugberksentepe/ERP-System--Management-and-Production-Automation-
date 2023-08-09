namespace UretimVeYonetimOtomasyon
{
    partial class frmUretilenIsEmirleri
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUretilenIsEmirleri));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colISEMRI_NUMARASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTOK_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTOK_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISEMRI_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISEMRI_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESLIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIPARIS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIPKALEM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Query";
            this.gridControl1.DataSource = this.sqlDataSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1914, 841);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_Uretim ve Yonetim Sistemi_Connection 3";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colISEMRI_NUMARASI,
            this.colSTOK_KODU,
            this.colSTOK_ADI,
            this.colISEMRI_ACIKLAMASI,
            this.colISEMRI_TARIHI,
            this.colTESLIM_TARIHI,
            this.colSIPARIS_NO,
            this.colMIKTAR,
            this.colSIPKALEM_ID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colISEMRI_NUMARASI
            // 
            this.colISEMRI_NUMARASI.Caption = "İş Emri Numarası";
            this.colISEMRI_NUMARASI.FieldName = "ISEMRI_NUMARASI";
            this.colISEMRI_NUMARASI.Name = "colISEMRI_NUMARASI";
            this.colISEMRI_NUMARASI.Visible = true;
            this.colISEMRI_NUMARASI.VisibleIndex = 0;
            // 
            // colSTOK_KODU
            // 
            this.colSTOK_KODU.Caption = "Stok Kodu";
            this.colSTOK_KODU.FieldName = "STOK_KODU";
            this.colSTOK_KODU.Name = "colSTOK_KODU";
            this.colSTOK_KODU.Visible = true;
            this.colSTOK_KODU.VisibleIndex = 1;
            // 
            // colSTOK_ADI
            // 
            this.colSTOK_ADI.Caption = "Stok Adı";
            this.colSTOK_ADI.FieldName = "STOK_ADI";
            this.colSTOK_ADI.Name = "colSTOK_ADI";
            this.colSTOK_ADI.Visible = true;
            this.colSTOK_ADI.VisibleIndex = 2;
            // 
            // colISEMRI_ACIKLAMASI
            // 
            this.colISEMRI_ACIKLAMASI.Caption = "İş Emri Açıklaması";
            this.colISEMRI_ACIKLAMASI.FieldName = "ISEMRI_ACIKLAMASI";
            this.colISEMRI_ACIKLAMASI.Name = "colISEMRI_ACIKLAMASI";
            this.colISEMRI_ACIKLAMASI.Visible = true;
            this.colISEMRI_ACIKLAMASI.VisibleIndex = 3;
            // 
            // colISEMRI_TARIHI
            // 
            this.colISEMRI_TARIHI.Caption = "İş Emri Tarihi";
            this.colISEMRI_TARIHI.FieldName = "ISEMRI_TARIHI";
            this.colISEMRI_TARIHI.Name = "colISEMRI_TARIHI";
            this.colISEMRI_TARIHI.Visible = true;
            this.colISEMRI_TARIHI.VisibleIndex = 4;
            // 
            // colTESLIM_TARIHI
            // 
            this.colTESLIM_TARIHI.Caption = "Teslim Tarihi";
            this.colTESLIM_TARIHI.FieldName = "TESLIM_TARIHI";
            this.colTESLIM_TARIHI.Name = "colTESLIM_TARIHI";
            this.colTESLIM_TARIHI.Visible = true;
            this.colTESLIM_TARIHI.VisibleIndex = 5;
            // 
            // colSIPARIS_NO
            // 
            this.colSIPARIS_NO.Caption = "Sipariş No";
            this.colSIPARIS_NO.FieldName = "SIPARIS_NO";
            this.colSIPARIS_NO.Name = "colSIPARIS_NO";
            this.colSIPARIS_NO.Visible = true;
            this.colSIPARIS_NO.VisibleIndex = 6;
            // 
            // colMIKTAR
            // 
            this.colMIKTAR.Caption = "Miktar";
            this.colMIKTAR.FieldName = "MIKTAR";
            this.colMIKTAR.Name = "colMIKTAR";
            this.colMIKTAR.Visible = true;
            this.colMIKTAR.VisibleIndex = 7;
            // 
            // colSIPKALEM_ID
            // 
            this.colSIPKALEM_ID.Caption = "Sipariş ID";
            this.colSIPKALEM_ID.FieldName = "SIPKALEM_ID";
            this.colSIPKALEM_ID.Name = "colSIPKALEM_ID";
            this.colSIPKALEM_ID.Visible = true;
            this.colSIPKALEM_ID.VisibleIndex = 8;
            // 
            // frmUretilenIsEmirleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 841);
            this.Controls.Add(this.gridControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUretilenIsEmirleri";
            this.Text = "Şentepe Danışmanlık Yönetim & Üretim Yazılımı";
            this.Load += new System.EventHandler(this.frmUretilenIsEmirleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colISEMRI_NUMARASI;
        private DevExpress.XtraGrid.Columns.GridColumn colSTOK_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSTOK_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn colISEMRI_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn colISEMRI_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTESLIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSIPARIS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colMIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSIPKALEM_ID;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    }
}
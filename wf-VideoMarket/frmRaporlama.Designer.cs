namespace wf_VideoMarket
{
    partial class frmRaporlama
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtpTarih2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTarih1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMusteri = new System.Windows.Forms.TextBox();
            this.btnMusteriBul = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilm = new System.Windows.Forms.TextBox();
            this.btnFilmBul = new System.Windows.Forms.Button();
            this.cbFilmTuru = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vw_DetayliSorgulamaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VideoMarketDataSet = new wf_VideoMarket.VideoMarketDataSet();
            this.vw_DetayliSorgulamaTableAdapter = new wf_VideoMarket.VideoMarketDataSetTableAdapters.vw_DetayliSorgulamaTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.vw_DetayliSorgulamaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoMarketDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTarih2
            // 
            this.dtpTarih2.Location = new System.Drawing.Point(127, 39);
            this.dtpTarih2.Name = "dtpTarih2";
            this.dtpTarih2.Size = new System.Drawing.Size(105, 20);
            this.dtpTarih2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(124, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Son Tarih";
            // 
            // dtpTarih1
            // 
            this.dtpTarih1.Location = new System.Drawing.Point(16, 39);
            this.dtpTarih1.Name = "dtpTarih1";
            this.dtpTarih1.Size = new System.Drawing.Size(105, 20);
            this.dtpTarih1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "İlk Tarih";
            // 
            // btnGetir
            // 
            this.btnGetir.ForeColor = System.Drawing.Color.Black;
            this.btnGetir.Location = new System.Drawing.Point(475, 38);
            this.btnGetir.Name = "btnGetir";
            this.btnGetir.Size = new System.Drawing.Size(127, 49);
            this.btnGetir.TabIndex = 14;
            this.btnGetir.Text = "Satışları Getir";
            this.btnGetir.UseVisualStyleBackColor = true;
            this.btnGetir.Click += new System.EventHandler(this.btnGetir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Müşteri Bul";
            // 
            // txtMusteri
            // 
            this.txtMusteri.Location = new System.Drawing.Point(78, 63);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.Size = new System.Drawing.Size(134, 20);
            this.txtMusteri.TabIndex = 26;
            this.txtMusteri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMusteriBul
            // 
            this.btnMusteriBul.BackColor = System.Drawing.Color.Transparent;
            this.btnMusteriBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriBul.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMusteriBul.Location = new System.Drawing.Point(209, 63);
            this.btnMusteriBul.Name = "btnMusteriBul";
            this.btnMusteriBul.Size = new System.Drawing.Size(34, 20);
            this.btnMusteriBul.TabIndex = 27;
            this.btnMusteriBul.Text = "...";
            this.btnMusteriBul.UseVisualStyleBackColor = false;
            this.btnMusteriBul.Click += new System.EventHandler(this.btnMusteriBul_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(259, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Film Bul";
            // 
            // txtFilm
            // 
            this.txtFilm.Location = new System.Drawing.Point(342, 67);
            this.txtFilm.Name = "txtFilm";
            this.txtFilm.Size = new System.Drawing.Size(127, 20);
            this.txtFilm.TabIndex = 29;
            this.txtFilm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFilmBul
            // 
            this.btnFilmBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilmBul.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFilmBul.Location = new System.Drawing.Point(315, 67);
            this.btnFilmBul.Name = "btnFilmBul";
            this.btnFilmBul.Size = new System.Drawing.Size(30, 20);
            this.btnFilmBul.TabIndex = 30;
            this.btnFilmBul.Text = "...";
            this.btnFilmBul.UseVisualStyleBackColor = true;
            this.btnFilmBul.Click += new System.EventHandler(this.btnFilmBul_Click);
            // 
            // cbFilmTuru
            // 
            this.cbFilmTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilmTuru.FormattingEnabled = true;
            this.cbFilmTuru.Items.AddRange(new object[] {
            "Tüm Kategoriler"});
            this.cbFilmTuru.Location = new System.Drawing.Point(315, 40);
            this.cbFilmTuru.Name = "cbFilmTuru";
            this.cbFilmTuru.Size = new System.Drawing.Size(154, 21);
            this.cbFilmTuru.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Film Türü";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vw_DetayliSorgulamaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "wf_VideoMarket.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 117);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(763, 427);
            this.reportViewer1.TabIndex = 33;
            // 
            // vw_DetayliSorgulamaBindingSource
            // 
            this.vw_DetayliSorgulamaBindingSource.DataMember = "vw_DetayliSorgulama";
            this.vw_DetayliSorgulamaBindingSource.DataSource = this.VideoMarketDataSet;
            // 
            // VideoMarketDataSet
            // 
            this.VideoMarketDataSet.DataSetName = "VideoMarketDataSet";
            this.VideoMarketDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vw_DetayliSorgulamaTableAdapter
            // 
            this.vw_DetayliSorgulamaTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpTarih1);
            this.groupBox1.Controls.Add(this.btnGetir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbFilmTuru);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpTarih2);
            this.groupBox1.Controls.Add(this.txtMusteri);
            this.groupBox1.Controls.Add(this.btnFilmBul);
            this.groupBox1.Controls.Add(this.btnMusteriBul);
            this.groupBox1.Controls.Add(this.txtFilm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 100);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorgu Parametreleri";
            // 
            // frmRaporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(805, 575);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmRaporlama";
            this.Text = "frmRaporlama";
            this.Load += new System.EventHandler(this.frmRaporlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vw_DetayliSorgulamaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoMarketDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTarih2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTarih1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMusteri;
        private System.Windows.Forms.Button btnMusteriBul;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilm;
        private System.Windows.Forms.Button btnFilmBul;
        private System.Windows.Forms.ComboBox cbFilmTuru;
        private System.Windows.Forms.Label label5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vw_DetayliSorgulamaBindingSource;
        private VideoMarketDataSet VideoMarketDataSet;
        private VideoMarketDataSetTableAdapters.vw_DetayliSorgulamaTableAdapter vw_DetayliSorgulamaTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
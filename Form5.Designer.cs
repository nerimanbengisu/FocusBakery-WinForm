namespace Focus_Bakery
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.pbUrun = new System.Windows.Forms.PictureBox();
            this.lblSure = new System.Windows.Forms.Label();
            this.zamanlayici = new System.Windows.Forms.Timer(this.components);
            this.cmbUrun = new System.Windows.Forms.ComboBox();
            this.btnOdaklan = new System.Windows.Forms.Button();
            this.prgPismeDurumu = new System.Windows.Forms.ProgressBar();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnIleri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUrun)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUrun
            // 
            this.pbUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pbUrun.BackColor = System.Drawing.Color.Transparent;
            this.pbUrun.Image = ((System.Drawing.Image)(resources.GetObject("pbUrun.Image")));
            this.pbUrun.Location = new System.Drawing.Point(134, 108);
            this.pbUrun.Name = "pbUrun";
            this.pbUrun.Size = new System.Drawing.Size(731, 525);
            this.pbUrun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUrun.TabIndex = 0;
            this.pbUrun.TabStop = false;
            // 
            // lblSure
            // 
            this.lblSure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSure.AutoSize = true;
            this.lblSure.BackColor = System.Drawing.Color.Transparent;
            this.lblSure.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSure.Location = new System.Drawing.Point(175, 37);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(183, 68);
            this.lblSure.TabIndex = 1;
            this.lblSure.Text = "Süre :";
            this.lblSure.Click += new System.EventHandler(this.zamanlayici_Tick);
            // 
            // zamanlayici
            // 
            this.zamanlayici.Interval = 1000;
            this.zamanlayici.Tick += new System.EventHandler(this.zamanlayici_Tick);
            // 
            // cmbUrun
            // 
            this.cmbUrun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUrun.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbUrun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Items.AddRange(new object[] {
            "Kruvasan",
            "Pasta",
            "Kurabiye",
            "Kek",
            "Ekmek"});
            this.cmbUrun.Location = new System.Drawing.Point(208, 602);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new System.Drawing.Size(376, 31);
            this.cmbUrun.TabIndex = 4;
            this.cmbUrun.SelectedIndexChanged += new System.EventHandler(this.cmbUrun_SelectedIndexChanged);
            // 
            // btnOdaklan
            // 
            this.btnOdaklan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdaklan.BackColor = System.Drawing.Color.White;
            this.btnOdaklan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdaklan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOdaklan.Location = new System.Drawing.Point(590, 600);
            this.btnOdaklan.Name = "btnOdaklan";
            this.btnOdaklan.Size = new System.Drawing.Size(185, 33);
            this.btnOdaklan.TabIndex = 5;
            this.btnOdaklan.Text = "Fırını Çalıştır 🔥\r\n";
            this.btnOdaklan.UseVisualStyleBackColor = false;
            this.btnOdaklan.Click += new System.EventHandler(this.btnOdaklan_Click);
            // 
            // prgPismeDurumu
            // 
            this.prgPismeDurumu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prgPismeDurumu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.prgPismeDurumu.Location = new System.Drawing.Point(399, 58);
            this.prgPismeDurumu.Name = "prgPismeDurumu";
            this.prgPismeDurumu.Size = new System.Drawing.Size(393, 35);
            this.prgPismeDurumu.TabIndex = 6;
            // 
            // btnGeri
            // 
            this.btnGeri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGeri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Location = new System.Drawing.Point(17, 602);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(185, 33);
            this.btnGeri.TabIndex = 7;
            this.btnGeri.Text = "Geri / Değiştir";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnIleri
            // 
            this.btnIleri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIleri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIleri.ForeColor = System.Drawing.Color.White;
            this.btnIleri.Location = new System.Drawing.Point(781, 600);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(185, 33);
            this.btnIleri.TabIndex = 8;
            this.btnIleri.Text = "İleri / Raporlarım \r\n";
            this.btnIleri.UseVisualStyleBackColor = false;
            this.btnIleri.Click += new System.EventHandler(this.btnIleri_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 637);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.prgPismeDurumu);
            this.Controls.Add(this.btnOdaklan);
            this.Controls.Add(this.cmbUrun);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.pbUrun);
            this.Name = "Form5";
            this.Text = "Odak Ekranı Focus Bakery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUrun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUrun;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Timer zamanlayici;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Button btnOdaklan;
        private System.Windows.Forms.ProgressBar prgPismeDurumu;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnIleri;
        // HATALI RenkliBar TANIMINI BURADAN DA SİLDİM
    }
}
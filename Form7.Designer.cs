namespace Focus_Bakery
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSkorlar = new System.Windows.Forms.DataGridView();
            this.btnGeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkorlar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Snow;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(290, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "🏆 ŞAMPİYONLAR LİGİ 🏆";
            // 
            // dgvSkorlar
            // 
            this.dgvSkorlar.AllowUserToAddRows = false;
            this.dgvSkorlar.AllowUserToDeleteRows = false;
            this.dgvSkorlar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvSkorlar.BackgroundColor = System.Drawing.Color.White;
            this.dgvSkorlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkorlar.Location = new System.Drawing.Point(166, 91);
            this.dgvSkorlar.Name = "dgvSkorlar";
            this.dgvSkorlar.ReadOnly = true;
            this.dgvSkorlar.RowHeadersWidth = 51;
            this.dgvSkorlar.RowTemplate.Height = 24;
            this.dgvSkorlar.Size = new System.Drawing.Size(745, 425);
            this.dgvSkorlar.TabIndex = 1;
            // 
            // btnGeri
            // 
            this.btnGeri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGeri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Location = new System.Drawing.Point(12, 462);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(127, 54);
            this.btnGeri.TabIndex = 2;
            this.btnGeri.Text = "Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 626);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.dgvSkorlar);
            this.Controls.Add(this.label1);
            this.Name = "Form7";
            this.Text = "Sıralama Focus Bakery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkorlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSkorlar;
        private System.Windows.Forms.Button btnGeri;
    }
}
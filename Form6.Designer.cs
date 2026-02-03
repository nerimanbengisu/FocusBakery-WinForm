using System;
using System.Drawing;

namespace Focus_Bakery
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOdul = new System.Windows.Forms.Button();
            this.btnMutfak = new System.Windows.Forms.Button();
            this.lblToplamUrun = new System.Windows.Forms.Label();
            this.lblToplamSure = new System.Windows.Forms.Label();
            this.dgvGecmis = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOdul);
            this.panel1.Controls.Add(this.btnMutfak);
            this.panel1.Controls.Add(this.lblToplamUrun);
            this.panel1.Controls.Add(this.lblToplamSure);
            this.panel1.Controls.Add(this.dgvGecmis);
            this.panel1.Location = new System.Drawing.Point(158, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 600);
            this.panel1.TabIndex = 0;
            // 
            // btnOdul
            // 
            this.btnOdul.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOdul.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdul.ForeColor = System.Drawing.Color.White;
            this.btnOdul.Location = new System.Drawing.Point(385, 500);
            this.btnOdul.Name = "btnOdul";
            this.btnOdul.Size = new System.Drawing.Size(276, 50);
            this.btnOdul.TabIndex = 3;
            this.btnOdul.Text = "🏆 Sıralama";
            this.btnOdul.UseVisualStyleBackColor = false;
            this.btnOdul.Click += new System.EventHandler(this.btnOdul_Click);
            // 
            // btnMutfak
            // 
            this.btnMutfak.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMutfak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnMutfak.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMutfak.ForeColor = System.Drawing.Color.White;
            this.btnMutfak.Location = new System.Drawing.Point(24, 500);
            this.btnMutfak.Name = "btnMutfak";
            this.btnMutfak.Size = new System.Drawing.Size(276, 50);
            this.btnMutfak.TabIndex = 1;
            this.btnMutfak.Text = "Yeni Pişirme (Fırın)";
            this.btnMutfak.UseVisualStyleBackColor = false;
            this.btnMutfak.Click += new System.EventHandler(this.btnMutfak_Click);
            // 
            // lblToplamUrun
            // 
            this.lblToplamUrun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToplamUrun.AutoSize = true;
            this.lblToplamUrun.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamUrun.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamUrun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblToplamUrun.Location = new System.Drawing.Point(19, 461);
            this.lblToplamUrun.Name = "lblToplamUrun";
            this.lblToplamUrun.Size = new System.Drawing.Size(160, 25);
            this.lblToplamUrun.TabIndex = 2;
            this.lblToplamUrun.Text = "Hesaplanıyor...";
            // 
            // lblToplamSure
            // 
            this.lblToplamSure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToplamSure.AutoSize = true;
            this.lblToplamSure.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamSure.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblToplamSure.Location = new System.Drawing.Point(19, 427);
            this.lblToplamSure.Name = "lblToplamSure";
            this.lblToplamSure.Size = new System.Drawing.Size(160, 25);
            this.lblToplamSure.TabIndex = 1;
            this.lblToplamSure.Text = "Hesaplanıyor...";
            // 
            // dgvGecmis
            // 
            this.dgvGecmis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvGecmis.BackgroundColor = System.Drawing.Color.White;
            this.dgvGecmis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGecmis.Location = new System.Drawing.Point(24, 24);
            this.dgvGecmis.Name = "dgvGecmis";
            this.dgvGecmis.RowHeadersWidth = 51;
            this.dgvGecmis.RowTemplate.Height = 24;
            this.dgvGecmis.Size = new System.Drawing.Size(637, 389);
            this.dgvGecmis.TabIndex = 0;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 626);
            this.Controls.Add(this.panel1);
            this.Name = "Form6";
            this.Text = "Dijital Pastane Defteri (Raporlar) Focus Bakery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form6_Load);
            this.Resize += new System.EventHandler(this.Form6_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblToplamUrun;
        private System.Windows.Forms.Label lblToplamSure;
        private System.Windows.Forms.DataGridView dgvGecmis;
        private System.Windows.Forms.Button btnMutfak;
        private System.Windows.Forms.Button btnOdul;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Focus_Bakery
{
    public partial class FrmMesaj : Form
    {
        public FrmMesaj(string mesaj)
        {
            InitializeComponent();
            lblMesaj.Text = mesaj;

            // Tasarım ekranındaki bağlantı kopsa bile bu satır işi garantiye alır:
            this.Load += new EventHandler(FrmMesaj_Load);
        }

        private void ButonYumusat(Button btn, int kavis)
        {
            if (btn.Width <= 0 || btn.Height <= 0) return;

            Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, kavis, kavis, 180, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y, kavis, kavis, 270, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y + r.Height - kavis, kavis, kavis, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - kavis, kavis, kavis, 90, 90);
            btn.Region = new Region(gp);
        }

        private void FrmMesaj_Load(object sender, EventArgs e)
        {
            // Buton ayarları
            btnTamam.FlatStyle = FlatStyle.Flat;
            btnTamam.FlatAppearance.BorderSize = 0;
            btnTamam.Cursor = Cursors.Hand;
            btnTamam.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193);
            btnTamam.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);

            // Ovalliği veriyoruz
            ButonYumusat(btnTamam, 40);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void Goster(string mesaj)
        {
            FrmMesaj yeniMesaj = new FrmMesaj(mesaj);
            yeniMesaj.ShowDialog();
        }

        private void lblMesaj_Click(object sender, EventArgs e) { }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN ŞART ---

namespace Focus_Bakery
{
    public partial class Form41 : Form
    {
        public Form41()
        {
            InitializeComponent();
        }

        // --- İMZA TASARIMIMIZ: BUTON YUMUŞATMA METODU ---
        private void ButonYumusat(Button btn, int kavis)
        {
            Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, kavis, kavis, 180, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y, kavis, kavis, 270, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y + r.Height - kavis, kavis, kavis, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - kavis, kavis, kavis, 90, 90);
            btn.Region = new Region(gp);
        }

        private void Form41_Load(object sender, EventArgs e)
        {
            // --- BUTON MAKYAJI ---

            // BAŞLA BUTONU (btnBasla)
            btnBasla.FlatStyle = FlatStyle.Flat;
            btnBasla.FlatAppearance.BorderSize = 0;
            btnBasla.Cursor = Cursors.Hand;

            // Üzerine gelince belirginleşen, yazıyı net tutan pembe
            btnBasla.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193);
            btnBasla.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);

            ButonYumusat(btnBasla, 40); // Tam istediğin ekstra ovallik ✨
        }

        private void Form41_Resize(object sender, EventArgs e)
        {
            // Boyut değişirse ovalliği koru
            ButonYumusat(btnBasla, 40);
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            // Durumları kontrol edelim
            bool kategoriSecildi = (cmbKategori.SelectedIndex != -1);
            bool yaziYazildi = !string.IsNullOrWhiteSpace(txtAciklama.Text);

            // 1. DURUM: Kullanıcı HİÇBİR ŞEY yapmamışsa
            if (!kategoriSecildi && !yaziYazildi)
            {
                FrmMesaj.Goster("Lütfen bir kategori seçin veya kendinize bir hedef yazın! 🥯");
                return;
            }

            // 2. DURUM: Kullanıcı İKİSİNİ DE yapmışsa (Yasaklı Durum)
            if (kategoriSecildi && yaziYazildi)
            {
                FrmMesaj.Goster("Aynı anda iki işe odaklanamayız! Lütfen ya listeden seçin ya da kendiniz yazın. 🥐");
                return;
            }

            // 3. DURUM: Her şey yolunda -> FORM 5'E GİT VE VERİYİ TAŞI
            Form5 frm5 = new Form5();

            if (kategoriSecildi)
            {
                frm5.gelenKonu = cmbKategori.SelectedItem.ToString();
            }
            else
            {
                frm5.gelenKonu = txtAciklama.Text;
            }

            frm5.Show();
            this.Hide();
        }

        // Tasarımı ve yapıyı bozmamak için bırakılan boş metodlar
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtAciklama_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
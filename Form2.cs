using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN ŞART ---

namespace Focus_Bakery
{
    public partial class Form2 : Form
    {
        private SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True;TrustServerCertificate=True;");

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Size panelSize)
        {
            InitializeComponent();
            panel1.Size = panelSize;
            NewMethod();
            CenterPanelAndChildren();
        }

        // --- BUTONLARI OVAL YAPMAK İÇİN YARDIMCI METOD (İmza Tasarımımız) ---
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

        private void Form2_Load(object sender, EventArgs e)
        {
            NewMethod();
            CenterPanelAndChildren();

            // --- BUTON MAKYAJI BAŞLIYOR ---

            // 1. KAYIT OL BUTONU (button1)
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;
            // Üzerine gelince koyulaşan pastel pembe (Yazı kaybolmaz!)
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);
            ButonYumusat(button1, 40); // Tam istediğin ekstra ovallik

            // 2. GERİ DÖN BUTONU (button2)
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
            // Üzerine gelince belirginleşen buğday tonu
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140);
            ButonYumusat(button2, 40);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            CenterPanelAndChildren();
            // Boyut değiştiğinde ovalliği koru
            ButonYumusat(button1, 40);
            ButonYumusat(button2, 40);
        }

        private void NewMethod()
        {
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
        }

        private void CenterPanelAndChildren()
        {
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2
            );

            if (panel1.Controls.Count > 0)
            {
                var visibleControls = panel1.Controls.Cast<Control>().Where(c => c.Visible).ToList();
                if (visibleControls.Count == 0) return;

                int minY = visibleControls.Min(c => c.Top);
                int maxY = visibleControls.Max(c => c.Bottom);
                int groupHeight = maxY - minY;

                int desiredTop = (panel1.ClientSize.Height - groupHeight) / 2;
                if (desiredTop < 0) desiredTop = 0;

                int offset = desiredTop - minY;

                if (offset != 0)
                {
                    foreach (Control c in visibleControls)
                    {
                        c.Top += offset;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                FrmMesaj.Goster("Lütfen tüm alanları (Güvenlik cevabı dahil) doldurunuz! 🥯");
                return;
            }

            if (textBox3.Text != textBox4.Text)
            {
                FrmMesaj.Goster("Şifreler uyuşmuyor! Lütfen tekrar kontrol edin. ❌");
                return;
            }

            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                    baglanti.Open();

                string sqlSorgusu = "INSERT INTO [kullanıcılar] (AdSoyad, KullaniciAdi, Sifre, GuvenlikCevabi) VALUES (@p1, @p2, @p3, @p4)";

                using (SqlCommand komut = new SqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", textBox3.Text);
                    komut.Parameters.AddWithValue("@p4", textBox5.Text);

                    komut.ExecuteNonQuery();
                }

                FrmMesaj.Goster("Kayıt başarıyla tamamlandı. Güvenlik cevabınızı sakın unutmayın! 🐣");
                this.Close(); // Kayıttan sonra pencereyi kapatmak şık olur
            }
            catch (Exception hata)
            {
                FrmMesaj.Goster("Bir hata oluştu: " + hata.Message);
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                    baglanti.Close();
            }
        }

        // Kullanılmayan olaylar dokunulmadan bırakıldı
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
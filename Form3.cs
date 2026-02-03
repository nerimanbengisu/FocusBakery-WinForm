using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN GEREKLİ ---

namespace Focus_Bakery
{
    public partial class Form3 : Form
    {
        private SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True;TrustServerCertificate=True;");

        public Form3()
        {
            InitializeComponent();
            NewMethod();
            CenterPanel();
            this.Load += Form3_Load;
            this.Resize += Form3_Resize;
        }

        public Form3(Size panelSize)
        {
            InitializeComponent();
            panel1.Size = panelSize;
            NewMethod();
            CenterPanel();
            this.Load += Form3_Load;
            this.Resize += Form3_Resize;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            CenterPanel();

            // --- BUTON MAKYAJI BAŞLIYOR ---

            // 1. ŞİFREYİ GÜNCELLE BUTONU (button1)
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;
            // Üzerine gelince belirginleşen pastel pembe
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);
            ButonYumusat(button1, 40); // 40 Birim Ovallik ✨

            // 2. İPTAL / GERİ DÖN BUTONU (button2)
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
            // Üzerine gelince belirginleşen buğday tonu
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140);
            ButonYumusat(button2, 40); // 40 Birim Ovallik ✨
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            CenterPanel();
            // Boyut değiştiğinde ovalliği tazele
            ButonYumusat(button1, 40);
            ButonYumusat(button2, 40);
        }

        private void NewMethod()
        {
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
        }

        private void CenterPanel()
        {
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                FrmMesaj.Goster("Lütfen tüm alanları (Güvenlik Cevabı dahil) doldurun! 🥯");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                FrmMesaj.Goster("Yeni şifreler birbiriyle eşleşmiyor! Lütfen kontrol ediniz. ❌");
                return;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                SqlCommand cmdKontrol = new SqlCommand("SELECT * FROM [kullanıcılar] WHERE KullaniciAdi=@kadi AND GuvenlikCevabi=@cevap", baglanti);
                cmdKontrol.Parameters.AddWithValue("@kadi", textBox1.Text);
                cmdKontrol.Parameters.AddWithValue("@cevap", textBox4.Text);

                SqlDataReader dr = cmdKontrol.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();

                    using (SqlCommand cmdUpdate = new SqlCommand("UPDATE [kullanıcılar] SET Sifre=@yeniSifre WHERE KullaniciAdi=@kadi", baglanti))
                    {
                        cmdUpdate.Parameters.AddWithValue("@yeniSifre", textBox2.Text);
                        cmdUpdate.Parameters.AddWithValue("@kadi", textBox1.Text);

                        cmdUpdate.ExecuteNonQuery();

                        FrmMesaj.Goster("Tebrikler! Şifreniz başarıyla güncellendi. 🥐");

                        this.Close();
                    }
                }
                else
                {
                    dr.Close();
                    FrmMesaj.Goster("Kullanıcı adı veya Güvenlik Cevabı hatalı! İşlem gerçekleştirilemedi. 🥯");
                }
            }
            catch (Exception ex)
            {
                FrmMesaj.Goster("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void Form3_Load_1(object sender, EventArgs e) { }
    }
}
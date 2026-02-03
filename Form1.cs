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
using System.Drawing.Drawing2D; // Oval köşeler için şart

namespace Focus_Bakery
{
    public partial class Form1 : Form
    {
        public static string GirisYapanKullanici = "";

        private SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True;TrustServerCertificate=True;");

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
        }

        // --- BUTONLARI DAHA OVAL YAPMAK İÇİN YARDIMCI METOD ---
        private void ButonYumusat(Button btn, int kavis)
        {
            Rectangle r = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath gp = new GraphicsPath();
            // Kavis miktarını 40-50 bandına çekeceğiz
            gp.AddArc(r.X, r.Y, kavis, kavis, 180, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y, kavis, kavis, 270, 90);
            gp.AddArc(r.X + r.Width - kavis, r.Y + r.Height - kavis, kavis, kavis, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - kavis, kavis, kavis, 90, 90);
            btn.Region = new Region(gp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2
            );

            // --- BUTON GÜZELLEŞTİRME ---

            // 1. GİRİŞ BUTONU (btnLogin)
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;

            // Rengi açmak yerine bir tık koyulaştırıyoruz (MistyRose tonu)
            // Böylece yazı asla kaybolmaz!
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193); // LightPink (Daha belirgin)
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180); // HotPink (Tıklayınca)
            ButonYumusat(btnLogin, 40); // Ovalliği 25'ten 40'a çıkardık ✨

            // 2. KAYIT BUTONU (btnSignUp)
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.Cursor = Cursors.Hand;

            // Üzerine gelince belirginleşen Buğday/Krem tonu
            btnSignUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179); // Wheat (Daha koyu krem)
            btnSignUp.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140); // Tan (Tıklayınca)
            ButonYumusat(btnSignUp, 40); // Ovalliği 25'ten 40'a çıkardık ✨
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [kullanıcılar] WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglanti))
                {
                    cmd.Parameters.AddWithValue("@p1", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@p2", txtPassword.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            GirisYapanKullanici = txtEmail.Text;
                            FrmMesaj.Goster("Giriş Başarılı! Hoş geldin " + GirisYapanKullanici + " 🐣");
                            Form41 fr = new Form41();
                            fr.Show();
                            this.Hide();
                        }
                        else
                        {
                            FrmMesaj.Goster("Hatalı kullanıcı adı veya şifre!");
                        }
                    }
                }
            }
            catch (Exception ex) { FrmMesaj.Goster("Hata: " + ex.Message); }
            finally { if (baglanti.State == ConnectionState.Open) baglanti.Close(); }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(panel1.Size);
            this.Hide();
            form2.FormClosed += (s, args) => this.Show();
            form2.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2
            );
            ButonYumusat(btnLogin, 40);
            ButonYumusat(btnSignUp, 40);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(panel1.Size);
            this.Hide();
            form3.FormClosed += (s, args) => this.Show();
            form3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
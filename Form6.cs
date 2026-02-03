using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN ŞART ---

namespace Focus_Bakery
{
    public partial class Form6 : Form
    {
        string baglantiAdresi = @"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True";

        public Form6()
        {
            InitializeComponent();

            try
            {
                panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
            }
            catch { }

            RaporlariGetir();
            IstatistikleriHesapla();
            TabloyuMakyajla();

            string aktifKullanici = string.IsNullOrEmpty(Form1.GirisYapanKullanici) ? "Misafir" : Form1.GirisYapanKullanici;
            FrmMesaj.Goster($"Hoş geldin Şef {aktifKullanici}! 🥐\nBugüne kadar yaptığın harika işlere bir göz atalım.");
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

        private void Form6_Load(object sender, EventArgs e)
        {
            // --- BUTON MAKYAJI ---

            // 1. MUTFAĞA DÖN BUTONU (btnMutfak)
            btnMutfak.FlatStyle = FlatStyle.Flat;
            btnMutfak.FlatAppearance.BorderSize = 0;
            btnMutfak.Cursor = Cursors.Hand;
            btnMutfak.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179); // Buğday tonu
            btnMutfak.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140);
            ButonYumusat(btnMutfak, 40);

            // 2. ÖDÜLLER BUTONU (btnOdul)
            btnOdul.FlatStyle = FlatStyle.Flat;
            btnOdul.FlatAppearance.BorderSize = 0;
            btnOdul.Cursor = Cursors.Hand;
            btnOdul.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193); // Pastel Pembe
            btnOdul.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);
            ButonYumusat(btnOdul, 40);
        }

        private void TabloyuMakyajla()
        {
            dgvGecmis.AllowUserToAddRows = false;
            dgvGecmis.AllowUserToOrderColumns = false;
            dgvGecmis.AllowUserToResizeColumns = false;
            dgvGecmis.AllowUserToResizeRows = false;
            dgvGecmis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGecmis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGecmis.MultiSelect = false;
            dgvGecmis.RowHeadersVisible = false;

            foreach (DataGridViewColumn col in dgvGecmis.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvGecmis.BackgroundColor = Color.White;
            dgvGecmis.BorderStyle = BorderStyle.None;
            dgvGecmis.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGecmis.GridColor = Color.FromArgb(245, 222, 179);
            dgvGecmis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvGecmis.EnableHeadersVisualStyles = false;
            dgvGecmis.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 69, 19);
            dgvGecmis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGecmis.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Bold);
            dgvGecmis.ColumnHeadersHeight = 45;
            dgvGecmis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGecmis.RowsDefaultCellStyle.BackColor = Color.MistyRose;
            dgvGecmis.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            dgvGecmis.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvGecmis.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            dgvGecmis.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGecmis.RowTemplate.Height = 40;

            dgvGecmis.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dgvGecmis.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvGecmis.DataBindingComplete += (s, e) =>
            {
                dgvGecmis.ClearSelection();
            };
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.Width = 650;
                panel1.Height = 500;
                int x = (this.ClientSize.Width - panel1.Width) / 2;
                int y = (this.ClientSize.Height - panel1.Height) / 2;
                panel1.Location = new Point(x, y);

                // Ovalliği koru
                ButonYumusat(btnMutfak, 40);
                ButonYumusat(btnOdul, 40);
            }
            catch { }
        }

        private void RaporlariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = @"
                        SELECT Tarih, 
                               CalisilanKonu AS 'Odaklanılan Konu', 
                               UrunAdi AS 'Pişen Ürün', 
                               SureDk AS 'Süre (Dk)' 
                        FROM OdakGecmisi 
                        WHERE KullaniciAdi = @isim 
                        ORDER BY Tarih DESC";

                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    string aktifKullanici = string.IsNullOrEmpty(Form1.GirisYapanKullanici) ? "Misafir" : Form1.GirisYapanKullanici;
                    komut.Parameters.AddWithValue("@isim", aktifKullanici);

                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);

                    dgvGecmis.DataSource = tablo;
                    dgvGecmis.ReadOnly = true;

                    if (tablo.Rows.Count == 0)
                    {
                        FrmMesaj.Goster("Henüz fırından çıkan bir ürünün yok! 🥯\nHadi mutfağa gidip bir şeyler pişirelim.");
                    }
                }
                catch (Exception hata)
                {
                    FrmMesaj.Goster("Rapor hatası: " + hata.Message);
                }
            }
        }

        private void IstatistikleriHesapla()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                try
                {
                    baglanti.Open();
                    string aktifKullanici = string.IsNullOrEmpty(Form1.GirisYapanKullanici) ? "Misafir" : Form1.GirisYapanKullanici;

                    SqlCommand komutSure = new SqlCommand("SELECT SUM(SureDk) FROM OdakGecmisi WHERE KullaniciAdi = @isim", baglanti);
                    komutSure.Parameters.AddWithValue("@isim", aktifKullanici);
                    object sonucSure = komutSure.ExecuteScalar();

                    SqlCommand komutUrun = new SqlCommand("SELECT COUNT(*) FROM OdakGecmisi WHERE KullaniciAdi = @isim", baglanti);
                    komutUrun.Parameters.AddWithValue("@isim", aktifKullanici);
                    object sonucUrun = komutUrun.ExecuteScalar();

                    if (sonucSure != DBNull.Value && sonucSure != null)
                        lblToplamSure.Text = "⏳ Toplam Odaklanma: " + sonucSure.ToString() + " Dakika ";
                    else
                        lblToplamSure.Text = "⏳ Toplam Odaklanma: 0 Dakika ";

                    if (sonucUrun != DBNull.Value && sonucUrun != null)
                        lblToplamUrun.Text = "🥐 Toplam Pişen Ürün: " + sonucUrun.ToString() + " Adet ";
                    else
                        lblToplamUrun.Text = "🥐 Toplam Pişen Ürün: 0 Adet ";
                }
                catch (Exception)
                {
                    lblToplamSure.Text = "Hesaplanamadı";
                }
            }
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            Form5 mutfak = new Form5();
            mutfak.Show();
            this.Hide();
        }

        private void btnOdul_Click(object sender, EventArgs e)
        {
            Form7 odulSayfasi = new Form7();
            odulSayfasi.Show();
            this.Hide();
        }

        private void lblToplamUrun_Click(object sender, EventArgs e) { }
        private void dgvGecmis_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN ŞART ---

namespace Focus_Bakery
{
    public partial class Form7 : Form
    {
        string baglantiAdresi = @"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True";

        public Form7()
        {
            InitializeComponent();
        }

        // --- İMZA TASARIMIMIZ: BUTON YUMUŞATMA METODU (Standart 40 Birim) ---
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

        private void Form7_Load(object sender, EventArgs e)
        {
            SkorlariGetir();
            TabloyuMakyajla();
            SiralamaAnaliziYap();

            // --- BUTON MAKYAJI ---
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.Cursor = Cursors.Hand;

            // Diğer formlardaki "Geri" butonlarıyla uyumlu buğday/krem tonu
            btnGeri.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179);
            btnGeri.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140);

            ButonYumusat(btnGeri, 40); // 40 Birim ekstra ovallik ✨
        }

        private void SiralamaAnaliziYap()
        {
            string aktifKullanici = string.IsNullOrEmpty(Form1.GirisYapanKullanici) ? "Misafir" : Form1.GirisYapanKullanici;
            int sira = 0;
            bool listedeVarMi = false;

            foreach (DataGridViewRow row in dgvSkorlar.Rows)
            {
                if (row.Cells["Şef 👩‍🍳"].Value != null && row.Cells["Şef 👩‍🍳"].Value.ToString() == aktifKullanici)
                {
                    sira = row.Index + 1;
                    listedeVarMi = true;
                    break;
                }
            }

            if (listedeVarMi)
            {
                if (sira == 1)
                    FrmMesaj.Goster($"İNANILMAZ! 🏆\nŞu an Focus Bakery liginin zirvesindesin, Baş Şef {aktifKullanici}!");
                else if (sira <= 3)
                    FrmMesaj.Goster($"Harika gidiyorsun! 🥈\nLigde {sira}. sıradaki yerini aldın. Şampiyonluk çok yakın!");
                else
                    FrmMesaj.Goster($"Selam Şef {aktifKullanici}! 🥐\nŞu an ligde {sira}. sıradasın. Biraz daha fırın başında vakit geçirerek yükselebilirsin!");
            }
            else if (aktifKullanici != "Misafir")
            {
                FrmMesaj.Goster("Henüz lig sıralamasına giremedin Şef! 🥯\nİlk ürününü pişirdiğinde ismin bu devler liginde görünecek.");
            }
        }

        private void SkorlariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = @"
                        SELECT TOP 10
                            T.KullaniciAdi AS 'Şef 👩‍🍳',
                            CASE 
                                WHEN T.UrunAdi = 'Kurabiye' THEN N'🍪 Kurabiye'
                                WHEN T.UrunAdi = 'Kek' THEN N'🧁 Kek'
                                WHEN T.UrunAdi = 'Pasta' THEN N'🎂 Pasta'
                                WHEN T.UrunAdi = 'Kruvasan' THEN N'🥐 Kruvasan'
                                WHEN T.UrunAdi = 'Ekmek' THEN N'🍞 Ekmek'
                                ELSE T.UrunAdi
                            END AS 'Son Ürün',
                            T.CalisilanKonu AS 'Son Odak',
                            CAST(Totals.TopSure AS nvarchar) + ' Dk' AS 'Top. Süre',
                            Totals.TopPuan AS 'TOPLAM PUAN',
                            FORMAT(T.Tarih, 'dd.MM.yyyy') AS 'Son Tarih'
                        FROM OdakGecmisi AS T
                        INNER JOIN (
                            SELECT 
                                KullaniciAdi,
                                SUM(SureDk) as TopSure,
                                SUM((SureDk * 10) + 
                                    CASE 
                                        WHEN UrunAdi = 'Kurabiye' THEN 50 
                                        WHEN UrunAdi = 'Kek' THEN 150 
                                        WHEN UrunAdi = 'Kruvasan' THEN 250 
                                        WHEN UrunAdi = 'Ekmek' THEN 300 
                                        WHEN UrunAdi = 'Pasta' THEN 500 
                                        ELSE 0 
                                    END
                                ) as TopPuan,
                                MAX(Tarih) as SonTarih
                            FROM OdakGecmisi
                            WHERE KullaniciAdi IS NOT NULL AND KullaniciAdi != ''
                            GROUP BY KullaniciAdi
                        ) AS Totals ON T.KullaniciAdi = Totals.KullaniciAdi AND T.Tarih = Totals.SonTarih
                        ORDER BY Totals.TopPuan DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dgvSkorlar.DataSource = tablo;
                }
                catch (Exception hata)
                {
                    FrmMesaj.Goster("Lig verileri yüklenirken bir hata oluştu: " + hata.Message);
                }
            }
        }

        private void TabloyuMakyajla()
        {
            dgvSkorlar.AllowUserToAddRows = false;
            dgvSkorlar.AllowUserToOrderColumns = false;
            dgvSkorlar.AllowUserToResizeColumns = false;
            dgvSkorlar.AllowUserToResizeRows = false;
            dgvSkorlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSkorlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSkorlar.MultiSelect = false;
            dgvSkorlar.RowHeadersVisible = false;

            foreach (DataGridViewColumn col in dgvSkorlar.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvSkorlar.BackgroundColor = Color.White;
            dgvSkorlar.BorderStyle = BorderStyle.None;
            dgvSkorlar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSkorlar.GridColor = Color.FromArgb(245, 222, 179);
            dgvSkorlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSkorlar.EnableHeadersVisualStyles = false;
            dgvSkorlar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSkorlar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 69, 19);
            dgvSkorlar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSkorlar.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Bold);
            dgvSkorlar.ColumnHeadersHeight = 45;
            dgvSkorlar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSkorlar.RowsDefaultCellStyle.BackColor = Color.MistyRose;
            dgvSkorlar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            dgvSkorlar.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvSkorlar.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            dgvSkorlar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSkorlar.RowTemplate.Height = 50;

            dgvSkorlar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);
            dgvSkorlar.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvSkorlar.DataBindingComplete += (s, e) => { dgvSkorlar.ClearSelection(); };
        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            // Yeniden boyutlandırmada buton ovalliğini koru
            ButonYumusat(btnGeri, 40);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Form6 raporEkrani = new Form6();
            raporEkrani.Show();
            this.Hide();
        }
    }
}
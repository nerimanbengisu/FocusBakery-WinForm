using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D; // --- OVAL KÖŞELER İÇİN ŞART ---

namespace Focus_Bakery
{
    public partial class Form5 : Form
    {
        // BU SATIR ÇOK ÖNEMLİ, SAKIN SİLME!
        public string gelenKonu = "Genel Çalışma";

        // Değişkenler
        int toplamSureSaniye = 0;
        int kalanSureSaniye = 0;
        string secilenUrun = "";

        public Form5()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            // --- SADECE ÜRÜN LİSTESİ ---
            cmbUrun.Items.Clear();
            cmbUrun.Items.Add("Ürün Seçiniz...");
            cmbUrun.Items.Add("Kurabiye (1 Dk)");
            cmbUrun.Items.Add("Kek (2 Dk)");
            cmbUrun.Items.Add("Kruvasan (3 Dk)");
            cmbUrun.Items.Add("Ekmek (4 Dk)");
            cmbUrun.Items.Add("Pasta (5 Dk)");

            cmbUrun.SelectedIndex = 0;
            cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;

            // --- DİĞER AYARLAR ---
            zamanlayici.Interval = 1000;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pbUrun.Image = Properties.Resources.img_hamur;
            lblSure.Text = "Süre: --";

            // --- BUTON MAKYAJI ---

            // 1. ANA ODAKLAN BUTONU (btnOdaklan) - Renklere dokunmadık, sadece ovallik
            btnOdaklan.FlatStyle = FlatStyle.Flat;
            btnOdaklan.FlatAppearance.BorderSize = 0;
            btnOdaklan.Cursor = Cursors.Hand;
            ButonYumusat(btnOdaklan, 40);

            // 2. GERİ BUTONU (btnGeri)
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.Cursor = Cursors.Hand;
            btnGeri.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 222, 179); // Buğday
            btnGeri.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 180, 140);
            ButonYumusat(btnGeri, 40);

            // 3. İLERİ/RAPORLAR BUTONU (btnIleri)
            btnIleri.FlatStyle = FlatStyle.Flat;
            btnIleri.FlatAppearance.BorderSize = 0;
            btnIleri.Cursor = Cursors.Hand;
            btnIleri.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 182, 193); // Pastel Pembe
            btnIleri.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 105, 180);
            ButonYumusat(btnIleri, 40);
        }

        private void btnOdaklan_Click(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedIndex == 0)
            {
                FrmMesaj.Goster("Lütfen pişirmek istediğiniz ürünü seçin! 🥯");
                return;
            }

            kalanSureSaniye = toplamSureSaniye;
            string tamAd = cmbUrun.SelectedItem.ToString();
            this.secilenUrun = tamAd.Split(' ')[0];
            pbUrun.Image = Properties.Resources.img_hamur;
            prgPismeDurumu.Minimum = 0;
            prgPismeDurumu.Maximum = toplamSureSaniye;
            prgPismeDurumu.Value = 0;
            SureyiYazdir();
            zamanlayici.Start();
        }

        private void zamanlayici_Tick(object sender, EventArgs e)
        {
            try
            {
                kalanSureSaniye--;
                int ilerleme = toplamSureSaniye - kalanSureSaniye;
                if (ilerleme >= 0 && ilerleme <= prgPismeDurumu.Maximum)
                {
                    prgPismeDurumu.Value = ilerleme;
                }
                SureyiYazdir();
                if (kalanSureSaniye <= 0)
                {
                    FirinBitti();
                }
            }
            catch (Exception hata)
            {
                zamanlayici.Stop();
                FrmMesaj.Goster("Sayaç hatası: " + hata.Message);
            }
        }

        private void SureyiYazdir()
        {
            int dk = kalanSureSaniye / 60;
            int sn = kalanSureSaniye % 60;
            lblSure.Text = $"{dk:D2}:{sn:D2}";
        }

        private void FirinBitti()
        {
            zamanlayici.Stop();
            lblSure.Text = "00:00";

            try
            {
                SoundPlayer oynatici = new SoundPlayer(Properties.Resources.soft_ding_uyari_3sn);
                oynatici.Play();
            }
            catch { }

            if (prgPismeDurumu.Maximum > 0)
                prgPismeDurumu.Value = prgPismeDurumu.Maximum;

            switch (secilenUrun)
            {
                case "Kruvasan": pbUrun.Image = Properties.Resources.img_pis_kruvasan; break;
                case "Kek": pbUrun.Image = Properties.Resources.img_pis_kek; break;
                case "Kurabiye": pbUrun.Image = Properties.Resources.img_pis_kurabiye; break;
                case "Ekmek": pbUrun.Image = Properties.Resources.img_pis_ekmek; break;
                case "Pasta": pbUrun.Image = Properties.Resources.img_pis_pasta; break;
                default: pbUrun.Image = Properties.Resources.img_pis_kek; break;
            }

            KaydiVeritabaninaIsle();
            FrmMesaj.Goster($"Ding! 🔔 {secilenUrun} hazır!\nOdaklanma puanın kaydedildi. 🥐");
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            zamanlayici.Stop();
            Form41 oncekiSayfa = new Form41();
            oncekiSayfa.Show();
            this.Hide();
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            zamanlayici.Stop();
            Form6 raporSayfasi = new Form6();
            raporSayfasi.Show();
            this.Hide();
        }

        private void KaydiVeritabaninaIsle()
        {
            if (string.IsNullOrEmpty(secilenUrun)) return;
            string baglantiAdresi = @"Data Source=LAPTOP-ORM28AEI\SQLEXPRESS;Initial Catalog=FocusBakeryDB;Integrated Security=True";
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "INSERT INTO OdakGecmisi (Tarih, UrunAdi, SureDk, CalisilanKonu, KullaniciAdi) VALUES (@tarih, @urun, @sure, @konu, @kullanici)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@urun", secilenUrun);
                    komut.Parameters.AddWithValue("@konu", gelenKonu);
                    string kaydedilecekIsim = string.IsNullOrEmpty(Form1.GirisYapanKullanici) ? "Misafir" : Form1.GirisYapanKullanici;
                    komut.Parameters.AddWithValue("@kullanici", kaydedilecekIsim);
                    int dakika = toplamSureSaniye / 60;
                    if (dakika < 1) dakika = 1;
                    komut.Parameters.AddWithValue("@sure", dakika);
                    komut.ExecuteNonQuery();
                }
                catch (Exception hata)
                {
                    FrmMesaj.Goster("Kayıt hatası: " + hata.Message);
                }
            }
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = cmbUrun.SelectedItem.ToString();
            if (secim.Contains("Kurabiye")) toplamSureSaniye = 1 * 60;
            else if (secim.Contains("Kek")) toplamSureSaniye = 2 * 60;
            else if (secim.Contains("Kruvasan")) toplamSureSaniye = 3 * 60;
            else if (secim.Contains("Ekmek")) toplamSureSaniye = 4 * 60;
            else if (secim.Contains("Pasta")) toplamSureSaniye = 5 * 60;
            else toplamSureSaniye = 0;

            if (toplamSureSaniye > 0)
            {
                int dk = toplamSureSaniye / 60;
                lblSure.Text = $"{dk:D2}:00";
            }
            else
            {
                lblSure.Text = "Süre: --";
            }
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            ButonYumusat(btnOdaklan, 40);
            ButonYumusat(btnGeri, 40);
            ButonYumusat(btnIleri, 40);
        }
    }
}
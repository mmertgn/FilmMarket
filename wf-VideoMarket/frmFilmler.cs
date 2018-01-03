using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_VideoMarket.Model;

namespace wf_VideoMarket
{
    public partial class frmFilmler : Form
    {
        public frmFilmler()
        {
            InitializeComponent();
        }
        private int SecilenFilmNo;
        int SecilenTurNo;
        private void frmFilmler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Film flm = new Film();
            flm.FilmleriGoster(lvFilmler);
            FilmTuru ft = new FilmTuru();
            ft.FilmTuruGosterFromFilmler(cbFilmTuru);
        }

        private void Temizle()
        {
            txtFilmAd.Clear();
            txtFiyat.Text = "";
            txtMiktar.Text = "1";
            txtOyuncular.Clear();
            txtOzet.Clear();
            txtYonetmen.Clear();
            txtFilmAd.Focus();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
            btnDegistir.Enabled = false;
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFilmAd.Text.Trim() != "" && txtYonetmen.Text.Trim() != "" && txtFiyat.Text.Trim() != "" && txtMiktar.Text.Trim() != "")
            {
                if (SecilenTurNo != 0)
                {
                    Film flm = new Film();
                    flm.FilmAd = txtFilmAd.Text;
                    flm.Yonetmen = txtYonetmen.Text;
                    if (flm.FilmKontrol(flm))
                    {
                        MessageBox.Show("Girdiğiniz Film önceden kayıt edilmiş!", "Zaten Var!");
                        txtFilmAd.Focus();
                    }
                    else
                    {
                        flm.FilmTurNo = SecilenTurNo;
                        try
                        {
                            flm.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                        }
                        catch (FormatException)
                        {
                            flm.Fiyat = 0;
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("Fiyat alanını kontrol ediniz!", "Dikkat! Hatalı Fiyat Girişi");
                            txtFiyat.Focus();
                            return;
                        }
                        try
                        {
                            flm.Miktar = Convert.ToInt32(txtMiktar.Text);
                        }
                        catch (FormatException)
                        {
                            flm.Miktar = 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Miktar alanını kontrol ediniz!", "Dikkat! Hatalı Miktar Girişi");
                            txtFiyat.Focus();
                            return;
                        }
                        flm.Oyuncular = txtOyuncular.Text;
                        flm.Ozet = txtOzet.Text;

                        if (flm.FilmEkle(flm))
                        {
                            MessageBox.Show("Film ekleme işlemi başarıyla gerçekleştirildi!", "Kayıt Tamamlandı");
                            Temizle();
                            btnKaydet.Enabled = false;
                            flm.FilmleriGoster(lvFilmler);
                        }
                    }
                }
            }
        }

        private void cbFilmTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ne ile değerleri olmayan yani propertyleri boş nesneler oluşurken, biz cbFilmturlerinden seçilen FilmTuru nesnesinin değerlerine sahip yeni bir nesne oluşturuyoruz.
            txtFilmTuru.Text = cbFilmTuru.Text;
            FilmTuru ft = (FilmTuru)cbFilmTuru.SelectedItem; //Combobox içinde objeler olduğundan, objeye de daha önce hem turad hemde turno atadığımızdan ikisine de bu şekilde erişebiliriz.
            //FilmTuru ft = cbFilmTuru.SelectedItem as FilmTuru; Buda diğer yazımı yukarıdaki ile aynı işi yapar
            txtFilmTuru.Text = ft.TurAd;
            SecilenTurNo = ft.FilmTurNo;
            //SecilenTurNo = ft.FilmTurNoGetirByFilmTuru(cbFilmTuru.Text);
            txtYonetmen.Focus();
        }

        private void txtFilmAra_TextChanged(object sender, EventArgs e)
        {
            Film flm = new Film();
            flm.FilmBul(lvFilmler, txtFilmAra.Text);
        }

        private void lvFilmler_DoubleClick(object sender, EventArgs e)
        {
            SecilenFilmNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[0].Text);
            txtFilmAd.Text = lvFilmler.SelectedItems[0].SubItems[1].Text;
            SecilenTurNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[2].Text);
            txtFilmTuru.Text = lvFilmler.SelectedItems[0].SubItems[3].Text;
            txtYonetmen.Text = lvFilmler.SelectedItems[0].SubItems[4].Text;
            txtOyuncular.Text = lvFilmler.SelectedItems[0].SubItems[5].Text;
            txtFiyat.Text = lvFilmler.SelectedItems[0].SubItems[6].Text;
            txtMiktar.Text = lvFilmler.SelectedItems[0].SubItems[7].Text;
            txtOzet.Text = lvFilmler.SelectedItems[0].SubItems[8].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmAd.Focus();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmAd.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "" && txtYonetmen.Text.Trim() != "")
            {
                Film flm = new Film();
                flm.FilmNo = SecilenFilmNo;
                flm.FilmAd = txtFilmAd.Text;
                flm.FilmTurNo = SecilenTurNo;
                flm.Yonetmen = txtYonetmen.Text;
                flm.Oyuncular = txtOyuncular.Text;
                flm.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                flm.Miktar = Convert.ToInt32(txtMiktar.Text);
                flm.Ozet = txtOzet.Text;
                if (flm.FilmKontrolByDegistir(flm))
                {
                    MessageBox.Show("Girdiğiniz Film önceden kayıt edilmiş!", "Zaten Var!");
                    txtFilmAd.Focus();
                }
                else
                {
                    if (flm.FilmGuncelle(flm))
                    {
                        MessageBox.Show("Film Güncelleme işlemi başarıyla gerçekleştirildi!", "Güncelleme Tamamlandı");
                        Temizle();
                        btnKaydet.Enabled = false;
                        flm.FilmleriGoster(lvFilmler);

                    }
                    else
                    {
                        MessageBox.Show("Film Güncelleme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanmadı!");
                        txtFilmAd.Focus();
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Film flm = new Film();
                flm.FilmNo = SecilenFilmNo;
                if (flm.FilmSil(flm))
                {
                    MessageBox.Show("Film silme işlemi başarıyla gerçekleştirildi!", "Silme Tamamlandı");
                    Temizle();
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    flm.FilmleriGoster(lvFilmler);

                }
                else
                {
                    MessageBox.Show("Film silme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanamadı!");
                }
            }
        }
    }
}

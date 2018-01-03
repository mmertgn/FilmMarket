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
    public partial class frmFilmTurleri : Form
    {
        public frmFilmTurleri()
        {
            InitializeComponent();
        }
        private int SecilenTurNo;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFilmTuru.Text.Trim() != "")
            {
                FilmTuru ft = new FilmTuru();
                if (ft.FilmTuruKontrol(txtFilmTuru.Text))
                {
                    MessageBox.Show("Girdiğiniz Film Türü önceden kayıt edilmiş!", "Zaten Var!");
                    txtFilmTuru.Focus();
                }
                else
                {
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruEkle(ft))
                    {
                        MessageBox.Show("Film Türü ekleme işlemi başarıyla gerçekleştirildi!", "Kayıt Tamamlandı");
                        Temizle();
                        btnKaydet.Enabled = false;
                        ft.FilmTurleriGoster(lvFilmTurleri);

                    }
                    else
                    {
                        MessageBox.Show("Film Türü ekleme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanmadı!");
                        txtFilmTuru.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Film Türü Girmelisiniz!", "Eksik Bilgi!");
                txtFilmTuru.Focus();
            }
        }

        private void frmFilmTurleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            FilmTuru ft = new FilmTuru();
            ft.FilmTurleriGoster(lvFilmTurleri);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
            btnDegistir.Enabled = false;
            Temizle();
        }

        private void Temizle()
        {
            txtFilmTuru.Clear();
            txtAciklama.Clear();
            txtFilmTuru.Focus();
        }

        private void lvFilmTurleri_DoubleClick(object sender, EventArgs e)
        {
            SecilenTurNo = Convert.ToInt32(lvFilmTurleri.SelectedItems[0].SubItems[0].Text);
            txtFilmTuru.Text = lvFilmTurleri.SelectedItems[0].SubItems[1].Text;
            txtAciklama.Text = lvFilmTurleri.SelectedItems[0].SubItems[2].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmTuru.Focus();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmTuru.Text.Trim() != "")
            {
                FilmTuru ft = new FilmTuru();
                if (ft.FilmTuruKontrolFromDegistir(txtFilmTuru.Text, SecilenTurNo))
                {
                    MessageBox.Show("Girdiğiniz Film Türü önceden kayıt edilmiş!", "Zaten Var!");
                    txtFilmTuru.Focus();
                }
                else
                {
                    ft.FilmTurNo = SecilenTurNo;
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruGuncelle(ft))
                    {
                        MessageBox.Show("Film Türü güncelleme işlemi başarıyla gerçekleştirildi!", "Güncelleme Tamamlandı");
                        Temizle();
                        btnDegistir.Enabled = false;
                        btnSil.Enabled = false;
                        ft.FilmTurleriGoster(lvFilmTurleri);

                    }
                    else
                    {
                        MessageBox.Show("Film Türü güncelleme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanmadı!");
                        txtFilmTuru.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Film Türü Boş Bırakılamaz!", "Eksik Bilgi!");
                txtFilmTuru.Focus();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FilmTuru ft = new FilmTuru();
                ft.FilmTurNo = SecilenTurNo;
                if (ft.FilmTuruSil(ft))
                {
                    MessageBox.Show("Film Türü silme işlemi başarıyla gerçekleştirildi!", "Silme Tamamlandı");
                    Temizle();
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    ft.FilmTurleriGoster(lvFilmTurleri);

                }
                else
                {
                    MessageBox.Show("Film Türü silme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanamadı!");
                }
            }
        }
    }
}

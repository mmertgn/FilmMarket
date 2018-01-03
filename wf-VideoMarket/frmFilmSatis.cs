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
    public partial class frmFilmSatis : Form
    {
        public frmFilmSatis()
        {
            InitializeComponent();
        }
        int orjAdet;
        private void frmFilmSatis_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            txtTarih.Text = DateTime.Now.ToShortDateString();
            FilmSatis fs = new FilmSatis();
            fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString();
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {
            frmMusteriSorgulama frm = new frmMusteriSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            txtMusteri.Text = Genel.secilenmusteri;

        }

        private void btnFilmBul_Click(object sender, EventArgs e)
        {
            frmFilmSorgulama frm = new frmFilmSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            txtFilm.Text = Genel.secilenFilm;
            txtStok.Text = Genel.secilenmiktar.ToString();
            txtFiyat.Text = string.Format("{0:#,##0}", Genel.secilenfiyat);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
            btnMusteriBul.Enabled = true;
            btnFilmBul.Enabled = true;
            btnMusteriBul_Click(sender, e);
            btnFilmBul_Click(sender, e);
        }
        private void Temizle()
        {
            txtAdet.Text = "1";
            txtFiyat.Text = "0";
            txtFilm.Clear();
            txtStok.Clear();
            Genel.secilenFilm = "";
            Genel.secilenfilmNo = 0;
            Genel.secilenmusteri = "";
            Genel.secilenmusterino = 0;
            Genel.secilenmiktar = 0;
            Genel.secilenfiyat = 0;
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            if (txtAdet.Text.Trim() == "")
            {
                txtAdet.Text = "1";
                txtAdet.SelectAll();
            }
            if (!string.IsNullOrEmpty(txtAdet.Text) && !string.IsNullOrEmpty(txtFiyat.Text))
            {
                txtTutar.Text = Convert.ToString(Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(txtFiyat.Text));
            }
            else
            {
                txtTutar.Text = txtFiyat.Text;
            }
        }

        private void txtAdet_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdet.SelectAll();
        }

        private void txtFiyat_MouseClick(object sender, MouseEventArgs e)
        {
            txtFiyat.SelectAll();
        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            if (txtFiyat.Text.Trim() == "")
            {
                txtFiyat.Text = "0";
                txtFiyat.SelectAll();
            }
            if (!string.IsNullOrEmpty(txtAdet.Text) && !string.IsNullOrEmpty(txtFiyat.Text))
            {
                txtTutar.Text = Convert.ToString(Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(txtFiyat.Text));
            }
            else
            {
                txtTutar.Text = txtFiyat.Text;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFilm.Text.Trim() != "" && txtMusteri.Text.Trim() != "")
            {
                if (Convert.ToInt32(txtAdet.Text) <= Convert.ToInt32(txtStok.Text))
                {
                    FilmSatis fs = new FilmSatis();
                    fs.Adet = Convert.ToInt32(txtAdet.Text);
                    fs.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                    fs.FilmNo = Genel.secilenfilmNo;
                    fs.MusteriNo = Genel.secilenmusterino;
                    fs.Tarih = Convert.ToDateTime(txtTarih.Text);
                    if (fs.SatisKaydet(fs))
                    {
                        Film flm = new Film();
                        flm.Miktar = Convert.ToInt32(txtStok.Text) - Convert.ToInt32(txtAdet.Text);
                        flm.FilmNo = Genel.secilenfilmNo;
                        if (flm.StokGuncelleFromFilmSatis(flm))
                        {
                            MessageBox.Show("Film Satış İşlemi Başarıyla Gerçekleştirildi!");
                            fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                            btnKaydet.Enabled = false;

                            btnMusteriBul.Enabled = false;
                            btnFilmBul.Enabled = false;
                            Temizle();

                        }
                        else { MessageBox.Show("Stok Güncellenemedi!"); }
                    }
                    else { MessageBox.Show("Satış Tamamlanamadı!"); }
                }
                else
                {
                    MessageBox.Show("Stoktan fazla satış gerçekleştirilemez!", "Dikkat! Yetersiz Stok!");
                    txtAdet.Text = txtStok.Text;
                }
            }
            else
            {
                MessageBox.Show("Müşteri ve Film mutlaka seçilmelidir!", "Dikkat! Eksik Bilgi!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            FilmSatis fs = new FilmSatis();
            fs.SatisNo = Genel.secilensatisno;
            if (fs.SatisSil(fs))
            {
                Film flm = new Film();
                flm.FilmNo = Genel.secilenfilmNo;
                flm.Miktar = Convert.ToInt32(txtStok.Text) + Convert.ToInt32(txtAdet.Text);
                if (flm.StokGuncelleFromFilmSatis(flm))
                {
                    MessageBox.Show("Film Silme İşlemi Başarıyla Gerçekleştirildi!");
                    fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                }
            }
            btnSil.Enabled = false;
            btnDegistir.Enabled = false;
            Temizle();
        }

        private void lvSatislar_DoubleClick(object sender, EventArgs e)
        {
            Genel.secilensatisno = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[0].Text);
            Genel.secilenmusterino = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[9].Text);
            Genel.secilenfilmNo = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[8].Text);
            txtMusteri.Text = lvSatislar.SelectedItems[0].SubItems[3].Text;
            txtFilm.Text = lvSatislar.SelectedItems[0].SubItems[2].Text;
            txtAdet.Text = lvSatislar.SelectedItems[0].SubItems[5].Text;
            txtFiyat.Text = lvSatislar.SelectedItems[0].SubItems[4].Text;
            txtTutar.Text = lvSatislar.SelectedItems[0].SubItems[6].Text;
            txtTarih.Text = lvSatislar.SelectedItems[0].SubItems[1].Text;
            txtStok.Text = lvSatislar.SelectedItems[0].SubItems[7].Text;
            btnKaydet.Enabled = false;
            btnSil.Enabled = true;
            btnDegistir.Enabled = true;
            orjAdet = Convert.ToInt32(txtAdet.Text);
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {

            int YeniAdet = Convert.ToInt32(txtAdet.Text) - orjAdet;
            if (YeniAdet <= Convert.ToInt32(txtStok.Text))
            {
                FilmSatis fs = new FilmSatis();
                fs.SatisNo = Genel.secilensatisno;
                fs.Adet = Convert.ToInt32(txtAdet.Text);
                fs.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                if (fs.FilmSatisAdetGuncelle(fs))
                {
                    MessageBox.Show("Film Satış Güncelleme İşlemi Başarıyla Gerçekleştirildi!");
                    if (Convert.ToInt32(txtAdet.Text) != orjAdet)
                    {
                        Film flm = new Film();
                        flm.FilmNo = Genel.secilenfilmNo;
                        flm.Miktar = Convert.ToInt32(txtStok.Text) - YeniAdet;
                        if (flm.StokGuncelleFromFilmSatis(flm))
                        {
                            MessageBox.Show("Film Güncelleme İşlemi Başarıyla Gerçekleştirildi!");
                            fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                            txtStok.Text = Convert.ToString(flm.Miktar);
                        }
                    }
                }
            }
        }
    }
}

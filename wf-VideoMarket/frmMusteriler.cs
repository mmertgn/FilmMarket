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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }
        private int SecilenMusteriNo;
        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Musteri ms = new Musteri();
            ms.MusterileriGoster(lvMusteriler);
        }
        private void Temizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtAdi.Focus();
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
            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "")
            {
                Musteri ms = new Musteri();
                ms.MusteriAd = txtAdi.Text;
                ms.MusteriSoyad = txtSoyadi.Text;
                if (ms.MusteriKontrol(ms))
                {
                    MessageBox.Show("Girdiğiniz Müşteri önceden kayıt edilmiş!", "Zaten Var!");
                    txtAdi.Focus();
                }
                else
                {
                    ms.MusteriAd = txtAdi.Text;
                    ms.MusteriSoyad = txtSoyadi.Text;
                    ms.Telefon = txtTelefon.Text;
                    ms.Adres = txtAdres.Text;
                    if (ms.MusteriEkle(ms))
                    {
                        MessageBox.Show("Müşteri ekleme işlemi başarıyla gerçekleştirildi!", "Kayıt Tamamlandı");
                        Temizle();
                        btnKaydet.Enabled = false;
                        ms.MusterileriGoster(lvMusteriler);

                    }
                    else
                    {
                        MessageBox.Show("Müşteri Ekleme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanmadı!");
                        txtAdi.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Müşteri Adı ve Soyadı Girmelisiniz!", "Eksik Bilgi!");
                txtAdi.Focus();
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "")
            {
                Musteri ms = new Musteri();
                ms.MusteriAd = txtAdi.Text;
                ms.MusteriSoyad = txtSoyadi.Text;
                if (ms.MusteriKontrolFromDegistir(ms))
                {
                    MessageBox.Show("Girdiğiniz Müşteri önceden kayıt edilmiş!", "Zaten Var!");
                    txtAdi.Focus();
                }
                else
                {
                    ms.MusteriNo = SecilenMusteriNo;
                    ms.MusteriAd = txtAdi.Text;
                    ms.MusteriSoyad = txtSoyadi.Text;
                    ms.Telefon = txtTelefon.Text;
                    ms.Adres = txtAdres.Text;
                    if (ms.MusteriGuncelle(ms))
                    {
                        MessageBox.Show("Müşteri Güncelleme işlemi başarıyla gerçekleştirildi!", "Güncelleme Tamamlandı");
                        Temizle();
                        btnKaydet.Enabled = false;
                        ms.MusterileriGoster(lvMusteriler);

                    }
                    else
                    {
                        MessageBox.Show("Müşteri Güncelleme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanmadı!");
                        txtAdi.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Müşteri Adı ve Soyadı Girmelisiniz!", "Eksik Bilgi!");
                txtAdi.Focus();
            }
        }

        private void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            SecilenMusteriNo = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
            txtAdi.Text = lvMusteriler.SelectedItems[0].SubItems[1].Text;
            txtSoyadi.Text = lvMusteriler.SelectedItems[0].SubItems[2].Text;
            txtTelefon.Text = lvMusteriler.SelectedItems[0].SubItems[3].Text;
            txtAdres.Text = lvMusteriler.SelectedItems[0].SubItems[4].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtAdi.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Musteri ms = new Musteri();
                ms.MusteriNo = SecilenMusteriNo;
                if (ms.MusteriSil(ms))
                {
                    MessageBox.Show("Müşteri silme işlemi başarıyla gerçekleştirildi!", "Silme Tamamlandı");
                    Temizle();
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    ms.MusterileriGoster(lvMusteriler);

                }
                else
                {
                    MessageBox.Show("Müşteri silme işlemi gerçekleştirilemedi!", "Dikkat İşlem Tamamlanamadı!");
                }
            }
        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Musteri ms = new Musteri();
            ms.MusteriBul(lvMusteriler, txtAdaGore.Text);
        }
    }
}

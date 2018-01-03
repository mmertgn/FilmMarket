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
    public partial class frmFilmSorgulama : Form
    {
        public frmFilmSorgulama()
        {
            InitializeComponent();
        }

        private void txtFilmAd_TextChanged(object sender, EventArgs e)
        {
            Film flm = new Film();
            flm.FilmBulBySorgulama(lvFilmler, txtFilmAd.Text, txtOyuncu.Text, txtYonetmen.Text, cbFilmTuru.Text);
        }

        private void frmFilmSorgulama_Load(object sender, EventArgs e)
        {
            txtFilmAd.Focus();
            this.Top = 0;
            this.Left = 0;
            Film flm = new Film();
            flm.FilmleriGoster(lvFilmler);
            FilmTuru ft = new FilmTuru();
            ft.FilmTuruGosterFromFilmler(cbFilmTuru);
            cbFilmTuru.Items.Insert(0, "Tüm Kategoriler");
        }

        private void lvFilmler_DoubleClick(object sender, EventArgs e)
        {
            Genel.secilenfilmNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[0].Text);
            Genel.secilenFilm = lvFilmler.SelectedItems[0].SubItems[1].Text;
            Genel.secilenmiktar = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[7].Text);
            Genel.secilenfiyat = Convert.ToDecimal(lvFilmler.SelectedItems[0].SubItems[6].Text);

            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_VideoMarket.Model;

namespace wf_VideoMarket
{
    public partial class frmRaporlama : Form
    {
        public frmRaporlama()
        {
            InitializeComponent();
        }

        private void frmRaporlama_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'VideoMarketDataSet.vw_DetayliSorgulama' table. You can move, or remove it, as needed.
            FilmTuru ft = new FilmTuru();
            ft.FilmTuruGosterFromFilmler(cbFilmTuru);
            cbFilmTuru.Items.Insert(0, "Tüm Kategoriler");
            cbFilmTuru.SelectedIndex = 0;
            this.vw_DetayliSorgulamaTableAdapter.Fill(this.VideoMarketDataSet.vw_DetayliSorgulama);

            this.reportViewer1.RefreshReport();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            if (cbFilmTuru.Text=="Tüm Kategoriler")
            {
                this.vw_DetayliSorgulamaTableAdapter.FillByRapor(this.VideoMarketDataSet.vw_DetayliSorgulama, txtMusteri.Text, txtFilm.Text, "", dtpTarih1.Value, dtpTarih2.Value);
            }
            else
            {
                this.vw_DetayliSorgulamaTableAdapter.FillByRapor(this.VideoMarketDataSet.vw_DetayliSorgulama, txtMusteri.Text, txtFilm.Text, cbFilmTuru.Text, dtpTarih1.Value, dtpTarih2.Value);
            }

            this.reportViewer1.RefreshReport();
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
        }
    }
}

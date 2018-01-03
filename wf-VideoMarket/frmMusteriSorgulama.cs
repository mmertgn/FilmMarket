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
    public partial class frmMusteriSorgulama : Form
    {
        public frmMusteriSorgulama()
        {
            InitializeComponent();
        }

        private void frmMusteriSorgulama_Load(object sender, EventArgs e)
        {
            txtAdaGore.Focus();
            this.Top = 0;
            this.Left = 0;
            Musteri ms = new Musteri();
            ms.MusterileriGoster(lvMusteriler);
        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Musteri ms = new Musteri();
            ms.MusteriBulFromSorgulama(lvMusteriler, txtAdaGore.Text,txtArananTelefon.Text,txtArananAdres.Text);
        }

        public void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            Genel.secilenmusterino = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
            Genel.secilenmusteri = lvMusteriler.SelectedItems[0].SubItems[1].Text + " " + lvMusteriler.SelectedItems[0].SubItems[2].Text;
           
            this.Close();
        }
    }
}

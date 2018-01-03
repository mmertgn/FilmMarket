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
    public partial class frmSatisSorgulama : Form
    {
        public frmSatisSorgulama()
        {
            InitializeComponent();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            FilmSatis fs = new FilmSatis();
            DataTable dt = fs.SatislariGosterByTarihlerArasi(dtpTarih1.Value, dtpTarih2.Value);
            dgvSatislar.DataSource = dt;
            dgvSatislar.Columns["Adet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSatislar.Columns["BirimFiyat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSatislar.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            decimal ToplamTutar = 0;
            int ToplamAdet = 0;
            foreach (DataRow dr in dt.Rows)
            {
                ToplamTutar += Convert.ToDecimal(dr["Tutar"]);
                ToplamAdet += Convert.ToInt32(dr["Adet"]);
            }
            txtToplamTutar.Text = string.Format("{0:c}", ToplamTutar);
            txtToplamAdet.Text = ToplamAdet.ToString();

        }
    }
}

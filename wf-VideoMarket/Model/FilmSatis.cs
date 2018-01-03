using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_VideoMarket.Model
{
    public class FilmSatis
    {
        #region Properties
        public int SatisNo { get; set; }
        public DateTime Tarih { get; set; }
        public int FilmNo { get; set; }
        public int MusteriNo { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }

        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);


        public DataTable SatislariGosterByTarihlerArasi(DateTime Tarih1,DateTime Tarih2)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select Convert(Date,Tarih,104) as Tarih, FilmAd,MusteriAd + ' ' + MusteriSoyad as Musteri, BirimFiyat,Adet,BirimFiyat*Adet as Tutar from FilmSatis fs inner join Filmler f on fs.FilmNo=f.FilmNo inner join Musteriler m on fs.MusteriNo = m.MusteriNo where fs.Silindi=0 and Tarih between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            //SqlDataAdapter da = new SqlDataAdapter("select * from vw_Sorgulama where Tarih between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value=Tarih1;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                string mesaj = ex.Message;
            }
            return dt;
        }
        public void SatislariGoster(ListView liste, TextBox TopAdet, TextBox TopTutar)
        {
            liste.Items.Clear();
            int TAdet = 0;
            decimal TTutar = 0;
            SqlCommand comm = new SqlCommand("SELECT Musteriler.MusteriAd + ' ' + Musteriler.MusteriSoyad as Musteri, Filmler.FilmAd, FilmSatis.SatisNo, FilmSatis.Tarih, FilmSatis.Adet, FilmSatis.FilmNo, FilmSatis.MusteriNo, FilmSatis.BirimFiyat, BirimFiyat*Adet as Tutar, Filmler.Miktar FROM Filmler INNER JOIN FilmSatis ON Filmler.FilmNo = FilmSatis.FilmNo INNER JOIN Musteriler ON FilmSatis.MusteriNo = Musteriler.MusteriNo where FilmSatis.Silindi=0 ORDER BY FilmSatis.SatisNo Desc", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr["SatisNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Tarih"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    liste.Items[sayac].SubItems.Add(string.Format("{0:#,##0}", Convert.ToDecimal(dr["BirimFiyat"].ToString()))); // Kuruşları istersek gösterirken {0:#,##0.00} şeklinde yazarız
                    liste.Items[sayac].SubItems.Add(dr["Adet"].ToString());
                    liste.Items[sayac].SubItems.Add(string.Format("{0:#,##0}", Convert.ToDecimal(dr["Tutar"].ToString())));
                    liste.Items[sayac].SubItems.Add(dr["Miktar"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["MusteriNo"].ToString());
                    sayac++;
                    TAdet += Convert.ToInt32(dr["Adet"]);
                    TTutar += Convert.ToDecimal(dr["Tutar"]);
                }
                TopAdet.Text = TAdet.ToString();
                //TopTutar.Text = string.Format("{0:#,##0}", TTutar);
                TopTutar.Text = string.Format("{0:#,##0}", TTutar) + " ₺";
                dr.Close();
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
        }

        public bool SatisKaydet(FilmSatis fs)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Insert into FilmSatis (Tarih,FilmNo,MusteriNo,Adet,BirimFiyat) values(@Tarih,@FilmNo,@MusteriNo,@Adet,@BirimFiyat)", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = fs.Tarih;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = fs.FilmNo;
            comm.Parameters.Add("@MusteriNo", SqlDbType.Int).Value = fs.MusteriNo;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = fs.Adet;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = fs.BirimFiyat;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return Sonuc;
        }

        public bool SatisSil(FilmSatis fs)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update FilmSatis set Silindi=1 Where SatisNo=@SatisNo", conn);
            comm.Parameters.Add("@SatisNo", SqlDbType.Int).Value = fs.SatisNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return Sonuc;
        }

        public bool FilmSatisAdetGuncelle(FilmSatis fs)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update FilmSatis set Adet=@Adet,BirimFiyat=@BirimFiyat Where SatisNo=@SatisNo", conn);
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = fs.Adet;
            comm.Parameters.Add("@SatisNo", SqlDbType.Int).Value = fs.SatisNo;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = fs.BirimFiyat;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return Sonuc;
        }
    }
}

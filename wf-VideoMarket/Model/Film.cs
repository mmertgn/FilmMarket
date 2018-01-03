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
    public class Film
    {
        private int _filmNo;
        private string _filmAd;
        private int _filmTurNo;
        private string _yonetmen;
        private string _oyuncular;
        private string _ozet;
        private decimal _fiyat;
        private int _miktar;


        #region Properties
        public int FilmNo
        {
            get
            {
                return _filmNo;
            }

            set
            {
                _filmNo = value;
            }
        }

        public string FilmAd
        {
            get
            {
                return _filmAd;
            }

            set
            {
                _filmAd = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        public int FilmTurNo
        {
            get
            {
                return _filmTurNo;
            }

            set
            {
                _filmTurNo = value;
            }
        }
        public string Yonetmen
        {
            get
            {
                return _yonetmen;
            }

            set
            {
                _yonetmen = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        public string Oyuncular
        {
            get
            {
                return _oyuncular;
            }

            set
            {
                _oyuncular = value;
            }
        }
        public string Ozet
        {
            get
            {
                return _ozet;
            }

            set
            {
                _ozet = value;
            }
        }
        public decimal Fiyat
        {
            get
            {
                return _fiyat;
            }

            set
            {
                _fiyat = value;
            }
        }
        public int Miktar
        {
            get
            {
                return _miktar;
            }

            set
            {
                _miktar = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public void FilmleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("SELECT Filmler.*,FilmTurleri.TurAd FROM Filmler INNER JOIN FilmTurleri ON Filmler.FilmTurNo = FilmTurleri.FilmTurNo where Filmler.Silindi=0 and Filmler.Varmi=1", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr["FilmNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmTurNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["TurAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Yonetmen"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Oyuncular"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Fiyat"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Miktar"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Ozet"].ToString());
                    sayac++;
                }
                dr.Close();
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
        }

        public void FilmBul(ListView liste, string ArananFilmAdi)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("SELECT Filmler.*,FilmTurleri.TurAd FROM Filmler INNER JOIN FilmTurleri ON Filmler.FilmTurNo = FilmTurleri.FilmTurNo where Filmler.FilmAd like @ArananFilmAdi and Filmler.Varmi=1", conn);
            comm.Parameters.Add("@ArananFilmAdi", SqlDbType.VarChar).Value = ArananFilmAdi + "%";

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr["FilmNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmTurNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["TurAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Yonetmen"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Oyuncular"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Fiyat"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Miktar"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Ozet"].ToString());
                    sayac++;
                }
                dr.Close();
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
        }

        public bool StokGuncelleFromFilmSatis(Film flm)
        {
            bool Sonuc = false;

            SqlCommand comm = new SqlCommand("Update Filmler Set Miktar=@Miktar Where FilmNo=@FilmNo", conn);
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = flm.Miktar;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = flm.FilmNo;

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
        
        public bool SatisIptalFromFilmSatis(Film flm)
        {
            bool Sonuc = false;

            SqlCommand comm = new SqlCommand("Update Filmler Set Miktar=@Miktar Where FilmNo=@FilmNo", conn);
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = flm.Miktar;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = flm.FilmNo;

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

        public void FilmBulBySorgulama(ListView liste,string FilmAdi, string FilmOyuncu, string FilmYonetmen, string FilmTuru)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("SELECT Filmler.*,FilmTurleri.TurAd FROM Filmler INNER JOIN FilmTurleri ON Filmler.FilmTurNo = FilmTurleri.FilmTurNo where (Filmler.FilmAd like @FilmAd + '%') and (FilmTurleri.TurAd like @TurAd +'%') and (Filmler.Yonetmen like '%' + @Yonetmen + '%') and (Filmler.Oyuncular like '%' + @Oyuncular + '%') and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = FilmAdi;
            if (FilmTuru == "Tüm Kategoriler")
            {
                FilmTuru = "";
            }
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTuru;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = FilmYonetmen;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = FilmOyuncu;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr["FilmNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["FilmTurNo"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["TurAd"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Yonetmen"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Oyuncular"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Fiyat"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Miktar"].ToString());
                    liste.Items[sayac].SubItems.Add(dr["Ozet"].ToString());
                    sayac++;
                }
                dr.Close();
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
        }
        public bool FilmKontrol(Film flm) //while a girerse kayıt var demektir.
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select count(*) from Filmler where FilmAd=@FilmAd and Yonetmen=@Yonetmen and Silindi=0 and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = flm.FilmAd;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = flm.Yonetmen;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteScalar());
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
        public bool FilmKontrolByDegistir(Film flm) //while a girerse kayıt var demektir.
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where FilmAd=@FilmAd and FilmNo!=@FilmNo and Silindi=0 and Varmi=1", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = flm.FilmAd;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = flm.FilmNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    Sonuc = true;
                }
                dr.Close();
                conn.Close();
                return Sonuc;
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            return Sonuc;
        }
        public bool FilmEkle(Film flm)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Insert into Filmler (FilmAd,FilmTurNo,Yonetmen,Ozet,Fiyat,Miktar,Oyuncular) values(@FilmAd,@FilmTurNo,@Yonetmen,@Ozet,@Fiyat,@Miktar,@Oyuncular)", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = flm.FilmAd;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = flm.FilmTurNo;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = flm.Yonetmen;
            comm.Parameters.Add("@Ozet", SqlDbType.VarChar).Value = flm.Ozet;
            comm.Parameters.Add("@Fiyat", SqlDbType.Money).Value = flm.Fiyat;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = flm.Miktar;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = flm.Oyuncular;

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
        public bool FilmGuncelle(Film flm)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Filmler Set FilmAd=@FilmAd,FilmTurNo=@FilmTurNo,Yonetmen=@Yonetmen,Ozet=@Ozet,Fiyat=@Fiyat,Miktar=@Miktar,Oyuncular=@Oyuncular Where FilmNo=@FilmNo", conn);
            comm.Parameters.Add("@FilmAd", SqlDbType.VarChar).Value = flm.FilmAd;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = flm.FilmTurNo;
            comm.Parameters.Add("@Yonetmen", SqlDbType.VarChar).Value = flm.Yonetmen;
            comm.Parameters.Add("@Ozet", SqlDbType.VarChar).Value = flm.Ozet;
            comm.Parameters.Add("@Fiyat", SqlDbType.Money).Value = flm.Fiyat;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = flm.Miktar;
            comm.Parameters.Add("@Oyuncular", SqlDbType.VarChar).Value = flm.Oyuncular;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = flm.FilmNo;

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

        public bool FilmSil(Film flm)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Filmler set Silindi=1,Varmi=0 Where FilmNo=@FilmNo", conn);
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = flm.FilmNo;

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

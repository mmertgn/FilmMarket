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
    public class FilmTuru
    {
        private int _filmTurNo;
        private string _turAd;
        private string _aciklama;

        #region Properties
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

        public string TurAd
        {
            get
            {
                return _turAd;
            }

            set
            {
                _turAd = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }


        public string Aciklama
        {
            get
            {
                return _aciklama;
            }

            set
            {
                _aciklama = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public void FilmTurleriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where Silindi=0", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {
                liste.Items.Add(dr[0].ToString());
                liste.Items[sayac].SubItems.Add(dr[1].ToString());
                liste.Items[sayac].SubItems.Add(dr[2].ToString());
                sayac++;
            }
            dr.Close();
            conn.Close();
        }

        public int FilmTurNoGetirByFilmTuru(string TurAdi)
        {
            int TurNo = 0;
            SqlCommand comm = new SqlCommand("Select FilmTurNo from FilmTurleri where TurAd=@TurAd and Silindi=0",conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = TurAdi;
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                TurNo = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException e)
            {
                String mesaj = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return TurNo;
        }

        //public void FilmTuruGosterFromFilmler(ComboBox cbFilmTuru)
        //{
        //    cbFilmTuru.Items.Clear();
        //    SqlCommand comm = new SqlCommand("Select TurAd from FilmTurleri where Silindi=0", conn);

        //    if (conn.State == ConnectionState.Closed) conn.Open();
        //    SqlDataReader dr = comm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        cbFilmTuru.Items.Add(dr[0].ToString());
        //    }
        //    dr.Close();
        //    conn.Close();
        //}
        public void FilmTuruGosterFromFilmler(ComboBox cbFilmTuru)
        {
            cbFilmTuru.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where Silindi=0", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                FilmTuru ft = new FilmTuru();
                ft._turAd = dr["TurAd"].ToString();
                ft._filmTurNo = Convert.ToInt32(dr["FilmTurNo"]);
                cbFilmTuru.Items.Add(ft); //Combobox item olarka obje aldığından, filmtürü ve filmturno bilgileri girilen FilmTuru nesnelerini ekliyoruz.
            }
            dr.Close();
            conn.Close();
        }
        //public bool FilmTuruKontrol(string FilmTurAd)
        //{
        //    bool Sonuc = false;
        //    SqlCommand comm = new SqlCommand("Select count(TurAd) from FilmTurleri where TurAd=@TurAd", conn);
        //    comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTurAd;

        //    if (conn.State == ConnectionState.Closed) conn.Open();

        //    if (Convert.ToBoolean(comm.ExecuteScalar()))
        //    {
        //        Sonuc = true;
        //    }
        //    conn.Close();
        //    return Sonuc;
        //}

        public bool FilmTuruKontrol(string FilmTurAd) //while a girerse kayıt var demektir.
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where TurAd=@TurAd and Silindi=0", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTurAd;

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows) //if'in içine dr nesnesi içinde veri varsa girer.
            {
                Sonuc = true;
                //while (dr.Read())
                //{
                //    Sonuc = true; /önceden bu tür kayıt edilmiş
                //}
            }
            dr.Close();
            conn.Close();
            return Sonuc;
        }
        public bool FilmTuruKontrolFromDegistir(string FilmTurAd, int SecilenTurNo) //while a girerse kayıt var demektir.
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from FilmTurleri where TurAd=@TurAd and FilmTurNo!=@FilmTurNo and Silindi=0", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = FilmTurAd;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = SecilenTurNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows) //if'in içine dr nesnesi içinde veri varsa girer.
            {
                Sonuc = true;
            }
            dr.Close();
            conn.Close();
            return Sonuc;
        }

        public bool FilmTuruEkle(FilmTuru ft)
        {
            SqlCommand comm = new SqlCommand("Insert into FilmTurleri (TurAd,Aciklama) values(@TurAd,@Aciklama)", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = ft.TurAd;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = ft.Aciklama;

            if (conn.State == ConnectionState.Closed) conn.Open();

            bool Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            conn.Close();
            return Sonuc;
        }

        public bool FilmTuruGuncelle(FilmTuru ft)
        {
            SqlCommand comm = new SqlCommand("Update FilmTurleri Set TurAd=@TurAd,Aciklama=@Aciklama Where FilmTurNo=@FilmTurNo", conn);
            comm.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = ft.TurAd;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = ft.Aciklama;
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = ft.FilmTurNo;

            if (conn.State == ConnectionState.Closed) conn.Open();

            bool Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            conn.Close();
            return Sonuc;
        }
        //public bool FilmTuruSil(FilmTuru ft)
        //{
        //    bool Sonuc = false;
        //    SqlCommand comm = new SqlCommand("Delete from FilmTurleri Where FilmTurNo=@FilmTurNo", conn);
        //    comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = ft.FilmTurNo;

        //    if (conn.State == ConnectionState.Closed) conn.Open();
        //    try
        //    {
        //        Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
        //        //return Sonuc; Yine de finally çalışır.
        //    }
        //    catch (SqlException ex)
        //    {
        //        string hata = ex.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return Sonuc;
        //}
        public bool FilmTuruSil(FilmTuru ft)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update FilmTurleri set Silindi=1 Where FilmTurNo=@FilmTurNo", conn);
            comm.Parameters.Add("@FilmTurNo", SqlDbType.Int).Value = ft.FilmTurNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                //return Sonuc; Yine de finally çalışır.
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
        public override string ToString()
        {
            return TurAd; //FilmTuru türünden nesneler ToString() uygulandığında string olarak TurAd değerini döndürecek.
        }
    }
}

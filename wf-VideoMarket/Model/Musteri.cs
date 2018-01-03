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
    public class Musteri
    {
        private int _musteriNo;
        private string _musteriAd;
        private string _musteriSoyad;
        private string _telefon;
        private string _adres;

        #region Properties
        public int MusteriNo
        {
            get
            {
                return _musteriNo;
            }

            set
            {
                _musteriNo = value;
            }
        }

        public string MusteriAd
        {
            get
            {
                return _musteriAd;
            }

            set
            {
                _musteriAd = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }



        public string MusteriSoyad
        {
            get
            {
                return _musteriSoyad;
            }
       
            set
            {
                _musteriSoyad = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Telefon
        {
            get
            {
                return _telefon;
            }

            set
            {
                _telefon = value;
            }
        }

        public string Adres
        {
            get
            {
                return _adres;
            }

            set
            {
                _adres = value;
            }
        }


        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public void MusterileriGoster(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Musteriler where Silindi=0", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {
                liste.Items.Add(dr[0].ToString());
                liste.Items[sayac].SubItems.Add(dr[1].ToString());
                liste.Items[sayac].SubItems.Add(dr[2].ToString());
                liste.Items[sayac].SubItems.Add(dr[3].ToString());
                liste.Items[sayac].SubItems.Add(dr[4].ToString());
                sayac++;
            }
            dr.Close();
            conn.Close();
        }
        public bool MusteriKontrol(Musteri ms)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from Musteriler where MusteriAd=@MusteriAd and MusteriSoyad=@MusteriSoyad and Silindi=0", conn);
            comm.Parameters.Add("@MusteriAd", SqlDbType.VarChar).Value = ms.MusteriAd;
            comm.Parameters.Add("@MusteriSoyad", SqlDbType.VarChar).Value = ms.MusteriSoyad;

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                Sonuc = true;
            }
            dr.Close();
            conn.Close();
            return Sonuc;
        }
        public bool MusteriKontrolFromDegistir(Musteri ms)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Select * from Musteriler where MusteriAd=@MusteriAd and MusteriSoyad=@MusteriSoyad and MusteriNo!=@MusteriNo and Silindi=0", conn);
            comm.Parameters.Add("@MusteriAd", SqlDbType.VarChar).Value = ms.MusteriAd;
            comm.Parameters.Add("@MusteriSoyad", SqlDbType.VarChar).Value = ms.MusteriSoyad;
            comm.Parameters.Add("@MusteriNo", SqlDbType.VarChar).Value = ms.MusteriNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                Sonuc = true;
            }
            dr.Close();
            conn.Close();
            return Sonuc;
        }
        public bool MusteriEkle(Musteri musteri)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Insert into Musteriler (MusteriAd,MusteriSoyad,Telefon,Adres) values(@MusteriAd,@MusteriSoyad,@Telefon,@Adres)", conn);
            comm.Parameters.Add("@MusteriAd", SqlDbType.VarChar).Value = musteri.MusteriAd;
            comm.Parameters.Add("@MusteriSoyad", SqlDbType.VarChar).Value = musteri.MusteriSoyad;
            comm.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = musteri.Telefon;
            comm.Parameters.Add("@Adres", SqlDbType.VarChar).Value = musteri.Adres;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }

            conn.Close();
            return Sonuc;
        }

        public bool MusteriGuncelle(Musteri musteri)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Musteriler Set MusteriAd=@MusteriAd,MusteriSoyad=@MusteriSoyad,Telefon=@Telefon,Adres=@Adres Where MusteriNo=@MusteriNo", conn);
            comm.Parameters.Add("@MusteriAd", SqlDbType.VarChar).Value = musteri.MusteriAd;
            comm.Parameters.Add("@MusteriSoyad", SqlDbType.VarChar).Value = musteri.MusteriSoyad;
            comm.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = musteri.Telefon;
            comm.Parameters.Add("@Adres", SqlDbType.VarChar).Value = musteri.Adres;
            comm.Parameters.Add("@MusteriNo", SqlDbType.VarChar).Value = musteri.MusteriNo;

            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
            return Sonuc;
        }
        public bool MusteriSil(Musteri musteri)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Musteriler Set Silindi=1 Where MusteriNo=@MusteriNo", conn);
            comm.Parameters.Add("@MusteriNo", SqlDbType.Int).Value = musteri.MusteriNo;

            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException e)
            {
                string mesaj = e.Message;
            }
            conn.Close();
            return Sonuc;
        }

        public void MusteriBul(ListView liste, string ArananMusteriAdi)
        {
            liste.Items.Clear();
            //SqlCommand comm = new SqlCommand("Select * from Musteriler where MusteriAd+' '+MusteriSoyad like concat(@ArananMusteriAdi,'%') and Silindi=0", conn);
            SqlCommand comm = new SqlCommand("Select * from Musteriler where MusteriAd+' '+MusteriSoyad like @ArananMusteriAdi and Silindi=0", conn);
            comm.Parameters.Add("@ArananMusteriAdi", SqlDbType.VarChar).Value = ArananMusteriAdi + "%";

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[sayac].SubItems.Add(dr[1].ToString());
                    liste.Items[sayac].SubItems.Add(dr[2].ToString());
                    liste.Items[sayac].SubItems.Add(dr[3].ToString());
                    liste.Items[sayac].SubItems.Add(dr[4].ToString());
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

        public void MusteriBulFromSorgulama(ListView liste, string ArananMusteriAdi, string ArananMusteriTelefon, string ArananMusteriAdres)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Musteriler where (MusteriAd+' '+MusteriSoyad+' '+Telefon+' '+Adres like @ArananMusteriBilgi) and Silindi=0", conn);
            comm.Parameters.Add("@ArananMusteriBilgi", SqlDbType.VarChar).Value = "%" + ArananMusteriAdi + "%" + ArananMusteriTelefon + "%" + ArananMusteriAdres + "%";


            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {
                liste.Items.Add(dr[0].ToString());
                liste.Items[sayac].SubItems.Add(dr[1].ToString());
                liste.Items[sayac].SubItems.Add(dr[2].ToString());
                liste.Items[sayac].SubItems.Add(dr[3].ToString());
                liste.Items[sayac].SubItems.Add(dr[4].ToString());
                sayac++;
            }
            dr.Close();
            conn.Close();

        }
        //public bool MusteriSil(Musteri musteri)
        //{
        //    SqlCommand comm = new SqlCommand("Delete Musteriler Where MusteriNo=@MusteriNo", conn);
        //    comm.Parameters.Add("@MusteriNo", SqlDbType.Int).Value = musteri.MusteriNo;

        //    if (conn.State == ConnectionState.Closed) conn.Open();

        //    bool Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
        //    conn.Close();
        //    return Sonuc;
        //}
    }
}

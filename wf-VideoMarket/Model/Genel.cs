using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_VideoMarket.Model
{
    public class Genel
    {
        public static string connStr = "Data Source=WISSEN-PC\\MSSQL2016; Initial Catalog=VideoMarket; uid=sa; pwd=123416"; //static tanımlaması sayesinde bu member çağrılırken direk çağrılabilir.Nesne oluşturmaya gerek kalmaz.

        //public static string connStr = "Data Source=DESKTOP-6OBI17H\\MSSQL2016; Initial Catalog=VideoMarket; uid=sa; pwd=123416";  
        public static int secilensatisno;
        public static int secilenfilmNo;
        public static string secilenFilm;
        public static int secilenmiktar;
        public static decimal secilenfiyat;
        public static int secilenmusterino;
        public static string secilenmusteri;
        
    }
}

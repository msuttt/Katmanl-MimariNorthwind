using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
   public class Komut
    {
        Baglanti baglanti = new Baglanti();
        public SqlCommand SqlCalistir(string sqlcumlesi)
        {
            SqlCommand command = new SqlCommand(sqlcumlesi,baglanti.BaglantiAc());           
            return command;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
   
    public class Baglanti
    {
        SqlConnection con = new SqlConnection(@"Data Source=MESUT-EXPER\SQLMESUT;Initial Catalog=Northwind;Integrated Security=True");

        public SqlConnection BaglantiAc()
        {
            con.Open();
            return con;
        }
        public SqlConnection BaglantiKapat()
        {
            con.Close();
            return con;
        }


    }
}
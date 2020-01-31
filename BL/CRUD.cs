using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Data.SqlClient;
using BL.DTO;


namespace BL
{
    public class CRUD : ICrud
    {
        Baglanti baglanti = new Baglanti();
        Komut komut = new Komut();
        public void Ekle(string name,string desc)
        {
            string sqlcumlesi = "insert into Categories(CategoryName, Description) values('" + name + "', '" + desc + "')";
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            cmd.ExecuteNonQuery();
            baglanti.BaglantiKapat();
        }

        public void Güncelle(string id,string name,string desc)
        {
            string sqlcumlesi = "update Categories set CategoryName='"+name+ "',Description='"+desc+"' where CategoryID='" + id+ "'";
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            cmd.ExecuteNonQuery();
            baglanti.BaglantiKapat();
        }

        public void Sil(string id)
        {
            string sqlcumlesi= "delete from Categories where CategoryID = '"+id+"'";
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            cmd.ExecuteNonQuery();
            baglanti.BaglantiKapat();
        }

        public List<CategoriesDTO> KategoriListesi(string sqlcumlesi)
        {
                
               SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
               SqlDataReader dr = cmd.ExecuteReader();

               List<CategoriesDTO> cat = new List<CategoriesDTO>();

            while (dr.Read())
            {
                cat.Add(new CategoriesDTO
                {
                    CategoryID = Convert.ToInt32(dr["CategoryID"]),
                    CategoryName = dr["CategoryName"].ToString(),
                    Description = dr["Description"].ToString(),
                });
            }
            dr.Close();
            return cat;
        }
       

        public List<CustomerDTO> MusteriListesi(string sqlcumlesi)
        {
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            SqlDataReader dr = cmd.ExecuteReader();

            List<CustomerDTO> cus = new List<CustomerDTO>();

            while (dr.Read())
            {
                cus.Add(new CustomerDTO
                {
                    CompanyName = dr["CompanyName"].ToString(),
                    ContactName = dr["ContactName"].ToString(),
                    ContactTitle = dr["ContactTitle"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),
                    Region = dr["Region"].ToString(),
                    PostalCode = dr["PostalCode"].ToString(),
                    Country = dr["Country"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Fax = dr["Fax"].ToString(),
                });
            }
            baglanti.BaglantiKapat();
            return cus;
        }

        public List<EmployeeDTO> CalisanListesi(string sqlcumlesi)
        {
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            SqlDataReader dr = cmd.ExecuteReader();

            List<EmployeeDTO> emp = new List<EmployeeDTO>();

            while (dr.Read())
            {
                emp.Add(new EmployeeDTO
                {
                    LastName = dr["LastName"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    BirthDate = Convert.ToDateTime(dr["BirthDate"].ToString()),
                    HireDate = Convert.ToDateTime(dr["HireDate"].ToString()),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),              
                    Country = dr["Country"].ToString(),
                    HomePhone = dr["HomePhone"].ToString(),
                   
                });
            }
            baglanti.BaglantiKapat();
            return emp;
        }

        public List<OrderDTO> SiparisListesi(string sqlcumlesi)
        {
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            SqlDataReader dr = cmd.ExecuteReader();

            List<OrderDTO> ord = new List<OrderDTO>();

            while (dr.Read())
            {
                ord.Add(new OrderDTO
                {
                    CustomerID = dr["CustomerID"].ToString(),
                    EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString()),
                    OrderDate = Convert.ToDateTime(dr["OrderDate"].ToString()),
                    RequiredDate = Convert.ToDateTime(dr["RequiredDate"].ToString()),
                    ShippedDate = Convert.ToDateTime(dr["ShippedDate"].ToString()),
                    Freight =Convert.ToDecimal(dr["Freight"].ToString()),
                });
            }
            baglanti.BaglantiKapat();
            return ord;
        }

        public List<ProductDTO> UrunListesi(string sqlcumlesi)
        {
            SqlCommand cmd = komut.SqlCalistir(sqlcumlesi);
            SqlDataReader dr = cmd.ExecuteReader();

            List<ProductDTO> pro = new List<ProductDTO>();

            while (dr.Read())
            {
                pro.Add(new ProductDTO
                {
                    ProductName = dr["ProductName"].ToString(),
                    CategoryID = Convert.ToInt32(dr["CategoryID"].ToString()),
                    QuantityPerUnit = dr["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(dr["UnitPrice"].ToString()),
                    UnitsOnOrder = Convert.ToInt16(dr["UnitsOnOrder"].ToString()),                 
                });
            }
            baglanti.BaglantiKapat();
            return pro;
        }
 

        //public List<ProductDTO> VeriCek(string id)
        //{
        //    string sqlcumlesi = "Select * from Products Where CategoryID='" + id + "'";
        //    List<ProductDTO> veriler = new List<ProductDTO>();

        //    SqlCommand com = komut.SqlCalistir(sqlcumlesi);
        //    SqlDataReader dr=com.ExecuteReader();
             
            
        //    while (dr.Read())
        //    {
        //        veriler.Add(new ProductDTO
        //        {
        //            ProductName = dr["ProductName"].ToString()
                    
        //        });                
                 
        //    }
        //    dr.Close();

        //    return veriler;
        //}
    }
}

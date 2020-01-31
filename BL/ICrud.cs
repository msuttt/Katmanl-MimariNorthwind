using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTO;

namespace BL
{
    public interface ICrud
    {    
        void Ekle(string sqlcumlesi, string text);
        void Sil(string id);
        void Güncelle(string sqlcumlesi, string text, string text1);

        //List<ProductDTO> VeriCek(string id);
        List<CategoriesDTO> KategoriListesi(string sqlcumlesi);
        List<CustomerDTO> MusteriListesi(string sqlcumlesi);
        List<EmployeeDTO> CalisanListesi(string sqlcumlesi);      
        List<OrderDTO> SiparisListesi(string sqlcumlesi);
        List<ProductDTO> UrunListesi(string sqlcumlesi);

    }
}

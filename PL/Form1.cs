using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BL.DTO;

namespace PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        public void Listele()
        {
            ICrud crud = new CRUD();
            var sonuc = crud.KategoriListesi("Select * from Categories");
            dtKategoriler.DataSource = sonuc;
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
           
            Listele();
        }

        private void BtnCatEkle_Click(object sender, EventArgs e)
        {
            try
            {
                ICrud crud = new CRUD();
                crud.Ekle(txtName.Text,richtxtDesc.Text);
                MessageBox.Show("Kategori eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void BtnCatGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (CategoriesDTO)dtKategoriler.SelectedRows[0].DataBoundItem;

                ICrud crud = new CRUD();

                crud.Güncelle((item.CategoryID).ToString(), txtName2.Text, richtxtDesc2.Text);
                MessageBox.Show("Kategori güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try { 
            var item = (CategoriesDTO)dtKategoriler.SelectedRows[0].DataBoundItem;
            ICrud crud = new CRUD();

            DialogResult result = new DialogResult();

            result =MessageBox.Show("Silmek istediğinize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                crud.Sil((item.CategoryID).ToString());
                MessageBox.Show("Veri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtKategoriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dtKategoriler.SelectedRows.Count != 0)
            {
                var item = (CategoriesDTO)dtKategoriler.SelectedRows[0].DataBoundItem;
                txtName2.Text = item.CategoryName;
                richtxtDesc2.Text = item.Description;
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            ICrud crud = new CRUD();
            CategoriesDTO cat = new CategoriesDTO();

            var item=crud.KategoriListesi("Select * from Categories where CategoryName='" + txtAra.Text+"'");

            if (item.Capacity==0)
            {
                MessageBox.Show("Veritabanında böyle bir kayıt yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                lblId.Text=item[0].CategoryID.ToString();
                lblName.Text=item[0].CategoryName.ToString();
                lblDesc.Text=item[0].Description.ToString();
            }
           
        }

        private void LblDesc_Click(object sender, EventArgs e)
        {

        }

        
      
    }
}

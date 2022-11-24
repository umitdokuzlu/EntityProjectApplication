using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjectApplication
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun select new {x.Urunid,x.UrunAd,x.Marka,x.Stok,x.Fiyat,x.Tbl_Kategori.Ad ,x.Durum }).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.UrunAd = TxtUrunAd.Text;
            t.Marka = TxtMarka.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(TxtFiyat.Text);
            t.Durum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var urun = db.Tbl_Urun.Find(x);
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var urun = db.Tbl_Urun.Find(x);
            urun.UrunAd = TxtUrunAd.Text;
            urun.Stok = short.Parse(TxtStok.Text);
            urun.Marka = TxtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori select new { x.id, x.Ad }).ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Ad";
            comboBox1.DataSource = kategoriler;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adisyon.formlar
{
    public partial class frmUrunEkle : Form
    {
        Modeller.RestoranEntities db=new Modeller.RestoranEntities();
        frmUrunler globalUrunlerFormu;
        public frmUrunEkle(frmUrunler fUrunlerFormu)
        {
            InitializeComponent();
            globalUrunlerFormu= fUrunlerFormu;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;//iptal butonu
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            Modeller.Urunler urun = new Modeller.Urunler
            {
                adi = textBox1.Text,
                Grupid = (int)comboBox1.SelectedValue,
                fiyat = numericUpDown1.Value
            };
            db.Entry(urun).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            this.DialogResult = DialogResult.OK;
        }

        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
           comboBox1.DataSource = db.urunGruplari.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modeller.Urunler urun = new Modeller.Urunler
            {
                adi = textBox1.Text,
                Grupid = (int)comboBox1.SelectedValue,
                fiyat = numericUpDown1.Value
            };
            db.Entry(urun).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            MessageBox.Show("ürün eklendi");
            globalUrunlerFormu.urunlerigetir();

            numericUpDown1.Value = 0;
            textBox1.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using adisyon.Modeller;

namespace adisyon.formlar
{
    public partial class frmUrunGruplari : Form
    {
        RestoranEntities db=new RestoranEntities();
        
        public frmUrunGruplari()
        {
            InitializeComponent();
        }

        private void frmUrunGruplari_Load(object sender, EventArgs e)
        {
            urungruplarinigetir();
        }
        private void urungruplarinigetir()
        {
            dataGridView1.DataSource = db.urunGruplari.ToList();
           // dataGridView1.Columns["ıd"].ReadOnly = true;
        }
        private void kaydet()//function kurduk her yerde kullanalım diye
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("ürün grubu adını boş bırakmayınız");
                return;
            }
            urunGruplari ug = new urunGruplari();
            ug.adi = textBox1.Text;
            db.Entry(ug).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            textBox1.Clear(); //textbox1.text=""; da yazılabilir
            textBox1.Focus();//imlecin tekrar textboxta durması orda devam etmesi gidip text boxa tıklamaya gerek kalmıyor
            urungruplarinigetir();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kaydet();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                kaydet();
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("silmek istediginizden emin misiniz","sil",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (cevap != DialogResult.Yes)
                return;

            DataGridViewRow secilisatir = dataGridView1.CurrentRow;
            int seciliid = (int)secilisatir.Cells["id"].Value;

            urunGruplari ug = db.urunGruplari.Where(x => x.id == seciliid).FirstOrDefault();

            db.Entry(ug).State=System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            urungruplarinigetir();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow degisensatir=dataGridView1.Rows[e.RowIndex];
            int id=(int)degisensatir.Cells["id"].Value;
            string ad1 = degisensatir.Cells["ad1"].Value.ToString();

            var ug=db.urunGruplari.FirstOrDefault(x => x.id == id);

            ug.adi = ad1;
            db.Entry(ug).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }
    }
}

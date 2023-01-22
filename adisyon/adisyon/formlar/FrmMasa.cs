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
    public partial class FrmMasa : Form
    {
        RestoranEntities db=new RestoranEntities();
        public FrmMasa()
        {
            InitializeComponent();
        }

        private void FrmMasa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Masalar.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Masalar masa=new Masalar();
            masa.adı = textBox1.Text;
            db.Entry(masa).State=System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            dataGridView1.DataSource = db.Masalar.ToList();
        }
    }
}

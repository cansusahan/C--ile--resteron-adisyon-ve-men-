using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adisyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void masaTanımalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlar.FrmMasa f = new formlar.FrmMasa();
            f.ShowDialog();
        }

        private void ürünGrubuTanımlamalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlar.frmUrunGruplari f=new formlar.frmUrunGruplari();
            f.ShowDialog();
        }

        private void ürünTanımlamlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlar.frmUrunler f=new formlar.frmUrunler();
            f.ShowDialog();
        }

        private void masallarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlar.frmMasalarListesi f = new formlar.frmMasalarListesi();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

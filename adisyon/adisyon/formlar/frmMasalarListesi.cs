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
    public partial class frmMasalarListesi : Form
    {
        public frmMasalarListesi()
        {
            InitializeComponent();
        }
        public void masalariGetir()
        {
            flowLayoutPanel1.Controls.Clear();
            var db = new adisyon.Modeller.RestoranEntities();
            List<Modeller.Masalar> kayitliMasalar = db.Masalar.ToList();

            foreach (var masa in kayitliMasalar)
            {
                Button b = new Button();
                b.Name = "button" + masa.id.ToString();
                b.Size = new System.Drawing.Size(150, 150);
                b.Text = masa.adı;
                b.Parent = flowLayoutPanel1;
                b.Tag = masa.id;
                b.Font = new Font(FontFamily.GenericSerif, 20);
                if ((bool)masa.AcikMi)
                {
                    b.BackColor = Color.DarkGreen;
                }
                else
                {
                    b.BackColor = Color.Gray;
                    b.ForeColor = Color.White;
                }
                b.Click += ButtonTiklama;

            }
        }
    
        private void frmMasalarListesi_Load(object sender, EventArgs e)
        {
             masalariGetir();
        }
        private void ButtonTiklama(object sender, EventArgs e)
        {
            Button b = sender as Button;
            frmSiparis f = new frmSiparis((int)b.Tag,this);
            f.ShowDialog();
            masalariGetir();


        }
    }
}

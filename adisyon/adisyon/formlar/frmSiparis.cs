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
    public partial class frmSiparis : Form
    {
        int masaid;
        Modeller.Masalar masa;
        Modeller.RestoranEntities db=new Modeller.RestoranEntities();
        int aktifSiparisId = -1;
        frmMasalarListesi frmMasalar;

        private int _adet;

        public int Adet
        {
            get { return _adet; }
            set
            {
                _adet = value;
                if (_adet < 1)
                {
                    _adet = 1;
                }
                label6.Text = _adet.ToString();
            }
        }
     
        public frmSiparis(int GonderenMasaid ,frmMasalarListesi f)
        {
            InitializeComponent();

            masaid = GonderenMasaid;
            masa = db.Masalar.FirstOrDefault(x => x.id == masaid);
            label1.Text =GonderenMasaid.ToString();
            frmMasalar = f;

        }

        private void frmSiparis_Load(object sender, EventArgs e)
        {
            Siparisler aktifsiparisler=db.Siparisler.Where(x => x.MasaId == masaid && x.AcikMi== true).FirstOrDefault();
            if (aktifsiparisler != null)
            {
                aktifSiparisId = aktifsiparisler.ıd;
            }
            SiparislerGetir();

            List<urunGruplari>urunGruplari=db.urunGruplari.ToList();
            foreach(var ug in urunGruplari)
            {
                Button b=new Button();
                b.Name="btnUrunGrupları"+ug.id.ToString();
                b.Text = ug.adi;
                b.Tag = ug.id;
                b.Size = new Size(120, 100);
                b.Parent = flpUrungrupları;
                b.Click += urunGruplariClick;

            }
        }

        private void urunGruplariClick(object sender, EventArgs e)
        {
          Button btn=sender as Button;
          int urunGrupid=(int)btn.Tag;
          List<Urunler>urunler=db.Urunler.Where(x=> x.Grupid==urunGrupid).ToList();
          flpUrunler.Controls.Clear();
            foreach(var u in urunler)
            {
                Button b = new Button();
                b.Name="btnUrun" +u.id.ToString();
                b.Text=u.adi;
                b.Size = new Size(120, 70);
                b.Parent = flpUrunler;
                b.Tag=u.id;
                b.Click += UrunButtonClick;
            }
        }

        private void UrunButtonClick(object sender, EventArgs e)
        {
            //bu urun siparise eklenecek
            //bu masanın acık siparisi varmı 
            //acık siparis varsa urun a siparise eklenecek
            //acık siparis yoksa siparis acılacak ve urun o siparise eklenecek

            Siparisler aktifSiparis = db.Siparisler.Where(x=> x.MasaId== masaid && x.AcikMi == true).FirstOrDefault();
            if (aktifSiparis == null) 
            {
                aktifSiparis=new Siparisler();
                aktifSiparis.MasaId= masaid;
                aktifSiparis.AcikMi= true;
                aktifSiparis.AcilmaZamani=DateTime.Now;
                db.Entry(aktifSiparis).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                masa.AcikMi = true;
                db.Entry(masa).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            aktifSiparisId = aktifSiparis.ıd;
            label5.Text=((DateTime)aktifSiparis.AcilmaZamani).ToLongDateString();

            Button urunBtn = sender as Button;
            int urunId = (int)urunBtn.Tag;
            Urunler urun=db.Urunler.Where(x=> x.id==urunId).FirstOrDefault();

            SiparisDetay siparisDetay = db.SiparisDetay.
                Where(x => x.SiparisId == aktifSiparisId && x.UrunId == urunId).FirstOrDefault();
            if(siparisDetay == null)
            {
                SiparisDetay sd = new SiparisDetay
                {
                    Fiyat = urun.fiyat,
                    Miktar = Adet,
                    SiparisId = aktifSiparisId,
                    UrunId = urun.id,
                    Tutar = urun.fiyat * Adet
                };
                db.Entry(sd).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            else
            {
                siparisDetay.Miktar+=Adet;
                siparisDetay.Tutar = siparisDetay.Miktar * siparisDetay.Fiyat;
                db.Entry(siparisDetay).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            Adet = 1;

            frmMasalar.masalariGetir();
            SiparislerGetir();
        }

        private void SiparislerGetir()
        {
            //List<SiparisDetay>siparisler=db.SiparisDetay.Where(x=>x.SiparisId==aktifSiparisId).ToList();

            var siparisDetaylar = (
                from sd in db.SiparisDetay
                join u in db.Urunler on sd.UrunId equals u.id
                where sd.SiparisId==aktifSiparisId
                select new
                {
                    ıd=sd.ıd,
                   UrunAdi=u.adi,
                   Miktar=sd.Miktar,
                   fiyat=sd.Fiyat,
                   Tutar=sd.Tutar
                }
                ).ToList();

            dataGridView1.DataSource=siparisDetaylar;
            label3.Text=siparisDetaylar.Select(x=>(decimal)x.Tutar).Sum().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (aktifSiparisId == -1)
                return;

            DialogResult sonuc = MessageBox.Show("hesap alıp masa kapatılsın mı?", "heasp al"
                ,MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc != DialogResult.Yes)
                return;

            masa.AcikMi = false;
            db.Entry(masa).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Siparisler siparis=db.Siparisler
                .Where(x=> x.ıd==aktifSiparisId)
                .FirstOrDefault();
            siparis.AcikMi = false;
            siparis.KapanmaZamani=DateTime.Now;
            db.Entry(siparis).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adet--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adet++;
        }
        private void SayiButtonClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Adet=Convert.ToInt16(b.Text);

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ürünİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int siparisDetayId = (int)dataGridView1.CurrentRow.Cells["ıd"].Value;

            SiparisDetay sd = db.SiparisDetay
                .Where(x => x.ıd == siparisDetayId)
                .FirstOrDefault();
            if (sd.Miktar == Adet)
            {
                MessageBox.Show("satılandan daha  fazla iptal edemezsin");
                return;
            }
            if (sd.Miktar == Adet)
            {
                db.Entry(sd).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                sd.Miktar -= Adet;
                sd.Tutar = sd.Miktar * sd.Fiyat;
                db.Entry(sd).State =System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            Adet = 1;
            SiparislerGetir();



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

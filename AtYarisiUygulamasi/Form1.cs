using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            AtDurumDegistir(true);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtDurumDegistir(false);
        }

        void AtDurumDegistir(bool durum)
        {
            atAlver.Enabled = atGolgeYele.Enabled = atPoyraz.Enabled = atYagiz.Enabled = atRuzgarGulu.Enabled = durum;
        }

        void AtDurumDegistir(bool durum, PictureBox at)
        {
            atAlver.Enabled = atGolgeYele.Enabled = atPoyraz.Enabled = atYagiz.Enabled = atRuzgarGulu.Enabled = durum;
            at.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    item.Left += rnd.Next(1, 10);
                }
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    Finish((PictureBox)item);
                }
            }
        }

        void Finish(PictureBox at)
        {
            if (at.Right - 18 >= label1.Left)
            {
                timer1.Stop();
                AtDurumDegistir(false, at);
                MessageBox.Show("Kazanan At :" + " " + at.Name);
            }
        }
    }
}

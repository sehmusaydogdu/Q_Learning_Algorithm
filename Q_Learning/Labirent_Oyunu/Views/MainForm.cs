using Labirent_Oyunu.Models;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirent_Oyunu
{
    public partial class MainForm : Form
    {
        public int count = 0;
        private Model model;
        public MainForm()
        {
            InitializeComponent();
            model = new Model();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            count++;
            Button button = (Button)sender;

            if (count == 1)
            {
                button.BackColor = Color.Red;
                btnBaslangic.BackColor = Color.Green;
                btnBaslangic.ForeColor = Color.White;
                btnBitis.BackColor = Color.Yellow;

                model.Baslangic = button.Tag.ToString();
            }

            else if (count == 2)
            {
                button.BackColor = Color.Green;
                btnBitis.BackColor = Color.Green;
                btnBitis.ForeColor = Color.White;

                Start_Click.Enabled = true;
                Start_Click.BackColor = Color.Green;

                btnEngelEkle.BackColor = Color.Yellow;
                btnEngelEkle.Enabled = true;

                model.Bitis = button.Tag.ToString();
            }
            else  
            {
                button.BackColor = Color.Black;
                model.Gidilemez.Add(int.Parse(button.Tag.ToString()));
            }
                
        }

        //Oyunu başlatır.
        private void Start_Click_Click(object sender, EventArgs e)
        {
            model.OyunuBaslat(panel);

        }
        

        /// <summary>
        /// Dinamik olarak buttonların oluşturulmasını sağlar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButttons_Click(object sender, EventArgs e)
        {
            int boyut= int.Parse(txtMatris.Text); 
            panel.Controls.Clear();
            model.MatrisBoyutu = boyut * boyut;
            model.Initialize();
            panel.Width = boyut* 50;
            panel.Height = boyut * 50;

            Point point = new Point { X = 0, Y = 0 };
            int say = 0;
            for (byte i = 0; i < model.MatrisBoyutu; i++)
            {
                say++;
                Button button = new Button
                {
                    BackColor = Color.White,
                    Tag = i.ToString(),
                    Width = 50,
                    Height = 50,
                    Location = new Point(point.X, point.Y)
                };
                button.Click += BtnClick;
                panel.Controls.Add(button);
                point.X += 50;

                if (say % boyut == 0)
                {
                    point.X = 0;
                    point.Y += 50;
                }
            }
            btnBaslangic.BackColor = Color.Yellow;
        }

        //Ekranı yeniler
        private void ClearButtons_Click(object sender, EventArgs e) => panel.Controls.Clear();

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Labirent_Oyunu.Models
{
    public class Model
    {
        private Panel panel;
        private const double GAMMA = 0.8;  //Öğrenme katsayısı
        private const int ITERASYON_SAYİSİ=100;  //İterasyon Sayisi
        
        public string Baslangic { get; set; }  //Başlangıç Durumu
        public string Bitis { get; set; }   //Bitiş Durumu
        public int MatrisBoyutu { get; set; }  //Matrislerin boyutu

        public double[,] Q_Matris { get; set; }  //Ödüller
        public double[,] R_Matris { get; set; }  //Rota

        public List<int> Gidilemez = new List<int>();
        public void Initialize()
        {
            Q_Matris = new double[MatrisBoyutu,MatrisBoyutu];
            R_Matris = new double[MatrisBoyutu, MatrisBoyutu];
        }  //Dizinin boyutunu ayarladım.

        public void OyunuBaslat(Panel panel)
        {
            this.panel = panel;
            int boyut = Gidilemez.Count;
            
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < MatrisBoyutu; j++)
                    R_Matris[j, Gidilemez[i]] = -1;
            }
            
            for (int i = 0; i < MatrisBoyutu; i++)
                R_Matris[i, int.Parse(Bitis)] = 100;
            
            Thread thread = new Thread(IslemYap);
            thread.Start();

        }

        private void IslemYap()
        {
            Random uret = new Random();
            string start = Baslangic, finish = Bitis;

            for (int i = 0; i < ITERASYON_SAYİSİ; i++)
            {
               int durum = uret.Next(MatrisBoyutu);
               int action = RastgeleHedefSec(durum);
               int tumdurum = QMAX(action);

                foreach (Button button in panel.Controls)
                    if (button.Tag.ToString().Equals(start) && !button.Tag.ToString().Equals(finish))
                        button.BackColor = Color.White;

               Q_Matris[durum, action] = (R_Matris[durum, action] + GAMMA * Q_Matris[action, tumdurum]);

               start = durum.ToString();

               foreach (Button button in panel.Controls)
                   if (button.Tag.ToString().Equals(start) && !button.Tag.ToString().Equals(Bitis))
                       button.BackColor = Color.Red;

               
               Thread.Sleep(5);
            }
            Goster();
        }

        public void Goster()
        {

            foreach (Button button in panel.Controls)
            {
                for (int i = 0; i < Gidilemez.Count; i++)
                 {
                     if (button.Tag.ToString() == Gidilemez[i].ToString())
                     {
                         button.BackColor = Color.Black;
                     }
                 }

                if (button.Tag.ToString().Equals(Baslangic))
                    button.BackColor = Color.Red;

                else if (button.Tag.ToString().Equals(Bitis))
                    button.BackColor = Color.Green;

            }

            for (int i = 0; i < MatrisBoyutu; i++)
            {
                int deger = maxBul(i);
                if (deger != -1)
                {
                    foreach (Button button in panel.Controls)
                    {
                        if (button.Tag.ToString().Equals(deger.ToString()))
                        {
                            button.BackColor = Color.Plum;
                        }
                    }
                }
            }
        }

        private int maxBul(int index)
        {
            double eb = int.MinValue;
            int yeri = -1;
            for (int i = 0; i < MatrisBoyutu; i++)
            {
                if (Q_Matris[index, i] >= eb && Q_Matris[index, i]!=0)
                {
                    eb = Q_Matris[index, i];
                    yeri = i;
                }
            }
            return yeri;
        }

        private int RastgeleHedefSec(int durum)
        {
            int action = 0;
            Random random = new Random();
            bool IsState = false;
            while (IsState == false)
            {
                action = random.Next(MatrisBoyutu);
                
                if (R_Matris[durum, action] > -1)
                    IsState = true;
            }
            return action;
        }
        private int QMAX(int action)
        {

            List<int> list = new List<int>();
            double index = 0, enbuyuk=int.MinValue;

            for (int i = 0; i < MatrisBoyutu; i++)
            {
                if (R_Matris[action, i] > -1)
                    list.Add(i);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (Q_Matris[action,list[i]] >= enbuyuk)
                {
                    enbuyuk = Q_Matris[action, list[i]];
                    index = list[i];
                }
            }
            return (int)index;
        }
    }
}

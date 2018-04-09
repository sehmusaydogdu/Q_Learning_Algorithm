using System;

namespace Sample_Q_Learning.Controller
{
    public class Management
    {
        private static int boyut = 6; //Matris boyutunu veriyorum.
        private static double GAMMA = 0.8; //Öğrenme katsayisini veriyorum. 0 < gamma < 1
        private static int iterasyonSayisi = 10; //İterasyon Sayisini belirliyorum


        //Başlangıç durumlarımı belirtiyorum.
        private static int[] baslangic_durumlari = new int[] { 1, 3, 5, 2, 4, 0 };


        //R_matrisi : (-1 => Gidilemez  0 => Gidilebilir  100 => Çıkış noktası (Varmak istediğim nokta))
        private static int[,] R_Matrisi= new int[,]      {{-1, -1, -1, -1, 0, -1}, 
                                                          {-1, -1, -1, 0, -1, 100}, 
                                                          {-1, -1, -1, 0, -1, -1}, 
                                                          {-1, 0, 0, -1, 0, -1}, 
                                                          {0, -1, -1, 0, -1, 100}, 
                                                          {-1, 0, -1, -1, 0, 100}};

        private static int[,] Q_Matrisi = new int[boyut,boyut]; //Ödül matrisim
        private static int mevcut_durum = 0;  //Mevcut durum
        private static Random random=new Random();

        /// <summary>
        /// Uygulamanın yönetileceği kısımdır.
        /// GezintiYap(); => Yolları öğrenmesini sağlamak için tasarlanmıştır. (Q_Matrisi)
        /// Test(); => Öğrendikten sonra gidilebilecek yolları göstermek için tasarlanmıştır.
        /// </summary>
        public Management()
        {
            GezintiYap(); //Başlangıç durumlarını tek tek gezerek ödül matrisini doldurmaya çalışıyorum.
            Test();  //Oluşturduğum Q_Matrisini test ediyorum
        }


        /// <summary>
        /// Tüm başlangıç durumlarından başlayarak Q matrisinin öğrenmesini sağlıyorum.
        /// </summary>
        private static void GezintiYap()
        {
            for (int j = 0; j < iterasyonSayisi; j++)
            {
                for (int i = 0; i < boyut; i++)
                    Durumlar(baslangic_durumlari[i]);
            }

            Console.WriteLine("Q Matrix değerlerim :");
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                    Console.Write(Q_Matrisi[i,j] + ",\t");
                Console.Write("\n");
            }

            Console.Write("\n");
        }


        /// <summary>
        /// Tüm başlangıç ​​durumlarından başlayarak testler yapıyorum.
        /// </summary>
        private static void Test()
        {
            Console.WriteLine("İlk durumlardan en kısa yollar: ");
            for (int i = 0; i < boyut; i++)
            {
                mevcut_durum = baslangic_durumlari[i];
                int newState = 0;
                do
                {
                    newState = Maximum(mevcut_durum, true);
                    Console.Write(mevcut_durum + ", ");
                    mevcut_durum = newState;

                } while (mevcut_durum < 5);
                Console.Write("5\n");
            }
        }

        private static void Durumlar(int durum)
        {
            mevcut_durum = durum;

            // Hedef duruma ulaşana kadar durumdan duruma seyehat et.
            do
            {
                Hedef_Durum_Sec();
            } while (mevcut_durum == 5);

            // Hedef durum 5 olduğunda mesafeler için bir tur daha at.
            for (int i = 0; i < boyut; i++)
                Hedef_Durum_Sec();

        }


        /// <summary>
        /// Rastgele olarak mevcut duruma bağlı bir hedef seçilmesi gerekir.
        /// </summary>
        private static void Hedef_Durum_Sec()
        {
            int gidilebilecekHedef = 0;
            gidilebilecekHedef = RastgeleHedefSec(boyut);// Rastgele olarak mevcut duruma bağlı bir hedef seçiyorum.

            if (R_Matrisi[mevcut_durum, gidilebilecekHedef] >= 0)
            {
                Q_Matrisi[mevcut_durum, gidilebilecekHedef] = Odul(gidilebilecekHedef);
                mevcut_durum = gidilebilecekHedef;
            }
        }


        /// <summary>
        /// Rastgele Olarak mevcut duruma bağlı bir eylem seçmek için kullanılacak metotdur.
        /// </summary>
        /// <param name="boyut">Dizinin Boyutu</param>
        /// <returns>Mevcut durumdan gidilebilecek bir hedef seçiyorum</returns>
        private static int RastgeleHedefSec(int boyut)
        {
            int hedef = 0;
            bool secildiMi = false;

            // Rastgele olarak mevcut_durum'a bağlı bir hedef seçiyorum
            while (secildiMi == false)
            {
                // üretilen sayi 0 ile dizi boyutu (6) arasında olması gerekir.
                hedef = random.Next(boyut);

                //rastgele seçilen hedefin engele takılmasını önlemek için (x>-1) koşulunu katıyorum.
                if (R_Matrisi[mevcut_durum,hedef] > -1)
                    secildiMi = true; //Eğer böyle bir durum var ise döngüden çıkar.
            }
            return hedef;
        }

        /// <summary>
        /// Öğrenme işi bittikten sonra artık Q_Matrisinden yola çıkarak
        /// yolu bulmaya çalışıyor. Burada ise Ödül matrisinde alabileceği en yüksek ödülü almaya çalışıyor.
        /// </summary>
        /// <param name="durum">Bulunduğum durum</param>
        /// <param name="index">Q_Matrisinden dönecek değeri belirliyor.</param>
        /// <returns>True  : Q_Matrisinin indexini döndürüyorum.
        ///          False : Q_Matrisinin değerini döndürüyorum. </returns>
        private static int Maximum(int durum, bool index)
        {
            int kazandi = 0;
            bool kazananBulunduMu = false,sonuc = false;

            while (!sonuc)
            {
                kazananBulunduMu = false;
                for (int i = 0; i < boyut; i++)
                {
                    if (i != kazandi)
                    {
                        //Kendi kendini kontrol etmesini engelliyorum.
                        if (Q_Matrisi[durum, i] > Q_Matrisi[durum, kazandi]) 
                        {
                            kazandi = i;
                            kazananBulunduMu = true;
                        }
                    }
                }

                if (kazananBulunduMu == false)
                    sonuc = true;
              }
            return index == true ? kazandi : Q_Matrisi[durum, kazandi];
        }

        /// <summary>
        /// Genel formülü kullanıp; (Q(s,t)=R(s,t)+Gamma*(max(Q(t,tumdurum))))
        /// geriye Q(s,t) ödülünü döndürüyorum.
        /// </summary>
        /// <param name="hedef">Gidilebilecek Hedef</param>
        /// <returns>Ödül => (Q(s,t))</returns>
        private static int Odul(int hedef) => (int)(R_Matrisi[mevcut_durum, hedef] + (GAMMA * Maximum(hedef, false)));
    }
}

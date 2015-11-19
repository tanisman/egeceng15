using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DSPRJ_2_2
{
    class Program
    {
        static int[] cukurDerinlikleri;
        static Stack<Karinca>[] cukurlar;
        static LinkedList<Karinca> karincalar;
        static void Main(string[] args)
        {
            Console.WriteLine("0-Dinamik degerler ile karinca problemi hesaplatmak");
            Console.WriteLine("1-Sabit degerler ile bilgisayarin 3snde hesapladigi problem sayisi (bagli liste)");
            Console.WriteLine("2-Sabit degerler ile bilgisayarin 3snde hesapladigi problem sayisi (dizi)");
            switch(Console.ReadLine())
            {
                case "0":
                    KarincaDinamikDegerler();
                    break;
                case "1":
                    Console.WriteLine("Bu bilgisayar 3snde bagli liste ile {0} adet karinca problemi cozebilir", ProcessCount(() => KarincaSabitDegerBagliListe(), 3000));
                    break;
                case "2":
                    Console.WriteLine("Bu bilgisayar 3snde dizi ile {0} adet karinca problemi cozebilir", ProcessCount(() => KarincaSabitDegerDizi(), 3000));
                    break;
            }
            

            Console.ReadLine();
        }

        static void KarincaDinamikDegerler()
        {
            karincalar = new LinkedList<Karinca>(); //karıncaları tutmak için bağlı liste oluştur
            Console.WriteLine("karinca sayisini giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) //karıncaları oluştur ve bağlı listeye at
            {
                karincalar.AddLast(new Karinca(String.Format("Karinca {0}", i + 1)));
            }
            Console.WriteLine("cukur sayisini giriniz: ");
            n = Convert.ToInt32(Console.ReadLine());
            cukurDerinlikleri = new int[n];
            cukurlar = new Stack<Karinca>[n];
            for (int i = 0; i < n; i++) //çukurları oluştur
            {
                Console.WriteLine("{0}. Cukurun buyuklugunu giriniz: ", i + 1);
                cukurDerinlikleri[i] = Convert.ToInt32(Console.ReadLine());
                cukurlar[i] = new Stack<Karinca>(cukurDerinlikleri[i]);
            }

            bool stop = false;
            for (int i = 0; i < cukurlar.Length; i++) //çukurları döngüye al
            {
                while (cukurlar[i].Count != cukurDerinlikleri[i] && !stop) //çukur dolana kadar ve stop sinyali gelmediği sürece döngü devam eder
                {
                    if (karincalar.Count == 0) //çukurlara düşmeyen karınca kalmadıysa
                    {
                        stop = true; //durdurulcak olarak işaretle
                        for (int j = 0; j < i; j++) //kendisinden önceki çukurlara bak (en uzaktan en yakına)
                        {
                            if (cukurlar[j].Count != 0) //çukur boş değilse
                            {
                                cukurlar[i].Push(cukurlar[j].Pop()); //önceki çukurdan çıkart şu anki çukura at
                                stop = false; //karınca eklenebildiği için durdurmayı iptal et
                                break; //for döngüsünden çık
                            }
                        }
                    }
                    else //eğer çukura düşmemiş karınca varsa
                    {
                        cukurlar[i].Push(karincalar.First.Value); //en öndeki karıncayı çukura düşür
                        karincalar.RemoveFirst(); //bağlı listeden sil
                    }
                }
                stop = false;
            }

            for (int i = 0; i < cukurlar.Length; i++)
            {
                while (cukurlar[i].Count > 0)
                    Console.WriteLine("{0} cikisa ulasti", cukurlar[i].Pop().Name); //çıkanları sırayla yazdır
            }
        }

        static void KarincaSabitDegerBagliListe()
        {
            karincalar = new LinkedList<Karinca>(); //karıncaları tutmak için bağlı liste oluştur
            for (int i = 0; i < 5; i++) //karıncaları oluştur ve diziye listeye at
            {
                karincalar.AddLast(new Karinca(String.Format("Karinca {0}", i + 1)));
            }
            cukurDerinlikleri = new[] { 3, 2, 4 };
            cukurlar = new Stack<Karinca>[3];
            for (int i = 0; i < 3; i++) //çukurları oluştur
                cukurlar[i] = new Stack<Karinca>(cukurDerinlikleri[i]);

            bool stop = false;
            for (int i = 0; i < cukurlar.Length; i++) //çukurları döngüye al
            {
                while (cukurlar[i].Count != cukurDerinlikleri[i] && !stop) //çukur dolana kadar ve stop sinyali gelmediği sürece döngü devam eder
                {
                    if (karincalar.Count == 0) //çukurlara düşmeyen karınca kalmadıysa
                    {
                        stop = true; //durdurulcak olarak işaretle
                        for (int j = 0; j < i; j++) //kendisinden önceki çukurlara bak (en uzaktan en yakına)
                        {
                            if (cukurlar[j].Count != 0) //çukur boş değilse
                            {
                                cukurlar[i].Push(cukurlar[j].Pop()); //önceki çukurdan çıkart şu anki çukura at
                                stop = false; //karınca eklenebildiği için durdurmayı iptal et
                                break; //for döngüsünden çık
                            }
                        }
                    }
                    else //eğer çukura düşmemiş karınca varsa
                    {
                        cukurlar[i].Push(karincalar.First.Value); //en öndeki karıncayı çukura düşür
                        karincalar.RemoveFirst(); //bağlı listeden sil
                    }
                }
                stop = false;
            }

            for (int i = 0; i < cukurlar.Length; i++)
            {
                while (cukurlar[i].Count > 0)
                    cukurlar[i].Pop();
            }
        }

        static void KarincaSabitDegerDizi()
        {
            Karinca[] karincalarDizi = new Karinca[5]; //karıncaları tutmak için dizi oluştur
            
            for (int i = 0; i < 5; i++) //karıncaları oluştur ve diziye at
            {
                karincalarDizi[i] = new Karinca(String.Format("Karinca {0}", i + 1));
            }
            cukurDerinlikleri = new[] { 3, 2, 4 };
            cukurlar = new Stack<Karinca>[3];
            for (int i = 0; i < 3; i++) //çukurları oluştur
                cukurlar[i] = new Stack<Karinca>(cukurDerinlikleri[i]);

            int siradakiKarinca = 0;
            bool stop = false;
            for (int i = 0; i < cukurlar.Length; i++) //çukurları döngüye al
            {
                while (cukurlar[i].Count != cukurDerinlikleri[i] && !stop) //çukur dolana kadar ve stop sinyali gelmediği sürece döngü devam eder
                {
                    if (siradakiKarinca >= karincalarDizi.Length) //çukurlara düşmeyen karınca kalmadıysa
                    {
                        stop = true; //durdurulcak olarak işaretle
                        for (int j = 0; j < i; j++) //kendisinden önceki çukurlara bak (en uzaktan en yakına)
                        {
                            if (cukurlar[j].Count != 0) //çukur boş değilse
                            {
                                cukurlar[i].Push(cukurlar[j].Pop()); //önceki çukurdan çıkart şu anki çukura at
                                stop = false; //karınca eklenebildiği için durdurmayı iptal et
                                break; //for döngüsünden çık
                            }
                        }
                    }
                    else //eğer çukura düşmemiş karınca varsa
                    {
                        cukurlar[i].Push(karincalarDizi[siradakiKarinca]); //en öndeki karıncayı çukura düşür
                        siradakiKarinca++; //sıradakı karıncaya geç
                    }
                }
                stop = false;
            }

            for (int i = 0; i < cukurlar.Length; i++)
            {
                while (cukurlar[i].Count > 0)
                    cukurlar[i].Pop();
            }
        }

        static double ProcessCount(Action act, int ms)
        {
            Stopwatch sw = new Stopwatch(); //stopwatch türünden nesne oluştur
            sw.Start(); //sayacı başlat
            act(); //fonksiyonu çağır
            return ms / sw.Elapsed.TotalMilliseconds; //verilen süreyi geçen süreye böl
        }
    }
}

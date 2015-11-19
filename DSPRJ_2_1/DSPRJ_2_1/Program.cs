using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPRJ_2_1
{
    class Program
    {
        static YaziciKuyrugu yazici_kuyrugu;
        static string[] ogrenciler = { "Ali GÜL", "Veli DEMİR", "Cemile ŞAHİN", "Ayten YILMAZ" };
        static int[] sayfaSayilari = { 27, 21, 41, 0, 15, 0, 47, 35, 3, 0, 12, 17, 0 };
        static void Main(string[] args)
        {

            yazici_kuyrugu = new YaziciKuyrugu();

            int idx = 0;
            foreach (string ogrenci in ogrenciler)
            {
                OgrIslem islem = new OgrIslem(ogrenci);
                while (sayfaSayilari[idx] != 0)
                {
                    islem.YazdirmaKuyrugunaEkle(sayfaSayilari[idx]);
                    idx++;
                }
                idx++;

                yazici_kuyrugu.Enqueue(islem);
            }

            int toplamits = 0;
            foreach (var it in yazici_kuyrugu)
            {
                int its = it.BekleyenSayfa() * 1; //sn
                Console.WriteLine("{0} - ITS = {1}", it.AdSoyad, its);
                toplamits += its;
            }
            float ots = toplamits / yazici_kuyrugu.Count;
            Console.WriteLine("OITS = {0}", ots);
            Console.WriteLine();

            while (yazici_kuyrugu.Count != 0)
            {
                var islem = yazici_kuyrugu.Dequeue();
                int sayfa = islem.YazdirmaKuyrugundanCikart();
                if (islem.BekleyenSayfa() > 0)
                    yazici_kuyrugu.Enqueue(islem);
                Console.WriteLine("{0} - {1} sayfa", islem.AdSoyad, sayfa);
            }

            Console.ReadLine();
        }
    }
}

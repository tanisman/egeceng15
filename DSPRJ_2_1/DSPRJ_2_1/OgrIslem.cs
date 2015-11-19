using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPRJ_2_1
{
    public class OgrIslem
    {
        public readonly string AdSoyad;
        private PriorityQueue<int> YazdirmaKuyrugu;
        private int m_YazdirilanSayfa;

        public OgrIslem(string adsoyad)
        {
            YazdirmaKuyrugu = new PriorityQueue<int>();
            AdSoyad = adsoyad;
            m_YazdirilanSayfa = 0;
        }

        public void YazdirmaKuyrugunaEkle(int sayfaSayisi)
        {
            YazdirmaKuyrugu.Enqueue(sayfaSayisi);
        }

        public int YazdirmaKuyrugundanCikart()
        {
            int total = 0;
            while (!YazdirmaKuyrugu.IsEmpty && total + YazdirmaKuyrugu.Peek() <= 50)
                total += YazdirmaKuyrugu.Dequeue();

            m_YazdirilanSayfa += total;

            return total;
        }

        public int BekleyenSayfa()
        {
            return YazdirmaKuyrugu.Sum(p => p); 
        }
    }
}

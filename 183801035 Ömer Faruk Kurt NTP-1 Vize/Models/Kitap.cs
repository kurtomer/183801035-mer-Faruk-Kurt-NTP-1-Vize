using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _183801035_Ömer_Faruk_Kurt_NTP_1_Vize.Models
{
    public class Kitap
    {
        public Kitap()
        {
            _BasımTarihi = DateTime.Now;   
        }
        #region Fields
        private string _KitapAdı;
        private string _Yazar;
        private DateTime _BasımTarihi;
        private string _Türü;
        #endregion
        #region Properties
        public string KitapAdı { get => _KitapAdı; set => _KitapAdı = value; }
        public string Yazar { get => _Yazar; set => _Yazar = value; }
        public DateTime BasımTarihi { get => _BasımTarihi; set => _BasımTarihi = value; }
        public string Türü { get => _Türü; set => _Türü = value; }
        #endregion
        public static void TxtDosyasinaYaz(List<Kitap> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                string[] text = { lst[i].KitapAdı, lst[i].Yazar, lst[i].BasımTarihi.ToString(), lst[i].Türü };
                File.AppendAllLines(@"C:\New Folder\Omer.txt", text);
            }

        }
    }
}

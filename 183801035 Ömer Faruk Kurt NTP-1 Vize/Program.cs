using _183801035_Ömer_Faruk_Kurt_NTP_1_Vize.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _183801035_Ömer_Faruk_Kurt_NTP_1_Vize
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showmenu = true;
            while (showmenu)
            {
                showmenu = Menu();
            }


        }
        private static bool Menu()
        {
            Console.WriteLine("Seçenekler");
            Console.WriteLine("1) Kitap Ekle");
            Console.WriteLine("2) Kitapları Listele");
            Console.WriteLine("3) Çıkış");
            Console.Write("\r\nİşlem seçiniz: ");
            List<Kitap> lst = new List<Kitap>();
            switch (Console.ReadLine())
            {
                case "1":
                    lst = DiziyeYaz();
                    if (lst != null)
                    {
                        Kitap.TxtDosyasinaYaz(lst);
                    }
                    return true;
                case "2":
                    Oku();
                    return true;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Listede Gösterilen Seçeneklerden birini yazarak seçiniz");
                    return true;
            }
        }
        public static List<Kitap> DiziyeYaz()
        {
            List<Kitap> lst = new List<Kitap>();
            Console.WriteLine("Kaç kitap ekleyeceğinizi giriniz");
            int sayi = 0;
            try
            {
                sayi = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ekleyeceğiniz kitap sayısı Rakamsal olarak girilmelidir");
            }
            catch (Exception)
            {
                Console.WriteLine("Bir hata oluştu");
            }
            try
            {
                for (int i = 0; i < sayi; i++)
                {
                    Kitap book = new Kitap();
                    Console.Write(i + 1 + ".Kitap adı giriniz:");
                    book.KitapAdı = Console.ReadLine();
                    Console.Write("Yazarı Giriniz:");
                    book.Yazar = Console.ReadLine();
                    Console.Write("Tarih Giriniz:");
                    DateTime BasımTarihi = Convert.ToDateTime(Console.ReadLine());
                    if (DateTime.Now <= BasımTarihi)
                    {
                        Console.WriteLine("Girilen tarih şu an ki yıldan büyük olmamalıdır");
                        return null;
                    }
                    else
                    {
                        book.BasımTarihi = BasımTarihi;
                    }
                    Console.Write("Tür Giriniz:");
                    book.Türü = Console.ReadLine();
                    lst.Add(book);
                }


            }
            catch (System.FormatException)
            {
                Console.WriteLine("Tarihi dd.mm.yyyy formatında giriniz");
            }
            catch (Exception)
            {
                Console.WriteLine("Bir sorun oluştu!!!");
            }
            return lst;
        }
        

        public static void Oku()
        {
            var table = new Table();
            string path = @"C:\New Folder\Omer.txt";
            string[] metin = File.ReadLines(path).ToArray();
            if (metin.Length>0)
            {
                int sayac = 0;
                table.SetHeaders("Kitabın Adı", "Kitabın Yazarı", "Kitabın Basım Tarihi", "Kitabın Türü");
                for (int i = 0; i < metin.Length / 4; i++)
                {
                    table.AddRow($"{metin[sayac]}", metin[sayac + 1], metin[sayac + 2], metin[sayac + 3]);
                    sayac = sayac + 3;
                    sayac++;
                }
                Console.WriteLine(table.ToString()); 
            }
            else
            {
                Console.WriteLine("Txt dosyasının içerisinde hiç veri yok");
            }
        }


    }
}

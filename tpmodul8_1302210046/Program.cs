// See https://aka.ms/new-console-template for more information
using System;

namespace tpmodul8_1302210046
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CovidConfig datacovid = new CovidConfig();
            Console.Write("Berapa suhu badan anda saat ini? Dalam " + datacovid.config.satuan_suhu + ": ");
            double suhu = double.Parse(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?: ");
            int hariDemam = int.Parse(Console.ReadLine());

            if (datacovid.IsInputValid(suhu, hariDemam))
            {
                Console.WriteLine(datacovid.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(datacovid.config.pesan_ditolak);
            }
        }
    }
}
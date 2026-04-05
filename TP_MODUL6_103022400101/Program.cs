using System;
using System.Diagnostics;

namespace TP_MODUL6_103022400101
{
    public class SayaMusicTrack
    {
        private int id;
        private int playCount;
        private string title;

        public SayaMusicTrack(string title)
        {
            Debug.Assert(title != null, "Error: Judul track tidak boleh null.");
            Debug.Assert(title.Length <= 100, "Error: Judul track maksimal 100 karakter.");

            this.title = title;
            this.playCount = 0;

            Random rnd = new Random();
            this.id = rnd.Next(10000, 100000);
        }

        public void IncreasePlayCount(int count)
        {
            Debug.Assert(count <= 10000000, "Error: Input penambahan play count maksimal 10.000.000 per pemanggilan.");

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Exception Terjadi: Proses penambahan play count gagal karena melebihi batas maksimum integer (Overflow).");
            }
        }

        public void PrintTrackDetails()
        {
            Console.WriteLine($"ID Track    : {this.id}");
            Console.WriteLine($"Judul Lagu  : {this.title}");
            Console.WriteLine($"Play Count  : {this.playCount}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PENGUJIAN NORMAL ===");
            SayaMusicTrack track1 = new SayaMusicTrack("Lagu Perdana");
            track1.PrintTrackDetails();

            track1.IncreasePlayCount(5000000);
            track1.PrintTrackDetails();


            Console.WriteLine("\n=== PENGUJIAN EXCEPTION (OVERFLOW) ===");
            SayaMusicTrack track2 = new SayaMusicTrack("Lagu Viral");

            for (int i = 0; i < 250; i++)
            {
                track2.IncreasePlayCount(10000000);
            }
            track2.PrintTrackDetails();
        }
    }
}
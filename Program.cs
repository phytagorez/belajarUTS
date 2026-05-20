using System;

namespace belajarUTS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Perpustakaan perpus = new Perpustakaan();
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("\n=====================================");
                Console.WriteLine("Selamat Datang Di Ejak Perpustakaan");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Semua Buku");
                Console.WriteLine("3. Update Data Buku");
                Console.WriteLine("4. Hapus Buku");
                Console.WriteLine("5. Pinjam Buku (Maks 3)");
                Console.WriteLine("6. Kembalikan Buku");
                Console.WriteLine("7. Lihat Daftar Buku Dipinjam");
                Console.WriteLine("8. Keluar");
                Console.Write("\nPilih Menu: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        perpus.TambahBuku();
                        break;
                    case "2":
                        perpus.TampilkanSemuaBuku();
                        break;
                    case "3":
                        perpus.UpdateBuku();
                        break;
                    case "4":
                        perpus.HapusBuku();
                        break;
                    case "5":
                        perpus.PinjamBuku();
                        break;
                    case "6":
                        perpus.KembalikanBuku();
                        break;
                    case "7":
                        perpus.TampilkanBukuDipinjam();
                        break;
                    case "8":
                        run = false;
                        Console.WriteLine("Terimakasih menggunakan perpustakaan Ejak!");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid, ayo tawuran");
                        break;
                }
                Console.Write("Tekan enter untuk lanjut...");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace belajarUTS
{
    public class Perpustakaan
    {
        private List<Buku> daftarBuku = new List<Buku>();

        public int HitungBukuDipinjam()
        {
            int count = 0;
            foreach (var buku in daftarBuku)
            {
                if (buku.isPinjam) count++;
            }
            return count;
        }

        public void TambahBuku()
        {
            Console.WriteLine("\n--- Tambah Buku ---");
            Console.WriteLine("1. Buku Fiksi\n2. Buku Non-Fiksi\n3. Majalah");
            Console.Write("Pilih Jenis: ");
            string jenis = Console.ReadLine();

            Console.Write("Masukkan Judul: ");
            string judul = Console.ReadLine();
            Console.Write("Masukkan Penulis: ");
            string penulis = Console.ReadLine();
            Console.Write("Masukkan Tahun Terbit: ");
            int.TryParse(Console.ReadLine(), out int tahun);

            if (jenis == "1")
            {
                Console.Write("Masukkan Genre: ");
                string kategori = Console.ReadLine();
                daftarBuku.Add(new BukuFiksi(judul, penulis, tahun, kategori));
            }
            else if (jenis == "2")
            {
                Console.Write("Masukkan Subjek: ");
                string kategori = Console.ReadLine();
                daftarBuku.Add(new BukuNonFiksi(judul, penulis, tahun, kategori));
            }
            else if (jenis == "3")
            {
                Console.Write("Masukkan Edisi: ");
                string kategori = Console.ReadLine();
                daftarBuku.Add(new Majalah(judul, penulis, tahun, kategori));
            }
            else
            {
                Console.WriteLine("Jenis tidak valid!");
                return;
            }
            Console.WriteLine("Buku berhasil ditambahkan!");
        }

        public void TampilkanSemuaBuku()
        {
            Console.WriteLine("\n--- Daftar Semua Koleksi ---");
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi perpustakaan masih kosong.");
                return;
            }
            // Menggunakan for loop agar tampil nomor urutnya
            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }
        }

        public void UpdateBuku()
        {
            Console.WriteLine("\n--- Update Data Buku ---");
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi kosong, tidak ada yang bisa diubah.");
                return;
            }

            // Tampilkan semua buku pakai loop beserta nomornya
            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }

            Console.Write($"\nPilih nomor buku yang ingin diubah (1-{daftarBuku.Count}): ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= daftarBuku.Count)
            {
                // Akses langsung menggunakan trik index - 1
                Buku buku = daftarBuku[pilihan - 1];

                Console.Write($"Masukkan Judul Baru ({buku.Judul}): ");
                string judulBaru = Console.ReadLine();
                if (!string.IsNullOrEmpty(judulBaru)) buku.Judul = judulBaru;

                Console.Write($"Masukkan Penulis Baru ({buku.Penulis}): ");
                string penulisBaru = Console.ReadLine();
                if (!string.IsNullOrEmpty(penulisBaru)) buku.Penulis = penulisBaru;

                Console.WriteLine("Data buku berhasil diperbarui!");
            }
            else
            {
                Console.WriteLine("Nomor tidak valid, gagal update data.");
            }
        }

        // 2. Menghapus data buku berdasarkan pilihan nomor (indeks)
        public void HapusBuku()
        {
            Console.WriteLine("\n--- Hapus Buku ---");
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi kosong, tidak ada yang bisa dihapus.");
                return;
            }

            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }

            Console.Write($"\nPilih nomor buku yang ingin dihapus (1-{daftarBuku.Count}): ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= daftarBuku.Count)
            {
                Buku buku = daftarBuku[pilihan - 1];
                daftarBuku.Remove(buku);
                Console.WriteLine($"Buku '{buku.Judul}' berhasil dihapus dari sistem!");
            }
            else
            {
                Console.WriteLine("Nomor tidak valid, gagal menghapus.");
            }
        }

        public void PinjamBuku()
        {
            Console.WriteLine("\n--- Pinjam Buku ---");
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi kosong, tidak ada buku yang bisa dipinjam.");
                return;
            }

            if (HitungBukuDipinjam() >= 3) // Maksimal 3 buku [cite: 10]
            {
                Console.WriteLine("Gagal! Batas maksimal peminjaman kamu sudah mencapai 3 buku.");
                return;
            }

            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }

            Console.Write($"\nPilih nomor buku yang ingin dipinjam (1-{daftarBuku.Count}): ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= daftarBuku.Count)
            {
                Buku buku = daftarBuku[pilihan - 1];

                if (buku.isPinjam)
                {
                    Console.WriteLine("Buku tersebut sedang dipinjam oleh orang lain.");
                }
                else
                {
                    buku.Pinjam();
                    Console.WriteLine($"Berhasil meminjam buku: {buku.Judul}");
                }
            }
            else
            {
                Console.WriteLine("Nomor tidak valid!");
            }
        }

        public void KembalikanBuku()
        {
            Console.WriteLine("\n--- Pengembalian Buku ---");
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi perpustakaan kosong.");
                return;
            }

            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }

            Console.Write($"\nPilih nomor buku yang ingin dikembalikan (1-{daftarBuku.Count}): ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= daftarBuku.Count)
            {
                Buku buku = daftarBuku[pilihan - 1];

                if (!buku.isPinjam)
                {
                    Console.WriteLine("Buku ini tidak sedang dalam status dipinjam.");
                }
                else
                {
                    buku.Kembalikan();
                    Console.WriteLine($"Terima kasih! Buku '{buku.Judul}' telah dikembalikan.");
                }
            }
            else
            {
                Console.WriteLine("Nomor tidak valid!");
            }
        }

        public void TampilkanBukuDipinjam()
        {
            Console.WriteLine("\n--- Daftar Buku Yang Sedang Kamu Pinjam ---");
            bool adaDipinjam = false;
            foreach (var buku in daftarBuku)
            {
                if (buku.isPinjam)
                {
                    buku.TampilkanInfo();
                    adaDipinjam = true;
                }
            }
            if (!adaDipinjam) Console.WriteLine("Kamu belum meminjam buku apapun.");
        }
    }
}
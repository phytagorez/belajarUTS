using System;
using System.Collections.Generic;
using System.Text;

namespace belajarUTS
{
    public class BukuFiksi : Buku
    {
        public string Kategori { get; set; }

        // Disederhanakan menjadi 4 parameter (isPinjam dihapus karena status default-nya diatur di base class)
        public BukuFiksi(string judul, string penulis, int tahunTerbit, string kategori) : base(judul, penulis, tahunTerbit)
        {
            this.Kategori = kategori; // Mengambil nilai dari inputan user
        }

        public override void TampilkanInfo()
        {
            // Menggunakan Properti berhuruf kapital bawaan dari kelas Buku (Base Class)
            string status = isPinjam ? "Dipinjam" : "Tersedia";
            Console.WriteLine($"[Fiksi] Judul: {Judul} | Penulis: {Penulis} | Tahun: {tahunTerbit} | Kategori: {Kategori} | Status: {status}");
        }
    }

    public class BukuNonFiksi : Buku
    {
        public string Kategori { get; set; }

        public BukuNonFiksi(string judul, string penulis, int tahunTerbit, string kategori) : base(judul, penulis, tahunTerbit)
        {
            this.Kategori = kategori;
        }

        public override void TampilkanInfo()
        {
            string status = isPinjam ? "Dipinjam" : "Tersedia";
            Console.WriteLine($"[Non Fiksi] Judul: {Judul} | Penulis: {Penulis} | Tahun: {tahunTerbit} | Kategori: {Kategori} | Status: {status}");
        }
    }

    public class Majalah : Buku
    {
        public string Kategori { get; set; }

        public Majalah(string judul, string penulis, int tahunTerbit, string kategori) : base(judul, penulis, tahunTerbit)
        {
            this.Kategori = kategori;
        }

        public override void TampilkanInfo()
        {
            string status = isPinjam ? "Dipinjam" : "Tersedia";
            // Diperbaiki: sebelumnya tertulis [Non Fiksi], sekarang disesuaikan jadi [Majalah]
            Console.WriteLine($"[Majalah] Judul: {Judul} | Penulis: {Penulis} | Tahun: {tahunTerbit} | Kategori: {Kategori} | Status: {status}");
        }
    }
}
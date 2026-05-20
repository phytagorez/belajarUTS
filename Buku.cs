using System;
using System.Collections.Generic;
using System.Text;

namespace belajarUTS
{
    public abstract class Buku : IPinjam
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int tahunTerbit { get; set; }
        public bool isPinjam { get; set; }


        public Buku(string judul, string penulis, int tahunTerbit)
        {
            this.Judul = judul;
            this.Penulis = penulis;
            this.tahunTerbit = tahunTerbit;
            this.isPinjam = false;
        }

        public abstract void TampilkanInfo();

        public void Pinjam()
        {
            isPinjam = true;
        }

        public void Kembalikan()
        {
            isPinjam = false;
        }
    }
}

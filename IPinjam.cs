using System;
using System.Collections.Generic;
using System.Text;

namespace belajarUTS
{
    public interface IPinjam
    {
        public bool isPinjam { get; set; }
        void Pinjam();
        void Kembalikan();
    }
}

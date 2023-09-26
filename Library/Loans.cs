using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Loans
    {
        public int LoanId { get; set; } // ID peminjaman (unik)
        public int BookId { get; set; }       // ID buku yang dipinjam
        public int MemberId { get; set; }     // ID anggota yang meminjam
        public DateTime LoanDate { get; set; } // Tanggal peminjaman
        public DateTime ReturnDate { get; set; } // Tanggal pengembalian

        // Properti atau field lain yang diperlukan untuk data peminjaman lainnya

        // Konstruktor untuk membuat objek Peminjaman
        public Loans(int memberId, int bookId, DateTime loanDate, DateTime returnDate)
        {
            MemberId = memberId;
            BookId = bookId;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public Loans()
        {
        }
    }
}

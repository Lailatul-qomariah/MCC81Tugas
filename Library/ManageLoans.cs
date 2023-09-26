using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ManageLoans
    {

        //  ('BorrowBook), ('ReturnBook'), (EditLoanStatus'), ('DeleteLoan') & ('GetLoans')
        private LibraryCatalog _bookService;
        private List<Loans> loans = new List<Loans>();
        public static ManageLoans manageLoans = new ManageLoans();
        private int loanIdCounter = 1;

        public ManageLoans () { }
        public ManageLoans(LibraryCatalog book)
        {
            loans = new List<Loans>();
            this._bookService = book;
            loanIdCounter = 1;
        }

        private bool IsBookAlreadyBorrowed(int memberId, int bookId)
        {
            // Periksa apakah anggota sudah meminjam buku ini sebelumnya
            return loans.Any(l => l.MemberId == memberId && l.BookId == bookId);
        }

        private bool IsBookAvailable(int bookId)
        {
            // Cek apakah buku dengan ID yang diminta tersedia dalam daftar buku
            var book = _bookService.FindIsbn(bookId);

            // Lakukan validasi tambahan apakah buku ditemukan atau tidak
            if (book != null)
            {
                // Buku ditemukan, maka kembalikan true
                return true;
            }
            else
            {
                // Buku tidak ditemukan, kembalikan false
                return false;
            }
        }
        public void BorrowBook(int memberId, int bookId)
        {
            // Cek apakah buku sudah dipinjam oleh anggota lain
            if (IsBookAvailable(bookId))
            {
                // Cek apakah anggota sudah meminjam buku ini sebelumnya
                if (!IsBookAlreadyBorrowed(memberId, bookId))
                {
                    Loans newLoan = new Loans
                    {
                        LoanId = loanIdCounter++,
                        MemberId = memberId,
                        BookId = bookId,
                        LoanDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(14) // Contoh: batas waktu pengembalian adalah 14 hari dari tanggal peminjaman
                    };
                    loans.Add(newLoan);
                    Console.WriteLine("Buku berhasil dipinjam.");

                    // Tingkatkan nilai nextLoanId agar sesuai dengan ID berikutnya
                    loanIdCounter++;
                }
                else
                {
                    Console.WriteLine("Anggota sudah meminjam buku ini sebelumnya.");
                }
            }
            else
            {
                Console.WriteLine("Buku tidak tersedia.");
            }
        }

        public void EditLoanStatus(int loanId, DateTime newReturnDate)
        {
            // Cari peminjaman berdasarkan ID peminjaman
            var loan = loans.FirstOrDefault(l => l.LoanId == loanId);

            if (loan != null)
            {
                // Ubah tanggal pengembalian
                loan.ReturnDate = newReturnDate;
                Console.WriteLine("Status peminjaman berhasil diubah.");
            }
            else
            {
                Console.WriteLine("Peminjaman tidak ditemukan.");
            }
        }


        public List<Loans> GetMemberLoans(int memberId)
        {
            return loans.FindAll(l => l.MemberId == memberId);
        }
        public void ViewLoanStatus()
        {
            Console.Write("ID Anggota: ");
            if (int.TryParse(Console.ReadLine(), out int memberId))
            {
                List<Loans> memberLoans = GetMemberLoans(memberId);

                if (memberLoans.Count > 0)
                {
                    Console.WriteLine($"Status Peminjaman untuk Anggota dengan ID {memberId}:");
                    foreach (var loan in memberLoans)
                    {
                        Book book = _bookService.FindIsbn(loan.BookId);
                        Console.WriteLine($"Buku: {book.Tittle}, Pengarang: {book.Author}, Tanggal Peminjaman: {loan.LoanDate}, Tanggal Pengembalian: {loan.ReturnDate}");
                    }
                }
                else
                {
                    Console.WriteLine("Anggota tidak memiliki peminjaman buku.");
                }
            }
            else
            {
                Console.WriteLine("ID Anggota tidak valid.");
            }
        }

        public void DeleteLoan(int loanId)
        {
            // Cari peminjaman berdasarkan ID peminjaman
            var loan = loans.FirstOrDefault(l => l.LoanId == loanId);

            if (loan != null)
            {
                // Hapus peminjaman buku dari daftar peminjaman
                loans.Remove(loan);
                Console.WriteLine("Peminjaman berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Peminjaman tidak ditemukan.");
            }
        }

        public void ViewAllLoans()
        {
            Console.WriteLine("Daftar Seluruh Peminjaman:");

            foreach (var loan in loans)
            {
                Book book = _bookService.FindIsbn(loan.BookId);
                Console.WriteLine($"ID Peminjaman: {loan.LoanId}" +
                    $"\nAnggota: {loan.MemberId}" +
                    $"\nBuku: {book.Tittle}" +
                    $"\nPengarang: {book.Author}" +
                    $"\nTanggal Peminjaman: {loan.LoanDate}" +
                    $"\nTanggal Pengembalian: {loan.ReturnDate}");
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Program
{

    public static void Main(string[] args)
    {
        ErrorHandler errorHandler = new ErrorHandler();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t MENU LIBRARY \t");
            Console.WriteLine("============================================");
            Console.WriteLine("\n1. Manage Book \n2. Manage Member \n3. Manage Loan \n4. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    MenuLibraryBook();
                    break;
                case "2":
                    MenuLibraryMember();
                    break;
                case "3":
                    MenuLibraryLoan();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    errorHandler.InvalInputHandler();
                    break;

            }
        }
    }


    public static void MenuLibraryLoan()
    {
        ErrorHandler errorHandler = new ErrorHandler();
        bool isTrue = true;
        while (isTrue)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t MENU LOAN \t");
            Console.WriteLine("============================================");
            Console.WriteLine("\n1. Create Data Loan \n2. Delete Loan \n3. Update Loan  \n4. View Status Loan \n5. Exit");
            Console.Write("Input : ");
            string inpMenu = Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE LOAN \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Id Peminjam :");
                    string idPeminjam = Console.ReadLine();
                    Console.Write("Masukkan Id Buku     :");
                    string bookId = Console.ReadLine();

                    if (errorHandler.TryParseInt(idPeminjam, out int idLoan) && errorHandler.TryParseInt(bookId, out int idBook))
                    {
                        ManageLoans.manageLoans.BorrowBook(idLoan, idBook);
                    }
                    else
                    {
                        errorHandler.InvalInputHandler();
                    }
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE LOAN \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan ID Peminjaman yang akan dihapus: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteLoanId))
                    {
                        ManageLoans.manageLoans.DeleteLoan(deleteLoanId);
                    }
                    else
                    {
                        Console.WriteLine("ID Peminjaman tidak valid.");
                    }
                    
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t EDIT LOAN \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan ID Peminjaman yang akan diedit: ");
                    if (int.TryParse(Console.ReadLine(), out int editLoanId))
                    {
                        Console.Write("Masukkan Tanggal Pengembalian Baru (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newReturnDate))
                        {
                            ManageLoans.manageLoans.EditLoanStatus(editLoanId, newReturnDate);
                        }
                        else
                        {
                            Console.WriteLine("Tanggal tidak valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID Peminjaman tidak valid.");
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t STATUS LOAN \t");
                    Console.WriteLine("============================================");
                    ManageLoans.manageLoans.ViewLoanStatus();
                    Console.ReadLine();
                    break;
                case "5":
                    isTrue = false;
                    break;
                    
                default:
                    errorHandler.InvalInputHandler();
                    break;
            }

        }

    }

    public static void MenuLibraryBook()
    {
        ErrorHandler errorHandler = new ErrorHandler();
        bool isTrue = true;
        while (isTrue)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t MENU LIBRARY \t");
            Console.WriteLine("============================================");
            Console.WriteLine("\n1. Create Data Book \n2. Delete Book \n3. Update Book \n4. View Book \n5. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Judul Buku      :");
                    string tittle = Console.ReadLine();
                    Console.Write("Masukkan Nama Penulis    :");
                    string author = Console.ReadLine();
                    Console.Write("Masukkan No ISBN Buku    :");
                    string noBuku = Console.ReadLine();

                    if (errorHandler.TryParseInt(noBuku, out int noISBN))
                    {
                        LibraryCatalog.catalog.AddBook(new Book(tittle, author, noISBN)); //manggil method di catalog
                    }
                    else
                    {
                        errorHandler.InvalInputHandler();
                    }
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No ISBN Buku :");
                    string noBukuDel = Console.ReadLine();
                    if (errorHandler.TryParseInt(noBukuDel, out int delBook))
                    {
                        Book bookToDelete = LibraryCatalog.catalog.FindIsbn(delBook);
                        LibraryCatalog.catalog.RemoveBook(bookToDelete);
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t EDIT BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No ISBN yang ingin di Edit :");
                    int searchBook = int.Parse(Console.ReadLine());
                    LibraryCatalog.catalog.UpdateBook(searchBook);
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW BOOK \t");
                    Console.WriteLine("============================================");
                    LibraryCatalog.catalog.ListBook();
                    Console.ReadLine();
                    break;
                case "5":
                    isTrue = false;
                    break;
                    
                default:
                    errorHandler.InvalInputHandler();
                    break;
            }

        }

    }



    public static void MenuLibraryMember()
    {
        ErrorHandlerMember errorHandler = new ErrorHandlerMember();
        bool isTrue = true;
        while (isTrue)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t KEANGGOTAAN LIBRARY \t");
            Console.WriteLine("============================================");
            Console.WriteLine("\n1. Create Data Member \n2. Delete Member \n3. Update Member \n4. View Member \n5. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE ANGGOTA \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Nama Member :");
                    string name = Console.ReadLine();
                    Console.Write("Masukkan Alamat   :");
                    string address = Console.ReadLine();
                    ManageMember.manageMember.AddMember(new Member(name, address));
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE ANGGOTA\t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Nomor Keanggotaan :");
                    string noMember = Console.ReadLine();
                    if (errorHandler.TryParseInt(noMember, out int delMember))
                    {
                        Member memberToDelete = ManageMember.manageMember.FindId(delMember);
                        ManageMember.manageMember.RemoveBook(memberToDelete);
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t EDIT BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No Keanggotaan yang ingin di Edit :");
                    int searchMember = int.Parse(Console.ReadLine());
                    ManageMember.manageMember.UpdateBook(searchMember);
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW ANGGOTA \t");
                    Console.WriteLine("============================================");
                    ManageMember.manageMember.ListMember();
                    Console.ReadLine();
                    break;
                case "5":
                    isTrue = false;
                    break;
                    
                default:
                    errorHandler.InvalInputHandler();
                    break;
            }

        }

    }




}



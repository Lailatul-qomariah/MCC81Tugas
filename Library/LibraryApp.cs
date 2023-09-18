

using System;
using System.Collections.Generic;

namespace Library;

public class LibraryApp
{
    public static void Main(string[] args)
    {
        MenuLibrary();
    }


    public static void MenuLibrary()
    {
        ErrorHandler errorHandler = new ErrorHandler();
        //LibraryCatalog catalog = new LibraryCatalog();
        //LibraryCatalog.catalog.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", 1937,2173247));
        while (true)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("\t MENU LIBRARY \t");
            Console.WriteLine("==========================");
            Console.WriteLine("\n1. Create Data Book \n2. Delete Book \n3. Search Book \n4. View Book \n5. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();

            switch (inpMenu)
            {
                case "1":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Judul Buku      :");
                    string tittle = Console.ReadLine();
                    Console.Write("Masukkan Nama Penulis    :");
                    string author = Console.ReadLine();
                    Console.Write("Masukkan No ISBN Buku    :");
                    string noBuku = Console.ReadLine();
                    Console.Write("Masukkan Tahun Publikasi :");
                    string tahun = Console.ReadLine();

                    if (errorHandler.TryParseInt(tahun, out int publishYear) && errorHandler.TryParseInt(noBuku, out int noISBN))
                    {
                        LibraryCatalog.catalog.AddBook(new Book(tittle, author, publishYear, noISBN)); //manggil method di catalog
                    }
                    else
                    {
                        errorHandler.InvalInputHandler();
                    }
                    
                    Console.ReadLine();



                    break;

                case "2":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No ISBN Buku :");
                    int noBukuDel = int.Parse(Console.ReadLine());
                    LibraryCatalog.catalog.RemoveBook(noBukuDel);
                    break;

                case "3":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t SEARCH BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Keyword yang ingin dicari :");
                    string searchBook = Console.ReadLine();
                    LibraryCatalog.catalog.FindBook(searchBook);
                    break;

                case "4":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW BOOK \t");
                    Console.WriteLine("============================================");
                    LibraryCatalog.catalog.ShowListBook();

                    break;
                case "5":
                    Environment.Exit(0);
                    break;
            }

        }

    }
}



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
        
        LibraryCatalog library = new LibraryCatalog();
        library.AddBook("kita", "ria", 2022, "1234567891");
        library.AddBook("Pra", "ria", 2023, "1234567892");

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
                    Console.Write("Masukkan Tahun Publikasi :");
                    if (int.TryParse(Console.ReadLine(), out int publishYear)) 
                    {
                        Console.Write("Masukkan No ISBN Buku    :");
                        string noBuku = Console.ReadLine();
                        library.AddBook(tittle, author, publishYear, noBuku);
                    } else
                    {
                        Console.WriteLine("\nInvalid Publish Year Format!\n");
                    }
                    break;

                case "2":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No ISBN Buku :");
                    string noBukuDel = Console.ReadLine();
                    library.RemoveBook(noBukuDel);
                    break;

                case "3":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t SEARCH BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Keyword yang ingin dicari :");
                    string searchBook = Console.ReadLine();
                    library.FindBook(searchBook);
                    break;

                case "4":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW BOOK \t");
                    Console.WriteLine("============================================");
                    library.ShowListBook();

                    break;
                case "5":
                    Environment.Exit(0);
                    break;
            }

        }

    }
}

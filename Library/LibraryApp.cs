

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Library;

public class LibraryApp
{
    public static void Main(string[] args)
    {
        MenuLibrary();
    }


    public static void MenuLibrary()
    {
        
        LibraryCatalog catalog = new LibraryCatalog();
        
        Book newBooks = new Book();
        while (true)

        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t MENU LIBRARY \t");
            Console.WriteLine("============================================");
            Console.WriteLine("\n1. Create Data Book \n2. Delete Book \n3. Search Book \n4. View Book \n5. Exit");
            Console.Write("Input : ");
            string inpMenu = Console.ReadLine();
            //Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Judul Buku              :");
                    newBooks.Tittle= Console.ReadLine();
                    Console.Write("Masukkan Nama Penulis            :");
                    newBooks.Author= Console.ReadLine();
                    Console.Write("Masukkan Tahun Publikasi 4 digit :");
                    bool yearInput = false;
                    string pattern = @"^\d{4}$"; // Validasi tahun harus 4 digit.
                    do
                    {
                        string inpYear = Console.ReadLine();
                        if (Regex.IsMatch(inpYear, pattern))
                        {
                            newBooks.PublishYear = int.Parse(inpYear);
                            yearInput = true;
                        }
                        else
                        {
                            ErrorHandler.HandleError("Invalid input. The year of publication must be a 4-digit number.");
                        }
                    } while (!yearInput);
                    
                    catalog.AddBook(newBooks);
                    Console.WriteLine("Book data has been successfully added!!");
                    Console.ReadLine();

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Judul Buku :");
                    string noBukuDel = Console.ReadLine();
                    catalog.RemoveBook(noBukuDel);
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t SEARCH BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Keyword yang ingin dicari :");
                    string searchBook = Console.ReadLine();
                    catalog.FindBook(searchBook);
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW BOOK \t");
                    Console.WriteLine("============================================");
                    catalog.ShowListBook();
                    Console.ReadLine();

                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    ErrorHandler.HandleError("Invalid Menu Option.");
                    Console.ReadLine();
                    break;
            }

        }

    }
}

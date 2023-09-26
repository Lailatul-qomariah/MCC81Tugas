using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    public class LibraryCatalog
    {
        //Alhamdulillah selesai 
        List<Book> booksks = new List<Book>();
        public static LibraryCatalog catalog = new LibraryCatalog();
        ErrorHandler errorHandler = new ErrorHandler();


        public void AddBook(Book book)
        {
            if (!errorHandler.HandleBookError(book.Tittle, book.Author, book.NoISBN))
            {
                return;
            }
            booksks.Add(book);
            Console.WriteLine("Book data has been successfully added!!");

        }

        public void UpdateBook(int inpUpdate)
        {
            Book idUpdate = FindIsbn(inpUpdate);
            Book bookEdit = booksks.FirstOrDefault(u => u.NoISBN == inpUpdate);
            if (bookEdit != null)
            {
                Console.Write("New Title Name  : ");
                bookEdit.Tittle= Console.ReadLine();

                Console.Write("New Author Name : ");
                bookEdit.Author= Console.ReadLine();

                Console.Write("New ISBN Number : ");
                bookEdit.NoISBN = int.Parse(Console.ReadLine());
    
            } 

        }

        public Book FindIsbn(int noBuku)
        {
            var book = booksks.FirstOrDefault(b => b.NoISBN == noBuku);

            if (book == null)
            {
                Console.WriteLine($"Buku dengan nomor ISBN {noBuku} tidak ditemukan.");
            }
            else
            {
                Console.WriteLine($"Buku ditemukan: {book.Tittle}");
            }

            return book;

        }

        public void RemoveBook(Book book)
        {
            
            if (booksks.Contains(book))
            {
                booksks.Remove(book);
                Console.WriteLine("Book data has been successfully deleted!!");
            }
            else
            {
                errorHandler.HandleBookNotDelete();
            }
        }
        public void ListBook()
        {
            ShowListBook(booksks);
        }
        public void FindBook(string title)
        {
            //search berdasarkan tittle, author, publisher dan ISBN
            var findBook = booksks.Where
                (b => Regex.IsMatch(b.Tittle, title, RegexOptions.IgnoreCase)).ToList();

            if (findBook.Count == 0)
            {
                errorHandler.HandleSearchNotFound();
            }
            else
            {
                ShowListBook(findBook);
            }
        }
        public void ShowListBook(List<Book> bookList) //parameter menggunakan list 
        {

            foreach (var listBook in bookList)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"" +
                    $"\nJudul Buku          : {listBook.Tittle} " +
                    $"\nPenulis             : {listBook.Author} " +
                    $"\nNomor ISBN          : {listBook.NoISBN}");
                Console.WriteLine("--------------------------------------------");

            }
        }

    }
}

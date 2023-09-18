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
        List<Book> booksks = new List<Book>();
        public static LibraryCatalog catalog = new LibraryCatalog();

        public void AddBook(Book book)
        {
            
            booksks.Add(book);
            Console.WriteLine("Book data has been successfully added!!");

        }



       /* public List<Book> FindBooksByKeyword(string keyword)
        {
            // Menggunakan ToLowerInvariant() untuk memastikan pencarian tanpa memperhatikan besar huruf.
            keyword = keyword.ToLowerInvariant();

            List<Book> foundBooks = books
                .Where(book => book.Tittle.ToLowerInvariant().Contains(keyword))
                .ToList();

            return foundBooks;
        }

        public Book FindBook(string title)
        {
            return books.FirstOrDefault(book => book.Tittle.Equals(title, StringComparison.OrdinalIgnoreCase));
        }*/



       /* public void ShowAllBook()
        {
            ShowBook(books);
        }

        public void ShowBook(List<Book> booksToShow)
        {
        
            if (booksToShow.Count == 0)
            {
                Console.WriteLine("Tidak ada data buku");
            }

            foreach (Book book in booksToShow)
            {
                Console.WriteLine(book.ToString() + "\n");
            }
        }*/


        public void RemoveBook(int noBuku)
        {
            var bookDelete = booksks.FirstOrDefault(b => b.NoISBN == noBuku); //mencocokkan dan mengambil objek berdasarkan no buku / ISBN
            if (bookDelete != null)
            {
                booksks.Remove(bookDelete);
                Console.WriteLine("Book data has been successfully deleted!!");
            }
            else
            {
                Console.WriteLine("Invalid ISBN number. Book not found!!");
            }
        }







        public void FindBook(string searchBook)
        {
            //search berdasarkan tittle, author, publisher dan ISBN
            var findBook = booksks.Where
                (b => Regex.IsMatch(b.Tittle, searchBook, RegexOptions.IgnoreCase)).ToList();

            if (findBook.Count == 0)
            {
                Console.WriteLine("There are no books that match the keywords given!");
            }
            else
            {
                ListBook(findBook);
            }
        }

        public void ListBook(List<Book> bookList) //parameter menggunakan list 
        {
            
            foreach (var listBook in bookList)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"" +
                    $"\nJudul Buku          : {listBook.Tittle} " +
                    $"\nPenulis             : {listBook.Author} " +
                    $"\nTahun Terbit        : {listBook.PublishYear}"+
                    $"\nNomor ISBN          : {listBook.NoISBN}");
                Console.WriteLine("--------------------------------------------");

            }
        }

        public void ShowListBook()
        {
            ListBook(booksks);
        }


    }
}

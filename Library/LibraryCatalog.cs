using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryCatalog
    {
        List<Book> bookList = new List<Book>();
        
        ErrorHandler errorHandl = new ErrorHandler();
        
        public void AddBook(string tittle, string author, string publishYear, string noBuku)
        {   //pengecekan apakah inputan kosong atau berisi spasi saja
            if (string.IsNullOrWhiteSpace(tittle) || string.IsNullOrWhiteSpace(author) || 
                string.IsNullOrWhiteSpace(publishYear) || string.IsNullOrWhiteSpace(noBuku))
            {
                Console.WriteLine("Data cannot be empty!. Make sure all columns are filled in!");
                return;
            }
            //cek apakah input publishyear dan isbn/no buku sesuai dengan valisasinya
            if (!errorHandl.ValidatePubYear(publishYear) || !errorHandl.validateIsbn(noBuku))
            {
                Console.WriteLine("\nInvalid Publish Year or ISBN Number Format!\n");
                return;
            }
            //cek apakah no isbn yg dimasukkan sama dengan no ISBN yang sudah ada
            if (bookList.Any(b => b.NoISBN == noBuku))
            {
                Console.WriteLine("\nISBN number is already in use!!!");
                return;
            }
            Book bookObj = new Book(tittle, author, publishYear, noBuku);
            bookList.Add(bookObj); //menambahkan objek ke dalam book list
            Console.WriteLine("Book data has been successfully added!!");

        }

        public void RemoveBook(string noBuku)
        {
            var bookDelete = bookList.FirstOrDefault(b => b.NoISBN == noBuku); //mencocokkan dan mengambil objek berdasarkan no buku / ISBN
            if (bookDelete != null)
            {
                bookList.Remove(bookDelete);
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
            var findBook = bookList.Where
                (b => Regex.IsMatch(b.Tittle, searchBook, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(b.Author, searchBook, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(b.PublishYear, searchBook, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(b.NoISBN, searchBook, RegexOptions.IgnoreCase)).ToList();

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
            ListBook(bookList);
        }


    }
}

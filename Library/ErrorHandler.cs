using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Library
{
    public class ErrorHandler
    {
        List<Book> books = new List<Book>();

        public bool validateIsbn(int noBuku)
        {
            string cekNoBuku = noBuku.ToString();
            if (Regex.IsMatch(cekNoBuku, @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$"))
            {
                return true;
            }
            return false;

        }

        public bool ValidatePubYear(int publishYear)
        {
            string cekYear = publishYear.ToString();
            if (Regex.IsMatch(cekYear, @"^\d{4}$"))
            {
                // Konversi input menjadi angka untuk memeriksa rentang tahun yang valid
                int year = int.Parse(cekYear);

                // Batasan tahun yang valid, misalnya 1900 hingga 2023
                int minYear = 1900;
                int maxYear = 2023;

                if (year >= minYear && year <= maxYear)
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public void InvalInputHandler()
        {
            Console.WriteLine("\nInvalid input!!!, please enter the data correctly!");
        }

        public void HandleBookNotDelete()
        {
            Console.WriteLine("Invalid ISBN number. Book not found!!");
        }

        public void HandleSearchNotFound()
        {
            Console.WriteLine("\nThere are no books that match the keywords given!!");
        }

        public bool HandleBookError(string title, string author, int noBuku)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || noBuku == 0)
            {
                Console.WriteLine("\nData cannot be empty!. Make sure all columns are filled in!");
                return false; // Jika input tidak valid, keluar dari metode.
            }

            if ( !validateIsbn(noBuku))
            {
                Console.WriteLine("\nISBN  must contain exactly 10 or 13 digits");
                return false;
            }
            //cek apakah no isbn yg dimasukkan sama dengan no ISBN yang sudah ada
            if (books.Any(b => b.NoISBN == noBuku))
            {
                Console.WriteLine("\nISBN number is already in use!!!");
                return true;
            }
            return true;

        }



    }
}

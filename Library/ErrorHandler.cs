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
        LibraryCatalog catalog = new LibraryCatalog();

        public bool validateIsbn(string noBuku)
        {

            if (Regex.IsMatch(noBuku, @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$"))
            {
                return true;
            }
            return false;

        }

        public bool ValidatePubYear(string publishYear)
        {

            if (Regex.IsMatch(publishYear, @"^\d{4}$"))
            {
                // Konversi input menjadi angka untuk memeriksa rentang tahun yang valid
                int year = int.Parse(publishYear);

                // Batasan tahun yang valid, misalnya 1900 hingga 2099
                int minYear = 1900;
                int maxYear = 2023;

                if (year >= minYear && year <= maxYear)
                {
                    return true;
                }
                Console.WriteLine("Input cannot be later than 2023 and less than 1900");
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

        public void HandleBookNotFound()
        {
            Console.WriteLine("\nBuku tidak ditemukan, Coba Lagi !");
        }

        public void HandleSearchNotFound()
        {
            Console.WriteLine("\nTidak ada book yang cocok dengan kata kunci yang diberikan !");
        }

        public bool HandleBookError(string title, string author, int publicationYear, int publishYear, int noBuku)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || publicationYear == 0)
            {
                Console.WriteLine("\nData cannot be empty!. Make sure all columns are filled in!");
                return false; // Jika input tidak valid, keluar dari metode.
            }
            if (ContainsDigits(author))
            {
                Console.WriteLine("\nJudul dan penulis tidak boleh mengandung angka !\n");
                return false; // Input mengandung angka, kembalikan false.
            }

           /* if (!ValidatePubYear(publishYear) || !validateIsbn(noBuku))
            {
                Console.WriteLine("\nInvalid Publish Year or ISBN Number Format!\n");
                return;
            }
            //cek apakah no isbn yg dimasukkan sama dengan no ISBN yang sudah ada
            if (bookList.Any(b => b.NoISBN == noBuku))
            {
                Console.WriteLine("\nISBN number is already in use!!!");
               */ /*return;*/

            return true;
        }
            

        private bool ContainsDigits(string input)
        {
            // Menggunakan regex untuk mencari angka dalam string
            return Regex.IsMatch(input, @"\d");
        }


    }
}

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
       public bool validateIsbn(string noBuku)
        {
            
            if (Regex.IsMatch(noBuku, @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")) //pattern untuk isbn pola 10 dan 13
            {
                return true;
            }
            return false;

        }

        public bool ValidatePubYear(string publishYear)
        {
              
                if (Regex.IsMatch(publishYear, @"^\d{4}$")) // pattern untuk tahun adalah 4 angka
                {
                    // Konversi inputan to int
                    int year = int.Parse(publishYear);

                    // Batasan tahun yang valid
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

    }
}

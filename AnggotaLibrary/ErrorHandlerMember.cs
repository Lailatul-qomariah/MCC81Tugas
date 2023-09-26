using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AnggotaLibrary
{
    public class ErrorHandlerMember
    {



        public bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        public void InvalInputHandler()
        {
            Console.WriteLine("\nInvalid input!!!, please enter the data correctly!");
        }

        public void HandlerMemberNotFound()
        {
            Console.WriteLine("Invalid Member number. Member not found!!");
        }

       

        public bool HandleMemberError(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("\nData cannot be empty!. Make sure all columns are filled in!");
                return false; // Jika input tidak valid, keluar dari metode.
            }

            return true;

        }



    }
}

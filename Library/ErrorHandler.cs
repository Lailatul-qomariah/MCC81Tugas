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
       
        public static void HandleError(string errorMessage)
        {
            Console.WriteLine($"Error: {errorMessage}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public string Tittle { get; set; }
        public string Author { get; set; }
        public int NoISBN { get; set; }
       
        public Book(string tittle, string author, int NoBuku)
        {
            Tittle = tittle;
            Author = author;
            NoISBN = NoBuku;
        }
    }



}

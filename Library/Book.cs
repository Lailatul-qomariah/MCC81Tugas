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
        public int PublishYear { get; set; }
       // public string NoISBN { get; set; }

        public Book() { }
        public Book(string tittle, string author, int publishYear)
        {
            Tittle = tittle;
            Author = author;
            PublishYear = publishYear;
            //NoISBN = NoBuku;
        }
    }



}

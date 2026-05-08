using ConsoleApp1.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public class SortBookByGenre : IComparer
    {
        public bool IsAscending { get; set; } = true;
        public int Compare(object x, object y)
        {
            Book book1 = x as Book;
            Book book2 = y as Book;
            return book1.Genre.CompareTo(book2.Genre)*(IsAscending?1:-1);
        }
    }
}

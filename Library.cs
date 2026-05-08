using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Classes
{
    public class Library
    {
        public List<LibraryItem> Items { get; set; } = new List<LibraryItem>();
        public void AddItem(LibraryItem item)
        {
            Items.Add(item);
        }
        public void BorrowItem(Member member, LibraryItem item)
        {
            if (Items.Contains(item))
            {
                member += item; 
                Items.Remove(item);  
                Console.WriteLine($"{item.Title} has been borrowed" );
            }
            else
            {
                throw new InvalidOperationException($"{item.Title} is not available.");
            }
        }
        public void ReturnItem(Member member, LibraryItem item)
        {
           
            member -= item; 
            Items.Add(item); 
            Console.WriteLine($"{item.Title} has been returned ");
        }
    }

}

using ConsoleApp1.Classes;
using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           try
            {
                #region creating instances
                Book book1 = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10),14,new DateTime(2025,1,3), Genre.Fiction);
                Book book2 = new Book(2, "1984", "George Orwell", new DateTime(1949, 6, 8), 21, new DateTime(2025, 1, 4), Genre.SciFi);
                Book book3 = new Book(3, "The Catcher in the Rye", "J.D. Salinger", new DateTime(1951, 7, 16), 30, new DateTime(2025, 1, 12), Genre.Fiction);

                Magazine Magazine1 = new Magazine(Frequency.weekly, 4, "Dracula", "John Snow", new DateTime(2000, 4, 10), 13, new DateTime(2025, 1, 3), Genre.Mystery);
                Magazine Magazine2 = new Magazine(Frequency.monthly, 5, "Castle", "John Smith", new DateTime(2010, 5, 12), 10, new DateTime(2025, 1, 11), Genre.Fantasy);

                Comic comic1 = new Comic(6, "Haunted Manor", "Sarah Lee", new DateTime(2018, 10, 5), 13, new DateTime(2025, 1, 3), Genre.Mystery);
                Comic comic2 = new Comic(7, "The Time Traveler", "Chris Evans", new DateTime(2020, 12, 25), 10, new DateTime(2024, 12, 25), Genre.Science);
                #endregion
                #region checking items due

                ArrayList items = new ArrayList { book1, book2, book3,Magazine1,Magazine2,comic1,comic2};

                Console.WriteLine("Check if items are due: \n");

                foreach(LibraryItem item in items)
                {
                    item.IsItemDue();
                }
                #endregion

                #region outputting books before sort

                Console.WriteLine("*******************");

                ArrayList books = new ArrayList { book1, book2, book3};

                foreach (Book book in books) 
                {
                    Console.WriteLine(book);
                }

                #endregion

                Console.WriteLine("*******************");

                #region Books sorted by genre

                books.Sort(new SortBookByGenre());

                Console.WriteLine("Books sorted by genre:");

                foreach (Book book in books)
                {
                    Console.WriteLine(book);
                }
                #endregion

                #region comparing magazines 

                Console.WriteLine("*******************");

                Console.WriteLine("Comparing magazine frequencys:");

                if(Magazine1.Equals(Magazine2))
                {
                    Console.WriteLine("They have same frequency!");
                }
                else
                {
                    Console.WriteLine("They do not have same frequency");
                }
                #endregion


                #region creating members
                Member member1 = new Member("Nikoloz Gabidauri", 101,true);
                Member member2 = new Member("Davit Shotadze", 701, false);
                Member member3 = new Member("Elene Kartvelishvili", 666, true);
                #endregion

                #region members borrowing items

                Console.WriteLine("*******************");

                member1 += book1;
                member1 += Magazine2;
                member1 += comic1;

                member2 += comic2;
                member2 += Magazine1;

                member3 += book2;
                member3 += book3;
               
                #endregion

                #region viewing borrowed items 

                Console.WriteLine("*******************");

                Console.WriteLine("Items borrowed:");
                member1.ViewBorrowedItems();

                member2.ViewBorrowedItems();

                member3.ViewBorrowedItems();
                #endregion



                #region members returning items
                Console.WriteLine("*******************");

                Console.WriteLine("Items returned:");
                member1 -= book3;
                member1 -= book1;
                member2 -= Magazine1;
                member3 -= book3;
                #endregion


                #region checking for status

                Console.WriteLine("*******************");

                Console.WriteLine("Check for membership status:");
                Console.WriteLine($"Nika's Membership: {member1[member1.MemberID]}");
                Console.WriteLine($"Davit's Membership: {member2[member2.MemberID]}");
                Console.WriteLine($"Elene's Membership: {member3[member3.MemberID]}");

                #endregion
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.ReadKey();
            }
        }
    }
}

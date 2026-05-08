using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Classes
{
    public class Magazine : LibraryItem,IEquatable<Magazine>
    {
        public Frequency Frequency { get; set; }

        public Magazine(Frequency frequency, int id,  string title, string author, DateTime publicationDate, int durationInDays, DateTime borrowTime, Genre genre)
        {
            this.Frequency = frequency;
            this.ID = id;
           
            this.Title = title;
            this.Author = author;
            this.PublicationDate = publicationDate;
            this.DurationInDays = durationInDays;
            this.BorrowTime = borrowTime;
            this.Genre = genre;
        }
        public override int IsItemDue()
        {
            DateTime today = DateTime.Now;
            DateTime dueDate = BorrowTime.AddDays(DurationInDays);

            if (today > dueDate)
            {
                int overdueDays = (today - dueDate).Days;
                int finePerDay = 3;
                int fine = overdueDays * finePerDay;

                Console.WriteLine($"You did not return the magazine on time. You are overdue by {overdueDays} days.");
                Console.WriteLine($"You will be fined: {fine} Gel");
                return fine;
            }
            else
            {
                Console.WriteLine("The magazine  is not overdue.");
                return 0;
            }
        }
        public override string ToString()
        {
            return $"Magazine  ID: {ID}\n" +
             $"Title: {Title}\n" +
             $"Author: {Author}\n" +
             $"Publication Date: {PublicationDate.ToShortDateString()}\n" +
             $"Duration (in days): {DurationInDays}\n" +
             $"Borrow Time: {BorrowTime.ToShortDateString()}\n" +
             $"Genre: {Genre}\n"+
             $"frequency: {Frequency}";
        }
        public bool Equals(Magazine other)
        {
            return this.Frequency.Equals(other.Frequency);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
   public  class Member
   {
        private Dictionary<int,bool>MembershipStatuses=new Dictionary<int,bool>();
        public Dictionary<int, List<LibraryItem>> BorrowedItems { get; set; }
        public string Name { get; set; }
        public int MemberID { get; set; }
        public bool MembershipStatus {  get; private set; }

        public Member(string name, int memberID, bool membershipStatus)
        {
            Name = name;
            MemberID = memberID;
            BorrowedItems = new Dictionary<int, List<LibraryItem>>();
            if (membershipStatus)
            {
                MembershipStatuses[memberID] = true;
            }
        }
        public string this[int id] 
        {
            get
            { 
                
                return MembershipStatuses.TryGetValue(id, out bool status)?"Active":"Inactive";
            }
           
        }
        public static Member operator +(Member member, LibraryItem item)
        {

            if (!member.BorrowedItems.ContainsKey(member.MemberID))
            {
                member.BorrowedItems[member.MemberID] = new List<LibraryItem>();
            }

            member.BorrowedItems[member.MemberID].Add(item);
            Console.WriteLine($"{member.Name} has borrowed: {item.Title}");
            return member;
        }
        public static Member operator -(Member member, LibraryItem item)
        {

            if (member.BorrowedItems.ContainsKey(member.MemberID) &&
                member.BorrowedItems[member.MemberID].Contains(item))
            {

                member.BorrowedItems[member.MemberID].Remove(item);
                Console.WriteLine($"{member.Name} has returned: {item.Title}");
            }
            else
            {
                Console.WriteLine($"{member.Name} hasn't borrowed {item.Title}");
            }
            return member;
        }

        public void ViewBorrowedItems()
        {
            if (BorrowedItems.ContainsKey(MemberID) && BorrowedItems[MemberID].Count > 0)
            {
                Console.WriteLine($"{Name} has borrowed the following items:");
                foreach (var item in BorrowedItems[MemberID])
                {
                    Console.WriteLine($" {item.Title}");
                }
            }
            else
            {
                Console.WriteLine($"{Name} has not borrowed any items.");
            }
        }
   }
}


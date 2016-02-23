//using Database;
//using System;
//using System.Data;
//using System.Linq;
//using System.Data.OleDb;

//namespace DataSeed
//{
//    static class Program
//    {
//        static void Main(string[] args)
//        {
//            bool flag = true;
//            do
//            {
//                Console.Clear();
//                Console.WriteLine("1. Workforce Roster");
//                Console.WriteLine("2. Skills Library");
//                Console.WriteLine("3. Reservation System");
//                Console.WriteLine("4. Procurement System");
//                Console.WriteLine("5. Time Tracking");
//                Console.WriteLine("=====================");
//                Console.Write("Enter your choice: ");
//                string choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": Omega.Seed(); break;
//                    case "2": Alpha.Seed(); break;
//                    case "3": Beta.Seed(); break;
//                    case "4": Charlie.Seed(); break;
//                    case "5": Delta.Seed(); break;
//                    default: flag = false; break;
//                }
//            } while (flag);
//        }
//    }
//}

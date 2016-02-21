//using Database;
//using System;
//using System.Linq;

//namespace DataSeed
//{
//    class Program
//    {

//        static void Main(string[] args)
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List History");
//                Console.WriteLine("2. Insert history");
//                Console.WriteLine("3. Edit history");
//                Console.WriteLine("4. Delete history");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listHistory(); break; }
//                    case "2": { insertHistory(); break; }
//                    case "3": { editHistory(); break; }
//                    case "4": { deleteHistory(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        public static void listHistory()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<History> historyUnit = new Repository<History>();
//                var histories = historyUnit.Get().ToList();
//                foreach (var history in histories)
//                {
//                    Console.WriteLine(history.Id + ": " + history.EventBegin + " - " + history.EventEnd + " - " + history.Asset + " - " + history.Description + " - " + history.Status + " - " + history.Person);
//                }
//            }
//            Console.WriteLine("--------------------");
//        }

//        static void insertHistory()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<History> historyUnit = new Repository<History>();
//                Console.WriteLine();
//                Console.Write("New history entry: ");
//                string historyEventBegin = Console.ReadLine();
//                while (historyEventBegin == "")
//                {
//                    Console.Write("Please enter date of asset procurement : ");
//                    historyEventBegin = Console.ReadLine();
//                }
//                string historyEventEnded = Console.ReadLine();
//                while (historyEventEnded == "")
//                {
//                    Console.Write("Please enter the end date of asset procurement : ");
//                    historyEventEnded = Console.ReadLine();
//                }

//                Console.Write("Status [1 - Active, 2 - Inactive]: ");


//                string status = Console.ReadLine();
//                History history = new History()
//                {
//                    nesto
//                    Status = (HistoryStatus)Convert.ToInt32(status)
//                };
//                historyUnit.Insert(history);
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }

//        static void editHistory()
//        {
//            Console.WriteLine();
//            Console.WriteLine("History ID: ");
//            string hid = Console.ReadLine();
//            if (hid != "")
//            {
//                int id = Convert.ToInt32(hid);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    Repository<History> historyUnit = new Repository<History>();
//                    var history = historyUnit.Get(id);
//                    if (history != null)
//                    {
//                        Console.Write("Edit History type: ");

         
//                string status = Console.ReadLine();
//                History history = new History()
//                {
//                    //nesto
//                    Status = (HistoryStatus)Convert.ToInt32(status)
//                };
//                historyUnit.Insert(history);
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }



// 
//        static void deleteHistory()
//        {
//            Console.WriteLine();
//            Console.WriteLine("History ID: ");
//            string id = Console.ReadLine();
//            int hid = Convert.ToInt32(id);
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<History> historyUnit = new Repository<History>();
//                historyUnit.Delete(hid);
//            }
//            Console.WriteLine("You deleted education: " + id);
//            Console.WriteLine("----------------------");
//        }


//    }
//}

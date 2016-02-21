using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    class Program___Alen
    {
        static void Main(string[] args)
        {
        string choice = "X";
                    do
                    {
                        Console.WriteLine("1. List Requests");
                        Console.WriteLine("2. Insert Request");
                        Console.WriteLine("3. Edit Request");
                        Console.WriteLine("4. Delete Request");
                        Console.WriteLine("9. Return");
                        choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1": { listRequests(); break; }
                            case "2": { insertRequest(); break; }
                            case "3": { editRequest(); break; }
                            case "4": { deleteRequest(); break; }
                        }
                    }
                    while (choice != "9");
                }

              
    public static void listRequests()
        {
    using (SchoolContext context = new SchoolContext())
    {
        Repository<Request> requestUnit = new Repository<Request>();
        var requests = requestUnit.Get().ToList();
        foreach (var request in requests)
        {
            Console.WriteLine(request.Id + ": " + request.requestType + " - " + request.RequestDescription + " - " + request.RequestDate + " - " + request.Status + " - " + request.Asset + " - " + request.User);
        }
    }
    Console.WriteLine("--------------------");
}


    static void insertRequest()
    {
    using (SchoolContext context = new SchoolContext())
    {
        Repository<Request> requestUnit = new Repository<Request>();
        Console.WriteLine();
        Console.Write("New request: ");
        string requestType = Console.ReadLine();
        while (requestType == "")
        {
            Console.Write("Please input the type of the request [1.ITRequest, 2.OfficeRequest] : ");
            requestType = Console.ReadLine();
        }
        string requestMessage = Console.ReadLine();
        while (requestMessage == "")
        {
            Console.Write("Please enter the request message : ");
            requestMessage = Console.ReadLine();
        }

        
       
        

       
        Request request = new Request()
        {
           
           
        };
        requestUnit.Insert(request);
    }
    Console.WriteLine("DONE!");
    Console.WriteLine("--------------------");
}




static void editRequest()
{
    Console.WriteLine();
    Console.WriteLine("Request ID: ");
    string reqId = Console.ReadLine();
    if (reqId != "")
    {
        int id = Convert.ToInt32(reqId);

        using (SchoolContext context = new SchoolContext())
        {
            Repository<Request> requestUnit = new Repository<Request>();
            var request = requestUnit.Get(id);
            if (request != null)
            {
                Console.Write("Edit request status: ");

                Console.Write("Status [1 - Awaiting for approval, 2 - Canceled, 3 - Approved, 4 - Completed, 5 - In Process]: ");
                RequestStatus status = (RequestStatus)Convert.ToInt32(Console.ReadLine());
                request.Status = status;

                requestUnit.Update(request, id);
            }
        }
        Console.WriteLine("DONE!");
        Console.WriteLine("--------------------");
    }
}

static void deleteRequest()
{
    Console.WriteLine();
    Console.WriteLine("Request ID: ");
    string id = Console.ReadLine();
    int reqId = Convert.ToInt32(id);
    using (SchoolContext context = new SchoolContext())
    {
        Repository<Request> requestUnit = new Repository<Request>();
        requestUnit.Delete(reqId);
    }
    Console.WriteLine("You deleted request: " + id);
    Console.WriteLine("----------------------");
}

    }
}

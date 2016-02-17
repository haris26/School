using System;
using System.Collections.Generic;

// PROCUREMENT SYSTEM
namespace Database
{
//  List of procurement/service requests
    public class Request
    {
<<<<<<< HEAD
        public int Id { get; set; }                                 // Identity[1]
        public RequestType requestType { get; set; }                // Request type (procuration ot service)
        public string RequestMessage { get; set; }                  // Description of the request
        public DateTime RequestDate { get; set; }                   // Date of the request
        public RequestStatus Status { get; set; }                   // Status

        //public int AssetId { get; set; }
        public Asset Asset { get; set; }
        //public int EmployeeId { get; set; }
        public Person User { get; set; }

        //public List<Request> requests = new List<Request>();
    }
=======
        public int Id { get; set; }
        public RequestType requestType { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
      //  public string RequestStatus { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }

        public List<Request> requests = new List<Request>();


    }


   
>>>>>>> 6155270056ed97d5e20f0b3dabfc43a72c8c3bc7
}

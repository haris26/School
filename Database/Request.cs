using System;
using System.Collections.Generic;

// PROCUREMENT SYSTEM
namespace Database
{
//  List of procurement/service requests
    public class Request
    {
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
}

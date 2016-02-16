using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Request
    {
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


   
}

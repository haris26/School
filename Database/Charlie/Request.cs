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
        public string RequestMessage { get; set; }                  // Message(detailed description) of the request
        public string RequestDescription { get; set; }              //Short description(like subject in messages) 
        public DateTime RequestDate { get; set; }
        public DateTime? CompletedRequestDate { get; set; }  // Date of the request
        public RequestStatus Status { get; set; }                   // Status
        public int Quantity { get; set; }
        public virtual AssetCategory AssetCategory { get; set; }
        public AssetType AssetType { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Person User { get; set; }
        public ServiceType ServiceType { get; set; }
    }


}

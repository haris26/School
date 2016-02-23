using System;

// PROCUREMENT SYSTEM
namespace Database
{
//  History of asset
    public class History
    {
        public int Id { get; set; }                     // Identity[1]
        // public int AssetID { get; set; }    
        public Asset Asset { get; set; }                // Navigation to Asset instead of AssetId
        public DateTime EventBegin { get; set; }        // History record from...
        public DateTime EventEnd { get; set; }          // History record to...
        public string Description { get; set; }         // Description of the activity
        //public enum Status { Done=1, Processing=2}
        public HistoryStatus Status { get; set; }       // Status of the activity

        public Person Person { get; set; }              // Person involved in the activity
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

// PROCUREMENT SYSTEM
namespace Database
{
//  History of asset
    public class History
    {
        public History()
        {
        }
        public int Id { get; set; }                     // Identity[1]   
       
        public virtual Asset Asset { get; set; }                // Navigation to Asset instead of AssetId
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventBegin { get; set; }        // History record from...
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EventEnd { get; set; }          // History record to...
        public string Description { get; set; }         // Description of the activity
        //public enum Status { Done=1, Processing=2}
        public HistoryStatus Status { get; set; }       //

        public virtual Person Person { get; set; }              

       
    }
}

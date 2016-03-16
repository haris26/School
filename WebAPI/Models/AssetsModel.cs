using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AssetsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User { get; set; }
        public string UserName { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Vendor { get; set; }
        public double Price { get; set; }
        public DateTime DateOfTrade { get; set; }
        public string Status { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
       

    }



}
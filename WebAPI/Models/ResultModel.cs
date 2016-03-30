using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ResultModel
    {
        public ResultModel()
        {
            ExactMatches = new List<EmployeeResultModel>();
            CloseMatches = new List<EmployeeResultModel>();
        }

        public IList<EmployeeResultModel> ExactMatches { get; set; }    
        public IList<EmployeeResultModel> CloseMatches { get; set; }   
    }
}
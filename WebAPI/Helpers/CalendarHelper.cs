//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Database;
//using WebAPI.Models;
//using WebAPI.Controllers;

//namespace WebAPI.Helpers
//{
//    public class CalendarHelper
//    {
//        MonthDetail(MonthWork monthwork)
//        {
//            SchoolContext context = new SchoolContext();
//            Day day = new Day();
//            MonthModel1 model = new MonthModel1();

//            var monthDetail = new DayUnit(context).Get()
//                .Where(x => (x.Date == MonthWork.Day))
//                .FirstOrDefault();

//            day = day.Date;
//            model.Id = day.Id;
//            model.Date = day.Date;

//            return monthwork;


        
//    }


//}
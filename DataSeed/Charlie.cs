﻿using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DataSeed
{
    static class Charlie
    {
        static string sourceData = Utility.sourceRoot + "charlie.xls";
        static SchoolContext context = new SchoolContext();

        public static void Seed()
        {
            //getCategories();            // assetCategory
            //getCharacteristicNames();   // assetCharacteristicNames
            //getAssets();                // assets
            //getCharacteristics();       // assetChar

            getRequests();              // request
            //getHistory();               // historyR

            Console.ReadKey();
        }

        static void getCategories()
        {
            Console.Write("CATEGORIES: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "AssetCategory");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                AssetCategory category = new AssetCategory()
                {
                    CategoryName = Utility.getString(row, 0)
                };
                N++;
                context.AssetCategory.Add(category);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getCharacteristicNames()
        {
            Console.Write("CHARACTERISTICS NAMES: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "AssetCharacteristicNames");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string catName = Utility.getString(row, 0);
                AssetCategory resource = context.AssetCategory.FirstOrDefault(x => x.CategoryName == catName);

                AssetCharacteristicNames characteristic = new AssetCharacteristicNames()
                {
                    AssetCategory = resource,
                    Name = Utility.getString(row, 1)
                };
                N++;
                context.AssetCharNames.Add(characteristic);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getAssets()
        {
            Console.Write("ASSETS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Asset");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string catName = Utility.getString(row, 2);
                AssetCategory category = context.AssetCategory.Where(x => x.CategoryName == catName).FirstOrDefault();
                string perName = Utility.getString(row, 7);
                Person person = context.People.Where(x => x.FirstName == perName).FirstOrDefault();

                Asset resource = new Asset()
                {
                    AssetCategory = category,
                   Name = Utility.getString(row, 0),
                    Vendor = Utility.getString(row, 1),
                    Model = Utility.getString(row, 3),
                    SerialNumber = Utility.getString(row, 4),
                    Price = Utility.getDouble(row, 5),
                    Status = (AssetStatus)Enum.Parse(typeof(AssetStatus), row.ItemArray.GetValue(6).ToString()),  
                    User = person,
                   
                    DateOfTrade = Utility.getDate(row,8),
                   
                    // Type = (AssetType)Utility.getInteger(row, 0)
                };
                N++;
                context.Assets.Add(resource);

            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getCharacteristics()
        {
            Console.Write("CHARACTERISTICS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "AssetChar");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string resName = Utility.getString(row, 2);

              //  int id = Utility.getInteger(row, 2);
               // Asset asset = context.Assets.Where(x => x.Id == id).FirstOrDefault();
                Asset asset = context.Assets.Where(x => x.Model == resName).FirstOrDefault();

                AssetChar characteristic = new AssetChar()
                {
                    Asset = asset,
                    Name = Utility.getString(row, 0),
                    Value = Utility.getString(row, 1)
                };
                N++;
                context.AssetCharacteristics.Add(characteristic);

            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getRequests()
        {
            Console.Write("REQUESTS: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "Request");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {


                string asName = Utility.getString(row, 5);
                Asset asset = context.Assets.FirstOrDefault(x => x.Model == asName);
                string perName = Utility.getString(row, 6);

                Person user = context.People.FirstOrDefault(x => x.FirstName == perName);

                Request request = new Request()
                {
                    User = user,
                    Asset = asset,
                    requestType = (RequestType)Utility.getInteger(row, 0),
                    RequestMessage = Utility.getString(row, 1),
                    RequestDescription = Utility.getString(row,2),
                    RequestDate = Utility.getDate(row, 3),
                    Status = (RequestStatus)Utility.getInteger(row, 4)
                };
                N++;
                context.Requests.Add(request);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getHistory()
        {
            Console.Write("HISTORY: ");
            DataTable rawData = Utility.OpenExcel(sourceData, "HistoryR");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                string asName = Utility.getString(row, 4);

                Asset asset = context.Assets.Where(x => x.Model == asName).FirstOrDefault();
    

              
                string perName = Utility.getString(row, 5);
                Person user = context.People.Where(x => x.FirstName == perName).FirstOrDefault();

                History history = new History()
                {
                    Person = user,
                    Asset = asset,
                    Status = (HistoryStatus)Utility.getInteger(row, 3),
                    Description = Utility.getString(row, 2),
                    EventBegin = Utility.getDate(row, 0),
                    EventEnd = Utility.getDate(row, 1)
                };
                N++;
                context.Histories.Add(history);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }
    }
}

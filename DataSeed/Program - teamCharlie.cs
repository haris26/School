using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    class Program
    {
       
        static SchoolContext context = new SchoolContext();


        static Repository<Asset> assets = new Repository<Asset>(context);
        static void Insert()
        {
            Console.WriteLine();
            Console.WriteLine("Vendor: ");
            string vendor = Console.ReadLine();
            double price = Convert.ToDouble(Console.ReadLine());
            string model = Console.ReadLine();
            Console.Write("Tip[1, 2, 3]: ");
            string Tip = Console.ReadLine();
            string serial = Console.ReadLine();

            Asset asset = new Asset()
            {
                Vendor = vendor,
                Price = price,
                SerialNumber = serial,
                Type = (AssetType)Convert.ToInt32(Tip)

            };
            assets.Insert(asset);

        }
       
    }
}
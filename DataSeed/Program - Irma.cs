
//﻿using Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class Program___Irma
//    {

//        static void Main(string[] args)
//        {

//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. Assets");
//                Console.WriteLine("2. Assets Categories");
//                Console.WriteLine("3. Asset Characteristic");


//                Console.WriteLine("9. END PROGRAM");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { assets(); break; }
//                    case "2": { assetCategories(); break; }
//                    case "3": { assetCharacteristic(); break; }


//                }
//            } while (choice != "9");
//        }

//        //________________________________________________________________________________________________________________________________________________________________ 
//        //Asset

//        static void assets()
//        {

//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List all assets");
//                Console.WriteLine("2. List one asset");
//                Console.WriteLine("3. Insert asset");
//                Console.WriteLine("4. Edit asset");
//                Console.WriteLine("5. Delete asset");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listAssets(); break; }
//                    case "2": { listOneAsset(); break; }
//                    case "3": { insertAsset(); break; }
//                    case "4": { editAsset(); break; }
//                    case "5": { deleteAsset(); break; }
//                }
//            }
//            while (choice != "9");
//        }

//        static void listAssets()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Asset> assetUnit = new Repository<Asset>(context);
//                var assets = assetUnit.Get().ToList();
//                foreach (var asset in assets)
//                {

//                    Console.WriteLine(asset.Id + ": " + asset.Vendor + " - " + asset.Type + ": " + asset.Status + ": " + asset.AssetCategory.CategoryName);
//                }
//            }
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }

//        static void listOneAsset()
//        {

//            Console.WriteLine();
//            Console.Write("Enter asset id: ");
//            string a_Id = Console.ReadLine();
//            if (a_Id != "")
//            {
//                int id = Convert.ToInt32(a_Id);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    AssetsUnit assetsUnit = new AssetsUnit(context);
//                    var asset = assetsUnit.Get(id);
//                    if (asset != null)
//                    {
//                        Console.WriteLine(asset.Id + ": " + asset.Vendor + " - " + asset.Type + ": " + asset.Status + ": " + asset.AssetCategory.CategoryName);
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }
//                }
//            }
//        }


//        static void insertAsset()
//        {

//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Asset> assets = new Repository<Asset>(context);


//                Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);

//                Console.WriteLine();
//                Console.Write("Vendor: ");
//                string Vendor = Console.ReadLine();
//                while (Vendor == "")
//                {
//                    Console.Write("Please enter vendor for the asset: ");
//                    Vendor = Console.ReadLine();
//                }

//                Console.Write("Type [1 - Device,  2 - Office Equipment]: ");
//                string type = Console.ReadLine();

//                if (type == "1")
//                {
//                    Console.Write("Category: ");
//                    listAssetCat();
//                    int categoryId = Convert.ToInt32(Console.ReadLine());
//                    AssetCategory newAssetCategory = assetCategory.Get(categoryId);

//                    Console.Write("Serial Number: ");

//                    string SerialNumber = Console.ReadLine();
//                    while (SerialNumber == "")
//                    {
//                        Console.Write("Please enter serial number for the asset: ");
//                        SerialNumber = Console.ReadLine();
//                    }

//                    Console.Write("Status [1 - Active,  2 - Coming Soon, 3- Out of order]: ");
//                    string status = Console.ReadLine();

//                    string Model = Console.ReadLine();
//                    while (Model == "")
//                    {
//                        Console.Write("Please enter model for the asset: ");
//                        Model = Console.ReadLine();
//                    }



//                    Asset asset = new Asset()
//                    {
//                        Vendor = Vendor,
//                        Type = (AssetType)Convert.ToInt32(type),
//                        AssetCategory = newAssetCategory,
//                        Status = (AssetStatus)Convert.ToInt32(status),
//                        SerialNumber = SerialNumber,
//                        Model = Model,

//                    };
//                    assets.Insert(asset);

//                }

//                else if (type == "2")
//                {

//                    Console.Write("Serial Number: ");

//                    string SerialNumber = Console.ReadLine();
//                    while (SerialNumber == "")
//                    {
//                        Console.Write("Please enter serial number for the asset: ");
//                        SerialNumber = Console.ReadLine();
//                    }

//                    Console.Write("Status [1 - Active,  2 - Coming Soon, 3- Out of order]: ");
//                    string status = Console.ReadLine();


//                    Asset asset = new Asset()
//                    {

//                        Type = (AssetType)Convert.ToInt32(type),

//                        Status = (AssetStatus)Convert.ToInt32(status),
//                        SerialNumber = SerialNumber,

//                    };
//                    assets.Insert(asset);

//                }

//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }



//        static void editAsset()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Asset ID: ");
//            string a_id = Console.ReadLine();
//            if (a_id != "")
//            {
//                int id = Convert.ToInt32(a_id);
//                using (SchoolContext context = new SchoolContext())
//                {
//                    AssetsUnit assetsUnit = new AssetsUnit(context);
//                    Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);
//                    var asset = assetsUnit.Get(id);
//                    Console.Write("Edit asset vendor: ");
//                    asset.Vendor = Console.ReadLine();
//                    Console.Write("Category: ");
//                    int category = Convert.ToInt32(Console.ReadLine());
//                    AssetCategory assetCat = assetCategory.Get(category);
//                    asset.AssetCategory = assetCat;
//                    Console.Write("Edit asset Model: ");
//                    asset.Model = Console.ReadLine();
//                    Console.Write("Edit serial number: ");
//                    asset.SerialNumber = Console.ReadLine();
//                    Console.Write("Type: [1- Device, 2- Office ]");
//                    int assetType = Convert.ToInt32(Console.ReadLine());
//                    asset.Type = (AssetType)Convert.ToInt32(assetType);
//                    assetsUnit.Update(asset, id);
//                }
//                Console.WriteLine("DONE!");
//                Console.WriteLine("--------------------");
//                Console.ReadKey();
//            }
//        }

//        static void deleteAsset()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Asset ID: ");
//            string id = Console.ReadLine();
//            int a_id = Convert.ToInt32(id);
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Asset> assetUnit = new Repository<Asset>(context);
//                assetUnit.Delete(a_id);
//            }
//            Console.WriteLine("You deleted asset: " + id);
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }

//        //________________________________________________________________________________________________________________________________________________________________ 
//        //AssetCategories

//        static void assetCategories()
//        {

//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List asset categories");
//                Console.WriteLine("2. List one category");
//                Console.WriteLine("3. Insert asset category");
//                Console.WriteLine("4. Edit assets categories");
//                Console.WriteLine("5. Delete asset categories");
//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listAssetCat(); break; }
//                    case "2": { listOneAssetCat(); break; }
//                    case "3": { insertAssetCat(); break; }
//                    case "4": { editAssetCat(); break; }
//                    case "5": { deleteAssetCat(); break; }
//                }
//            }
//            while (choice != "9");
//        }
//        static void listAssetCat()
//        {

//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                var assetCategories = assetCategoryUnit.Get().ToList();
//                foreach (var assetCategory in assetCategories)
//                {
//                    Console.WriteLine(assetCategory.Id + ": " + assetCategory.CategoryName);
//                }
//            }
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }
//        static void listOneAssetCat()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                Repository<AssetCharacteristicNames> assetChar = new Repository<AssetCharacteristicNames>(context);

//                Console.WriteLine();
//                Console.Write("Enter category id: ");
//                string a_Id = Console.ReadLine();
//                if (a_Id != "")
//                {
//                    int id = Convert.ToInt32(a_Id);
//                    var a_cat = assetCategoryUnit.Get(id);
//                    if (a_cat != null)
//                    {
//                        Console.WriteLine(a_cat.Id + ": " + a_cat.CategoryName);
//                        Console.WriteLine("Characteristics for " + a_cat.CategoryName + a_cat.CategoryName + ": ");
//                        getCharNames(a_cat.Id);
//                    }


//                }
//                Console.WriteLine("----------------------");
//            }

//        }
//        static void getCharNames(int Id)
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCharacteristicNames> CharOfAssets = new Repository<AssetCharacteristicNames>(context);
//                var a_characteristics = CharOfAssets.Get().ToList();
//                var assetCharacteristics = a_characteristics.Where(x => x.AssetCategory.Id == Id);
//                foreach (var name in assetCharacteristics)
//                {
//                    Console.WriteLine("- " + name.Name);
//                }
//            }
//        }
//        static void insertAssetCat()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {

//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);

//                Console.WriteLine();
//                Console.Write("Insert category name: ");
//                string assetCategoryName = Console.ReadLine();


//                AssetCategory assetCategory = new AssetCategory()
//                {

//                    CategoryName = assetCategoryName

//                };

//                assetCategoryUnit.Insert(assetCategory);
//                Console.WriteLine("Number of characteristics for category: ");
//                string num = Console.ReadLine();
//                if (num != "")
//                {
//                    int number = Convert.ToInt32(num);
//                    for (int i = 0; i < number; i++)
//                    {
//                        assetCharacteristicsForCat(assetCategory.Id);
//                    }
//                }
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }
//        static void assetCharacteristicsForCat(int Id)
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCharacteristicNames> assetCharNamesUnit = new Repository<AssetCharacteristicNames>(context);
//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                AssetCategory a_cat = assetCategoryUnit.Get(Id);
//                Console.WriteLine("Characteristic name: ");
//                string cName = Console.ReadLine();
//                if (cName != "")
//                {
//                    AssetCharacteristicNames cn = new AssetCharacteristicNames()
//                    {
//                        Name = cName,
//                        AssetCategory = a_cat,
//                    };
//                    assetCharNamesUnit.Insert(cn);
//                }
//            }
//        }
//        static void editAssetCat()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);


//                Console.WriteLine();
//                Console.WriteLine("Asset Category ID: ");
//                string a_catId = Console.ReadLine();
//                if (a_catId != "")
//                {
//                    int id = Convert.ToInt32(a_catId);


//                    var assetCategory = assetCategoryUnit.Get(id);
//                    if (assetCategory != null)
//                    {
//                        Console.Write("Edit Asset category name: ");
//                        assetCategory.CategoryName = Console.ReadLine();
//                        //  updateAssetCharNames(assetCategory.Id);
//                        assetCategoryUnit.Update(assetCategory, id);
//                    }
//                }
//                Console.WriteLine("DONE!");
//                Console.WriteLine("--------------------");
//                Console.ReadKey();
//            }
//        }
//        static void deleteAssetCat()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);

//                Console.WriteLine();
//                Console.WriteLine("Asset Category ID: ");
//                string a_catId = Console.ReadLine();
//                if (a_catId != "")
//                {
//                    int id = Convert.ToInt32(a_catId);
//                    var cat = assetCategoryUnit.Get(id);
//                    if (cat != null)
//                    {
//                        deleteAssetCharNames(cat.Id);
//                        assetCategoryUnit.Delete(id);
//                    }

//                    Console.WriteLine("You deleted category: " + cat.CategoryName);
//                } Console.WriteLine("--------------------");
//                Console.ReadKey();
//            }
//        }
//        static void deleteAssetCharNames(int Id)
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetCharacteristicNames> assetCharNames = new Repository<AssetCharacteristicNames>(context);
//                var characteristics = assetCharNames.Get().ToList();
//                var a_catCharacteristics = characteristics.Where(x => x.AssetCategory.Id == Id);
//                foreach (var name in a_catCharacteristics)
//                {
//                    assetCharNames.Delete(name.Id);
//                }
//            }
//        }



//        //__________________________________________________________________________________________________________________________________________________________________
//        //AssetCharacteristics


//        static void assetCharacteristic()
//        {

//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List all asset characteristics");
//                Console.WriteLine("2. List specific asset characteristic");
//                Console.WriteLine("3. Insert asset characteristic");
//                Console.WriteLine("4. Edit assets characteristic");
//                Console.WriteLine("5. Delete asset characteristic");

//                Console.WriteLine("9. Return");
//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1": { listAllAssetChar(); break; }
//                    case "2": { printOneAssetChar(); break; }
//                    case "3": { insertAssetChar(); break; }
//                    case "4": { editAssetChar(); break; }
//                    case "5": { deleteAssetChar(); break; }
//                }

//            }
//            while (choice != "9");
//        }

//        static void listAllAssetChar()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<AssetChar> characteristics = new Repository<AssetChar>(context);

//                var a_characteristics = characteristics.Get().ToList();
//                foreach (var characteristic in a_characteristics)
//                {
//                    Console.WriteLine(characteristic.Id + ": " + characteristic.Name + " - " + characteristic.Value + " " + characteristic.Asset.Id);
//                }
//            }
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }



//        static void insertAssetChar()
//        {

//            Asset asset = null;


//            using (SchoolContext context = new SchoolContext())
//            {
//                AssetCharUnit assetCharUnit = new AssetCharUnit(context);
//                Repository<Asset> assetUnit = new Repository<Asset>(context);


//                do
//                {
//                    Console.WriteLine();
//                    Console.Write("Asset Id: ");
//                    int a_Id = Convert.ToInt32(Console.ReadLine());

//                    asset = assetUnit.Get(a_Id);
//                    if (asset == null)
//                    {
//                        Console.WriteLine("Asset with id " + a_Id + " does not exist, please enter another id.");
//                    }
//                    else
//                    {
//                        Console.WriteLine(asset.Vendor + " " + asset.Model + " " + asset.User.FirstName);
//                    }
//                } while (asset == null);

//                Console.WriteLine("Write name of the characteristic");
//                string name = Console.ReadLine();

//                Console.Write("Write value:");
//                string value = Console.ReadLine();
//                AssetChar assetChar = new AssetChar()
//                {
//                    Asset = asset,
//                    Name = name,
//                    Value = value,
//                };

//                assetCharUnit.Insert(assetChar);
//            }
//            Console.WriteLine("--------------------");
//            Console.ReadKey();
//        }


//        static void editAssetChar()
//        {
//            Console.WriteLine();
//            Console.Write("Insert ID of characteristic you want to edit: ");
//            string c_id = Console.ReadLine();
//            if (c_id != "")
//            {
//                int id = Convert.ToInt32(c_id);

//                Console.WriteLine();
//                Console.Write("Insert new name for characteristic " + c_id + "  ");
//                string cName = Console.ReadLine();

//                Console.WriteLine();
//                Console.Write("Insert new Value for characteristic" + c_id + " ");
//                string cValue = Console.ReadLine();

//                if (cName != "" && cValue != "")
//                {
//                    string name = Convert.ToString(cName);
//                    string value = Convert.ToString(cValue);

//                    using (SchoolContext context = new SchoolContext())
//                    {
//                        AssetCharUnit assetCharUnit = new AssetCharUnit(context);
//                        var selectedchar = assetCharUnit.Get(id);

//                        if (selectedchar != null)
//                        {
//                            selectedchar.Name = cName;
//                            selectedchar.Value = cValue;

//                        }
//                        assetCharUnit.Update(selectedchar, id);

//                        Console.WriteLine("Edited!");
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }
//                }
//            }
//        }


//        static void printOneAssetChar()
//        {
//            Console.WriteLine();
//            Console.Write("Insert identification of characteristic you want to show: ");
//            string c_id = Console.ReadLine();
//            if (c_id != "")
//            {
//                int id = Convert.ToInt32(c_id);

//                using (SchoolContext context = new SchoolContext())
//                {
//                    AssetCharUnit assetCharUnit = new AssetCharUnit(context);
//                    var a_char = assetCharUnit.Get(id);

//                    Console.WriteLine(a_char.Id + ": " + a_char.Name + " - " + a_char.Value + " " + a_char.Asset.Id);
//                    Console.WriteLine("--------------------");
//                    Console.ReadKey();
//                }
//            }
//        }




//        static void deleteAssetChar()
//        {

//            Console.WriteLine("Enter characteristic ID: ");
//            string a_id = Console.ReadLine();
//            if (a_id != "")
//            {
//                int id = Convert.ToInt32(a_id);

//                using (SchoolContext context = new SchoolContext())
//                {

//                    Repository<AssetChar> assetCharUnit = new Repository<AssetChar>(context);
//                    var a_char = assetCharUnit.Get(id);


//                    if (a_char != null)
//                    {
//                        assetCharUnit.Delete(id);
//                    }
//                }
//                Console.ReadKey();
//            }
//        }
//    }
//}

//﻿//using Database;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace DataSeed
////{
////    class Program___Irma
////    {

////        static void Main(string[] args)
////        {

////            string choice = "X";
////            do
////            {
////                Console.WriteLine("1. Assets");
////                Console.WriteLine("2. Assets Categories");
////                Console.WriteLine("3. Asset Characteristic");


////                Console.WriteLine("9. END PROGRAM");
////                choice = Console.ReadLine();

////                switch (choice)
////                {
////                    case "1": { assets(); break; }
////                    case "2": { assetCategories(); break; }
////                    case "3": { assetCharacteristic(); break; }


////                }
////            } while (choice != "9");
////        }

////        //________________________________________________________________________________________________________________________________________________________________ 
////        //Asset

////        static void assets()
////        {

////            string choice = "X";
////            do
////            {
////                Console.WriteLine("1. List all assets");
////                Console.WriteLine("2.List one asset");
////                Console.WriteLine("3. Insert asset");
////                Console.WriteLine("4. Edit asset");
////                Console.WriteLine("5. Delete asset");
////                Console.WriteLine("9. Return");
////                choice = Console.ReadLine();

////                switch (choice)
////                {
////                    case "1": { listAssets(); break; }
////                    case "2": { listOneAsset(); break; }
////                    case "3": { insertAsset(); break; }
////                    case "4": { editAsset(); break; }
////                    case "5": { deleteAsset(); break; }
////                }
////            }
////            while (choice != "9");
////        }

////        static void listAssets()
////        {
////            using (SchoolContext context = new SchoolContext())
////            {
////                Repository<Asset> assetUnit = new Repository<Asset>(context);
////                var assets = assetUnit.Get().ToList();
////                foreach (var asset in assets)
////                {
////                    ;
////                    Console.WriteLine(asset.Id + ": " + asset.Vendor + " - " + asset.Type + ": " + asset.Status + ": " + asset.AssetCategory.CategoryName);
////                }
////            }
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }

////        static void listOneAsset()
////        {

////            Console.WriteLine();
////            Console.Write("Enter asset id: ");
////            string a_Id = Console.ReadLine();
////            if (a_Id != "")
////            {
////                int id = Convert.ToInt32(a_Id);

////                using (SchoolContext context = new SchoolContext())
////                {
////                    AssetsUnit assetsUnit = new AssetsUnit(context);
////                    var asset = assetsUnit.Get(id);
////                    if (asset != null)
////                    {
////                        Console.WriteLine(asset.Id + ": " + asset.Vendor + " - " + asset.Type + ": " + asset.Status + ": " + asset.AssetCategory.CategoryName);
////                        Console.WriteLine("--------------------");
////                        Console.ReadKey();
////                    }
////                }
////            }
////        }


////        static void insertAsset()
////        {

////            using (SchoolContext context = new SchoolContext())
////            {
////                AssetsUnit assetsUnit = new AssetsUnit(context);

////                Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);

////                Console.WriteLine();
////                Console.Write("Vendor: ");
////                string Vendor = Console.ReadLine();
////                while (Vendor == "")
////                {
////                    Console.Write("Please enter vendor for the asset: ");
////                    Vendor = Console.ReadLine();
////                }

////                Console.Write("Type [1 - Device,  2 - Office Equipment]: ");
////                string type = Console.ReadLine();

////                if (type == "1")
////                {
////                    Console.Write("Category: ");
////                    int category = Convert.ToInt32(Console.ReadLine());
////                    AssetCategory newAssetCategory = assetCategory.Get(category);

////                    Console.Write("Serial Number: ");

////                    string SerialNumber = Console.ReadLine();
////                    while (SerialNumber == "")
////                    {
////                        Console.Write("Please enter serial number for the asset: ");
////                        SerialNumber = Console.ReadLine();
////                    }

////                    Console.Write("Status [1 - Active,  2 - Coming Soon, 3- Out of order]: ");
////                    string status = Console.ReadLine();

////                    string Model = Console.ReadLine();
////                    while (Model == "")
////                    {
////                        Console.Write("Please enter model for the asset: ");
////                        Model = Console.ReadLine();
////                    }


////                    Asset asset = new Asset()
////                    {
////                        Vendor = Vendor,
////                        Type = (AssetType)Convert.ToInt32(type),
////                        AssetCategory = newAssetCategory,
////                        Status = (AssetStatus)Convert.ToInt32(status),
////                        SerialNumber = SerialNumber,
////                        Model = Model,

////                    };
////                    assetsUnit.Insert(asset);

////                }

////                else if (type == "2")
////                {

////                    Console.Write("Serial Number: ");

////                    string SerialNumber = Console.ReadLine();
////                    while (SerialNumber == "")
////                    {
////                        Console.Write("Please enter serial number for the asset: ");
////                        SerialNumber = Console.ReadLine();
////                    }

////                    Console.Write("Status [1 - Active,  2 - Coming Soon, 3- Out of order]: ");
////                    string status = Console.ReadLine();


////                    Asset asset = new Asset()
////                    {

////                        Type = (AssetType)Convert.ToInt32(type),

////                        Status = (AssetStatus)Convert.ToInt32(status),
////                        SerialNumber = SerialNumber,

////                    };
////                    assetsUnit.Insert(asset);

////                }

////            }
////            Console.WriteLine("DONE!");
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }



////        static void editAsset()
////        {
////            Console.WriteLine();
////            Console.WriteLine("Asset ID: ");
////            string a_id = Console.ReadLine();
////            if (a_id != "")
////            {
////                int id = Convert.ToInt32(a_id);
////                using (SchoolContext context = new SchoolContext())
////                {
////                    AssetsUnit assetsUnit = new AssetsUnit(context);
////                    Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);
////                    var asset = assetsUnit.Get(id);
////                    Console.Write("Edit asset vendor: ");
////                    asset.Vendor = Console.ReadLine();
////                    Console.Write("Category: ");
////                    int category = Convert.ToInt32(Console.ReadLine());
////                    AssetCategory assetCat = assetCategory.Get(category);
////                    asset.AssetCategory = assetCat;
////                    Console.Write("Edit asset Model: ");
////                    asset.Model = Console.ReadLine();
////                    Console.Write("Edit serial number: ");
////                    asset.SerialNumber = Console.ReadLine();
////                    Console.Write("Type: [1- Device, 2- Office ]");
////                    int assetType = Convert.ToInt32(Console.ReadLine());
////                    asset.Type = (AssetType)Convert.ToInt32(assetType);
////                    assetsUnit.Update(asset, id);
////                }
////                Console.WriteLine("DONE!");
////                Console.WriteLine("--------------------");
////                Console.ReadKey();
////            }
////        }

////        static void deleteAsset()
////        {
////            Console.WriteLine();
////            Console.WriteLine("Asset ID: ");
////            string id = Console.ReadLine();
////            int a_id = Convert.ToInt32(id);
////            using (SchoolContext context = new SchoolContext())
////            {
////                Repository<Asset> assetUnit = new Repository<Asset>(context);
////                assetUnit.Delete(a_id);
////            }
////            Console.WriteLine("You deleted asset: " + id);
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }

////        //________________________________________________________________________________________________________________________________________________________________ 
////        //AssetCategories

////        static void assetCategories()
////        {

////            string choice = "X";
////            do
////            {
////                Console.WriteLine("1. List asset categories");
////                Console.WriteLine("2. List one category");
////                Console.WriteLine("3. Insert asset category");
////                Console.WriteLine("4. Edit assets categories");
////                Console.WriteLine("5. Delete asset categories");
////                Console.WriteLine("9. Return");
////                choice = Console.ReadLine();

////                switch (choice)
////                {
////                    case "1": { listAssetCat(); break; }
////                    case "2": { listOneAssetCat(); break; }
////                    case "3": { insertAssetCat(); break; }
////                    case "4": { editAssetCat(); break; }
////                    case "5": { deleteAssetCat(); break; }
////                }
////            }
////            while (choice != "9");
////        }
////        static void listAssetCat()
////        {

////            using (SchoolContext context = new SchoolContext())
////            {
////                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
////                var assetCategories = assetCategoryUnit.Get().ToList();
////                foreach (var assetCategory in assetCategories)
////                {
////                    Console.WriteLine(assetCategory.Id + ": " + assetCategory.CategoryName);
////                }
////            }
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }
////        static void listOneAssetCat()
////        {
////            Console.WriteLine();
////            Console.Write("Enter category id: ");
////            string a_Id = Console.ReadLine();
////            if (a_Id != "")
////            {
////                int id = Convert.ToInt32(a_Id);

////                using (SchoolContext context = new SchoolContext())
////                {

////                    Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
////                    var assetCategories = assetCategoryUnit.Get(id);


////                    if (assetCategories != null)
////                    {
////                        Console.WriteLine(assetCategories.Id + ": " + assetCategories.CategoryName);
////                        Console.WriteLine(assetCategories.CategoryName + " Characteristics");
////                        getCharNames(assetCategories.Id);
////                    }


////                }
////                Console.WriteLine("----------------------");
////            }

////        }
////        static void getCharNames(int Id)
////        {
////            using (SchoolContext context = new SchoolContext())
////            {
////                Repository<AssetCharacteristicNames> CharOfAssets = new Repository<AssetCharacteristicNames>(context);
////                var a_characteristics = CharOfAssets.Get().ToList();
////                var assetCharacteristics = a_characteristics.Where(x => x.AssetCategory.Id == Id);
////                foreach (var name in assetCharacteristics)
////                {
////                    Console.WriteLine("- " + name.Name);
////                }
////            }
////        }
////        static void insertAssetCat()
////        {
////            using (SchoolContext context = new SchoolContext())
////            {

////                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);

////                Console.WriteLine();
////                Console.Write("Insert new category name: ");
////                string assetCategoryName = Console.ReadLine();
////                while (assetCategoryName == "")
////                {
////                    Console.Write("Please enter name of the category for the asset: ");
////                    assetCategoryName = Console.ReadLine();
////                }

////                AssetCategory assetCategory = new AssetCategory()
////                {

////                    CategoryName = assetCategoryName
////                };
////                assetCategoryUnit.Insert(assetCategory);
////            }
////            Console.WriteLine("DONE!");
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }
////        static void editAssetCat()
////        {


////            Console.WriteLine();
////            Console.WriteLine("Asset Category ID: ");
////            string a_catId = Console.ReadLine();
////            if (a_catId != "")
////            {
////                int id = Convert.ToInt32(a_catId);
////                using (SchoolContext context = new SchoolContext())
////                {
////                    Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
////                    var assetCategory = assetCategoryUnit.Get(id);
////                    if (assetCategory != null)
////                    {
////                        Console.Write("Edit Asset category name: ");
////                        assetCategory.CategoryName = Console.ReadLine();
////                        assetCategoryUnit.Update(assetCategory, id);
////                    }
////                }
////                Console.WriteLine("DONE!");
////                Console.WriteLine("--------------------");
////                Console.ReadKey();
////            }
////        }
////        static void deleteAssetCat()
////        {
////            Console.WriteLine();
////            Console.WriteLine("Asset Category ID: ");
////            string a_catId = Console.ReadLine();
////            int id = Convert.ToInt32(a_catId);
////            using (SchoolContext context = new SchoolContext())
////            {
////                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
////                assetCategoryUnit.Delete(id);
////            }
////            Console.WriteLine("You deleted skill category: " + id);
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }





////        //__________________________________________________________________________________________________________________________________________________________________
////        //AssetCharacteristics


////        static void assetCharacteristic()
////        {

////            string choice = "X";
////            do
////            {
////                Console.WriteLine("1. List all asset characteristics");
////                Console.WriteLine("2. List one  asset characteristic");
////                Console.WriteLine("3. Insert asset characteristic");
////                Console.WriteLine("4. Edit assets characteristic");
////                Console.WriteLine("5. Delete asset characteristic");

////                Console.WriteLine("9. Return");
////                choice = Console.ReadLine();

////                switch (choice)
////                {
////                    case "1": { listAllAssetChar(); break; }
////                    case "2": { printOneAssetChar(); break; }
////                    case "3": { insertAssetChar(); break; }
////                    case "4": { editAssetChar(); break; }
////                    case "5": { deleteAssetChar(); break; }
////                }

////            }
////            while (choice != "9");
////        }

////        static void listAllAssetChar()
////        {
////            using (SchoolContext context = new SchoolContext())
////            {
////                AssetCharUnit assetCharUnit = new AssetCharUnit(context);
////                var characteristics = assetCharUnit.Get().ToList();
////                foreach (var characteristic in characteristics)
////                {
////                    Console.WriteLine(characteristic.Id + ": " + characteristic.Name + " - " + characteristic.Value + " " + characteristic.Asset.Id);
////                }
////            }
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }



////        static void insertAssetChar()
////        {

////            Asset asset = null;


////            using (SchoolContext context = new SchoolContext())
////            {
////                AssetCharUnit assetCharUnit = new AssetCharUnit(context);
////                Repository<Asset> assetUnit = new Repository<Asset>(context);


////                do
////                {
////                    Console.WriteLine();
////                    Console.Write("Asset Id: ");
////                    int a_Id = Convert.ToInt32(Console.ReadLine());

////                    asset = assetUnit.Get(a_Id);
////                    if (asset == null)
////                    {
////                        Console.WriteLine("Asset with id " + a_Id + " does not exist, please enter another id.");
////                    }
////                    else
////                    {
////                        Console.WriteLine(asset.Vendor + " " + asset.Model + " " + asset.User.FirstName);
////                    }
////                } while (asset == null);

////                Console.WriteLine("Write name of the characteristic");
////                string name = Console.ReadLine();

////                Console.Write("Write value:");
////                string value = Console.ReadLine();
////                AssetChar assetChar = new AssetChar()
////                {
////                    Asset = asset,
////                    Name = name,
////                    Value = value,
////                };

////                assetCharUnit.Insert(assetChar);
////            }
////            Console.WriteLine("--------------------");
////            Console.ReadKey();
////        }


////        static void editAssetChar()
////        {
////            Console.WriteLine();
////            Console.Write("Insert ID of characteristic you want to edit: ");
////            string c_id = Console.ReadLine();
////            if (c_id != "")
////            {
////                int id = Convert.ToInt32(c_id);

////                Console.WriteLine();
////                Console.Write("Insert new name for characteristic " + c_id + "  ");
////                string cName = Console.ReadLine();

////                Console.WriteLine();
////                Console.Write("Insert new Value for characteristic" + c_id + " ");
////                string cValue = Console.ReadLine();

////                if (cName != "" && cValue != "")
////                {
////                    string name = Convert.ToString(cName);
////                    string value = Convert.ToString(cValue);

////                    using (SchoolContext context = new SchoolContext())
////                    {
////                        AssetCharUnit assetCharUnit = new AssetCharUnit(context);
////                        var selectedchar = assetCharUnit.Get(id);

////                        if (selectedchar != null)
////                        {
////                            selectedchar.Name = cName;
////                            selectedchar.Value = cValue;

////                        }
////                        assetCharUnit.Update(selectedchar, id);

////                        Console.WriteLine("Edited!");
////                        Console.WriteLine("--------------------");
////                        Console.ReadKey();
////                    }
////                }
////            }
////        }


////        static void printOneAssetChar()
////        {
////            Console.WriteLine();
////            Console.Write("Insert identification of characteristic you want to show: ");
////            string c_id = Console.ReadLine();
////            if (c_id != "")
////            {
////                int id = Convert.ToInt32(c_id);

////                using (SchoolContext context = new SchoolContext())
////                {
////                    AssetCharUnit assetCharUnit = new AssetCharUnit(context);
////                    var a_char = assetCharUnit.Get(id);

////                    Console.WriteLine(a_char.Id + ": " + a_char.Name + " - " + a_char.Value + " " + a_char.Asset.Id);
////                    Console.WriteLine("--------------------");
////                    Console.ReadKey();
////                }
////            }
////        }




////        static void deleteAssetChar()
////        {

////            Console.WriteLine("Enter characteristic ID: ");
////            string a_id = Console.ReadLine();
////            if (a_id != "")
////            {
////                int id = Convert.ToInt32(a_id);

////                using (SchoolContext context = new SchoolContext())
////                {

////                   Repository<AssetChar> assetCharUnit= new Repository<AssetChar>(context);
////                    var a_char = assetCharUnit.Get(id);


////                    if (a_char != null)
////                    {
////                        assetCharUnit.Delete(id);
////                    }
////                }
////                Console.ReadKey();
////            }
////        }


     

////    }
////}


 
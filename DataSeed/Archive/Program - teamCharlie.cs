//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Database;
//using System.Data.OleDb;
//using System.Data;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSeed
//{
//    class Program
//    {
//        static string sourceData = @"C:\MistralProjects\school\GigiSchool.xls";
//        static SchoolContext context = new SchoolContext();

//        static void Main(string[] args)
//        {
//            string choice = "X";
//            do
//            {
//                Console.WriteLine("Choose one option ");
//                Console.WriteLine("1. Assets");

//                Console.WriteLine("2. Char names");
//                Console.WriteLine("3. Requests");
//                Console.WriteLine("4. History");
//                Console.WriteLine("9. End");
//                Console.WriteLine("--------------------------------------------");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1": { doAssets(); break; }
//                    case "2": { doCharacteristicNames(); break; }
//                    case "3": { doRequests(); break; }
//                    case "4": { doHistory(); break; }
//                }
//            } while (choice != "9");
//            Console.Clear();
//        }

//        static void doAssets()
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


//        static void assets()
//        {

//            string choice = "X";
//            do
//            {
//                Console.WriteLine("1. List all assets");
//                Console.WriteLine("2.List one asset");
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
//                    ;
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
//            getAssetCategories();
//            getAssetChar();
//            getAssetCharNames();
//            getAssets();
//            getRequests();

//            using (SchoolContext context = new SchoolContext())
//            {
//                AssetsUnit assetsUnit = new AssetsUnit(context);

//                Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);

//                Console.WriteLine();
//                Console.Write("Vendor: ");
//                string Vendor = Console.ReadLine();
//                while (Vendor == "")
//                {
//                    Console.Write("Please enter vendor for the asset: ");
//                    Vendor = Console.ReadLine();
//                }

//                Console.Write("Type [1 - Device,  2 - Office New]: ");
//                string type = Console.ReadLine();

//                if (type == "1")
//                {
//                    Console.Write("Category: ");
//                    int category = Convert.ToInt32(Console.ReadLine());
//                    AssetCategory newAssetCategory = assetCategory.Get(category);

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
//                    assetsUnit.Insert(asset);

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
//                } } }

//                    static void editAsset()
//        {
//                        Console.WriteLine();
//                        Console.WriteLine("Asset ID: ");
//                        string a_id = Console.ReadLine();
//                        if (a_id != "")
//                        {
//                            int id = Convert.ToInt32(a_id);
//                            using (SchoolContext context = new SchoolContext())
//                            {
//                                AssetsUnit assetsUnit = new AssetsUnit(context);
//                                Repository<AssetCategory> assetCategory = new Repository<AssetCategory>(context);
//                                var asset = assetsUnit.Get(id);
//                                Console.Write("Edit asset vendor: ");
//                                asset.Vendor = Console.ReadLine();
//                                Console.Write("Category: ");
//                                int category = Convert.ToInt32(Console.ReadLine());
//                                AssetCategory assetCat = assetCategory.Get(category);
//                                asset.AssetCategory = assetCat;
//                                Console.Write("Edit asset Model: ");
//                                asset.Model = Console.ReadLine();
//                                Console.Write("Edit serial number: ");
//                                asset.SerialNumber = Console.ReadLine();
//                                Console.Write("Type: [1- Device, 2- Office ]");
//                                int assetType = Convert.ToInt32(Console.ReadLine());
//                                asset.Type = (AssetType)Convert.ToInt32(assetType);
//                                assetsUnit.Update(asset, id);
//                            }
//                            Console.WriteLine("DONE!");
//                            Console.WriteLine("--------------------");
//                            Console.ReadKey();
//                        }
//                    }

//                    static void deleteAsset()
//        {
//                        Console.WriteLine();
//                        Console.WriteLine("Asset ID: ");
//                        string id = Console.ReadLine();
//                        int a_id = Convert.ToInt32(id);
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<Asset> assetUnit = new Repository<Asset>(context);
//                            assetUnit.Delete(a_id);
//                        }
//                        Console.WriteLine("You deleted asset: " + id);
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }

//                    static void assetCategories()
//        {

//                        string choice = "X";
//                        do
//                        {
//                            Console.WriteLine("1. List asset categories");
//                            Console.WriteLine("2. List one category");
//                            Console.WriteLine("3. Insert asset category");
//                            Console.WriteLine("4. Edit assets categories");
//                            Console.WriteLine("5. Delete asset categories");
//                            Console.WriteLine("9. Return");
//                            choice = Console.ReadLine();

//                            switch (choice)
//                            {
//                                case "1": { listAssetCat(); break; }
//                                case "2": { listOneAssetCat(); break; }
//                                case "3": { insertAssetCat(); break; }
//                                case "4": { editAssetCat(); break; }
//                                case "5": { deleteAssetCat(); break; }
//                            }
//                        }
//                        while (choice != "9");
//                    }
//                    static void listAssetCat()
//        {

//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                            var assetCategories = assetCategoryUnit.Get().ToList();
//                            foreach (var assetCategory in assetCategories)
//                            {
//                                Console.WriteLine(assetCategory.Id + ": " + assetCategory.CategoryName);
//                            }
//                        }
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }
//                    static void listOneAssetCat()
//        {
//                        Console.WriteLine();
//                        Console.Write("Enter category id: ");
//                        string a_Id = Console.ReadLine();
//                        if (a_Id != "")
//                        {
//                            int id = Convert.ToInt32(a_Id);

//                            using (SchoolContext context = new SchoolContext())
//                            {

//                                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                                var assetCategories = assetCategoryUnit.Get(id);

//                                if (assetCategories != null)
//                                {
//                                    Console.WriteLine(assetCategories.Id + ": " + assetCategories.CategoryName);
//                                    Console.WriteLine(assetCategories.CategoryName + " Characteristics");
//                                    getCharNames(assetCategories.Id);
//                                }


//                            }
//                            Console.WriteLine("----------------------");
//                        }

//                    }
//                    static void getCharNames(int Id)
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> CharOfAssets = new Repository<AssetCharacteristicNames>(context);
//                            var a_characteristics = CharOfAssets.Get().ToList();
//                            var assetCharacteristics = a_characteristics.Where(x => x.AssetCategory.Id == Id);
//                            foreach (var name in assetCharacteristics)
//                            {
//                                Console.WriteLine("- " + name.Name);
//                            }
//                        }
//                    }
//                    static void insertAssetCat()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {

//                            Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);

//                            Console.WriteLine();
//                            Console.Write("Insert new category name: ");
//                            string assetCategoryName = Console.ReadLine();
//                            while (assetCategoryName == "")
//                            {
//                                Console.Write("Please enter name of the category for the asset: ");
//                                assetCategoryName = Console.ReadLine();
//                            }

//                            AssetCategory assetCategory = new AssetCategory()
//                            {
//                                AssetCategory = category,
//                                Type = (AssetType)Enum.Parse(typeof(AssetType), row.ItemArray.GetValue(0).ToString()),
//                                Model = row.ItemArray.GetValue(1).ToString(),
//                                SerialNumber = row.ItemArray.GetValue(2).ToString(),
//                                Description = row.ItemArray.GetValue(3).ToString(),
//                                Vendor = row.ItemArray.GetValue(4).ToString(),
//                                Price = Convert.ToDouble(row.ItemArray.GetValue(5).ToString()),
//                                Status = (AssetStatus)Enum.Parse(typeof(AssetStatus), row.ItemArray.GetValue(6).ToString()),
//                                User = user,
//                            };
//                            assetCategoryUnit.Insert(assetCategory);
//                        }
//                        Console.WriteLine("DONE!");
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }
//                    static void editAssetCat()
//        {


//                        Console.WriteLine();
//                        Console.WriteLine("Asset Category ID: ");
//                        string a_catId = Console.ReadLine();
//                        if (a_catId != "")
//                        {
//                            int id = Convert.ToInt32(a_catId);
//                            using (SchoolContext context = new SchoolContext())
//                            {
//                                Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                                var assetCategory = assetCategoryUnit.Get(id);
//                                if (assetCategory != null)
//                                {
//                                    Console.Write("Edit Asset category name: ");
//                                    assetCategory.CategoryName = Console.ReadLine();
//                                    assetCategoryUnit.Update(assetCategory, id);
//                                }
//                            }
//                            Console.WriteLine("DONE!");
//                            Console.WriteLine("--------------------");
//                            Console.ReadKey();
//                        }
//                    }
//                    static void deleteAssetCat()
//        {
//                        Console.WriteLine();
//                        Console.WriteLine("Asset Category ID: ");
//                        string a_catId = Console.ReadLine();
//                        int id = Convert.ToInt32(a_catId);
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCategory> assetCategoryUnit = new Repository<AssetCategory>(context);
//                            assetCategoryUnit.Delete(id);
//                        }
//                        Console.WriteLine("You deleted asset category: " + id);
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }

//                    {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            AssetCharUnit assetCharUnit = new AssetCharUnit(context);
//                            var characteristics = assetCharUnit.Get().ToList();
//                            foreach (var characteristic in characteristics)
//                            {
//                                Console.WriteLine(characteristic.Id + ": " + characteristic.Name + " - " + characteristic.Value + " " + characteristic.Asset.Id);
//                            }
//                        }
//                        Console.WriteLine("--------------------");
//                        Console.ReadKey();
//                    }

//                    static void insertAssetChar()
//        {

//                        Asset asset = null;

//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            do
//                            {
//                                Console.WriteLine();
//                                Console.Write("Asset Id: ");
//                                int a_Id = Convert.ToInt32(Console.ReadLine());

//                                requestType = (RequestType)Enum.Parse(typeof(RequestType), row.ItemArray.GetValue(0).ToString()),
//                    RequestMessage = row.ItemArray.GetValue(1).ToString(),
//                    RequestDate = getDate(row, 2),
//                    Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), row.ItemArray.GetValue(3).ToString())
            
//                Console.WriteLine("Write name of the characteristic");
//                                string name = Console.ReadLine();

//                                Console.Write("Write value:");
//                                string value = Console.ReadLine();
//                                AssetChar assetChar = new AssetChar()
//                                {
//                                    Asset = asset,
//                                    Name = name,
//                                    Value = value,
//                                };

//                                assetCharUnit.Insert(assetChar);
//                            }

//                        Console.WriteLine("--------------------");
//                            Console.ReadKey();
//                        }

//                        static void editAssetChar()
//        {
//                            Console.WriteLine();
//                            Console.Write("Insert ID of characteristic you want to edit: ");
//                            string c_id = Console.ReadLine();
//                            if (c_id != "")
//                            {
//                                int id = Convert.ToInt32(c_id);

//                                Console.WriteLine();
//                                Console.Write("Insert new name for characteristic " + c_id + "  ");
//                                string cName = Console.ReadLine();

//                                Console.WriteLine();
//                                Console.Write("Insert new Value for characteristic" + c_id + " ");
//                                string cValue = Console.ReadLine();

//                                if (cName != "" && cValue != "")
//                                {
//                                    string name = Convert.ToString(cName);
//                                    string value = Convert.ToString(cValue);

//                                    using (SchoolContext context = new SchoolContext())
//                                    {
//                                        AssetCharUnit assetCharUnit = new AssetCharUnit(context);
//                                        var selectedchar = assetCharUnit.Get(id);

//                                        if (selectedchar != null)
//                                        {
//                                            selectedchar.Name = cName;
//                                            selectedchar.Value = cValue;

//                                        }
//                                        assetCharUnit.Update(selectedchar, id);

//                                        Console.WriteLine("Edited!");
//                                        Console.WriteLine("--------------------");
//                                        Console.ReadKey();
//                                    }
//                                }
//                            }
//                        }


//                        static void printOneAssetChar()
//        {
//                            Console.WriteLine();
//                            Console.Write("Insert identification of characteristic you want to show: ");
//                            string c_id = Console.ReadLine();
//                            if (c_id != "")
//                            {
//                                AssetChar assetChar = new AssetChar()
//                                {

//                                    Name = row.ItemArray.GetValue(0).ToString(),
//                                    Value = row.ItemArray.GetValue(1).ToString(),


//                                };
//                                N++;
//                                context.AssetCharacteristics.Add(assetChar);
//                                Console.WriteLine(a_char.Id + ": " + a_char.Name + " - " + a_char.Value + " " + a_char.Asset.Id);
//                                Console.WriteLine("--------------------");
//                                Console.ReadKey();
//                            }
//                        }
//                    }


//                    static void deleteAssetChar()
//        {

//                        Console.WriteLine("Enter characteristic ID: ");
//                        string a_id = Console.ReadLine();
//                        if (a_id != "")
//                        {
//                            //string catName = row.ItemArray.GetValue(1).ToString();
//                            //AssetCategory category = context.AssetCategory.FirstOrDefault(x => x.CategoryName == catName);

//                            AssetCharacteristicNames assetCharNames = new AssetCharacteristicNames()
//                            int id = Convert.ToInt32(a_id);

//                            using (SchoolContext context = new SchoolContext())
//                            {

//                                Repository<AssetChar> assetCharUnit = new Repository<AssetChar>(context);
//                                var a_char = assetCharUnit.Get(id);


//                                if (a_char != null)
//                                {
//                                    assetCharUnit.Delete(id);
//                                }
//                            }
//                            Console.ReadKey();
//                        }
//                    }
//                    static void doCharacteristicNames()
//        {
//                        string choice = "x";
//                        do
//                        {
//                            Console.WriteLine("-----------------------------------------");
//                            Console.WriteLine("CHARACTERISTICS");
//                            Console.WriteLine("1. Show characteristic names");
//                            Console.WriteLine("2. Show one characteristic name");
//                            Console.WriteLine("3. Insert new characteristic name");
//                            Console.WriteLine("4. Delete characterstic name");
//                            Console.WriteLine("5. Update characteristic names");
//                            Console.WriteLine("9. Return");
//                            Console.WriteLine("----------------------------------------");
//                            choice = Console.ReadLine();
//                            switch (choice)
//                            {
//                                case "1": { showAllCharacteristicNames(); break; }
//                                case "2": { showOneCharacteristicName(); break; }
//                                case "3": { insertNewCharacteristicName(); break; }
//                                case "4": { deleteCharacteristicName(); break; }
//                                case "5": { updateCharacteristicName(); break; }
//                            }
//                        } while (choice != "9");
//                        Console.Clear();
//                    }

//                    static void addCharacteristicsForCat(int Id)
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristics = new Repository<AssetCharacteristicNames>(context);
//                            Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
//                            AssetCategory cat = categories.Get(Id);
//                            Console.WriteLine("Characteristic name: ");
//                            string cName = Console.ReadLine();
//                            if (cName != "")
//                            {
//                                AssetCharacteristicNames cn = new AssetCharacteristicNames()
//                                {
//                                    Name = cName,
//                                    AssetCategory = cat
//                                };
//                                characteristics.Insert(cn);
//                            }
//                        }
//                    }

//                    static void deleteCharcteristicNames(int Id)
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicsOfCat = new Repository<AssetCharacteristicNames>(context);
//                            var characteristics = characteristicsOfCat.Get().ToList();
//                            var catCharacteristics = characteristics.Where(x => x.AssetCategory.Id == Id);
//                            foreach (var name in catCharacteristics)
//                            {
//                                characteristicsOfCat.Delete(name.Id);
//                            }
//                        }
//                    }

//                    static void showAllCharacteristicNames()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
//                            Console.WriteLine();
//                            var charac = characteristicNames.Get().ToList();
//                            foreach (var charName in charac)
//                            {
//                                Console.WriteLine(charName.Id + " - " + charName.Name + " | " + charName.AssetCategory.CategoryName);
//                            }
//                            Console.WriteLine("---------------------------------------");
//                        }
//                    }

//                    static void showOneCharacteristicName()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
//                            Console.WriteLine();
//                            Console.WriteLine("Enter asset characteristic name id: ");
//                            string enteredId = Console.ReadLine();
//                            if (enteredId != "")
//                            {
//                                int id = Convert.ToInt32(enteredId);
//                                var charName = characteristicNames.Get(id);
//                                if (charName != null)
//                                {
//                                    Console.WriteLine(charName.Id + " - " + charName.Name + " | " + charName.AssetCategory.CategoryName);
//                                }
//                            }
//                            Console.WriteLine("                  ");
//                        }
//                    }

//                    static void insertNewCharacteristicName()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
//                            Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
//                            Console.WriteLine();
//                            Console.WriteLine("Choose asset category to add new characteristic: ");
//                            //showAllCategories();
//                            int categoryId = Convert.ToInt32(Console.ReadLine());
//                            AssetCategory cat = categories.Get(categoryId);
//                            Console.WriteLine("Characteristic name: ");
//                            string cName = Console.ReadLine();
//                            if (cName != "")
//                            {
//                                AssetCharacteristicNames cn = new AssetCharacteristicNames()
//                                {
//                                    Name = cName,
//                                    AssetCategory = cat
//                                };
//                                characteristicNames.Insert(cn);
//                            }
//                            Console.WriteLine("                  ");
//                        }
//                    }

//                    static void updateCharacteristicName()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
//                            Repository<AssetCategory> categories = new Repository<AssetCategory>(context);
//                            Console.WriteLine();
//                            Console.WriteLine("Enter id: ");
//                            string enteredId = Console.ReadLine();
//                            if (enteredId != "")
//                            {
//                                var charName = characteristicNames.Get(Convert.ToInt32(enteredId));
//                                if (charName != null)
//                                {
//                                    Console.WriteLine("Edit name: ");
//                                    string cName = Console.ReadLine();
//                                    charName.Name = cName;

//                                    string numb = Console.ReadLine();
//                                    charName.AssetCategory = categories.Get(Convert.ToInt32(numb));
//                                    characteristicNames.Update(charName, charName.Id);
//                                }
//                            }
//                            Console.WriteLine("                              ");
//                        }
//                    }

//                    static void deleteCharacteristicName()
//        {
//                        using (SchoolContext context = new SchoolContext())
//                        {
//                            Repository<AssetCharacteristicNames> characteristicNames = new Repository<AssetCharacteristicNames>(context);
//                            Console.WriteLine();
//                            Console.WriteLine("Enter Id: ");
//                            string cid = Console.ReadLine();
//                            if (cid != "")
//                            {
//                                int id = Convert.ToInt32(cid);
//                                var charac = characteristicNames.Get(id);
//                                if (charac != null)
//                                {
//                                    characteristicNames.Delete(charac.Id);
//                                }
//                            }
//                            Console.WriteLine("--------------------------------------------");
//                        }
//                    }

//                    static void doRequests()
//        {
//                        string choice = "X";
//                        do
//                        {
//                            Console.WriteLine("1. List Requests");
//                            Console.WriteLine("2. Insert Request");
//                            Console.WriteLine("3. Edit Request");
//                            Console.WriteLine("4. Delete Request");
//                            Console.WriteLine("9. Return");
//                            choice = Console.ReadLine();

//                            switch (choice)
//                            {
//                                case "1": { listRequests(); break; }
//                                case "2": { insertRequest(); break; }
//                                case "3": { editRequest(); break; }
//                                case "4": { deleteRequest(); break; }
//                            }
//                        }
//                        while (choice != "9");
//                    }

//        public static void listRequests()
//        {
//            using (SchoolContext context = new SchoolContext())
//            {
//                Repository<Request> requestUnit = new Repository<Request>(context);
//                var requests = requestUnit.Get().ToList();
//                foreach (var request in requests)
//                {
//                    Console.WriteLine(request.Id + ": " + request.requestType + " - " + request.RequestDescription + " - " + request.RequestDate + " - " + request.Status + " - " + request.Asset + " - " + request.User);
//                }
//            }
//            Console.WriteLine("--------------------");
//        }

//        AssetCategory = (AssetCategory)Enum.Parse(typeof(AssetCategory), row.ItemArray.GetValue(0).ToString()),
//                    Name = row.ItemArray.GetValue(1).ToString(),
//                };
//    requestUnit.Insert(request);
//            }
//Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }




//        static void editRequest()
//{
//    Console.WriteLine();
//    Console.WriteLine("Request ID: ");
//    string reqId = Console.ReadLine();
//    if (reqId != "")
//    {
//        int id = Convert.ToInt32(reqId);

//        using (SchoolContext context = new SchoolContext())
//        {
//            Repository<Request> requestUnit = new Repository<Request>(context);
//            var request = requestUnit.Get(id);
//            if (request != null)
//            {
//                Console.Write("Edit request status: ");

//                Console.Write("Status [1 - Awaiting for approval, 2 - Canceled, 3 - Approved, 4 - Completed, 5 - In Process]: ");
//                RequestStatus status = (RequestStatus)Convert.ToInt32(Console.ReadLine());
//                request.Status = status;

//                requestUnit.Update(request, id);
//            }
//        }
//        Console.WriteLine("DONE!");
//        Console.WriteLine("--------------------");
//    }
//}

//static void deleteRequest()
//{
//    Console.WriteLine();
//    Console.WriteLine("Request ID: ");
//    string id = Console.ReadLine();
//    int reqId = Convert.ToInt32(id);
//    using (SchoolContext context = new SchoolContext())
//    {
//        Repository<Request> requestUnit = new Repository<Request>(context);
//        requestUnit.Delete(reqId);
//    }
//    Console.WriteLine("You deleted request: " + id);
//    Console.WriteLine("----------------------");
//}

//static void doHistory()
//{
//    string choice = "X";
//    do
//    {
//        Console.WriteLine("1. List History");
//        Console.WriteLine("2. Insert history");
//        Console.WriteLine("3. Edit history");
//        Console.WriteLine("4. Delete history");
//        Console.WriteLine("9. Return");
//        choice = Console.ReadLine();

//        switch (choice)
//        {
//            case "1": { listHistory(); break; }
//            case "2": { insertHistory(); break; }
//            case "3": { editHistory(); break; }
//            case "4": { deleteHistory(); break; }
//        }
//    }
//    while (choice != "9");
//}

//public static void listHistory()
//{
//    using (SchoolContext context = new SchoolContext())
//    {
//        Repository<History> historyUnit = new Repository<History>(context);
//        var histories = historyUnit.Get().ToList();
//        foreach (var history in histories)
//        {
//            Console.WriteLine(history.Id + ": " + history.EventBegin + " - " + history.EventEnd + " - " + history.Asset + " - " + history.Description + " - " + history.Status + " - " + history.Person);
//        }
//    }
//    Console.WriteLine("--------------------");
//}

//static void insertHistory()
//{
//    using (SchoolContext context = new SchoolContext())
//    {
//        Repository<History> historyUnit = new Repository<History>(context);
//        Repository<Person> person = new Repository<Person>(context);
//        Repository<Asset> assets = new Repository<Asset>(context);

//        Console.WriteLine();
//        Console.Write("New history entry: ");
//        DateTime historyEventBegin;

//        Console.Write("Please enter date of asset procurement : ");
//        historyEventBegin = Convert.ToDateTime(Console.ReadLine());

//        DateTime historyEventEnded;

//        Console.Write("Please enter the end date of asset procurement : ");
//        historyEventEnded = Convert.ToDateTime(Console.ReadLine());


//        Console.Write("Status [1 - Active, 2 - Inactive]: ");
//        string status = Console.ReadLine();
//        Console.WriteLine("Asset id: ");
//        int idAsset = Convert.ToInt32(Console.ReadLine());
//        var asset = assets.Get(idAsset);
//        Console.WriteLine("Please enter the person id: ");
//        int idPerson = Convert.ToInt32(Console.ReadLine());
//        var persons = person.Get(idPerson);

//        History history = new History()
//        {
//            EventBegin = historyEventBegin,
//            EventEnd = historyEventEnded,
//            Asset = asset,
//            Person = persons,
//            Status = (HistoryStatus)Convert.ToInt32(status)
//        };
//        historyUnit.Insert(history);
//    }
//    Console.WriteLine("DONE!");
//    Console.WriteLine("--------------------");
//}

//static void editHistory()
//{
//    Console.WriteLine();
//    Console.WriteLine("History ID: ");
//    string hid = Console.ReadLine();
//    if (hid != "")
//    {
//        int id = Convert.ToInt32(hid);

//        using (SchoolContext context = new SchoolContext())
//        {
//            Repository<History> historyUnit = new Repository<History>(context);
//            var histories = historyUnit.Get(id);
//            if (histories != null)
//            {
//                Console.Write("Edit History status: ");
//                string status = Console.ReadLine();
//                History history = new History()
//                {
//                    //nesto

//                    Status = (HistoryStatus)Convert.ToInt32(status)
//                };
//                historyUnit.Insert(history);
//            }
//            Console.WriteLine("DONE!");
//            Console.WriteLine("--------------------");
//        }
//    }
//}



//static void deleteHistory()
//{
//    Console.WriteLine();
//    Console.WriteLine("History ID: ");
//    string id = Console.ReadLine();
//    int hid = Convert.ToInt32(id);
//    using (SchoolContext context = new SchoolContext())
//    {
//        Repository<History> historyUnit = new Repository<History>(context);
//        historyUnit.Delete(hid);
//    }

//    Console.WriteLine("You deleted history: " + id);

//    Console.WriteLine("----------------------");
//}

//            }
//        }

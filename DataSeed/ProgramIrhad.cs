using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace DataSeed
{
    class ProgramIrhad
    {
        static SchoolContext context = new SchoolContext();
        static Repository<Characteristic> characteristicsUnit = new Repository<Characteristic>(context);
        static Repository<Resource> resourceUnit = new Repository<Resource>(context);
        static void Main(string[] args)
        {
            string choice = "X";
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Show all Characteristics: ");
                Console.WriteLine("2. Show one Characteristics: ");
                Console.WriteLine("3. Crate new Characteristic: ");
                Console.WriteLine("4. Update Characteristic: ");
                Console.WriteLine("5. Delete Characteristic: ");
                Console.WriteLine("9. End.");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": { showAllCharacteristics(); break; }
                    case "2": { showOneCharacteristics(); break; }
                    case "3": { createNewCharacteristic(); break; }
                    case "4": { updateCharacteristic(); break; }
                    case "5": { deleteCharacteristic(); break; }
                   
                }
            }
            while (choice != "9");
        }
        static void showAllCharacteristics()
        {
            var characteristics = characteristicsUnit.Get().ToList();
            foreach (var characteristic in characteristics)
            {
                Console.WriteLine("id: "+characteristic.Id+" name: " + characteristic.Name + " value: " + characteristic.Value +" resource: "+characteristic.Resource.Name);
            }
            Console.ReadKey();
        }
        static void showOneCharacteristics()
        {
            Console.WriteLine("Enter the id of the characteristic");
            int id = Convert.ToInt32(Console.ReadLine());
            var characteristic = characteristicsUnit.Get(id);
         
                Console.WriteLine("id: " + characteristic.Id + " name: " + characteristic.Name + " value: " + characteristic.Value + " resource: " + characteristic.Resource.Name);
            
            Console.ReadKey();
        }
        static void createNewCharacteristic()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the name of the characteristic: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the value of the characteristic: ");
            string value = Console.ReadLine();
            var resource = resourceUnit.Get(2);
            Characteristic charac = new Characteristic()
            {
                Name = name,
                Value = value,
                Resource = resource
            };
            characteristicsUnit.Insert(charac);

        }
        static void updateCharacteristic()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the id of the charactaristic you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            var charac = characteristicsUnit.Get(id);
            if( charac != null)
            {
                Console.WriteLine("Enter the name of the characteristic: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the value of the characteristic: ");
                string value = Console.ReadLine();
                var resource = resourceUnit.Get(2);
                charac.Name = name;
                charac.Value = value;
                charac.Resource = resource;
                characteristicsUnit.Update(charac, charac.Id);
            }
        }
       static void deleteCharacteristic()
        {
            Console.WriteLine();
                       Console.WriteLine("Enter the id of the characteristic you want to delete");
                       int id = Convert.ToInt32(Console.ReadLine());
                        var charc = characteristicsUnit.Get(id);
                        if (charc != null)
                        {
                           characteristicsUnit.Delete(charc.Id);
                       }
        }
    }
}

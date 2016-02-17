// PROCUREMENT SYSTEM
namespace Database
{
//  Basic assets data
    public class Asset
<<<<<<< HEAD
    {       
        // public int AssetId { get; set; } instead of classId in all our projects we will use just Id (convention)
        public int Id { get; set; }
        
        public string Description { get; set; }     // asset description [name]
        public string Vendor { get; set; }          // vendor - so far just description - maybe separate class in the future
        public double Price { get; set; }           // price
        
        // public string EmployeeID { get; set; } we will use navigation to person instead of simple foreign key
        public Person User { get; set; }            // person who use particular asset 
        
        // public enum Status { Active=1,Coming_soon=2, Out_of_order=3 } we will put status to enumerators
        public AssetStatus Status { get; set; }
=======
    {
        [Key]
        public int AssetId { get; set; }
        public string Description { get; set; }
        Dictionary<string, string> Characteristics = new Dictionary<string, string>();
        public string Vendor { get; set; }
        public double Price { get; set; }
        virtual public string  EmployeeID { get; set; }
        public enum Status { Active=1,Coming_soon=2, Out_of_order=3 }
>>>>>>> 6155270056ed97d5e20f0b3dabfc43a72c8c3bc7
    }
}

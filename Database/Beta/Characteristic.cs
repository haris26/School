// RESERVATION SYSTEM
namespace Database
{
//  Characteristic of the various resources
    public class Characteristic
    {
        public int Id { get; set; }                                         // Identity[1]
        public string Name { get; set; }                                    // Name of the charasteristic
        public string Value { get; set; }                                   // Value of the characteristic
        public virtual Resource Resource { get; set; }                      // Navigation to the resource 

    }
}

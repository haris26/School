// RESERVATION SYSTEM
namespace Database
{
//  Resources
    public class Resource
    {
        public int Id { get; set; }             // Identity[1]
        public string Name { get; set; }        // Name

        public int  CategoryId { get; set;}     // Category ??? We need a class here, but class is not defined yet
    }
}

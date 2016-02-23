using System.Collections.Generic;

namespace Database
{
    //Category of the resource
    public class ResourceCategory
    {
        public int Id { get; set; }                                                         //Identity[1]
        public string CategoryName { get; set; }                                            //Name of the category
        public virtual ICollection<CharacteristicName> CharacteristicNames  { get; set; }   //Name of characteristics for specific category
    }
}
                                  
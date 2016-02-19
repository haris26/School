namespace Database
{
    public class AssetCharacteristicNames
    {
        public int Id { get; set; }
        public virtual AssetCategory AssetCategory { get; set; }      //Navigation to the resource category
        public string Name { get; set; }
    }
}
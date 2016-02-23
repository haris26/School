using System.Data.Entity;
using Database;

namespace DataSeed
{
    class CharacteristicUnit: Repository<Characteristic>
    {
        public CharacteristicUnit(SchoolContext context) : base(context)
        {

        }

        public override void Insert(Characteristic characteristic)
        {
            context.CategoryCharacteristics.Add(characteristic);
            context.Entry(characteristic.Resource).State = EntityState.Unchanged;
            context.SaveChanges();
        }
    }
}

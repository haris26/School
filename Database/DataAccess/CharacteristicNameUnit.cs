using System.Data.Entity;


namespace Database
{
    public class CharacteristicNameUnit : Repository<CharacteristicName>
    {
        public CharacteristicNameUnit(SchoolContext context) : base(context)
        {

        }
        public override void Insert(CharacteristicName entity)
        {
            context.CharacteristicNames.Add(entity);
            context.Entry(entity.ResourceCategory).State = EntityState.Unchanged;
            context.SaveChanges();
        }
        public override void Update(CharacteristicName entity, int id)
        {
            CharacteristicName oldEntity = Get(id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                oldEntity.ResourceCategory = entity.ResourceCategory;
                context.SaveChanges();

            }
        }
    }
}

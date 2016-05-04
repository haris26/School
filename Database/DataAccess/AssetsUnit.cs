using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AssetsUnit : Repository<Asset>
    {
        public AssetsUnit(SchoolContext context) : base(context)
        {

        }



        public override void Insert(Asset entity)
        {

            context.Assets.Add(entity);
            context.Entry(entity.User).State = EntityState.Unchanged;
            context.Entry(entity.AssetCategory).State = EntityState.Unchanged;


         
         context.SaveChanges();

        }

        public override void Update(Asset entity, int Id)
        {
            Asset oldEntity = Get(Id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                oldEntity.User = entity.User;
                context.SaveChanges();
            }

        }
    }
}
   
       

    

  


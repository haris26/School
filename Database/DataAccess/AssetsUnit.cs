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
        public override void Update(Asset entity, int id)
        {
            Asset oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.User = entity.User;
                oldEnt.AssetCategory = entity.AssetCategory;
                context.SaveChanges();
            }
        }

    }
}
   
       

    

  


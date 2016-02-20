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

        public SchoolContext context = new SchoolContext();

        public override void Insert(Asset asset)
        {
            context.Assets.Add(asset);
            context.Entry(asset.User).State = EntityState.Unchanged;
        
            
            
            context.SaveChanges();

        }

    }
}
   
       

    

  


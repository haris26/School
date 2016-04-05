using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class Characteristics
    {
        public static IList<CharacteristicsListModel> Create (Resource resource)
        {
            SchoolContext context = new SchoolContext();
            IList<CharacteristicsListModel> models = new List<CharacteristicsListModel>();

            var characteristics = new Repository<Characteristic>(context).Get().ToList().Where(x => x.Resource.Id == resource.Id).ToList();

            foreach(var c in characteristics)
            {
                models.Add(new CharacteristicsListModel()
                {
                    Id = resource.Id,
                    Name = c.Name,
                    Value = c.Value
                });
            }

            return models;
        }
    }
}
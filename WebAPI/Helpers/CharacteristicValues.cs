using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Helpers
{
    public static class CharacteristicValues
    {
        public static IList<string> Create (string Type, SchoolContext context)
        {
            IList<string> result = new List<string>();
            var characteristicNames = context.CharacteristicNames.Select(x => x.Name).ToList();

            if (characteristicNames.Contains(Type))
            {
                result = GetCharacteristics(Type, context);

            }
            else
            {
                result = GetResources(Type, context);
            }

            return result;
        }

        public static IList<string> GetCharacteristics (string Type, SchoolContext context)
        {
            var osTypes = context.CategoryCharacteristics.ToList().Where(x => x.Name == Type).Select(x => x.Value).Distinct().ToList();

            return osTypes;
        }

        public static IList<string> GetResources (string Type, SchoolContext context)
        {
            List<Characteristic> items = context.CategoryCharacteristics.ToList().Where(x => x.Value == Type).Distinct().ToList();
            List<string> allResources = new List<string>();

            foreach (var item in items)
            {
                string resource = context.Resources.ToList().Where(x => x.Characteristics.Contains(item)).Select(x => x.Name).FirstOrDefault();
                allResources.Add(resource);
            }

            return allResources;
        }
    }
}
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebAPI.Models
{
    public class ModelFactory
    {

        public TeamModel Create(Team team)
        {
            TeamModel model = new TeamModel()
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                Type = team.Type.ToString()
            };
            foreach (var person in team.Roles)
            {
                model.Members.Add(new MemberModel() { Name = person.Person.FirstName + " " + person.Person.LastName, Role = person.Role.Name });
            }
            return model;
        }
        public RequestModel Create(Request request)
        {
            return new RequestModel()
            {
                Id = request.Id,
                requestType = request.requestType,
                RequestDescription = request.RequestDescription,
                RequestMessage = request.RequestMessage,
                RequestDate = request.RequestDate,
               // Asset = request.Asset.Id,
              //  AssetModel = request.Asset.Name,
                Person = request.User.Id,
                PersonName = request.User.FirstName + " " + request.User.LastName,
                Category = request.AssetCategory.Id,
                CategoryName = request.AssetCategory.CategoryName,
                Quantity = request.Quantity,
                Status = request.Status,
                AssetType = request.AssetType,


            };
        }

        public RoleModel Create(Role role)
        {
            return new RoleModel()
            {
                Id = role.Id,
                Name = role.Name,
                Count = role.Roles.Count
            };
        }

        public PeopleModel Create(Person person)
        {
            return new PeopleModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Category = person.Category,
                Phone = person.Phone,
                Status = person.Status
            };
        }
    }
    }

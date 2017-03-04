using PeoplePets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using PeoplePets.Models;
using ServiceWrapper.People;

namespace PeoplePets.BusinessLayer
{
    public class People : IPeople
    {
        public IEnumerable<string> GetOwnerCatNames()
        {
            try
            {
                var owners = new PeopleWrapper().GetOwners();
                if (owners != null && owners.Any())
                {
                    return owners.Where(o => o.pets != null)
                        .SelectMany(o => o.pets.Where(p => p != null && p.type.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))
                        .Select(p => p.name)).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public IEnumerable<string> GetOwnerCatNames(string gender)
        {
            try
            {
                var owners = new PeopleWrapper().GetOwners();
                if (owners != null && owners.Any())
                {
                    return owners.Where(o => o.gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase) && o.pets != null)
                    .SelectMany(o => o.pets.Where(p => p != null && p.type.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))
                    .Select(p => p.name)).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}

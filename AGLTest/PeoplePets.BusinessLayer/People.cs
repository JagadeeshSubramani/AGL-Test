using PeoplePets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using PeoplePets.ViewModels;
using ServiceWrapper.People;

namespace PeoplePets.BusinessLayer
{
    public class People : IPeople
    {
        public IEnumerable<Owner> GetOwnerCatNames()
        {
            try
            {
                var owners = new PeopleWrapper().GetOwners();
                if (owners != null && owners.Any())
                {
                    var maleOwnerCatNames = owners.Where(o => o.gender.Equals("male", StringComparison.InvariantCultureIgnoreCase) && o.pets != null)
                        .SelectMany(o => o.pets.Where(p => p.type.Equals("cat", StringComparison.InvariantCultureIgnoreCase)))
                        .OrderBy(p => p.name )
                        .Select(p => p.name ).ToList();

                    var maleOwner = new Owner()
                    {
                        Gender = "Male",
                        CatNames = maleOwnerCatNames
                    };

                    var femaleOwnerCatNames = owners.Where(o => o.gender.Equals("female", StringComparison.InvariantCultureIgnoreCase) && o.pets != null)
                        .SelectMany(o => o.pets.Where(p => p.type.Equals("cat", StringComparison.InvariantCultureIgnoreCase)))
                        .OrderBy(p => p.name)
                        .Select(p => p.name ).ToList();

                    var femaleOwner = new Owner()
                    {
                        Gender = "Female",
                        CatNames = femaleOwnerCatNames
                    };

                    return new List<Owner>() { maleOwner, femaleOwner };
                }
                else
                {
                    return new List<Owner>();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public Owner GetOwnerCatNames(string gender)
        {
            try
            {
                var owners = new PeopleWrapper().GetOwners();
                if (owners != null && owners.Any())
                {
                    var catNames = owners.Where(o => o.gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase) && o.pets != null)
                    .SelectMany(o => o.pets.Where(p => p.type.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))                    
                    .Select(p => p.name))
                    .OrderBy(n => n).ToList();

                    return new Owner { Gender = gender, CatNames = catNames };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}

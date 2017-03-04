using System.Collections.Generic;

namespace PeoplePets.Models
{
    public class Owner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }
    }
}
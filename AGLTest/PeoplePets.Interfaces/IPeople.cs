using PeoplePets.ViewModels;
using System.Collections.Generic;

namespace PeoplePets.Interfaces
{
    public interface IPeople
    {
        IEnumerable<Owner> GetOwnerCatNames();

        Owner GetOwnerCatNames(string gender);
    }
}

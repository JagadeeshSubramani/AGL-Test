using System.Collections.Generic;

namespace PeoplePets.Interfaces
{
    public interface IPeople
    {
        IEnumerable<string> GetOwnerCatNames();

        IEnumerable<string> GetOwnerCatNames(string gender);
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PeoplePets.Tests
{
    [TestClass]
    public class PeoplePetTest
    {
        [TestMethod]
        public void GetCatNames()
        {
            var expectedCatNames = new List<string>
            {
                "Garfield",
                "Garfield",
                "Tom",
                "Max",
                "Jim",
                "Tabby",
                "Simba"
            };

            var catNames = new PeoplePets.BusinessLayer.People().GetOwnerCatNames();

            CollectionAssert.AreEqual(expectedCatNames, (List<string>)catNames);
        }

        [TestMethod]
        public void GetMaleOwnerCatNames()
        {
            var expectedCatNames = new List<string>
            {
                "Garfield",
                "Tom",
                "Max",
                "Jim",
            };

            var catNames = new PeoplePets.BusinessLayer.People().GetOwnerCatNames("Male");

            CollectionAssert.AreEqual(expectedCatNames, (List<string>)catNames);
        }

        [TestMethod]
        public void GetFemaleOwnerCatNames()
        {
            var expectedCatNames = new List<string>
            {
                "Garfield",
                "Tabby",
                "Simba"
            };

            var catNames = new PeoplePets.BusinessLayer.People().GetOwnerCatNames("Female");

            CollectionAssert.AreEqual(expectedCatNames, (List<string>)catNames);
        }
    }
}

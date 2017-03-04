using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeoplePets.ViewModels;
using System.Collections.Generic;

namespace PeoplePets.Tests
{
    [TestClass]
    public class PeoplePetTest
    {
        [TestMethod]
        public void GetCatNames()
        {
            var expected = new List<Owner>
            {
                new Owner
                {
                    Gender = "Male",
                    CatNames = new List<string>
                    {
                        "Garfield",
                        "Jim",
                        "Max",
                        "Tom",
                    }
                },
                new Owner
                {
                    Gender = "Female",
                    CatNames = new List<string>
                    {
                        "Garfield",
                        "Simba",
                        "Tabby",
                    }
                }
             };

            var owerCatNames = (List<Owner>)new PeoplePets.BusinessLayer.People().GetOwnerCatNames();
            for (int i = 0; i < expected.Count; i++)            
            {
                Assert.AreEqual(expected[i].Gender, owerCatNames[i].Gender);
                CollectionAssert.AreEqual(expected[i].CatNames, owerCatNames[i].CatNames);
            }            
        }

        [TestMethod]
        public void GetMaleOwnerCatNames()
        {
            var expected = new Owner
            {
                Gender = "Male",
                CatNames = new List<string>
                    {
                        "Garfield",
                        "Jim",
                        "Max",
                        "Tom",
                    }
            };

            var catNames = new PeoplePets.BusinessLayer.People().GetOwnerCatNames("Male");

            CollectionAssert.AreEqual(expected.CatNames, catNames.CatNames);
        }

        [TestMethod]
        public void GetFemaleOwnerCatNames()
        {
            var expected = new Owner
            {
                Gender = "Female",
                CatNames = new List<string>
                    {
                        "Garfield",
                        "Simba",
                        "Tabby",
                    }
            };

            var catNames = new PeoplePets.BusinessLayer.People().GetOwnerCatNames("Female");

            CollectionAssert.AreEqual(expected.CatNames, catNames.CatNames);
        }
    }
}

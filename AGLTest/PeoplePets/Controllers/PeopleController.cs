using PeoplePets.Interfaces;
using PeoplePets.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PeoplePets.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeople _people;
        
        public PeopleController(IPeople people)
        {
            _people = people;
        }

        [ActionName("Cats")]
        public ActionResult GetCatNames(string gender)
        {
            if (ModelState.IsValid)
            {
                if (gender == null)
                {
                    return View((List<Owner>)_people.GetOwnerCatNames());
                }
                else
                {
                    return View(new List<Owner> { _people.GetOwnerCatNames(gender) });
                }
            }
            return new EmptyResult();
        }
    }
}
using PeoplePets.Interfaces;
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
                IEnumerable<string> catNames;
                if (gender == null)
                {
                    ViewData["Gender"] = "All";
                    catNames = _people.GetOwnerCatNames();
                }
                else
                {
                    ViewData["Gender"] = gender;
                    catNames = _people.GetOwnerCatNames(gender);
                }
                if (((List<string>)catNames).Count > 0)
                    return View(catNames);
            }
            return new EmptyResult();
        }
    }
}
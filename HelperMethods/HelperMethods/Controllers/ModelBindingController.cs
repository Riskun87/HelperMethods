using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class ModelBindingController : Controller
    {
        private Person[] personData =
        {
            new Person { PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin },
            new Person { PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User },
            new Person { PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User },
            new Person { PersonId = 4, FirstName = "Anne", LastName = "Jone", Role = Role.Guest }
        };


        public ActionResult Index(int id)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix="HomeAddress", Exclude="Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult NamesCollection(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        /*public ActionResult Address(FormCollection formData)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            try
            {
                UpdateModel(addresses, formData);
            } catch (InvalidOperationException ex)
            {
                // provide feedback to user
            }
            return View(addresses);
        }*/

        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses);
            return View(addresses);
        }
    }
}
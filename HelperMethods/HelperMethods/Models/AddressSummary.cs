using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperMethods.Infrastructure;

namespace HelperMethods.Models
{
    //[Bind(Include="City")]
    [ModelBinder(typeof(AdressSummaryBinder))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using sample_project.Models;
using Trirand.Web.Mvc;

namespace sample_project.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult ChartDemo()
        {
            return View();
        }
    }
}

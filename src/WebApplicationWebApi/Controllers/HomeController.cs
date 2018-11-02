using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AsyncAwaitAnalysisCommon;

namespace WebApplicationWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            TestCase.RunTestTaskAsync().GetAwaiter().GetResult();

            return View();
        }

        public async Task<ActionResult> IndexAsync()
        {
            ViewBag.Title = "Home Page";

            await TestCase.RunTestTaskAsync();

            return View();
        }
    }
}

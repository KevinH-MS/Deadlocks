using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Deadlocks.Controllers
{
    public class HomeController : Controller
    {
        async Task<string> GetTitleAsync()
        {
            return await Task.Factory.StartNew(() => "Home Page", TaskCreationOptions.LongRunning);
        }

        public ActionResult Index()
        {
            var t = GetTitleAsync();

            ViewBag.Title = t.Result;

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplication1.Models;
using static WebApplication1.Program;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var query = new List<CellPhone>();
            using (var db = new CodeFirstContext())
            {
                query = db.CellPhones.ToList();
            }
            return View(query);
        }

        [HttpGet]
        public ActionResult NewCellPhone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CellPhone cellphone)
        {
            var query = new List<CellPhone>();
            using (var db = new CodeFirstContext())
            {
                var cellPhone = new CellPhone { cellPhoneBrand = cellphone.cellPhoneBrand, 
                                                cellPhoneModel = cellphone.cellPhoneModel, price = cellphone.price };
                db.CellPhones.Add(cellPhone);
                db.SaveChanges();

                query = db.CellPhones.ToList();
            }
            return View("Index", query);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WAppActionResults.Utils.ActionResults;

namespace WAppActionResults.Controllers
{
    public class ExcelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]//[HttpPost]
        public async Task<ActionResult> GenerateExcel()
        {
            var guid = Guid.NewGuid().ToString();
            var list = new[] {
                new { Name="Juan", Age=32, Email="juan@server.com", Date = DateTime.Today },
                new { Name="Jose", Age=22, Email="jose@server.com", Date = DateTime.Today.AddMonths(-3) },
                new { Name="Michael", Age=52, Email="michael@server.com", Date = DateTime.Today.AddYears(-23) },
                new { Name="Arturo", Age=32, Email="art@server.com", Date = DateTime.Today.AddYears(-34) },
            };

            //await Task.Delay(5000);
            //TempData[guid] = ExcelResult.Generar(list, "excel");
            //return Json(new { Guid = guid });

            return new ExcelResult("excel", list);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WAppActionResults.Utils.ActionResults;

namespace WAppActionResults.Controllers
{
    public class Persona
    {
        public string Nombre { get; set; }
    }

    //https://msdn.microsoft.com/en-us/library/system.web.mvc.actionresult(v=vs.118).aspx
    //https://developer.mozilla.org/es/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Lista_completa_de_tipos_MIME

    public class HomeController : Controller
    {
        //EJEMPLO 0:
        //public ActionResult Index()
        //{
        //    return new EmptyResult();
        //    return Empty();  
        //}

        //EJEMPLO 1: POr defecto se devuelve un ContentResult
        //public Persona Index()
        //{
        //    return DateTime.Now.Second;
        //}

        //EJEMPLO 1.1: POr defecto se devuelve un ContentResult
        //public Persona Index()
        //{
        //    return new Persona { Nombre = "Michael Emir" };
        //}

        //EJEMPLO 2:
        //public ActionResult Index()
        //{
        //    var persona = new Persona { Nombre = "Michael Emir" };

        //    //return new ContentResult { Content = $"{persona.Nombre}" };
        //    return Content($"{persona.Nombre}", "text/csv");
        //}

        //EJEMPLO 3:
        //public ActionResult Index()
        //{            
        //    return new FileContentResult(new byte[] { }, "mime type");
        //    //Stream
        //    return new FileStreamResult(new FileStream("", FileMode.Open), "mime type");
        //    //Archivo en disco del servidor
        //    return new FilePathResult("", "mime type");

        //    return File(new byte[] { }, "mime type");
        //}

        //  EJEMPLO 4: LLAMADA AJAX DE LOGIN
        //public ActionResult Index()
        //{
        //    ActionResult result;

        //    if (true) //resultado del logeo
        //    {
        //        result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Acceso no permitido.");
        //    }

        //    return result;
        //}

        //EJEMPLOT 5: se redirige a la pagina configurada en el Web.config
        //public ActionResult Index()
        //{
        //    ActionResult result;

        //    if (true) //resultado del logeo
        //    {
        //        //ambos permiten devolver una descripción
        //        result = new HttpUnauthorizedResult("Acceso no permitido.");
        //        result = new HttpNotFoundResult("Recurso no encontrado.");
        //    }

        //    return result;
        //}

        //EJEMPLO 6
        //public ActionResult Index()
        //{
        //    var persona = new Persona { Nombre = "Michael Emir" };

        //    return Json(persona, JsonRequestBehavior.AllowGet); //por motivos de seguridad por defecto no se permiten llamadas GET
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
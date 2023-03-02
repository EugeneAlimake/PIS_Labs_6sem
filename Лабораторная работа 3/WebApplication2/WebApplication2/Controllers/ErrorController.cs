using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound(string catchall = null)
        {
            Response.Write($"{Request.HttpMethod}: {catchall} не поддерживается");
            return new HttpNotFoundResult();
        }
    }
}
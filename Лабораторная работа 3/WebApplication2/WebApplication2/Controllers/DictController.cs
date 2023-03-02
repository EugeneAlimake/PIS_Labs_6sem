using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DictController : Controller
    {
        public TelephoneBook Book { get; set; } = new TelephoneBook();
        // GET: Dict
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.TelephoneBook = Book.GetAll();//представляет определить различные свойства и присвоить им любые значения
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(string surname, string phoneNumber)
        {
            Book.AddRow(surname, phoneNumber);
            return RedirectPermanent("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSave(int? id, string surname, string phoneNumber)
        {
            if (!id.HasValue)
            {
                return RedirectPermanent("/Dict/Error");
            }


            if (!Book.Update(id.Value, surname, phoneNumber))
            {
                return RedirectPermanent("/Dict/Error");
            }
            return RedirectPermanent("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectPermanent("/Dict/Error");
            }

            if (!Book.Delete(id.Value))
            {
                return RedirectPermanent("/Dict/Error");
            }

            return RedirectPermanent("/Dict/Index");
        }
    }
}
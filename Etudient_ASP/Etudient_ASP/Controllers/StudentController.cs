using Etudient_ASP.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etudient_ASP.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        db_TestEntites dbobj = new db_TestEntites();
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Client model)
        {

           Client obj = new Client();
            obj.Id = model.Id;
            obj.Nom = model.Nom;
            obj.Prénom = model.Prénom;
            obj.Adresse = model.Adresse;
           // object p = dbobj.Client.Add(obj);
            dbobj.Savechange();

            return View("Student");
        }
    }
}
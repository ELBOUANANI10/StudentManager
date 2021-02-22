using Microsoft.AspNetCore.Mvc;
using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _std;
        public StudentController(StudentContext std)
        {
            _std = std;
        }
        public IActionResult Index()
        {
            var list = _std.Students.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Index(string search)
        {
            var studentSearch = from a in _std.Students select a;
            if (!String.IsNullOrEmpty(search))
            {
                studentSearch = studentSearch.Where(b => b.FName.Contains(search) || b.LName.Contains(search));
            }
            return View(studentSearch.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _std.Add(student);
                _std.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var upd = _std.Students.FirstOrDefault(s => s.id == id);
            return View(upd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if(student!=null) 
            { 
                _std.Update(student);
                _std.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var dl = _std.Students.FirstOrDefault(s => s.id == id);
            return View(dl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student student)
        {
            _std.Students.Remove(student);
            _std.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGManager.Domain.Models;
using RPGManager.Factory;
using RPGManager.ILogic;

namespace RPGManager.WebPresentation.Controllers
{
    public class ClassController : Controller
    {
        private IClassLogic _context = ClassLogicFactory.getClassSQLContext();
        private List<ClassCategory> categories = new List<ClassCategory>();
        private User user = new User(1, "Stefan", "Bergh", "stefan__bergh@hotmail.com");

        public ClassController()
        {
                
        }

        // GET: Category
        public IActionResult Index()
        {
            return View(_context.GetAllClasses(user.Id));
        }

        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class cClass = _context.GetAllClasses(user.Id).Find(a => a.Id == id);

            if (cClass == null)
            {
                return NotFound();
            }

            if (cClass.AccountId != user.Id)
            {
                return NotFound();
            }

            return View(cClass);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int ClassCategoryId, string name, int startinglevel)
        {
            Class cClass = new Class(user.Id, ClassCategoryId, name, startinglevel);

            _context.insertClass(cClass);

            return View("Index", _context.GetAllClasses(user.Id));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class cClass = _context.GetAllClasses(user.Id).Find(a => a.Id == id);

            if (cClass == null)
            {
                return NotFound();
            }

            if (cClass.AccountId != user.Id)
            {
                return NotFound();
            }

            return View(cClass);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, int ClassCategoryId, string name, int startinglevel)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class cClass = new Class((int)id, user.Id, ClassCategoryId, name, startinglevel);

            if (cClass == null)
            {
                return NotFound();
            }

            if (cClass.AccountId != user.Id)
            {
                return NotFound();
            }

            _context.updateClass(cClass);

            return View("Index", _context.GetAllClasses(user.Id));
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class cClass = _context.GetAllClasses(user.Id).Find(a => a.Id == id);

            if (cClass == null)
            {
                return NotFound();
            }

            return View(cClass);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cClass = _context.GetAllClasses(user.Id).Find(a => a.Id == id);
            _context.deleteClass(cClass);
            return View("Index", _context.GetAllClasses(user.Id));
        }
    }
}

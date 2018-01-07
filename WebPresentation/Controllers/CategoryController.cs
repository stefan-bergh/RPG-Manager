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
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace RPGManager.WebPresentation.Controllers
{
    public class CategoryController : Controller
    {
        private ICategorieLogic _context = CategorieLogicFactory.getCategorieSQLContext();
        private List<ClassCategory> categories = new List<ClassCategory>();
        private User user = new User(1, "Stefan", "Bergh", "stefan__bergh@hotmail.com");
        
        public CategoryController()
        {
        }

        // GET: Category
        public IActionResult Index()
        {
            return View(_context.GetAllCategorys(user.Id));
        }

        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            ClassCategory classCategory = _context.GetAllCategorys(user.Id).Find(a => a.Id == id);

            if (classCategory == null)
            {
                return NotFound();
            }

            if(classCategory.AccountId != user.Id)
            {
                return NotFound();
            }

            return View(classCategory);
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
        public IActionResult Create(string name, string description)
        {            
            ClassCategory classCategory = new ClassCategory(user.Id, name, description);

            _context.insertCategory(classCategory);

            return View("Index", _context.GetAllCategorys(user.Id));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            ClassCategory classCategory = _context.GetAllCategorys(user.Id).Find(a => a.Id == id);

            if (classCategory == null)
            {
                return NotFound();
            }

            if (classCategory.AccountId != user.Id)
            {
                return NotFound();
            }
            
            return View(classCategory);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, string name, string description)
        {            
            if (id != null)
            {
                return NotFound();
            }

            ClassCategory classCategory = new ClassCategory((int)id, user.Id, name, description);
            
            if (classCategory == null)
            {
                return NotFound();
            }

            if (classCategory.AccountId != user.Id)
            {
                return NotFound();
            }

            _context.updateCategory(classCategory);

            return View("Index", _context.GetAllCategorys(user.Id));
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }

            ClassCategory classCategory = _context.GetAllCategorys(user.Id).Find(a => a.Id == id);

            if (classCategory == null)
            {
                return NotFound();
            }

            return View(classCategory);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {            
            var classCategory = _context.GetAllCategorys(user.Id).Find(a => a.Id == id);
            _context.deleteCategory(classCategory);
            return View("Index", _context.GetAllCategorys(user.Id));
        }
    }
}

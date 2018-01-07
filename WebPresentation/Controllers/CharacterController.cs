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
    public class CharacterController : Controller
    {
        private ICharacterLogic _context = CharacterLogicFactory.getCharacterSQLContext();
        private List<ClassCategory> categories = new List<ClassCategory>();
        private User user = new User(1, "Stefan", "Bergh", "stefan__bergh@hotmail.com");

        public CharacterController()
        {

        }

        // GET: Category
        public IActionResult Index()
        {
            return View(_context.GetAllCharacters(user.Id));
        }

        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _context.GetAllCharacters(user.Id).Find(a => a.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            if (character.AccountId != user.Id)
            {
                return NotFound();
            }

            return View(character);
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
        public IActionResult Create(string name, int startingLevel, int classId)
        {
            Character character = new Character(user.Id, name, startingLevel, classId);

            _context.insertCharacter(character);

            return View("Index", _context.GetAllCharacters(user.Id));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _context.GetAllCharacters(user.Id).Find(a => a.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            if (character.AccountId != user.Id)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, string name, int startingLevel, int classId)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = new Character((int)id, user.Id, name, startingLevel, classId);

            if (character == null)
            {
                return NotFound();
            }

            if (character.AccountId != user.Id)
            {
                return NotFound();
            }

            _context.updateCharacter(character);

            return View("Index", _context.GetAllCharacters(user.Id));
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _context.GetAllCharacters(user.Id).Find(a => a.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var character = _context.GetAllCharacters(user.Id).Find(a => a.Id == id);
            _context.deleteCharacter(character);
            return View("Index", _context.GetAllCharacters(user.Id));
        }
    }
}

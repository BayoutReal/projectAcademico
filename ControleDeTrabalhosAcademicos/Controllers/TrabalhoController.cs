using Microsoft.AspNetCore.Mvc;
using ControleDeTrabalhosAcademicos.Models;
using ControleDeTrabalhosAcademicos.Data;
using System.Linq;

namespace ControleDeTrabalhosAcademicos.Controllers
{
    public class TrabalhoController : Controller
    {
        private readonly TrabalhosContext _context;

        public TrabalhoController(TrabalhosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trabalhos = _context.Trabalhos.ToList();
            return View(trabalhos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Trabalhos.Add(trabalho);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(trabalho);
        }

        public IActionResult Edit(int id)
        {
            var trabalho = _context.Trabalhos.FirstOrDefault(t => t.TrabalhoId == id);
            if (trabalho == null)
            {
                return NotFound();
            }
            return View(trabalho);
        }

        [HttpPost]
        public IActionResult Edit(Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Trabalhos.Update(trabalho);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(trabalho);
        }

        public IActionResult Delete(int id)
        {
            var trabalho = _context.Trabalhos.FirstOrDefault(t => t.TrabalhoId == id);
            if (trabalho == null)
            {
                return NotFound();
            }
            return View(trabalho);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var trabalho = _context.Trabalhos.FirstOrDefault(t => t.TrabalhoId == id);
            if (trabalho != null)
            {
                _context.Trabalhos.Remove(trabalho);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var trabalho = _context.Trabalhos.FirstOrDefault(t => t.TrabalhoId == id);
            if (trabalho == null)
            {
                return NotFound();
            }
            return View(trabalho);
        }
    }
}

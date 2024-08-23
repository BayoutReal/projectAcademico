using Microsoft.AspNetCore.Mvc;
using ControleDeTrabalhosAcademicos.Models;
using ControleDeTrabalhosAcademicos.Data;
using System.Linq;

namespace ControleDeTrabalhosAcademicos.Controllers
{
    public class AutorController : Controller
    {
        private readonly TrabalhosContext _context;

        public AutorController(TrabalhosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var autores = _context.Autores.ToList();
            return View(autores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }
    }
}

// File: Controllers/OrientadorController.cs

using Microsoft.AspNetCore.Mvc;
using ControleDeTrabalhosAcademicos.Models;
using ControleDeTrabalhosAcademicos.Data;
using System.Linq;

namespace ControleDeTrabalhosAcademicos.Controllers
{
    public class OrientadorController : Controller
    {
        private readonly TrabalhosContext _context;

        public OrientadorController(TrabalhosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orientadores = _context.Orientadores.ToList();
            return View(orientadores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orientador orientador)
        {
            if (ModelState.IsValid)
            {
                _context.Orientadores.Add(orientador);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orientador);
        }
    }
}

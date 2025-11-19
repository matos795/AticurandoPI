using AticurandoPI.Data;
using AticurandoPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AticurandoPI.Controllers
{
    public class TurmaController : Controller
    {
        private readonly AppDbContext _context;
        public TurmaController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            var turmas = _context.Turmas
            .Include(t => t.Curso)
            .ToList();

            return View(turmas);
        }

        // GET: Turmas/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CursoId = new SelectList(_context.Cursos, "Id", "Nome");
            return View();
        }

        // POST: Turmas/Create
        [HttpPost]
        public IActionResult Create(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CursoId = new SelectList(_context.Cursos, "Id", "Nome");
                return View(turma);
            }

            _context.Turmas.Add(turma); // Model OK → salva
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Turmas/Edit/5
        public IActionResult Edit(int id)
        {
            var turma = _context.Turmas.Find(id);
            if (turma == null) return NotFound();

            ViewBag.CursoId = new SelectList(_context.Cursos, "Id", "Nome");
            return View(turma);
        }

        // POST: Turmas/Edit/5

        [HttpPost]
        public IActionResult Edit(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CursoId = new SelectList(_context.Cursos, "Id", "Nome");
                return View(turma);
            }

            _context.Turmas.Update(turma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Turmas/Delete/5
        public IActionResult Delete(int? id)
        {
            var turma = _context.Turmas.Find(id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var turma = _context.Turmas.Find(id);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Turmas/Details/5
        public IActionResult Details(int? id)
        {
            var turma = _context.Turmas
            .Include(t => t.Curso)
            .FirstOrDefault(t => t.Id == id);

            if (turma == null) return NotFound();

            return View(turma);
        }
    }
}
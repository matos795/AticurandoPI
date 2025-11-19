using AticurandoPI.Data;
using AticurandoPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AticurandoPI.Controllers
{
        public class CursoController : Controller
        {
            private readonly AppDbContext _context;
            public CursoController(AppDbContext context) => _context = context;

            public IActionResult Index()
            {
                return View(_context.Cursos.ToList());
            }

            // GET: Cursos/Create
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

        // POST: Cursos/Create
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Cursos/Edit/5
        public IActionResult Edit(int id)
            {
                var curso = _context.Cursos.Find(id);
                if (curso == null) return NotFound();
                return View(curso);
            }

        // POST: Cursos/Edit/5

        [HttpPost]
        public IActionResult Edit(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

            _context.Cursos.Update(curso);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Cursos/Delete/5
        public IActionResult Delete(int id)
            {
                var curso = _context.Cursos.Find(id);
                if (curso == null) return NotFound();
                return View(curso);
            }

            // POST: Cursos/Delete/5
            [HttpPost]
            public IActionResult DeleteConfirmed(int id)
            {
                var curso = _context.Cursos.Find(id);
                if (curso != null)
                {
                    _context.Cursos.Remove(curso);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            // GET: Cursos/Details/5
            public IActionResult Details(int? id)
            {
                var curso = _context.Cursos.Find(id);
                if (curso == null) return NotFound();
                return View(curso);
            }
        }
    }
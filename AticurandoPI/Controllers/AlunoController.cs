using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AticurandoPI.Data;
using AticurandoPI.Models;
using System.Threading.Tasks;

namespace AticurandoPI.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;
        public AlunoController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            return View(_context.Alunos.ToList());
        }

        // GET: Alunos/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public IActionResult Edit(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        // POST: Alunos/Edit/5

        [HttpPost]
        public IActionResult Edit(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                _context.Alunos.Update(aluno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno != null) 
            {
                _context.Alunos.Remove(aluno);
                _context.SaveChanges();
            } 
            return RedirectToAction("Index");
        }

        // GET: Alunos/Details/5
        public IActionResult Details(int? id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }
    }
}

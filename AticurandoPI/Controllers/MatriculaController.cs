using AticurandoPI.Data;
using AticurandoPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AticurandoPI.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly AppDbContext _context;
        public MatriculaController(AppDbContext context) => _context = context;

        // GET: Index
        public IActionResult Index()
        {
            var matriculas = _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Turma)
                    .ThenInclude(t => t.Curso)
                .ToList();

            return View(matriculas); // passa IEnumerable<Matricula>
        }


        // GET: Create
        public IActionResult Create()
        {
            PreencherViewBags();
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                matricula.DataHora = DateTime.Now;
                matricula.Status = Models.Enumeracoes.StatusMatricula.PENDENTE;

                // Se MotivoCancelamento for null, mantém null (permitido)
                matricula.MotivoCancelamento ??= null;

                _context.Matriculas.Add(matricula);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Repreenche dropdowns caso haja erro de validação
            PreencherViewBags(matricula);
            return View(matricula);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var matricula = _context.Matriculas.Find(id);
            if (matricula == null) return NotFound();

            PreencherViewBags(matricula);
            return View(matricula);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Matriculas.Update(matricula);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            PreencherViewBags(matricula);
            return View(matricula);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var matricula = _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Turma)
                    .ThenInclude(t => t.Curso)
                .FirstOrDefault(m => m.Id == id);

            if (matricula == null) return NotFound();

            return View(matricula);
        }

        // POST: DeleteConfirmed
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var matricula = _context.Matriculas.Find(id);

            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //// GET: Details
        //public IActionResult Details(int id)
        //{
        //    var matricula = _context.Matriculas
        //        .Include(m => m.Aluno)
        //        .Include(m => m.Turma)
        //            .ThenInclude(t => t.Curso)
        //        .FirstOrDefault(m => m.Id == id);

        //    if (matricula == null) return NotFound();

        //    return View(matricula);
        //}

        public IActionResult Aprove(int id)
        {
            var matricula = _context.Matriculas.Find(id);

            if (matricula != null)
            {
                matricula.Status = Models.Enumeracoes.StatusMatricula.ATIVA;
                matricula.DataHora = DateTime.Now;

                _context.Matriculas.Update(matricula);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Método auxiliar para preencher ViewBag com segurança
        private void PreencherViewBags(Matricula matricula = null)
        {
            ViewBag.AlunoId = new SelectList(_context.Alunos.ToList(), "Id", "Nome", matricula?.AlunoId);

            ViewBag.TurmaId = new SelectList(
                _context.Turmas
                    .Include(t => t.Curso)
                    .Select(t => new {
                        Id = t.Id,
                        Nome = ((t.Curso != null ? t.Curso.Nome : "Sem Curso") ?? "Sem Curso") + " - " + (t.Turno ?? "")
                    })
                    .ToList(),
                "Id", "Nome",
                matricula?.TurmaId
            );
        }
    }
}

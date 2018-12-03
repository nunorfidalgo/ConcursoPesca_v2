using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConcursoPesca.Models;

namespace ConcursoPesca.Controllers
{
    public class ConcursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Concursos
        public async Task<ActionResult> Index()
        {
            return View(await db.Concursos.ToListAsync());
        }

        // GET: Concursos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return HttpNotFound();
            }
            return View(concurso);
        }

        // GET: Concursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ConcursoId,Nome,Data,Hora,Localizacao,Descricao")] Concurso concurso)
        {
            if (ModelState.IsValid)
            {
                db.Concursos.Add(concurso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(concurso);
        }

        // GET: Concursos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return HttpNotFound();
            }
            return View(concurso);
        }

        // POST: Concursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ConcursoId,Nome,Data,Hora,Localizacao,Descricao")] Concurso concurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concurso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(concurso);
        }

        // GET: Concursos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return HttpNotFound();
            }
            return View(concurso);
        }

        // POST: Concursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Concurso concurso = await db.Concursos.FindAsync(id);
            db.Concursos.Remove(concurso);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

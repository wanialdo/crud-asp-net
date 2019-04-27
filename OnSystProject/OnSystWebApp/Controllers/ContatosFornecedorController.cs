using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entidade;

namespace OnSystWebApp.Controllers
{
    public class ContatosFornecedorController : Controller
    {
        private OnSystDbContext db = new OnSystDbContext();

        // GET: ContatosFornecedor
        public ActionResult Index()
        {
            var contatosFornecedor = db.ContatosFornecedor.Include(c => c.Fornecedor);
            return View(contatosFornecedor.ToList());
        }

        // GET: ContatosFornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoFornecedor contatoFornecedor = db.ContatosFornecedor.Find(id);
            if (contatoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(contatoFornecedor);
        }

        // GET: ContatosFornecedor/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome");
            return View();
        }

        // POST: ContatosFornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Telefone,FornecedorID")] ContatoFornecedor contatoFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.ContatosFornecedor.Add(contatoFornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", contatoFornecedor.FornecedorID);
            return View(contatoFornecedor);
        }

        // GET: ContatosFornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoFornecedor contatoFornecedor = db.ContatosFornecedor.Find(id);
            if (contatoFornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", contatoFornecedor.FornecedorID);
            return View(contatoFornecedor);
        }

        // POST: ContatosFornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Telefone,FornecedorID")] ContatoFornecedor contatoFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatoFornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", contatoFornecedor.FornecedorID);
            return View(contatoFornecedor);
        }

        // GET: ContatosFornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoFornecedor contatoFornecedor = db.ContatosFornecedor.Find(id);
            if (contatoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(contatoFornecedor);
        }

        // POST: ContatosFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContatoFornecedor contatoFornecedor = db.ContatosFornecedor.Find(id);
            db.ContatosFornecedor.Remove(contatoFornecedor);
            db.SaveChanges();
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

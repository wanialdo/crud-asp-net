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
    public class PropostasController : Controller
    {
        private OnSystDbContext db = new OnSystDbContext();

        // GET: Propostas
        public ActionResult Index()
        {
            var propostas = db.Propostas.Include(p => p.Cliente).Include(p => p.Fornecedores);
            return View(propostas.ToList());
        }

        // GET: Propostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // GET: Propostas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome");
            return View();
        }

        // POST: Propostas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClienteID,FornecedorID")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                string serial = String.Format("{0}{1}{2}",
                                                DateTime.Now.Year,
                                                DateTime.Now.Month.ToString().PadLeft(2,'0'),
                                                DateTime.Now.Day.ToString().PadLeft(2,'0'));

                Proposta ultimoId = db.Propostas
                    .Where(x => x.ClienteID == proposta.ClienteID)
                    .Where(x => x.Numero.ToString().StartsWith(serial))
                    .OrderByDescending(x => x.ID).FirstOrDefault();

                var contador = "01";
                if (ultimoId != null && ultimoId.ID != 0)
                {
                    int ultimovalor = Convert.ToInt32(ultimoId.Numero.ToString().Substring(8)) + 1;
                    contador = ultimovalor.ToString().PadLeft(2, '0');
                }

                proposta.Numero = Convert.ToInt32(serial + contador);
                db.Propostas.Add(proposta);
                db.SaveChanges();

                return RedirectToAction("Edit", new { id = proposta.ID });
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", proposta.ClienteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", proposta.FornecedorID);
            return View(proposta);
        }

        // GET: Propostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", proposta.ClienteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", proposta.FornecedorID);
            return View(proposta);
        }

        // POST: Propostas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClienteID,FornecedorID")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", proposta.ClienteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", proposta.FornecedorID);
            return View(proposta);
        }

        // GET: Propostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // POST: Propostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposta proposta = db.Propostas.Find(id);
            db.Propostas.Remove(proposta);
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

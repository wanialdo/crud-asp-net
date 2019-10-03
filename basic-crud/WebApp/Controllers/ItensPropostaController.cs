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
    public class ItensPropostaController : Controller
    {
        private OnSystDbContext db = new OnSystDbContext();

        // GET: ItensProposta
        public ActionResult Index(int id=0)
        {
            var itensPropostas = db.ItensPropostas.Include(i => i.Proposta);

            if (id != 0)
            {
                itensPropostas = itensPropostas.Where(x => x.PropostaID == id);
                ViewBag.IdProposta = id;
            }

            return View(itensPropostas.ToList());
        }

        // GET: ItensProposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensPropostas.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            return View(itemProposta);
        }

        // GET: ItensProposta/Create
        public ActionResult Create(int idProposta)
        {
            ViewBag.ListaProposta = db.Propostas; // new SelectList(db.Propostas, "ID", "ID");
            ViewBag.IdProposta = idProposta;
            return View();
        }

        // POST: ItensProposta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descrição,Quantidade,Valor,PropostaID")] ItemProposta itemProposta)
        {
            if (ModelState.IsValid)
            {
                db.ItensPropostas.Add(itemProposta);
                db.SaveChanges();
                return RedirectToAction("Edit", "Propostas", new { id = itemProposta.PropostaID });
            }

            ViewBag.PropostaID = new SelectList(db.Propostas, "ID", "ID", itemProposta.PropostaID);
            return View(itemProposta);
        }

        // GET: ItensProposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensPropostas.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropostaID = new SelectList(db.Propostas, "ID", "ID", itemProposta.PropostaID);
            return View(itemProposta);
        }

        // POST: ItensProposta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descrição,Quantidade,Valor,PropostaID")] ItemProposta itemProposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemProposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Propostas", new { id = itemProposta.PropostaID });
            }
            ViewBag.PropostaID = new SelectList(db.Propostas, "ID", "ID", itemProposta.PropostaID);
            return View(itemProposta);
        }

        // GET: ItensProposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensPropostas.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            return View(itemProposta);
        }

        // POST: ItensProposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemProposta itemProposta = db.ItensPropostas.Find(id);
            var idRetorno = itemProposta.Proposta;
            db.ItensPropostas.Remove(itemProposta);
            db.SaveChanges();
            return RedirectToAction("Edit", "Propostas", new { id = idRetorno });
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

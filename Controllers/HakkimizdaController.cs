using KurumsalWeb1.Models.DataContext;
using KurumsalWeb1.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb1.Controllers
{
    public class HakkimizdaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            return View(db.Hakkimizda.ToList());
        }

        public ActionResult Edit(int id)
        {
            var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(hakkimizda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // Ck editör için.
        public ActionResult Edit(int id, Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();

                h.Aciklama = hakkimizda.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }
    }
}
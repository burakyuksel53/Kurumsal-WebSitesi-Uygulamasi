using KurumsalWeb1.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using KurumsalWeb1.Models.Model;

namespace KurumsalWeb1.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);            
            return View();
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.SliderId));
        }

        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }

        public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }

        public ActionResult Hizmetlerimiz()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x => x.HizmetId));
        }

        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad!=null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mail adresi";
                WebMail.Password = "";
                WebMail.SmtpPort = 587;
                WebMail.Send("mail adresi",konu,email + "</br>" + mesaj);
                ViewBag.Uyari("Mesajınız başarıyla gönderildi.");
            }
            else
            {
                ViewBag.Uyari("Lütfen tekrar deneyiniz.");
            }
            return View();
        }

        public ActionResult Blog(int Sayfa = 1)
        {
            return View(db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa,5));
        }

        public ActionResult KategoriBlog(int id, int Sayfa = 1)
        {
            var b = db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).Where(x => x.Kategori.KategoriId == id).ToPagedList(Sayfa,5);
            return View(b);
        }


        public ActionResult BlogDetay(int id)
        {
            return View(db.Blog.Include("Kategori").Include("Comments").Where(x => x.BlogId == id).SingleOrDefault());
        }

        public JsonResult YorumYap(string namesurname, string eposta, string usercomment, int blogid)
        {
            if (usercomment == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Comment.Add(new Comment { NameSurname = namesurname, EPosta = eposta, UserComment = usercomment, BlogId = blogid, Confirm = false });
            db.SaveChanges();            
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public ActionResult BlogKategoriPartial()
        {
            return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));
        }

        public ActionResult SonBlogPartial()
        {
            return PartialView(db.Blog.ToList().OrderBy(x => x.BlogId));
        }

        public ActionResult FooterPartial()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList().OrderByDescending(x => x.HizmetId);
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);

            return PartialView();
        }
    }
}
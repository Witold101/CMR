using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CMRV.App_GlobalResources;
using CMRVLibrary.Main;
using CMRV.Models.Main;

namespace CMRV.Controllers
{
    public class SetupController : Controller
    {
        //Устанавливает поток для нужного языка
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                string currentLangCode = requestContext.RouteData.Values["lang"] as string;

                if (currentLangCode != null)
                {
                    var ci = new CultureInfo(currentLangCode);
                    Thread.CurrentThread.CurrentUICulture = ci;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
                }
            }
            base.Initialize(requestContext);
        }

        private CountryCodeContext db = new CountryCodeContext();

        // GET: /Setup/
        public ActionResult Index()
        {
            ViewBag.MainBarTitle = GlobalRes.Setup;
            return View(db.CountryCodes.ToList());
        }

        // GET: /Setup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryCode countrycode = db.CountryCodes.Find(id);
            if (countrycode == null)
            {
                return HttpNotFound();
            }
            return View(countrycode);
        }

        public ActionResult PartialCountryCode()
        {
            return View("Index", db.CountryCodes.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartialCountryCode([Bind(Include = "Id,Code,Country")] CountryCode countrycode)
        {
            if (ModelState.IsValid)
            {
                List<CountryCode> countryCodes=new List<CountryCode>(db.CountryCodes.ToList());
                if (!countryCodes.FindAll(a=>a.Code.Trim()==countrycode.Code.Trim()).Any())
                {
                    db.CountryCodes.Add(countrycode);
                    db.SaveChanges();
                }
            }
            return PartialView("Index",db.CountryCodes.ToList());
        }



        // GET: /Setup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryCode countrycode = db.CountryCodes.Find(id);
            if (countrycode == null)
            {
                return HttpNotFound();
            }
            return View(countrycode);
        }

        // POST: /Setup/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Code,Country")] CountryCode countrycode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countrycode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countrycode);
        }

        // GET: /Setup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryCode countrycode = db.CountryCodes.Find(id);
            if (countrycode == null)
            {
                return HttpNotFound();
            }
            return View(countrycode);
        }

        // POST: /Setup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryCode countrycode = db.CountryCodes.Find(id);
            db.CountryCodes.Remove(countrycode);
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

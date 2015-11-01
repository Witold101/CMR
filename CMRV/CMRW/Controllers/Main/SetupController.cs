using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CMRW.Controllers.Main
{
    public class SetupController : Controller
    {
        //Устанавливает в потоке язык
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

        crm_dbEntities db = new crm_dbEntities();

        // GET: Setup
        public ActionResult Index()
        {
            return View(db.td_department.ToList());
        }

        [HttpGet]
        public ActionResult ParInitialSettings()
        {
            return View(db.td_department.ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParInitialSettings([Bind(Include = "id,name")] td_department department)
        {
            if (ModelState.IsValid)
            {
                department.name = department.name.Trim();
                db.td_department.Add(department);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult ParDepartment()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ParInitialSettingsEdit()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParInitialSettingsEdit([Bind(Include = "id,name")] td_department department)
        {
            if (ModelState.IsValid)
            {
                department.name = department.name.Trim();
                td_department departmentTable = db.td_department.Find(department.id);
                departmentTable.name = department.name;
                db.SaveChanges();
            }
            return PartialView("ParDepartment",db.td_department.ToList());
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ParInitialSettingsDell()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParInitialSettingsDell([Bind(Include = "id")] td_department department)
        {
            if (ModelState.IsValid)
            {
                db.td_department.Remove(db.td_department.Find(department.id));
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        } 
    }
}
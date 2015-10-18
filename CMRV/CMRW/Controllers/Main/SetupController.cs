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
        public ActionResult ParDepartmentAdd()
        {
            return View(db.td_department.ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParDepartmentAdd([Bind(Include = "id,name")] td_department department)
        {
            if (ModelState.IsValid)
            {
                department.name = department.name.Trim();
                db.td_department.Add(department);
                db.SaveChanges();
            }
            return PartialView("ParDepartmentAdd",db.td_department.ToList());
        } 

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _service;
        //
        // GET: /Page/ 
        public SettingController(ISettingService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(_service.Get());
        }

        public ActionResult Edit()
        {
            var editConfiguration = _service.Get();

            return View(editConfiguration);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                var s = _service.Get();

                if (s != null)
                {
                    s.SettingsCacheTimeInMinutes = int.Parse(collection["CacheTimeInMinutes"]);
                    s.GridPageSize = int.Parse(collection["GridPageSize"]);
                    s.ShowContentEllipsis = bool.Parse(collection["ShowContentEllipsis"]);
                    s.ContentExtractLength = int.Parse(collection["ContentExtractLength"]);
                    s.AllowRejectedContentReActivation = bool.Parse(collection["AllowRejectedContentReactivation"]);
                    s.AllowExpiredContentReActivation = bool.Parse(collection["AllowExpiredContentReactivation"]);
                    s.ModifiedBy = "XXXX";

                    _service.Save(s);
                }

                // Remove the existing cached settings item; it will be re-added back automatically by the BaseController
                var cacheService = new CacheService();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
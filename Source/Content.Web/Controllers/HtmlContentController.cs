﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities;
using System.Text;
using System.Web.Routing; 

namespace ContentNamespace.Web.Controllers
{
    public class HtmlContentController : ContentManagerBaseController
    {
        private readonly IContentService _service;

        // GET: /HtmlContent/
        public HtmlContentController(IContentService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(this._service.Get());
        }

        //
        // GET: /HtmlContent/Details/5 
        public ActionResult Details(int id)
        {
            return View(this._service.Get(id));
        }

        //
        // GET: /HtmlContent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HtmlContent/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] HtmlContent c)
        {  
            c.ModifiedBy = "XXXX";//TODO: should be loged in user
            c.ModifiedDate = DateTime.Now;
            c.ExpireDate = DateTime.MaxValue;
            c.ActiveDate = new DateTime(1900, 1, 1); 
            c.ContentData = "Hello <b>World</b>";
            if (!this.Validate(c))
            {
                return View();
            }
            this._service.Save(c);
            return RedirectToAction("Edit/" + c.Id);
        }

        //
        // GET: /HtmlContent/Edit/5 
        public ActionResult Edit(int id)
        {
            var editContent = this._service.Get(id);

            editContent.Edit();

            return View(editContent);
        }

        //ref: http://tinyurl.com/d6xolp      
        // POST: /HtmlContent/Edit/5 
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                HtmlContent c = this._service.Get(id);
                c.ContentData = collection["ContentData"]; 
                c.ModifiedBy = "XXXX";//TODO: should be loged in user
                c.ModifiedDate = DateTime.Now;
                c.ExpireDate = DateTime.MaxValue;
                c.ActiveDate = new DateTime(1900, 1, 1);  
                this._service.Save(c);
 
                return RedirectToAction("Details", new { id = id });
                // return RedirectToAction("Details", new RouteValueDictionary(new { id = id }));
            }
            catch
            {
                return View();
            }
        }


        protected bool Validate(HtmlContent item)
        {
            if (item.Name.Trim().Length == 0)
                ModelState.AddModelError("Name", "Name name is required.");
            //if (contactToCreate.LastName.Trim().Length == 0)
            //    ModelState.AddModelError("LastName", "Last name is required.");
            //if (contactToCreate.Phone.Length > 0 && !Regex.IsMatch(contactToCreate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            //    ModelState.AddModelError("Phone", "Invalid phone number.");
            //if (contactToCreate.Email.Length > 0 && !Regex.IsMatch(contactToCreate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            //    ModelState.AddModelError("Email", "Invalid email address."); 
            return ModelState.IsValid;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Content;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(_context
                .Suppliers
                .OrderBy(s => s.Name));
        }
        #region Create
        public ActionResult Create()
        {
            return View();

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Supplier supplier )
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit

        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var supplier = _context
                .Suppliers
                .Find(id.Value);

            if (supplier == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.NotFound);
            }

            return View(supplier);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(supplier)
                    .State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        #endregion

    }
}
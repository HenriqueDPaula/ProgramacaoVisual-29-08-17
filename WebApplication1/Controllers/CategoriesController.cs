using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Content;
using System.Data.Entity;
using System.Net;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EFContext _context = new EFContext();
        /*private static IList<Category> categoryList =
            new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Keyboard"},
                new Category() { CategoryId = 2, Name = "Monitor"},
                new Category() { CategoryId = 3, Name = "Laptop"},
                new Category() { CategoryId = 4, Name = "Mouse"},
                new Category() { CategoryId = 5, Name = "Printers"}
            };
        */
        // GET: Categories
        public ActionResult Index()
        {
            return View(_context
                .Categories
                .OrderBy(s => s.Name));
            //return View(categoryList.OrderBy(c => c.Name) );
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(long? id)
        {
            /*var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();*/

            /* A função acima poderia ser escrita conforme abaixo
             * category = categoryList
                .First(c => c.CategoryId == id);
                */

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = _context
                .Categories
                .Find(id.Value);

            if (category == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.NotFound);
            }

            return View(category);
        }

        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = _context
                .Categories
                .Find(id.Value);

            if (category == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.NotFound);
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category)
                    .State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = _context
                .Categories
                .Find(id.Value);

            if (category == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.NotFound);
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                var s = _context
                    .Categories
                    .Find(category.CategoryId);

                if (s == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                _context.Categories.Remove(s);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomLight.Domain;
using System.Web.UI;
using System.IO;

namespace CustomLight.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
			ViewBag.Categories = await db.Categories.ToListAsync();
			return View(await db.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,ShortDescription,Icon,IconMimeType,Created,Updated")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,ShortDescription,Icon,IconMimeType,Created,Updated")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
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


		[OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
		public FileContentResult GetCategoryIcon(int Id)
		{
			Category cat = db.Categories
				.FirstOrDefault(c => c.Id == Id);

			if (cat.Icon != null)
			{
				return File(cat.Icon, cat.IconMimeType);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Тестовый метод, наполняет БД фейками
		/// private чтобы случайно не запустить по URL
		/// </summary>
		private void TestFillDB()
		{
			TestFillCategories();
		}

		private void TestFillCategories()
		{
			for (int i = 0; i < 8; i++)
			{
				var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (i + 1) + ".jpg");
				byte[] iconData = System.IO.File.ReadAllBytes(filepath);
				string iconMimeType = "image/jpg";
				var now = DateTime.Now;
				Category cat = new Category
				{
					Name = "Наименование_" + i,
					Description = "Описание_" + i,
					ShortDescription = "Краткое описание_" + i,
					Icon = iconData,
					IconMimeType = iconMimeType,
					Created = now,
					Updated = now,
				};
				db.Categories.Add(cat);
			}
			db.SaveChanges();
		}
	}
}

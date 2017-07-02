using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomLight.Models;
using System.Web.UI;

namespace CustomLight.Controllers
{
    public class EssentialsController : BaseController
    {
        //// GET: Essentials
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Essentials.ToListAsync());
        //}

        //// GET: Essentials/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Essential essential = await db.Essentials.FindAsync(id);
        //    if (essential == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(essential);
        //}

        //// GET: Essentials/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Essentials/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Title,LogoImageData,LogoImageMimeType,About,Address,Phone,Boss,Email,LogoImageInvertedData,LogoImageInvertedMimeType")] Essential essential)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Essentials.Add(essential);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(essential);
        //}

        // GET: Essentials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Essential essential = await db.Essentials.FindAsync(id);
            if (essential == null)
            {
                return HttpNotFound();
            }
            return View(essential);
        }

        // POST: Essentials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,LogoImageData,LogoImageMimeType,About,Address,Phone,Boss,Email,LogoImageInvertedData,LogoImageInvertedMimeType")] Essential essential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(essential).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(essential);
        }

        //// GET: Essentials/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Essential essential = await db.Essentials.FindAsync(id);
        //    if (essential == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(essential);
        //}

        //// POST: Essentials/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Essential essential = await db.Essentials.FindAsync(id);
        //    db.Essentials.Remove(essential);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		[OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "logoType")]
		public FileContentResult GetLogotype(string logoType)
		{
			Essential essential = db.Essentials
				.FirstOrDefault(c => c != null);

			if (essential != null)
			{
				switch (logoType)
				{
					case "normal":
						if (essential.LogoImageData != null)
						{
							return File(essential.LogoImageData, essential.LogoImageMimeType);
						}
						else
						{
							return null;
						}
					case "inverted":
						if (essential.LogoImageInvertedData != null)
						{
							return File(essential.LogoImageInvertedData, essential.LogoImageInvertedMimeType);
						}
						else
						{
							return null;
						}
					default:
						return null;
				}
			}
			else
			{
				return null;
			}
		}
	}
}

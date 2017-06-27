using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLight.Domain;
using System.Data.Entity;
using System.IO;
using System.Web.UI;
using System.Threading.Tasks;

namespace CustomLight.WebUI.Controllers
{
    public class HomeController : Controller
    {
		private Entities db = new Entities();

		public HomeController()
		{
			ViewBag.Title = "Custom-Light";
		}

		// GET: Home
		// GET: Categories
		public async Task<ActionResult> Index()
		{
			ViewBag.Categories = await db.Categories.ToListAsync();
			return View(await db.Categories.ToListAsync());
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
		public void TestFillDB()
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
				Category cat = new Category {
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
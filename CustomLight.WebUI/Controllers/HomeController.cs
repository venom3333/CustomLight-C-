using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLight.Domain;
using System.Data.Entity;
using System.IO;
using System.Web.UI;

namespace CustomLight.WebUI.Controllers
{
    public class HomeController : Controller
    {
		private List<Category> Categories;

		public HomeController()
		{
			ViewBag.Title = "Custom-Light";
			using (Entities db = new Entities())
			{
				this.Categories = db.Categories.ToList();
			}
		}

		// GET: Home
		public ActionResult Index()
        {
			ViewBag.Categories = Categories;
            return View();
        }

		[OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
		public FileContentResult GetCategoryIcon(int Id)
		{
			Category cat = Categories
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
			using (Entities db = new Entities())
			{
				TestFillCategories(db);
			}
		}

		private void TestFillCategories(Entities db)
		{
			for (int i = 0; i < 8; i++)
			{
				var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (i + 1) + ".jpg");
				byte[] iconData = System.IO.File.ReadAllBytes(filepath);
				string iconMimeType = "image/jpg";
				Category cat = new Category { Name = "Prob_" + i, Description = "TEasdasdST!!_" + i, ShortDescription = "LALALffffA!!_" + i, Icon = iconData, IconMimeType = iconMimeType };
				db.Categories.Add(cat);
			}
			db.SaveChanges();
		}
	}
}
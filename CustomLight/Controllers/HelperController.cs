using CustomLight.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomLight.Controllers
{
    public class HelperController : Controller
    {
		private CustomLightEntities db = new CustomLightEntities();
		// GET: Test
		//public ActionResult Index()
  //      {
  //          return View();
  //      }

		/// <summary>
		/// Тестовый метод, наполняет БД фейками
		/// private чтобы случайно не запустить по URL
		/// </summary>
		private ActionResult TestFillDB()
		{
			TestFillCategories();
			return View();
		}

		/// <summary>
		/// Часть тестового наполнения
		/// </summary>
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
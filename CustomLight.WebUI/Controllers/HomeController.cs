using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomLight.Domain;
using CustomLight.Domain.Entities;
using CustomLight.Domain.Context;
using System.Data.Entity;

namespace CustomLight.WebUI.Controllers
{
    public class HomeController : Controller
    {
		private List<Category> Categories;

		public HomeController()
		{
			using (AppDbContext db = new AppDbContext())
			{
				this.Categories = db.Categories.ToList();
				//Category cat1 = new Category { Name = "Prob2", Description = "TEST!!!", ShortDescription = "LALALA!!!", Created = DateTime.Now, Updated = DateTime.Now };
				//Categories.Add(cat1);
				//db.SaveChanges();
			}
		}

        // GET: Home
        public ActionResult Index()
        {
            return View(Categories);
        }
    }
}
﻿using System;
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
				//for (int i = 0; i < 8; i++)
				//{
				//	Category cat = new Category { Name = "Prob_" + i, Description = "TEasdasdST!!_" + i, ShortDescription = "LALALffffA!!_" + i, Created = DateTime.Now, Updated = DateTime.Now };
				//	db.Categories.Add(cat);
				//}
				//db.SaveChanges();
				this.Categories = db.Categories.ToList();
			}
		}

        // GET: Home
        public ActionResult Index()
        {
			ViewBag.Categories = Categories;
            return View();
        }
    }
}
using CustomLight.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CustomLight.Controllers
{
    public class BaseController : Controller
    {
		protected CustomLightEntities db = new CustomLightEntities();

		public BaseController()
		{
			ViewBag.Categories = db.Categories.ToList();
			ViewBag.Projects = db.Projects.ToList();
			ViewBag.Pages = db.Pages.ToList();
			ViewBag.Essentials = db.Essentials.FirstOrDefault(e => e != null);
		}
	}
}
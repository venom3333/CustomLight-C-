using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLight.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomLight.UnitTests
{
	[TestClass]
	public class FillDB
	{
		private CustomLightEntities db = new CustomLightEntities();

		DateTime now = DateTime.Now;

		// GET: Test
		//public ActionResult Index()
		//      {
		//          return View();
		//      }

		/// <summary>
		/// Тестовый метод, наполняет БД фейками
		/// private чтобы случайно не запустить по URL
		/// </summary>
		[TestMethod]
		public void TestFillDB()
		{
			// Категории
			FillCategories();

			// Типы продуктов
			FillProductTypes();

			// Продукты
			FillProducts();

			// Проекты
			FillProjects();

		}

		private void FillProductTypes()
		{
			// SpecificationTitles
			var specs = new List<SpecificationTitle>
			{
				new SpecificationTitle { Name = "Диаметр" },
				new SpecificationTitle { Name = "Длина" },
				new SpecificationTitle { Name = "Ширина" },
				new SpecificationTitle { Name = "Высота" },
				new SpecificationTitle { Name = "Мощность" },
				new SpecificationTitle { Name = "Световой поток" },
				new SpecificationTitle { Name = "Цена" }
			};

			db.ProductTypes.Add(new ProductType
			{
				Name = "Светильник",
				SpecificationTitles = specs
			});
			db.SaveChanges();
		}

		private void FillProjects()
		{
			for (int i = 0; i < 8; i++)
			{
				// Иконки
				var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (i + 1) + ".jpg");
				byte[] iconData = System.IO.File.ReadAllBytes(filepath);
				string iconMimeType = "image/jpg";

				// Картинки
				var images = new List<ProjectImage>();
				for (int j = 0; i < 8; i++)
				{
					images.Add(new ProjectImage
					{
						ImageData = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (j + 1) + ".jpg")),
						ImageMimeType = iconMimeType
					});
				}

				// Остальной объект
				Project project = new Project
				{
					Name = "Наименование проекта_" + i,
					Description = "Описание проекта_" + i,
					ShortDescription = "Краткое описание проекта_" + i,
					Icon = iconData,
					IconMimeType = iconMimeType,
					Created = now,
					Updated = now,
					IsPublished = true,
					ProjectImages = images,
				};
				db.Projects.Add(project);
			}
			db.SaveChanges();
		}

		private void FillProducts()
		{
			for (int i = 0; i < 8; i++)
			{
				// Тип продукта
				string pt = "Светильник";

				// Иконки
				var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (i + 1) + ".jpg");
				byte[] iconData = System.IO.File.ReadAllBytes(filepath);
				string iconMimeType = "image/jpg";

				// Картинки
				var images = new List<ProductImage>();
				for (int j = 0; i < 8; i++)
				{
					images.Add(new ProductImage
					{
						ImageData = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (j + 1) + ".jpg")),
						ImageMimeType = iconMimeType
					});
				}



				// Остальной объект
				Product product = new Product
				{
					Name = "Наименование проекта_" + i,
					Description = "Описание проекта_" + i,
					ShortDescription = "Краткое описание проекта_" + i,
					Icon = iconData,
					IconMimeType = iconMimeType,
					Created = now,
					Updated = now,
					IsPublished = true,
					ProductImages = images,
					ProductType = db.ProductTypes.FirstOrDefault(x => x.Name == pt),

					// Спецификации
					SpecificationValues = (db.SpecificationTitles.Where(st => st.ProductType.Name == pt).ToList())
											.Select(t => new SpecificationValue { SpecificationTitleId = t.Id, Value = new Random().Next(10, 100).ToString() }).ToList()
				};
				db.Products.Add(product);
			}
			db.SaveChanges();
		}

		/// <summary>
		/// Часть тестового наполнения
		/// </summary>
		private void FillCategories()
		{
			for (int i = 0; i < 8; i++)
			{
				// иконки
				var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/icons/icon_" + (i + 1) + ".jpg");
				byte[] iconData = System.IO.File.ReadAllBytes(filepath);
				string iconMimeType = "image/jpg";

				// Остальной объект
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

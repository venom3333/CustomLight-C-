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

			// Страницы
			FillPages();

			// Основные данные
			FillEssentials();

		}

		private void FillEssentials()
		{
			// Логотип норм
			var filepathLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/сustomlight-logo.svg");
			byte[] logoData = System.IO.File.ReadAllBytes(filepathLogo);
			string logoMimeType = "image/svg+xml";

			// Логотип инверс
			var filepathLogoW = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/imgs/сustomlight-logo-w.svg");
			byte[] logoDataW = System.IO.File.ReadAllBytes(filepathLogoW);
			string logoMimeTypeW = "image/svg+xml";

			db.Essentials.Add(
				new Essential
				{
					About = "О компании ляляля!",
					Address = "141280, Московская область, г.Ивантеевка, Студенческий проезд, дом 12",
					Boss = "Вован",
					LogoImageData = logoData,
					LogoImageMimeType = logoMimeType,
					LogoImageInvertedData = logoDataW,
					LogoImageInvertedMimeType = logoMimeTypeW,
					Title = "Custom-Light",
					Phone = "8(495)773-71-59",
					Email = "info@custom-light.ru"
				}
			);
			db.SaveChanges();
		}

		private void FillPages()
		{
			for(int i = 0; i < 3; i++)
			{
				db.Pages.Add(
					new Page
					{
						Created = now,
						Updated = now,
						Alias = "alias_" + i,
						Name = "Имя страницы_" + i,
						PageContent = @"Идейные соображения высшего порядка, а также дальнейшее развитие различных форм деятельности представляет собой интересный эксперимент проверки новых предложений. Таким образом новая модель организационной деятельности позволяет оценить значение форм развития. Равным образом дальнейшее развитие различных форм деятельности обеспечивает широкому кругу (специалистов) участие в формировании соответствующий условий активизации. Повседневная практика показывает, что рамки и место обучения кадров представляет собой интересный эксперимент проверки позиций, занимаемых участниками в отношении поставленных задач.
										Задача организации, в особенности же постоянный количественный рост и сфера нашей активности способствует подготовки и реализации систем массового участия. Повседневная практика показывает, что постоянный количественный рост и сфера нашей активности требуют определения и уточнения форм развития. Повседневная практика показывает, что новая модель организационной деятельности требуют определения и уточнения новых предложений. Таким образом постоянный количественный рост и сфера нашей активности влечет за собой процесс внедрения и модернизации дальнейших направлений развития. Задача организации, в особенности же консультация с широким активом позволяет оценить значение дальнейших направлений развития. Повседневная практика показывает, что постоянный количественный рост и сфера нашей активности требуют определения и уточнения соответствующий условий активизации.
										Таким образом укрепление и развитие структуры способствует подготовки и реализации системы обучения кадров, соответствует насущным потребностям. Задача организации, в особенности же постоянное информационно-пропагандистское обеспечение нашей деятельности обеспечивает широкому кругу (специалистов) участие в формировании форм развития. Не следует, однако забывать, что начало повседневной работы по формированию позиции требуют от нас анализа направлений прогрессивного развития. Идейные соображения высшего порядка, а также постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение дальнейших направлений развития.
										Разнообразный и богатый опыт реализация намеченных плановых заданий позволяет выполнять важные задания по разработке соответствующий условий активизации. Таким образом сложившаяся структура организации позволяет выполнять важные задания по разработке позиций, занимаемых участниками в отношении поставленных задач. Товарищи! укрепление и развитие структуры представляет собой интересный эксперимент проверки форм развития. Разнообразный и богатый опыт постоянное информационно-пропагандистское обеспечение нашей деятельности требуют определения и уточнения позиций, занимаемых участниками в отношении поставленных задач. Разнообразный и богатый опыт консультация с широким активом влечет за собой процесс внедрения и модернизации системы обучения кадров, соответствует насущным потребностям.
										Не следует, однако забывать, что новая модель организационной деятельности позволяет оценить значение дальнейших направлений развития. С другой стороны сложившаяся структура организации требуют от нас анализа соответствующий условий активизации. Повседневная практика показывает, что новая модель организационной деятельности влечет за собой процесс внедрения и модернизации новых предложений. Повседневная практика показывает, что укрепление и развитие структуры требуют от нас анализа направлений прогрессивного развития. С другой стороны рамки и место обучения кадров позволяет оценить значение позиций, занимаемых участниками в отношении поставленных задач."
					}
				);
				db.SaveChanges();
			}
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
				for (int j = 0; j < 8; j++)
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
				for (int j = 0; j < 8; j++)
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
					Name = "Наименование продукта_" + i,
					Description = "Описание продукта_" + i,
					ShortDescription = "Краткое описание продукта_" + i,
					Icon = iconData,
					IconMimeType = iconMimeType,
					Created = now,
					Updated = now,
					IsPublished = true,
					ProductImages = images,
					ProductType = db.ProductTypes.FirstOrDefault(x => x.Name == pt),
				};

				// Спецификации
				var specs = new List<Specification>();

				for (int s = 0; s < 5; s++)
				{
					specs.Add
						(
							new Specification
								{
									SpecificationValues = (db.SpecificationTitles.Where(st => st.ProductType.Name == pt).ToList()).Select(t => new SpecificationValue { SpecificationTitleId = t.Id, Value = new Random().Next(10, 150).ToString() }).ToList(),
								}
						);
				}
				product.Specifications = specs;

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
					Name = "Наименование категории_" + i,
					Description = "Описание категории__" + i,
					ShortDescription = "Краткое описание категории__" + i,
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

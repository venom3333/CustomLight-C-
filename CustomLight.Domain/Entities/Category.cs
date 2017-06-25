﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomLight.Domain.Entities
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public byte[]  Icon { get; set; }
		public string IconMimeType { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Created { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Updated { get; set; }

		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
	}
}

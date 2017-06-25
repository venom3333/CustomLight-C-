using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomLight.Domain.Entities
{
	public class Page
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Alias { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Created { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Updated { get; set; }
	}
}

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
	public class Specification
	{
		[Key]
		public int Id { get; set; }

		public int Diameter { get; set; }
		public int Length { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public int Power { get; set; }
		public int LightOutput { get; set; }

		[Required]
		public double Price { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Created { get; set; }

		[Column(TypeName = "DateTime2")]
		public DateTime Updated { get; set; }
	}
}

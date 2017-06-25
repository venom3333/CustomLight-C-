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
	public class Image
	{
		public int Id;

		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }

		public virtual ICollection<Project> Projects{ get; set; }
		public virtual ICollection<Product> Products{ get; set; }
	}
}

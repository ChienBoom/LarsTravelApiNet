﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsTravel.Models
{
	[Table("city")]
	public class City
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		[StringLength(1000)]
		public string Description { get; set; }
		[Required]
		[StringLength(2000)]
		public string Pictures { get; set; }
		public List<Tour> Tours { get; set; }
	}
}

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	[Table("tour")]
	public class Tour
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		[StringLength(100)]
		public string Address { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		[Required]
		public string Pictures { get; set; }
		public long CityId { get; set; }
		[Required]
		[JsonIgnore]
		public City City { get; set; }
		[Required]
		public long EvaluateId { get; set; }
		public Evaluate Evaluate { get; set; }
		[JsonIgnore]
		public List<Ticket> Tickets { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	[Table("hotel")]
	public class Hotel
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(255)]
		public string Address { get; set; }
		[Required]
		[StringLength(11)]
		public string PhoneNumber { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		[JsonIgnore]
		public List<TicketDetail> TicketDetails { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	[Table("member_package")]
	public class MemberPackage
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		[JsonIgnore]
		public List<TicketDetail> TicketDetails { get; set; }
	}
}

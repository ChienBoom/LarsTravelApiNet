using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	[Table("ticket_detail")]
	public class TicketDetail
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartDay { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime EndDay { get; set; }
		[Required]
		public Decimal Price { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		[Required]
		[JsonIgnore]
		public Ticket Ticket { get; set; }
		public long MemberPackageId { get; set; }
		[Required]
		public MemberPackage MemberPackage { get; set; }
		public long HotelId { get; set; }
		public Hotel Hotel { get; set; }
	}
}

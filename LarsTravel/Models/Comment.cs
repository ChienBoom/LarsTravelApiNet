using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	[Table("comment")]
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required]
		public long Id { get; set;}
		[Required]
		[StringLength(1000)]
		public string Content { get; set;}
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DateOfComment { get; set;}
		public long UserId { get; set;}
		[Required]
		public User User { get; set;}
		public long EvaluateId { get; set;}
		[Required]
		public Evaluate Evaluate { get; set;}
	}
}

using LarsTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace LarsTravel.Context
{
	public class DataContext :DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<City> City { get; set; }
		public DbSet<Comment> Comment { get; set; }
		public DbSet<Evaluate> Evaluate { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<MemberPackage> MemberPackage { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
		public DbSet<TicketDetail> TicketDetail { get; set; }
		public DbSet<Tour> Tour { get; set; }
		public DbSet<User> User { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<City>()
				.HasMany(p => p.Tours)
				.WithOne(a => a.City)
				.HasForeignKey(a => a.CityId);
			modelBuilder.Entity<Evaluate>()
				.HasOne(p => p.Tour)
				.WithOne(a => a.Evaluate)
				.HasForeignKey<Tour>(a => a.EvaluateId);
			modelBuilder.Entity<Evaluate>()
				.HasOne(p => p.Comment)
				.WithOne(a => a.Evaluate)
				.HasForeignKey<Comment>(a => a.EvaluateId);
			modelBuilder.Entity<Tour>()
				.HasMany(p => p.Tickets)
				.WithOne(a => a.Tour)
				.HasForeignKey(a => a.TourId);
			modelBuilder.Entity<User>()
				.HasMany(p => p.Comments)
				.WithOne(a => a.User)
				.HasForeignKey(a => a.UserId);
			modelBuilder.Entity<User>()
				.HasMany(p => p.Tickets)
				.WithOne(a => a.User)
				.HasForeignKey(a => a.UserId);
			modelBuilder.Entity<Ticket>()
				.HasOne(p => p.TicketDetail)
				.WithOne(a => a.Ticket)
				.HasForeignKey<Ticket>(a => a.TicketDetailId);
			modelBuilder.Entity<MemberPackage>()
				.HasMany(p => p.TicketDetails)
				.WithOne(a => a.MemberPackage)
				.HasForeignKey(a => a.MemberPackageId);
			modelBuilder.Entity<Hotel>()
				.HasMany(p => p.TicketDetails)
				.WithOne(a => a.Hotel)
				.HasForeignKey(a => a.HotelId);
		}
	}
}

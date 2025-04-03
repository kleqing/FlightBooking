using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models;

public class DbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	public DbContext(DbContextOptions<DbContext> options) : base(options) { }

	public DbSet<Airport> Airport { get; set; }
	public DbSet<ChairBooked> ChairBooked { get; set; }
	public DbSet<City> City { get; set; }
	public DbSet<Class> Class { get; set; }
	public DbSet<Flight> Flight { get; set; }
	public DbSet<FlightTime> FlightTime { get; set; }
	public DbSet<Passenger> Passenger { get; set; }
	public DbSet<Restrictions> Restrictions { get; set; }
	public DbSet<Ticket> Tickets { get; set; }
	public DbSet<Transit> Transit { get; set; }
	public DbSet<User> User { get; set; }
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		
		//* Set the primary key for each entity
		builder.Entity<Airport>()
			.HasKey(a => a.AirportId);

		builder.Entity<ChairBooked>()
			.HasKey(c => c.ChairBookedId);
		
		builder.Entity<City>()
			.HasKey(c => c.CityId);
		
		builder.Entity<Class>()
			.HasKey(c => c.ClassId);
		
		builder.Entity<Flight>()
			.HasKey(f => f.FlightId);
		
		builder.Entity<FlightTime>()
			.HasKey(f => f.FlightTimeId);
		
		builder.Entity<Passenger>()
			.HasKey(p => p.PassengerId);

		builder.Entity<Restrictions>()
			.HasNoKey();

		builder.Entity<Ticket>()
			.HasKey(t => t.TicketId);
		
		builder.Entity<Transit>()
			.HasKey(t => t.TransitId);
		
		//* Unique constraints
		builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
		builder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
		
		//* Set the foreign key relationships
		builder.Entity<Airport>()
			.HasOne(c => c.City)
			.WithMany(c => c.Airports)
			.HasForeignKey(c => c.CityId);
		
		builder.Entity<Airport>()
			.HasMany(t => t.Transits)
			.WithOne(t => t.Airport)
			.HasForeignKey(t => t.AirportId);
		
		builder.Entity<Airport>()
			.HasMany(f => f.Flights)
			.WithOne(f => f.Airport)
			.HasForeignKey(f => f.AirportId);
		
		builder.Entity<ChairBooked>()
			.HasOne(f => f.FlightTime)
			.WithMany(f => f.ChairBooked)
			.HasForeignKey(f => f.FlightTimeId);

		builder.Entity<Class>()
			.HasMany(f => f.Tickets)
			.WithOne(t => t.Class)
			.HasForeignKey(c => c.ClassId);
		
		builder.Entity<Flight>()
			.HasMany(t => t.Transits)
			.WithOne(t => t.Flight)
			.HasForeignKey(t => t.FlightId);

		builder.Entity<Flight>()
			.HasMany(f => f.FlightTimes)
			.WithOne(t => t.Flight)
			.HasForeignKey(f => f.FlightId);
		
		builder.Entity<FlightTime>()
			.HasMany(t => t.Tickets)
			.WithOne(f => f.FlightTime)
			.HasForeignKey(t => t.FlightTimeId);
		
		builder.Entity<Passenger>()
			.HasMany(t => t.Tickets)
			.WithOne(p => p.Passenger)
			.HasForeignKey(t => t.PassengerId);
	}
}
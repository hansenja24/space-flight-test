using System;
using Microsoft.EntityFrameworkCore;

namespace space_flight.Models
{
	public class SpaceFlightDbContext : DbContext
	{
		public SpaceFlightDbContext()
		{
		}

        public DbSet<CrewReq> Crew { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(@"Server=localhost;Port=8889;database=space_flight;uid=root;pwd=root;");
		}

		public SpaceFlightDbContext(DbContextOptions<SpaceFlightDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace space_flight.Models
{
	public class EFItemRepository : IItemRepository
	{
        SpaceFlightDbContext db = new SpaceFlightDbContext();

		public IQueryable<CrewReq> Items
		{ get { return db.Crew; } }

		public CrewReq Save(CrewReq item)
		{
			db.Crew.Add(item);
			db.SaveChanges();
			return item;
		}

		public CrewReq Edit(CrewReq item)
		{
			db.Entry(item).State = EntityState.Modified;
			db.SaveChanges();
			return item;
		}

		public void Remove(CrewReq item)
		{
			db.Crew.Remove(item);
			db.SaveChanges();
		}
    }
}
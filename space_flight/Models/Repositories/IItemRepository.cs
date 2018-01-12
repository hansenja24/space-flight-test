using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace space_flight.Models
{
    public interface IItemRepository
    {
        IQueryable<CrewReq> Items { get; }
        CrewReq Save(CrewReq item);
        CrewReq Edit(CrewReq item);
        void Remove(CrewReq item);

    }
}

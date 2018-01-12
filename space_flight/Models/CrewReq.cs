using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
namespace space_flight.Models
{
	public class CrewReq
	{
        public CrewReq(int thisDuration, int thisTasks, int thisId)
        {
            Id = thisId;
            Duration = thisDuration;
            Tasks = thisTasks;
        }

		public CrewReq()
		{

		}

        public int Duration { get; set; }
        public int Tasks { get; set; }
        public int Id { get; set; }

		public double GetCrewNumber()
		{

            double crewResult = Convert.ToDouble(Tasks) / (Convert.ToDouble(Duration) * 16) / 4;

            return Math.Ceiling(crewResult);
		}
	}
  
}

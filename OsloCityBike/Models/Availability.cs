using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OsloCityBike.Models
{
	public class Availability
	{
		public int Bikes { get; set; }
		public int Locks { get; set; }
	}
	public class AvailableStations
	{
		public int ID { get; set; }
		public Availability Availability { get; set; }		
	}

	public class RootAvailable
	{
		public List<AvailableStations> Stations { get; set; }
		public DateTime Updated_At { get; set; }
		public double Refresh_Rate { get; set; }
	}
}

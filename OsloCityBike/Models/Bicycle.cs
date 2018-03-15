using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OsloCityBike.Models
{
	public class Center
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
	public class Stations 
	{
		public int ID { get; set; }
		public bool In_Service { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public int Number_Of_Locks { get; set; }
		public Center Center { get; set; }
		public List<Center> Bounds { get; set; }
	}

	public class Root
	{
		public List<Stations> Stations { get; set; }
	}
}

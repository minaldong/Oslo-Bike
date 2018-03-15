using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using OsloCityBike.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace OsloCityBike.Controllers
{
    public class BicycleController : Controller
    {
		public ActionResult Index()
        {
			return View();
        }

		[HttpPost]
		public ActionResult ListStations()
		{
			Root model = null;		
			HttpClientHandler hndlr = new HttpClientHandler();
			hndlr.UseDefaultCredentials = true;
			HttpClient client = new HttpClient(hndlr);
			client.BaseAddress = new Uri("https://oslobysykkel.no");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Client-Identifier", "d1cb8ab3e982e466e42ac9b5fe3f09ae");
			
			var task = client.GetAsync("api/v1/stations")
			  .ContinueWith((taskwithresponse) =>
			  {
				  var response = taskwithresponse.Result;
				  var jsonString = response.Content.ReadAsStringAsync();
				  jsonString.Wait();
				  
				  JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
				  model = jsonSerializer.Deserialize<Root>(jsonString.Result);

			  });
			task.Wait();

			return PartialView("ListStations", model);
		}

		[HttpPost]
		public ActionResult ListAvailableStations()
		{
			RootAvailable model = null;
			HttpClientHandler hndlr = new HttpClientHandler();
			hndlr.UseDefaultCredentials = true;
			HttpClient client = new HttpClient(hndlr);
			client.BaseAddress = new Uri("https://oslobysykkel.no");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("Client-Identifier", "d1cb8ab3e982e466e42ac9b5fe3f09ae");

			var task = client.GetAsync("api/v1/stations/availability")
			  .ContinueWith((taskwithresponse) =>
			  {
				  var response = taskwithresponse.Result;
				  var jsonString = response.Content.ReadAsStringAsync();
				  jsonString.Wait();

				  JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
				  model = jsonSerializer.Deserialize<RootAvailable>(jsonString.Result);

			  });
			task.Wait();

			return PartialView("ListAvailableStations", model);
		}
	}
}
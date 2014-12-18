using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starter.Controllers
{
	public class HtmlHelpersController : Controller
	{
		// GET: HtmlHelpers
		public ActionResult Index()
		{
			return View(new ViewModel());
		}
	}

	public class ViewModel
	{
		private List<RegionItem> _regions = new List<RegionItem>()
		{
			new RegionItem() {Id = 1, Name = "North"},
			new RegionItem() {Id = 2, Name = "South"},
			new RegionItem() {Id = 3, Name = "East"},
			new RegionItem() {Id = 4, Name = "West"}
		};

		public int SelectedRegion { get; set; }

		public IEnumerable<SelectListItem> Regions
		{
			get { return new SelectList(_regions, "Id", "Name"); }
		}
	}

	public class RegionItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

}

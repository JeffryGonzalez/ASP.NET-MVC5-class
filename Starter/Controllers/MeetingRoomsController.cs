using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Starter.Domain;

namespace Starter.Controllers
{
	public class MeetingRoomsController : Controller
	{

		// GET: MeetingRooms
		public ActionResult Index()
		{
			using (var context = new MeetingRoomReservationsContext())
			{
				var result = context.MeetingRooms.Project().To<MeetingRoomIndexViewModel>().ToList();
				return View(result);

			}
		}

		public ActionResult Find(MeetingRoomFindViewModel.MeetingRoomFindViewModelQuery searched)
		{

			using (var context = new MeetingRoomReservationsContext())
			{
				MeetingRoomFindViewModel vm = null;
				if (searched == null)
				{
					vm = new MeetingRoomFindViewModel();
					vm.Query = new MeetingRoomFindViewModel.MeetingRoomFindViewModelQuery();

					vm.Query.Capabilities =
						context.Capabilities.Project().To<CapabilityViewModel>().ToList();
				}
				else
				{
					vm = searched;
					// find the results
				}
				return View(vm);
			}
		}
	}

	public class MeetingRoomFindViewModel
	{
		public MeetingRoomFindViewModel()
		{
			AvailableCapabilities  = new List<int>();
		}
		public class MeetingRoomFindViewModelQuery
		{
			public MeetingRoomFindViewModelQuery()
			{
				AvailableDate = DateTime.Now.AddDays(1);

			}

			[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
			[DataType(DataType.Date)]
			public DateTime AvailableDate { get; set; }
			public List<CapabilityViewModel> Capabilities { get; set; }

			public int MinCapacity { get; set; }
		}
		public MeetingRoomFindViewModelQuery Query { get; set; }
		public List<int> AvailableCapabilities { get; set; }
		public MeetingRoomIndexViewModel Results { get; set; }
	}

	public class MeetingRoomIndexViewModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public int NumberOfPeople { get; set; }
		public List<CapabilityViewModel> Capabilities { get; set; }
	}

	public class CapabilityViewModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public bool Selected { get; set; }
	}


}

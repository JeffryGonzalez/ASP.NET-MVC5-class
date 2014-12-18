using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Starter.Controllers;
using Starter.Domain;

namespace Starter.App_Start
{
	public static class AutomapperConfig
	{
		public static void ConfigureMappings()
		{
			/* Mapper.CreateMap<OrderLine, OrderLineDTO>()
    .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name);
*/
			Mapper.CreateMap<MeetingRoom, MeetingRoomIndexViewModel>()
				.ForMember(d => d.NumberOfPeople, o => o.MapFrom(d => d.Capacity))
				.ForMember(d => d.Capabilities, o => o.MapFrom(d => d.Capabilities.Select(c=>c.Description)));

			Mapper.CreateMap<MeetingRoomCapabilities, CapabilityViewModel>();
			Mapper.CreateMap<MeetingRoomCapabilities, MeetingRoomFindViewModel>();

		}
	}
}

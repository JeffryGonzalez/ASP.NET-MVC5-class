using System.Collections.ObjectModel;
using Starter.Domain;

namespace Starter.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Starter.Domain.MeetingRoomReservationsContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Starter.Domain.MeetingRoomReservationsContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			var satellite = new MeetingRoomCapabilities() { Description = "Satellite" };
			var kitchenette = new MeetingRoomCapabilities() { Description = "Kitchenette" };
			var telecom = new MeetingRoomCapabilities() { Description = "Teleconferencing" };
			var projector = new MeetingRoomCapabilities() { Description = "Projector" };

			var room1 = new MeetingRoom()
			{
				Description = "Room1",
				Capacity = 05,
				Capabilities = new Collection<MeetingRoomCapabilities>() {kitchenette, satellite}
			};
			var room2 = new MeetingRoom()
			{
				Description = "Room2",
				Capacity = 10,
				Capabilities = new Collection<MeetingRoomCapabilities>() { satellite, projector }
			};

			var room3 = new MeetingRoom()
			{
				Description = "Room3",
				Capacity = 15,
				Capabilities = new Collection<MeetingRoomCapabilities>() { kitchenette, satellite, telecom }
			};


			context.Capabilities.AddOrUpdate(c => c.Description,
					satellite, kitchenette, telecom, projector
				);

			context.MeetingRooms.AddOrUpdate(m=>m.Description,
				room1, room2, room3);



		}
	}
}

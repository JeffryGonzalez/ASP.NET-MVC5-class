using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Starter.Domain
{
	public class MeetingRoomReservationsContext : DbContext
	{
		public DbSet<MeetingRoom> MeetingRooms { get; set; }
		public DbSet<MeetingRoomCapabilities> Capabilities { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}

	public class MeetingRoom
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public int Capacity { get; set; }
		public virtual ICollection<MeetingRoomCapabilities> Capabilities { get; set; }
	}

	public class MeetingRoomCapabilities
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public virtual ICollection<MeetingRoom> Rooms { get; set; }
	}
}

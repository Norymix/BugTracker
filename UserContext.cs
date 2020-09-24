using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace BugTracker
{
	class UserContext : DbContext
	{
		public UserContext()
			: base("DbConnection")
		{ }

		public DbSet<Ticket> Tickets { get; set; }
	}
}

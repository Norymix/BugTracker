using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace BugTracker
{
	class CmDataBase
	{
		public void PrintTickets(string sqlQuery)
		{
			using (UserContext db = new UserContext())
			{
				var table = db.Database.SqlQuery<Ticket>(sqlQuery);
				foreach (var tickets in table)
					Console.WriteLine("Id: " + tickets.Id + " |Title: " + tickets.Title + " |Description: " + tickets.Description + " |Status: " + tickets.Status);
			}
		} 
		public void AddTicketToDB(Ticket ticket)
		{
			using UserContext db = new UserContext();
			db.Tickets.Add(ticket);
			db.SaveChanges();
			Console.WriteLine("Ticket by created!");
		}
		public void AddTicket()
		{
			Console.WriteLine("Title:");
			string title = Console.ReadLine();
			Console.WriteLine("Description:");
			string description = Console.ReadLine();
			string status = "New";
			Ticket ticket = new Ticket { Title = title, Description = description, Status = status };
			AddTicketToDB(ticket);
		}
		public void ShowAllTickets()
		{
			PrintTickets("SELECT * FROM Tickets");
		}
		public void ShowNewTickets()
		{
			PrintTickets("SELECT * FROM Tickets WHERE status = 'new'");
		}
		public void ShowAssignedTickets()
		{
			PrintTickets("SELECT * FROM Tickets WHERE status = 'assigned'");
		}
		public void ShowClosedTickets()
		{
			PrintTickets("SELECT * FROM Tickets WHERE status = 'closed'");
		}
		public void ShowRejectedTickets()
		{
			PrintTickets("SELECT * FROM Tickets WHERE status = 'rejected'");
		}
		public void ChangeStatusTicket()
		{
			using UserContext db = new UserContext();
			ShowAllTickets();
			Console.WriteLine("Please, enter id value:");
			int id = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Please, enter new status (new, assigned, rejected, closed)");
			string status = Console.ReadLine();
			var newTicket = db.Tickets.Where(c => c.Id == id).FirstOrDefault();
			newTicket.Status = status;
			db.SaveChanges();
		}
	}
}

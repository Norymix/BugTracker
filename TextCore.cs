using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker
{
	class TextCore
	{
		public void PrintAllCommand()
		{
			List<string> commands = new List<string>()
			{
				"new ticket",
				"show all ticket",
				"show new ticket", 
				"show closed ticket", 
				"show rejected ticket",
				"show assigned ticket",
				"change status ticket" +
				"exit"
			};
			for (int i = 0; i < commands.Count; i++) Console.WriteLine(commands[i]);
		}//выводит все возможные комманды на экран
		public string ReadString()
		{
			Console.WriteLine("Enter 'help' for print all commands\nEnter command:");
			string textCommand = Console.ReadLine();
			textCommand = textCommand.ToLower();
			textCommand = textCommand.Replace(" ", "");
			return textCommand;
		}//читаем комманду с клавиатуры
		public void GetString()
		{
			CoreText(ReadString());
		} //получает комманду и передает ее в ядро обработки текста		
		public void CoreText(string keyString)
		{
			CmDataBase db = new CmDataBase();
			switch (keyString)
			{
				case "help":
					PrintAllCommand();
					break;
				case "newticket":
					db.AddTicket();
					break;
				case "showalltickets":
					db.ShowAllTickets();
					break;
				case "shownewtickets":
					db.ShowNewTickets();
					break;
				case "showclosedtickets":
					db.ShowClosedTickets();
					break;
				case "showrejectedtickets":
					db.ShowRejectedTickets();
					break;
				case "showassignedtickets":
					db.ShowAssignedTickets();
					break;
				case "changestatusticket":
					db.ChangeStatusTicket();
					break;
				case "exit":
					break;
				default:
					Console.WriteLine("Incorrect choice");
					break;

			}
		}//здесь мы обрабатываем все комманды и направляем их по методам
	}
}

using System;
using System.Security.Cryptography.X509Certificates;

namespace BugTracker
{
	class Program
	{
		static void Main(string[] args)
		{
			TextCore textCore = new TextCore();
			while (true)
			{
				textCore.GetString();
				Console.WriteLine("Continue? (y/n)");
				if (Console.ReadLine() == "n") break;
			}
		}
	}
}

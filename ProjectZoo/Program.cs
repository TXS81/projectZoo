
using System;
using System.Threading;
namespace ProjectZoo
{
	class Program
	{
		static System.Timers.Timer lifeTimer;
		/// <summary>
		/// Посредник, который используется для работы с зоопарком
		/// </summary>
		/// <param name="args"></param>
		static ZooManager _manager = new ZooManager();

		static void Main(string[] args)
		{

			SetTimer(5000);

			ShowMenu();

		}

		private static void ShowMenu()
		{
			Console.Clear();
			Console.WriteLine("\tWelcome to our AmazingZoo! \n Choose what you would like to do:\n\n");
			Console.WriteLine("\t1. Show animals (PRESS 1)");
			Console.WriteLine("\t2. Add an animal (PRESS 2)");
			Console.WriteLine("\t3. Feed animal (PRESS 3)");
			Console.WriteLine("\t4. Heal an animal (PRESS 4)");
			Console.WriteLine("\t5. Remove an animal (PRESS 5)");
			Console.WriteLine("\t6. Exit (PRESS 6)");

			Console.Write("\n\tPress the key: ");

			char ch;
			char.TryParse(Console.ReadLine(), out ch);

			if (_manager.IsZooOpened == false)
			{
				LeaveZoo();
			}

			switch (ch)
			{
				case '1':
					ShowAnimals();
					break;
				case '2':
					AddAnimal();
					break;
				case '3':
					FeedAnimal();
					break;
				case '4':
					HealAnimal();
					break;
				case '5':
					RemoveAnimal();
					break;
				case '6':
					ExitZoo();
					break;
				default:
					Console.Clear();
					Console.WriteLine("\n\tTry to choose any allowed key.");
					ReturnToMenu();
					break;
			}
		}
		private static void ReturnToMenu()
		{
			Console.Write("\n\tPress any key to return to the menu.");
			Console.ReadKey();
			ShowMenu();
		}
		private static void SetTimer(double interval = 5000)
		{
			lifeTimer = new System.Timers.Timer(interval);

			lifeTimer.Elapsed += OnTimedEvent;
			lifeTimer.AutoReset = true;
			lifeTimer.Enabled = true;
		}
		private static void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (_manager.Manage() == false)
			{
				LeaveZoo();
			}
		}
		private static void LeaveZoo()
		{

			Console.Clear();
			lifeTimer.Stop();

			Console.WriteLine("\n\n\tAll animals are dead.\n\tOur AmazingZoo is closing by officials from PETA for some reasons.");
			Console.Write("\n\tYou have to leave our zoo.");
			Thread.Sleep(5000);

			ExitZoo();

		}
		private static void ExitZoo()
		{
			if (lifeTimer != null)
			{
				lifeTimer.Stop();
				lifeTimer.Dispose();
			}
			Environment.Exit(0);
		}

		private static void RemoveAnimal()
		{
			string name = EnterName();
			string msg = _manager.RemoveAnimal(name);
			Console.WriteLine(msg);
			ReturnToMenu();
		}
		private static void HealAnimal()
		{
			string name = EnterName();
			string result = _manager.HealAnimal(name);
			Console.WriteLine(result);
			ReturnToMenu();
		}
		private static void FeedAnimal()
		{
			string name = EnterName();

			string msg;
			var result = _manager.FeedAnimal(name, out msg);
			if (result == false)
			{
				Console.WriteLine(msg);
				Console.Write("\n\tWould you like to do this immediately? \n\tIf yes - press 'y'.\n Press the key.");
				var key = Console.ReadKey();
				if (key.Key == ConsoleKey.Y)
				{
					Console.Clear();
					string resultH = _manager.HealAnimal(name);
					Console.WriteLine(resultH);
				}
				else
				{
					ShowMenu();
					return;
				}
			}
			else
			{
				Console.WriteLine(msg);
			}
			ReturnToMenu();
		}
		private static void AddAnimal()
		{
			Console.Clear();
			Console.WriteLine("\n\tChoose type of an animal\n\n Lion - Press 1,\n Tiger - Press 2,\n Elephant - Press 3,\n Bear - Press 4,\n Wolf - Press 5,\n Fox - Press 6\n");
			Console.Write("\n\n Press the key: ");
			Species? sp = _manager.GetSpecies(Console.ReadKey().KeyChar);
			if (sp != null)
			{
				string name = EnterName();
				Console.WriteLine(_manager.AddAnimal(name, (Species)sp));
			}
			else
			{
				Console.Clear();
				Console.WriteLine("\nSuch species doesn't exist.");
			}

			ReturnToMenu();
		}
		private static string EnterName()
		{
			Console.Clear();
			Console.Write("\n\tEnter a unique name: ");
			string name = Console.ReadLine();
			if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
			{
				name = EnterName();
			}
			return name;
		}
		private static void ShowAnimals()
		{
			Console.Clear();

			string result = _manager.ShowAnimals();
			Console.WriteLine(result);
			ReturnToMenu();
		}


	}
}



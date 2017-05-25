using System;
namespace ProjectZoo
{
	interface IZooManager
	{
		string AddAnimal(string name, Species type);
		bool? FeedAnimal(string name, out string msg);
		Species? GetSpecies(char type);
		string HealAnimal(string name);
		bool IsZooOpened { get; }
		bool Manage();
		string RemoveAnimal(string name);
		string ShowAnimalByName(string name);
		string ShowAnimals();
	}
}

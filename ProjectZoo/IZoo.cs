
using System.Collections.Generic;
namespace ProjectZoo
{
	interface IZoo
	{
		bool IsOpened { get; set; }
		string AddAnimal(Animal animal);
		bool? FeedAnimal(string name);
		bool? HealAnimal(string name);
		bool? RemoveAnimal(string name);
		bool LifeCycling();
		string ShowAnimals();
		string ShowAnimalByName(string name);
		Animal GetRandomAnimal();
		Animal GetAnimalByName(string name);
		List<Animal> GetAllAnimals();

	}


}

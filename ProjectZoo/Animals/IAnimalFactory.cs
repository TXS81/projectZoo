namespace ProjectZoo.Animals
{
	interface IAnimalFactory
	{
		Animal CreateAnimal(string name, Species type);
		Species? GetSpecies(string str);
	}
}

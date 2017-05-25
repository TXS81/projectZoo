
using System;
namespace ProjectZoo.Animals
{
	class AnimalFactory : IAnimalFactory
	{
		public Animal CreateAnimal(string name, Species type)
		{

			switch (type)
			{
				case Species.LION:
					return this.CreateLion(name);
				case Species.TIGER:
					return this.CreateTiger(name);
				case Species.ELEPHANT:
					return this.CreateElephant(name);
				case Species.BEAR:
					return this.CreateBear(name);
				case Species.WOLF:
					return this.CreateWolf(name);
				case Species.FOX:
					return this.CreateFox(name);
				default:
					return null;
			}
		}
		public Species? GetSpecies(string str)
		{
			Species result;
			bool convertedSuccessfully = Enum.TryParse<Species>(str, false, out result);
			if (convertedSuccessfully && Enum.IsDefined(typeof(Species), result))
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		private Fox CreateFox(string name)
		{
			return new Fox(name);
		}
		private Wolf CreateWolf(string name)
		{
			return new Wolf(name);
		}
		private Bear CreateBear(string name)
		{
			return new Bear(name);
		}
		private Elephant CreateElephant(string name)
		{
			return new Elephant(name);
		}
		private Tiger CreateTiger(string name)
		{
			return new Tiger(name);
		}
		private Lion CreateLion(string name)
		{
			return new Lion(name);
		}
	}
}

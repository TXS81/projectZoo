﻿
using ProjectZoo.Animals;
using System;
using System.Collections.Generic;
namespace ProjectZoo
{
	class ZooManager : IZooManager
	{
		private IZoo _zoo;
		private IAnimalFactory _factory;

		public ZooManager()
		{
			this._zoo = new Zoo();
			this._factory = new AnimalFactory();

		}
		public ZooManager(IZoo zoo, IAnimalFactory factory)
		{
			this._zoo = zoo;
			this._factory = factory;

		}
		public bool IsZooOpened { get { return _zoo.IsOpened; } }
		public string ShowAnimals()
		{
			string result = String.Empty;
			List<Animal> collectionOfAnimals = _zoo.GetAllAnimals();
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				foreach (var animal in collectionOfAnimals)
				{
					result += String.Format("\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n\n", animal.GetType().Name, animal.Name, animal.Health, animal.Status);
				}

			}
			else
			{
				result = "\n\tThere is no animals in our Zoo";

			}
			return result;
		}
		public string ShowAnimalByName(string name)
		{
			string result = String.Empty;
			List<Animal> collectionOfAnimals = _zoo.GetAllAnimals();
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				Animal currAnimal = CatchAnimalByName(name, collectionOfAnimals);
				if (currAnimal != null)
				{
					result = String.Format("\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n\n", currAnimal.GetType().Name, currAnimal.Name, currAnimal.Health, currAnimal.Status);
				}
				else
				{
					result = "\n\tThere is no such animal in our Zoo.";
				}

			}
			else
			{
				result = "\n\tThere isn't any animal in our Zoo.";
			}
			return result;
		}
		public Species? GetSpecies(char type)
		{
			string typeS = Convert.ToString(type);
			return this._factory.GetSpecies(typeS);
		}
		public string AddAnimal(string name, Species type)
		{
			if (CheckName(name))
			{
				_zoo.AddAnimal(_factory.CreateAnimal(name, (Species)type));
				return String.Format("\n\t{0} {1} has been added.\n", type.ToString(), name) + ShowAnimals();
			}
			else
			{
				return "\n\tIt's not a unique name for an animal.";
			}
		}
		public bool? FeedAnimal(string name, out string msg)
		{
			bool? isFed = this._zoo.FeedAnimal(name);
			if (isFed == null)
			{
				msg = CheckName(name) ? "\n\tCouldn't find the animal with this name" : "\n\tUnfortunately, this animal is dead.";

			}
			else if (isFed == false)
			{
				msg = "\n\tThis animal doesn't want to eat. \n\tIt's ill, so you have to heal it firstly.";
			}
			else
			{
				msg = "\n\tThis animal is well-fed." + this.ShowAnimalByName(name);
			}
			return isFed;
		}
		public string HealAnimal(string name)
		{
			string result = String.Empty;
			bool? isHealed = _zoo.HealAnimal(name);
			if (isHealed == null)
			{
				result = CheckName(name) ? "\n\tCouldn't find the animal with this name" : "\n\tUnfortunately, this animal is dead.";
			}
			else if (isHealed == false)
			{
				result = "\n\tThis animal hasn't been healed. It's quite healthy now.";
			}
			else
			{
				result = "\n\tThis animal is getting better." + this.ShowAnimalByName(name);
			}
			return result;
		}
		public string RemoveAnimal(string name)
		{
			string msg = String.Empty;
			bool? result = _zoo.RemoveAnimal(name);
			if (result == null)
			{
				msg = "\n\tThere isn't such animal in our zoo.\n";
			}
			else if (result == false)
			{
				msg = "\n\tThis animal isn't dead. You can't remove it from the zoo.\n";
			}
			else
			{
				msg = "\n\tThis animal has been removed.\n";
			}
			return msg;
		}
		public bool Manage()
		{
			return _zoo.LifeCycling();
		}
		private bool CheckName(string name)
		{
			Animal foundAnimal = this._zoo.GetAnimalByName(name);

			return foundAnimal == null ? true : false;

		}
		private Animal CatchAnimalByName(string name, List<Animal> collectionOfAnimals)
		{
			if (String.IsNullOrEmpty(name) || collectionOfAnimals.Count < 1)
			{
				return null;
			}
			else
			{
				return collectionOfAnimals.Find(a => a.Name == name);
			}
		}

	}
}

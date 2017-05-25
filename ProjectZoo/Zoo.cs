using System;
using System.Collections.Generic;

namespace ProjectZoo
{
	class Zoo : IZoo
	{
		private Object locker;
		private List<Animal> collectionOfAnimals;

		public Zoo()
		{
			this.collectionOfAnimals = new List<Animal>();
			this.locker = new object();
			this.IsOpened = true;
		}
		public bool IsOpened { get; set; }
		public bool CheckName(string name)
		{
			if (String.IsNullOrEmpty(name) && this.collectionOfAnimals == null)
			{
				return false;
			}
			else
			{
				if (this.collectionOfAnimals.Count > 0)
				{
					Animal foundAnimal = this.collectionOfAnimals.Find(p => p.Name == name);

					return (foundAnimal == null) ? true : false;

				}
				else
				{
					return true;
				}
			}

		}

		#region IZoo Members

		public string AddAnimal(Animal animal)
		{
			if (animal != null)
			{
				this.collectionOfAnimals.Add(animal);

				return String.Format("{0} {1} has been added to the Zoo.", animal.GetType().Name, animal.Name);
			}
			else
			{
				return "The animal hasn't been added.";
			}
		}

		public bool? FeedAnimal(string name)
		{
			Animal caughtAnimal = this.GetAnimalByName(name);
			if (caughtAnimal != null)
			{
				return caughtAnimal.Eat();

			}
			else
			{
				return null;
			}

		}

		public bool? HealAnimal(string name)
		{
			Animal caughtAnimal = this.GetAnimalByName(name);
			if (caughtAnimal != null)
			{
				return caughtAnimal.GetBetter();

			}
			else
			{
				return null;
			}

		}

		public bool? RemoveAnimal(string name)
		{
			Animal caughtAnimal = this.GetAnimalByName(name);
			if (caughtAnimal != null)
			{
				if (caughtAnimal.Status == State.DEAD)
				{
					this.collectionOfAnimals.Remove(caughtAnimal);
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return null;
			}

		}

		public bool LifeCycling()
		{
			lock (locker)
			{
				Animal caughtAnimal = this.GetRandomAnimal();
				if (caughtAnimal != null)
				{
					caughtAnimal.GrowOld();
				}

				if (IsThisTheEnd())
				{
					this.IsOpened = false;
					return false;
				}
			}
			return true;
		}

		public string ShowAnimals()
		{
			string result = String.Empty;
			if (this.collectionOfAnimals.Count > 0)
			{
				foreach (var animal in this.collectionOfAnimals)
				{
					result += String.Format("Species: {0} Name: {1} Status: {3} Health: {2}\n\n", animal.GetType().Name, animal.Name, animal.Health, animal.Status);
				}
				return result;
			}
			else
			{
				result = "There is no animals in our Zoo";
				return result;
			}
		}
		public string ShowAnimalByName(string name)
		{
			string result = String.Empty;
			if (this.collectionOfAnimals.Count > 0)
			{
				Animal currAnimal = GetAnimalByName(name);
				if (currAnimal != null)
				{
					result += String.Format("\n\tSpecies: {0} \n\tName: {1} \n\tStatus: {3} \n\tHealth: {2}\n\n", currAnimal.GetType().Name, currAnimal.Name, currAnimal.Health, currAnimal.Status);
				}
				else
				{
					result = "There is no such animal in our Zoo";
				}

			}
			else
			{
				result = "There isn't any animal in our Zoo";
			}
			return result;
		}
		public Animal GetAnimalByName(string name)
		{
			if (String.IsNullOrEmpty(name) || this.collectionOfAnimals.Count < 1)
			{
				return null;
			}
			else
			{
				return this.collectionOfAnimals.Find(a => a.Name == name);
			}
		}
		public Animal GetRandomAnimal()
		{
			if (this.collectionOfAnimals.Count < 1)
			{
				return null;
			}
			else
			{
				int rndIndex = new Random().Next(0, this.collectionOfAnimals.Count);
				return this.collectionOfAnimals[rndIndex];
			}
		}
		public List<Animal> GetAllAnimals()
		{
			return this.collectionOfAnimals;
		}

		#endregion

		private bool IsThisTheEnd()
		{
			if (this.collectionOfAnimals.Count > 0)
			{
				if (this.collectionOfAnimals.Find(a => a.Status != State.DEAD) == null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;
		}
	}
}

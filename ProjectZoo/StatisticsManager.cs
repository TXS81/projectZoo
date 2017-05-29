using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectZoo
{
	static class StatisticsManager
	{
		public static string ShowAllByGroup(List<Animal> collectionOfAnimals)
		{
			string result = String.Empty;

			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var groupedAnimals = from item in collectionOfAnimals
									 group item by item.GetType().Name;

				foreach (IGrouping<string, Animal> element in groupedAnimals)
				{
					result += String.Format("\n\tSpecies: {0}\n", element.Key);
					foreach (var animal in element)
					{
						result += String.Format("\n\tName: {0}\n\tStatus: {2}\t\tHealth: {1}\n", animal.Name, animal.Health, animal.Status);
					}
					result += "----------------------------";
				}

			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAnimalWithStatus(List<Animal> collectionOfAnimals, State state)
		{
			string result = String.Empty;
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimals = from item in collectionOfAnimals
									  where item.Status == state
									  select item;

				if (selectedAnimals != null && selectedAnimals.Count() > 0)
				{
					foreach (Animal animal in selectedAnimals)
					{
						result += String.Format("\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n", animal.GetType().Name, animal.Name, animal.Health, animal.Status);
					}
				}
				else
				{
					result = "\n\tThere is no animal with such state in our Zoo";
				}

			}
			else
			{
				result = "\n\tThere is no animals in our Zoo";

			}
			return result;
		}
		public static string ShowSomeAnimal(List<Animal> collectionOfAnimals, State state = State.ILL, string type = "Tiger")
		{
			string result = String.Empty;

			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimals = from item in collectionOfAnimals
									  where item.GetType().Name == type && item.Status == state
									  select item;

				if (selectedAnimals != null && selectedAnimals.Count() > 0)
				{
					foreach (Animal animal in selectedAnimals)
					{
						result += String.Format("\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n", animal.GetType().Name, animal.Name, animal.Health, animal.Status);
					}
				}
				else
				{
					result = "\n\tThere is no such animal with such state in our Zoo";
				}

			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAnimalWithName(List<Animal> collectionOfAnimals, string name, string type = "Elephant")
		{
			string result = String.Empty;
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimals = from item in collectionOfAnimals
									  where item.GetType().Name == type && item.Name == name
									  select item;

				if (selectedAnimals != null && selectedAnimals.Count() > 0)
				{
					foreach (Animal animal in selectedAnimals)
					{
						result += String.Format("\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n", animal.GetType().Name, animal.Name, animal.Health, animal.Status);
					}
				}
				else
				{
					result = "\n\tThere is no animal with such name in our Zoo";
				}

			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAllNamesWithState(List<Animal> collectionOfAnimals, State state = State.HUNGRY)
		{
			string result = String.Empty;
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimalNames = from item in collectionOfAnimals
										  where item.Status == state
										  select item.Name;

				if (selectedAnimalNames != null && selectedAnimalNames.Count() > 0)
				{
					foreach (string n in selectedAnimalNames)
					{
						result += String.Format("\n\tName: {0}", n);
					}
				}
				else
				{
					result = "\n\tThere is no animals with such state in our Zoo";
				}

			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAllDeadByGroup(List<Animal> collectionOfAnimals)
		{
			string result = String.Empty;

			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var groupedAnimals = from item in collectionOfAnimals
									 where item.Status == State.DEAD
									 group item by item.GetType().Name;

				if (groupedAnimals != null && groupedAnimals.Count() > 0)
				{
					foreach (IGrouping<string, Animal> element in groupedAnimals)
					{
						result += String.Format("\n\tSpecies: {0}\n", element.Key);
						foreach (var animal in element)
						{
							result += String.Format("\n\tName: {0}\n\tStatus: {2}\t\tHealth: {1}\n", animal.Name, animal.Health, animal.Status);
						}
						result += "----------------------------";
					}
				}
				else
				{
					result = "\n\tThere're no dead animals in our Zoo";

				}
			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowNumberOfDead(List<Animal> collectionOfAnimals)
		{
			string result = String.Empty;

			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var groupedAnimals = from item in collectionOfAnimals
									 where item.Status == State.DEAD
									 group item by item.GetType().Name;

				if (groupedAnimals != null && groupedAnimals.Count() > 0)
				{
					foreach (IGrouping<string, Animal> element in groupedAnimals)
					{
						result += String.Format("\n\tSpecies: {0}\t Number of dead: {1}\n", element.Key, element.Count());

					}
				}
				else
				{
					result = "\n\tThere're no dead animals in our Zoo";

				}
			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowHealthiestAnimals(List<Animal> collectionOfAnimals)
		{
			string result = String.Empty;

			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var groupedAnimals = from item in collectionOfAnimals
									 where item.Health > 0
									 group item by item.GetType().Name;

				if (groupedAnimals != null && groupedAnimals.Count() > 0)
				{
					foreach (IGrouping<string, Animal> element in groupedAnimals)
					{
						result += String.Format("\n\tSpecies: {0}", element.Key);
						var animal = from t in element
									 where t.Health >= element.Max(a => a.Health)
									 select t;
						if (animal != null && animal.Count() > 0)
							result += String.Format("\n\tName: {0}\n\tStatus: {2}\t\tHealth: {1}\n", animal.First().Name, animal.First().Health, animal.First().Status);
					}
				}
				else
				{
					result = "\n\tThere're no somehow health animals in our Zoo";

				}
			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAnimalsWithHealth(List<Animal> collectionOfAnimals, int edge, params string[] types)
		{
			string result = String.Empty;
			if (types.Length != 2)
			{
				throw new Exception("\n\tError in StatisticsManager.ShowAnimalsWithHealth: There is a problem with types.\n");

			}
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimals = from item in collectionOfAnimals
									  where item.GetType().Name == types[0] || item.GetType().Name == types[1]
									  where item.Health > edge
									  group item by item.GetType().Name;

				if (selectedAnimals != null && selectedAnimals.Count() > 0)
				{
					foreach (IGrouping<string, Animal> element in selectedAnimals)
					{
						result += String.Format("\n\tSpecies: {0}\n", element.Key);
						foreach (var animal in element)
						{
							result += String.Format("\n\tName: {0}\n\tStatus: {2}\t\tHealth: {1}\n", animal.Name, animal.Health, animal.Status);
						}
						result += "----------------------------";
					}
				}
				else
				{
					result = "\n\tThere is no such animal with such health in our Zoo";
				}

			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static string ShowAnimalWithMinMaxHealth(List<Animal> collectionOfAnimals)
		{
			string result = String.Empty;
			if (collectionOfAnimals != null && collectionOfAnimals.Count > 0)
			{
				var selectedAnimals = from item in collectionOfAnimals
									  where item.Health >= collectionOfAnimals.Max(a => a.Health) || item.Health <= collectionOfAnimals.Min(a => a.Health)
									  orderby item.Health descending
									  select item;

				if (selectedAnimals != null && selectedAnimals.Count() > 0)
				{
					var animalMax = selectedAnimals.First();
					var animalMin = selectedAnimals.Last();

					if (animalMax != null)
						result += String.Format("\n\tMax health has\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n", animalMax.GetType().Name, animalMax.Name, animalMax.Health, animalMax.Status);

					if (animalMin != null)
						result += String.Format("\n\tMin health has\n\tName: {1}\n\tSpecies: {0}\n\tStatus: {3}\t\tHealth: {2}\n", animalMin.GetType().Name, animalMin.Name, animalMin.Health, animalMin.Status);
				}
				else
				{
					result = "\n\tThere is no animal with such condition in our Zoo";
				}
			}
			else
			{
				result = "\n\tThere are no animals in our Zoo";

			}
			return result;
		}
		public static double AverageHealth(List<Animal> collectionOfAnimals)
		{
			return collectionOfAnimals.Average(animal => animal.Health);
		}
	}
}


namespace ProjectZoo
{
	public enum Species
	{
		LION = 1,
		TIGER,
		ELEPHANT,
		BEAR,
		WOLF,
		FOX
	}
	public enum State : byte
	{
		WELLFED,
		HUNGRY,
		ILL,
		DEAD,
	}

	public abstract class Animal
	{
		private int _baseHealth;
		public string Name { get; set; }
		public int Health { get; set; }
		public State Status { get; set; }

		public Animal(int baseHealth)
		{
			this._baseHealth = baseHealth;
			this.Health = this._baseHealth;
			this.Status = State.WELLFED;
		}
		public bool? Eat()
		{
			if (this.Status == State.DEAD)
			{
				return null;
			}
			else if (this.Status == State.ILL)
			{
				return false;
			}
			else
			{
				this.Status = State.WELLFED;
				return true;
			}
		}
		public bool? GetBetter()
		{
			if (this.Status == State.DEAD)
			{
				return null;
			}

			if (this.Health < this._baseHealth)
			{
				this.Health++;

				if (this.Health == this._baseHealth)
					this.Status = State.HUNGRY;

				return true;
			}
			return false;
		}
		public void GrowOld()
		{
			switch (this.Status)
			{
				case State.WELLFED:
					this.Status = State.HUNGRY;
					break;
				case State.HUNGRY:
					this.Status = State.ILL;
					this.Health--;
					break;
				case State.ILL:
					if (this.Health > 1)
					{
						this.Health--;
					}
					else
					{
						this.Die();
					}
					break;
				case State.DEAD:
					break;
			}
		}
		private void Die()
		{
			this.Health = 0;
			this.Status = State.DEAD;
		}

	}


}

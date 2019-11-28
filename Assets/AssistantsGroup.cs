namespace IdleClicker
{
	using UnityEngine;

	/// <summary>
	/// Single group of assistants. One group represents one type of assistants.
	/// </summary>
	public class AssistantsGroup
	{
		private int id;

		private string name;

		private int assistantsOwned;

		private double initialPrice;

		private double moneyPerSecondFromOne;

		private double priceForOne;

		private double price;

		private double moneyPerSecond;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="assistantsOwned"></param>
		/// <param name="initialPrice"></param>
		/// <param name="moneyPerSecondFromOne"></param>
		/// <param name="priceForOne"></param>
		/// <param name="price"></param>
		/// <param name="moneyPerSecond"></param>
		public AssistantsGroup(
			int id,
			string name,
			int assistantsOwned,
			double initialPrice,
			double moneyPerSecondFromOne)
		{
			this.id = id;
			this.name = name;
			this.assistantsOwned = assistantsOwned;
			this.initialPrice = initialPrice;
			this.moneyPerSecondFromOne = moneyPerSecondFromOne;
		}

		/// <summary>
		/// Id of the assistant group, used to identify it.
		/// </summary>
		public int Id
		{
			get => id;
			internal set
			{
				id = value;
			}
		}

		/// <summary>
		/// Name that will be displayed on Text component.
		/// </summary>
		public string Name
		{
			get { return name; }
			internal set
			{
				if (!string.IsNullOrEmpty(value)) name = value;
				else
					Debug.LogError(
						"You're trying to set name in one of the AssistantsGroup: " +
						$"'{id}' to an empty or null value.");
			}
		}

		/// <summary>
		/// Initial price of one assistant, on first level.
		/// </summary>
		public double InitialPrice
		{
			get => initialPrice;
			internal set
			{
				if (value > 0) initialPrice = value;
				else
					Debug.LogError(
						$"You're trying to set initialPrice in AssistantsGroup: " +
						$"'{id}' to a value that is equal or less than zero.");
			}
		}

		/// <summary>
		/// Current money per second earned from one assistant of this type.
		/// </summary>
		public double MoneyPerSecondFromOne
		{
			get => moneyPerSecondFromOne;
			internal set
			{
				if (value >= 0) moneyPerSecondFromOne = value;
				else
					Debug.LogError(
						$"You're trying to set moneyPerSecondFromOne in AssistantsGroup: " +
						$"'{id}' to a value that is less than zero.");
			}
		}

		/// <summary>
		/// Current price for one assistant.
		/// </summary>
		public double PriceForOne
		{
			get => priceForOne;
			internal set
			{
				if (value > 0) priceForOne = value;
				else
					Debug.LogError(
						$"You're trying to set priceForOne in AssistantsGroup: " +
						$"'{id}' to a value that is equal or less than zero.");
			}
		}

		/// <summary>
		/// Current price for assistants to buy. Depends on how many assistants are chosen (with a button) to buy.
		/// </summary>
		public double Price
		{
			get => price;
			internal set
			{
				if (value > 0) price = value;
				else
					Debug.LogError(
						$"You're trying to set price in AssistantsGroup: " +
						$"'{id}' to a value that is equal or less than zero.");
			}
		}

		/// <summary>
		/// How many assistants of this group are now owned.
		/// </summary>
		public int AssistantsOwned
		{
			get => assistantsOwned;
			internal set
			{
				if (value >= 0) assistantsOwned = value;
				else
					Debug.LogError(
						$"You're trying to set assistantsOwned in AssistantsGroup: " +
						$"'{id}' to a value that is less than zero.");
			}
		}

		/// <summary>
		/// How much money per second this group earns right now.
		/// </summary>
		public double MoneyPerSecond
		{
			get => moneyPerSecond;

			internal set
			{
				if (value >= 0) moneyPerSecond = value;
				else
					Debug.LogError(
						$"You're trying to set moneyPerSecond in AssistantsGroup: " +
						$"'{id}' to a value that is less than zero.");
			}
		}
	}
}

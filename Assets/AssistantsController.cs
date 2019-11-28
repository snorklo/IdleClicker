namespace IdleClicker
{
	using System.Collections;
	using System.Collections.Generic;

	using UnityEngine;

	using System.Collections;
	using System.Collections.Generic;

	using UnityEngine;

	/// <summary>
	/// Manages data about all assistants.
	/// </summary>
	public class AssistantsController
	{
		private static readonly int assistantsGroupsAmount = 5;

		public static int AssistantsGroupsAmount
		{
			get => assistantsGroupsAmount;
		}

		private List<AssistantsGroup> assistants = new List<AssistantsGroup>();

		public List<AssistantsGroup> Assistants
		{
			get => assistants;
			set => assistants = value;
		}

		private List<string> names = new List<string>
		{
			"Window Clerk", "Expedition Worker", "Postman", "Motor Vehicle Operator", "Shift Supervisor"
		};

		private List<double> initialPrices = new List<double>
		{
			10, 100, 1000, 10000, 100000
		};

		private List<double> moneyPerSecondFromOnes = new List<double>
		{
			1, 10, 100, 1000, 10000
		};

		private bool isInitialized;

		private void Initialize()
		{
			if (isInitialized) return;

			for (var i = 0; i < assistantsGroupsAmount; i++)
			{
				assistants.Add(
					new AssistantsGroup(
						i,
						names[i],
						0,
						initialPrices[i],
						moneyPerSecondFromOnes[i]));

				isInitialized = true;
			}
		}
	}
}

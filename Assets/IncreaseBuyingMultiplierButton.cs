namespace IdleClicker
{
	using System;

	using UnityEngine;
	using UnityEngine.UI;

	public class IncreaseBuyingMultiplierButton : MonoBehaviour
	{
		private int buyingMultiplierCounter;

		private BuyingMultiplier[] buyingMultipliers =
		{
			BuyingMultiplier.buyingMultiplier1,
			BuyingMultiplier.buyingMultiplier10,
			BuyingMultiplier.buyingMultiplier100
		};
		
		public Text buyingMultiplierText;

		public event Action<int> MultiplierCounterIncreased;

		// private string[] buyingMultipliers = {"1", "10", "100", "max"};
		
		public void IncreaseBuyingMultiplier()
		{
			buyingMultiplierCounter++;
			if (buyingMultiplierCounter >= buyingMultipliers.Length) buyingMultiplierCounter = 0;
			buyingMultiplierText.text = string.Format(
				"Buy × {0}",
				buyingMultipliers[buyingMultiplierCounter].MultiplierText);
			if (MultiplierCounterIncreased != null)
				MultiplierCounterIncreased(buyingMultipliers[buyingMultiplierCounter].MultiplierValue);
		}
	}
}

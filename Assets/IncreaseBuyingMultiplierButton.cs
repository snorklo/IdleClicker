namespace IdleClicker
{
	using System;

	using UnityEngine;
	using UnityEngine.UI;

	public class IncreaseBuyingMultiplierButton : MonoBehaviour
	{
		private int buyingMultiplierCounter;

		private readonly BuyingMultiplier[] buyingMultipliers =
		{
			BuyingMultiplier.buyingMultiplier1,
			BuyingMultiplier.buyingMultiplier10,
			BuyingMultiplier.buyingMultiplier100
		};
		
		[SerializeField]
		private Text buyingMultiplierText;

		/// <summary>
		/// 
		/// </summary>
		public event Action<int> MultiplierCounterIncreased;

		// private string[] buyingMultipliers = {"1", "10", "100", "max"};
		
		/// <summary>
		/// 
		/// </summary>
		public void IncreaseBuyingMultiplier()
		{
			buyingMultiplierCounter++;
			if (buyingMultiplierCounter >= buyingMultipliers.Length) buyingMultiplierCounter = 0;
			buyingMultiplierText.text = $"Buy × {buyingMultipliers[buyingMultiplierCounter].MultiplierText}";
			MultiplierCounterIncreased?.Invoke(buyingMultipliers[buyingMultiplierCounter].MultiplierValue);
		}
	}
}

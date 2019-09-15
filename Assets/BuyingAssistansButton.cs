namespace IdleClicker
{
	using System;

	using UnityEngine;
	using UnityEngine.UI;

	public class BuyingAssistansButton : MonoBehaviour
	{
		[SerializeField]
		private IncreaseBuyingMultiplierButton increaseBuyingMultiplierButton;

		[SerializeField]
		private double initialPrice;

		[SerializeField]
		private double initialMoneyPerSecond;
			
		private double price;

		private double amountToBuy;

		/// <summary>
		/// 
		/// </summary>
		public Text assistantsOwnedText;

		/// <summary>
		/// 
		/// </summary>
		public Button assistantsButton;

		public event Action<double, double> BoughtForPrice;

		private void OnEnable()
		{
			increaseBuyingMultiplierButton.MultiplierCounterIncreased += OnMultiplierCounterIncreased;
		}

		private void Start()
		{
			price = initialPrice;
		}

		private void OnDisable()
		{
			increaseBuyingMultiplierButton.MultiplierCounterIncreased -= OnMultiplierCounterIncreased;
		}

		private void Update()
		{
			assistantsButton.interactable = moneyPanel.Money >= 100;
		}

		private void OnMultiplierCounterIncreased(int value)
		{
			amountToBuy = value;
			price *= price;
		}

		/// <summary>
		/// 
		/// </summary>
		public void Hire()
		{
			BuyForPrice(price);
			IncreaseWindowClerksNumber(amountToBuy);
			IncreaseMPS(10);
			RefreshMPS();
		}

		private void BuyForPrice(double price)
		{
			BoughtForPrice?.Invoke(price);
		}

		private void IncreaseMPS(double moneyPerSecond)
		{
			
		}

		private void IncreaseWindowClerksNumber(double value)
		{
			windowClerksOwned += value;
			assistantsOwnedText.text = NumberFormatter.FormatNumber(windowClerksOwned, 1, false);
		}
	}
}

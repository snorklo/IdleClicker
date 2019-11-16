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

		[SerializeField]
		private MoneyPanel moneyPanel;

		[SerializeField]
		private Text priceText;

		[SerializeField]
		private double moneyPerSecondFromOne;

		private double price;

		private double moneyPerSecond;

		private double amountToBuy;

		private double asistantsOwned;

		/// <summary>
		/// 
		/// </summary>
		public Text assistantsOwnedText;

		/// <summary>
		/// 
		/// </summary>
		public Button assistantsButton;

		/// <summary>
		/// 
		/// </summary>
		public event Action<double> BoughtForPrice;

		/// <summary>
		/// 
		/// </summary>
		public event Action<double> MpsIncreased;

		private void OnEnable()
		{
			increaseBuyingMultiplierButton.MultiplierCounterIncreased += OnMultiplierCounterIncreased;
		}

		private void Start()
		{
			price = initialPrice;
			moneyPerSecond = moneyPerSecondFromOne;
			amountToBuy = 1;
		}

		private void OnDisable()
		{
			increaseBuyingMultiplierButton.MultiplierCounterIncreased -= OnMultiplierCounterIncreased;
		}

		private void Update()
		{
			assistantsButton.interactable = moneyPanel.Money >= price;
		}

		private void OnMultiplierCounterIncreased(int value)
		{
			amountToBuy = value;
			price = initialPrice * value;
			moneyPerSecond = moneyPerSecondFromOne * value;
			priceText.text = $"{price} L";
		}

		/// <summary>
		/// 
		/// </summary>
		public void Hire()
		{
			BuyForPrice(price);
			IncreaseAssistantsAmount(amountToBuy);
			IncreaseMps();
		}

		private void BuyForPrice(double price)
		{
			BoughtForPrice?.Invoke(price);
		}

		private void IncreaseMps()
		{
			MpsIncreased?.Invoke(moneyPerSecond);
		}

		private void IncreaseAssistantsAmount(double value)
		{
			asistantsOwned += value;
			assistantsOwnedText.text = NumberFormatter.FormatNumber(asistantsOwned, 2, true);
		}
	}
}

namespace IdleClicker
{
	using System;
	using System.Linq;

	using UnityEngine;
	using UnityEngine.UI;

	public class BuyingAssistansButton : MonoBehaviour
	{
		[SerializeField]
		private int assistantsGroupId;

		public int AssistantsGroupId
		{
			get => assistantsGroupId;
			set
			{
				if ((value >= 0) && (value <= AssistantsController.AssistantsGroupsAmount)) assistantsGroupId = value;
				else
				{
					Debug.Log(
						$"You're trying to assign 'assistantsGroupId' to '{value}'. That " +
						"is not in scope of 'AssistantsController.AssistantsGroupsAmount'");
				}
			}
		}

		[SerializeField]
		private IncreaseBuyingMultiplierButton increaseBuyingMultiplierButton;

		private AssistantsGroup assistantsGroup;

		private double initialPrice;

		private double initialMoneyPerSecond;

		private MoneyPanel moneyPanel;

		private Text priceText;

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
		/// Assistants were bought for price.
		/// </summary>
		public event Action<double> BoughtForPrice;

		/// <summary>
		/// Money per second increased.
		/// </summary>
		public event Action<double> MpsIncreased;

		private void OnEnable()
		{
			// todo: find increase buying multiplier button
			increaseBuyingMultiplierButton.MultiplierCounterIncreased += OnMultiplierCounterIncreased;
		}

		private void Awake()
		{
			AssignInitialValues();
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

		private void AssignInitialValues()
		{
			assistantsGroup = Initializer.AssistantsController.Assistants.Any(aG => aG.Id == assistantsGroupId)
				? Initializer.AssistantsController.Assistants.FirstOrDefault(
					aG => aG.Id == assistantsGroupId)
				: null;
			if (assistantsGroup == null)
			{
				Debug.LogWarning("assistantsGroup for button with 'assistantsGroupId' id is null.");
				return;
			}

			initialPrice = assistantsGroup.InitialPrice;
			price = assistantsGroup.Price;
			moneyPerSecondFromOne = assistantsGroup.MoneyPerSecondFromOne;
			moneyPerSecond = assistantsGroup.MoneyPerSecond;
			asistantsOwned = assistantsGroup.AssistantsOwned;
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

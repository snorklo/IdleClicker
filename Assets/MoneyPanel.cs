namespace IdleClicker
{
	using System.Collections;

	using UnityEngine;
	using UnityEngine.UI;

	public class MoneyPanel : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField]
		public Text moneyText;

		/// <summary>
		/// 
		/// </summary>
		public Text moneyPerSecondText;
		
		[SerializeField]
		private BuyingAssistansButton buyingWindowClerkButton;
		
		private double money;

		private double moneyPerSecond;
		
		private double moneyFromClick;

		/// <summary>
		/// 
		/// </summary>
		public double Money
		{
			get { return money; }
			private set { money = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public double MoneyPerSecond
		{
			get { return moneyPerSecond; }
			private set { moneyPerSecond = value; }
		}

		private void OnEnable()
		{
			buyingWindowClerkButton.BoughtForPrice += SubstractMoneyAfterPurchase;
			buyingWindowClerkButton.MpsIncreased += IncreaseMps;
			Letter.LetterClicked += AddMoneyFromClick;
		}

		private void Start()
		{
			moneyFromClick = 1;
			
			RefreshMoney();
			RefreshMps();

			StartCoroutine(IncreaseMoneyFromMoneyPerSecond());
		}

		private void OnDisable()
		{
			buyingWindowClerkButton.BoughtForPrice -= SubstractMoneyAfterPurchase;
			buyingWindowClerkButton.MpsIncreased -= IncreaseMps;
			Letter.LetterClicked -= AddMoneyFromClick;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		public void IncreaseMps(double value)
		{
			moneyPerSecond += value;
			RefreshMps();
		}
		
		private IEnumerator IncreaseMoneyFromMoneyPerSecond()
		{
			while (true)
			{
				money += moneyPerSecond;
				RefreshMoney();
				yield return new WaitForSecondsRealtime(1f);
			}
			// ReSharper disable once IteratorNeverReturns
		}
		
		private void SubstractMoneyAfterPurchase(double price)
		{
			money -= price;
			while (money < 0)
			{
				money *= 1000;
				NumberFormatter.DecreaseCurrentMoneyExponentCounter();
			}

			RefreshMoney();
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void RefreshMoney()
		{
			moneyText.text = "L " + NumberFormatter.FormatNumber(money, 3, true);
		}

		/// <summary>
		/// 
		/// </summary>
		public void RefreshMps()
		{
			moneyPerSecondText.text = "L / s " + NumberFormatter.FormatNumber(moneyPerSecond, 2, true);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void AddMoneyFromClick()
		{
			money += moneyFromClick;
			RefreshMoney();
		}
	}
}

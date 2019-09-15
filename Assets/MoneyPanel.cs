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

		public double Money
		{
			get { return money; }
			private set { money = value; }
		}

		public double MoneyPerSecond
		{
			get { return moneyPerSecond; }
			private set { moneyPerSecond = value; }
		}

		private void OnEnable()
		{
			BoughtForPrice += SubstractMoneyAfterPurchase;
		}

		private void Start()
		{
			moneyFromClick = 1;
			
			RefreshMoney();
			RefreshMPS();

			StartCoroutine(IncreaseMoneyFromMoneyPerSecond());
		}

		private void OnDisable()
		{
			BoughtForPrice -= SubstractMoneyAfterPurchase;
		}
		
		public void IncreaseMPS(double value)
		{
			moneyPerSecond += value;
		}
		
		private IEnumerator IncreaseMoneyFromMoneyPerSecond()
		{
			while (true)
			{
				money += moneyPerSecond;
				RefreshMoney();
				yield return new WaitForSecondsRealtime(1f);
			}
		}
		
		private void SubstractMoneyAfterPurchase(double price, double moneyPerSecond)
		{
			money -= price;
			while (money < 0)
			{
				money *= 1000;
				NumberFormatter.DecreaseCurrentMoneyExponentCounter();
			}

			RefreshMoney();
		}
		
		public void RefreshMoney()
		{
			moneyText.text = "L " + NumberFormatter.FormatNumber(money, 3, true);
		}

		public void RefreshMPS()
		{
			moneyPerSecondText.text = "L / s " + NumberFormatter.FormatNumber(moneyPerSecond, 2, true);
		}
		
		public void AddMoneyFromClick()
		{
			money += moneyFromClick;
			RefreshMoney();
		}
	}
}

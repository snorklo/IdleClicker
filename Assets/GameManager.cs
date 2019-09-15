namespace IdleClicker
{




	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	using UnityEngine;
	using UnityEngine.UI;

	public class GameManager : MonoBehaviour
	{
		private double money;

		private double moneyPerSecond;

		public Text MoneyText;

		public Text MoneyPerSecondText;

		private double betterPensOwned;

		private double windowClerksOwned;

		public Text WindowClerksOwnedText;

		public Button windowClerks;

		public Button betterPen;

		private double moneyFromClick;

		//  
		// 10^105 - Quattuortrigintillion
		// 10^108 - Quintrigintillion
		// 10^111 - Sextrigintillion
		// 10^114 - Septentrigintillion
		// 10^117 - Octotrigintillion
		// 10^120 - Novemtrigintillion
		//
		// 10^123 - Quadragintillion
		// 10^126 - Unquadragintillion
		// Duoquadragintillion
		//  Trequadragintillion
		//  Quattuorquadragintillion
		// Quinquadragintillion
		// Sexquadragintillion
		// Septenquadragintillion
		// Octoquadragintillion
		// Novemquadragintillion

		private void Update()
		{
			betterPen.interactable = money >= 30;
			windowClerks.interactable = money >= 100;
		}

		private void BuyForPrice(double price)
		{
			money -= price;
			while (money < 0)
			{
				money *= 1000;
				 NumberFormatter.DecreaseCurrentMoneyExponentCounter();
			}

			RefreshMoney();
		}
		
		private void Start()
		{
			moneyFromClick = 1;
			money = 0;
			moneyPerSecond = 0;
			RefreshMoney();
			RefreshMPS();

			StartCoroutine(IncreaseMoneyFromMoneyPerSecond());
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

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		public void AddMoneyFromClick()
		{
			money += moneyFromClick;
			RefreshMoney();
		}

		// private void IncreaseBetterPensNumber(double value)
		// {
		// 	betterPensOwned += value;
		// 	BetterPensOwnedText.text = FormatNumber(betterPensOwned, 1, false);
		// }

		private void IncreaseWindowClerksNumber(double value)
		{
			windowClerksOwned += value;
			WindowClerksOwnedText.text = NumberFormatter.FormatNumber(windowClerksOwned, 1, false);
		}

		private void IncreaseMoneyFromClick(double value)
		{
			moneyFromClick += value;
		}

		/// <summary>
		/// 
		/// </summary>
		public void HireBetterPen()
		{
			BuyForPrice(30);

			// IncreaseBetterPensNumber(1);
			IncreaseMoneyFromClick(1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void HireWindowClerk()
		{
			BuyForPrice(100);
			IncreaseWindowClerksNumber(1);
			IncreaseMPS(10);
			RefreshMPS();
		}

		public void IncreaseMPS(double value)
		{
			moneyPerSecond += value;
		}

		public void RefreshMoney()
		{
			MoneyText.text = "L " + NumberFormatter.FormatNumber(money, 3, true);
		}

		public void RefreshMPS()
		{
			MoneyPerSecondText.text = "L / s " + NumberFormatter.FormatNumber(moneyPerSecond, 2, true);
		}
	}
}
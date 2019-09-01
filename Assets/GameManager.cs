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

	private double assistantsOwned;

	public Text BetterPensOwnedText;

	public Text AssistantsOwnedText;

	public Button Assistants;

	public Button BetterPen;

	private double moneyFromClick;

	private static int currentMoneyExponentCounter;

	private static string currentMoneyExponent;

	private static string[] shortExponents =
		{"", "k", "M", "B", "T", "Q", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii"};

	private static string[] longExponents =
	{
		"",
		"Thousand",
		"Million",
		"Billion",
		"Trillion",
		"Quadrillion",
		"Quintillion",
		"Sextillion",
		"Septillion",
		"Octillion",
		"Nonillion",
		"Decillion",
		"Undecillion",
		"Duodecillion",
		"Tredecillion",
		"Quattuordecillion",
		"Quindecillion",
		"Sexdecillion",
		"Septendecillion",
		"Octodecillion",
		"Novendecillion",
		"Vigintillion",
		"Unvigintillion",
		"Duovigintillion",
		"Trevigintillion",
		"Quattuorvigintillion",
		"Quinvigintillion",
		"Sexvigintillion",
		"Septenvigintillion",
		"Octovigintillion",
		"Novemvigintillion",
		"Trigintillion",
		"Untrigintillion",
		"Duotrigintillion",
		"Tretrigintillion"
	};

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
		BetterPen.interactable = money >= 30;

		Assistants.interactable = money >= 100;
	}

	private void BuyForPrice(double price)
	{
		money -= price;
		while (money < 0)
		{
			money *= 1000;
			currentMoneyExponentCounter--;
		}

		RefreshMoney();
	}

	private static string FormatNumber(double number, int digits, bool useLongExponents)
	{
		int exponentsCounter = 0;

		while (number / 1000 > 1)
		{
			exponentsCounter++;
			if (exponentsCounter >= longExponents.Length) exponentsCounter = 0;
			number /= 1000;
		}

		string numberAsString = "";

		switch (digits)
		{
			case 3:
				numberAsString = string.Format("{0:F3}", number).Contains(".")
					? string.Format("{0:F3}", number).TrimEnd('0').TrimEnd('.')
					: string.Format("{0:F3}", number);
				break;

			case 2:
				numberAsString = string.Format("{0:F2}", number).Contains(".")
					? string.Format("{0:F2}", number).TrimEnd('0').TrimEnd('.')
					: string.Format("{0:F2}", number);
				break;

			case 1:
				numberAsString = string.Format("{0:F1}", number).Contains(".")
					? string.Format("{0:F1}", number).TrimEnd('0').TrimEnd('.')
					: string.Format("{0:F1}", number);
				break;

			default:
				numberAsString = string.Format("{0:F0}", number).Contains(".")
					? string.Format("{0:F0}", number).TrimEnd('0').TrimEnd('.')
					: string.Format("{0:F0}", number);
				break;
		}

		currentMoneyExponentCounter = exponentsCounter;
		currentMoneyExponent = longExponents[exponentsCounter];

		return useLongExponents
			? numberAsString + " " + longExponents[exponentsCounter]
			: numberAsString + " " + shortExponents[exponentsCounter];
	}

	private string multiplier;

	private void Start()
	{
		multiplier = "";
		moneyFromClick = 1;
		money = 0;
		moneyPerSecond = 1;
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

	private void IncreaseBetterPensNumber(double value)
	{
		betterPensOwned += value;
		BetterPensOwnedText.text = FormatNumber(betterPensOwned, 1, false);
	}

	private void IncreaseAssistantsNumber(double value)
	{
		assistantsOwned += value;
		AssistantsOwnedText.text = FormatNumber(assistantsOwned, 1, false);
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
		IncreaseBetterPensNumber(1);
		IncreaseMoneyFromClick(1);
	}

	/// <summary>
	/// 
	/// </summary>
	public void HireAssistant()
	{
		BuyForPrice(100);
		IncreaseAssistantsNumber(1);
		IncreaseMPS(3);
		RefreshMPS();
	}

	public void IncreaseMPS(double value)
	{
		moneyPerSecond += value;
	}

	public void RefreshMoney()
	{
		MoneyText.text = "L " + FormatNumber(money, 3, true);
	}

	public void RefreshMPS()
	{
		MoneyPerSecondText.text = "L / s " + FormatNumber(moneyPerSecond, 2, true);
	}
}

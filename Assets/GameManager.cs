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

	public Text Money;

	public Text MoneyPerSecond;

	private double moneyFromClick;

	private static string[] exponents = {"", "k", "M", "B", "T", "Q", "aa", "bb", "cc", "dd", "ee", "ff"};

	private static string FormatNumber(double number)
	{
		int exponentsCounter = 0;

		while (number / 1000 > 1)
		{
			exponentsCounter++;
			if (exponentsCounter >= exponents.Length) exponentsCounter = 0;
			number /= 1000;
		}

		var numberAsString = string.Format("{0:F2}", number).Contains(".")
			? string.Format("{0:F2}", number).TrimEnd('0').TrimEnd('.')
			: string.Format("{0:F2}", number);

		return numberAsString + exponents[exponentsCounter];
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

	private void RefreshMultiplier() { }

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	public void AddMoneyFromClick()
	{
		money += moneyFromClick;
		RefreshMoney();
	}

	private void IncreaseMoneyFromClick(double value)
	{
		moneyFromClick += value;
	}

	public void HireBetterPen()
	{
		IncreaseMoneyFromClick(1);
	}

	public void HireAssistant()
	{
		IncreaseMPS(1000);
		RefreshMPS();
	}

	public void HireAssistant1()
	{
		IncreaseMPS(10000);
		RefreshMPS();
	}

	public void HireAssistant2()
	{
		IncreaseMPS(100000);
		RefreshMPS();
	}

	public void IncreaseMPS(double value)
	{
		moneyPerSecond += value;
	}

	public void RefreshMoney()
	{
		Money.text = "L " + FormatNumber(money);
	}

	public void RefreshMPS()
	{
		MoneyPerSecond.text = "L / s " + FormatNumber(moneyPerSecond);
	}
}

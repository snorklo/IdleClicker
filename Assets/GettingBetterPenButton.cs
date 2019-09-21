namespace IdleClicker
{
	using UnityEngine;
	using UnityEngine.UI;

	public class GettingBetterPenButton : MonoBehaviour
	{
		[SerializeField]
		private MoneyPanel moneyPanel;
		
		/// <summary>
		/// 
		/// </summary>
		public Button betterPen;
		
		private void Update()
		{
			betterPen.interactable = moneyPanel.Money >= 30;
		}

		/// <summary>
		/// 
		/// </summary>
		// public void GetBetterPen()
		// {
		// 	BuyForPrice(30);
		// 	// IncreaseBetterPensNumber(1);
		// 	IncreaseMoneyFromClick(1);
		// }
		
		
		//
		// private void IncreaseMoneyFromClick(double value)
		// {
		// 	
		// 	moneyFromClick += value;
		// }
		
		
	}
}

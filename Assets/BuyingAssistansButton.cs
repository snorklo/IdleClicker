namespace IdleClicker
{
	using UnityEngine;
	using UnityEngine.UI;

	public class BuyingAssistansButton : MonoBehaviour
	{
		[SerializeField]
		private IncreaseBuyingMultiplierButton increaseBuyingMultiplierButton;
		
		private void OnEnable()
		{	
			increaseBuyingMultiplierButton.MultiplierCounterIncreased += OnMultiplierCounterIncreased;
		}

		private void OnDisable()
		{
			increaseBuyingMultiplierButton.MultiplierCounterIncreased -= OnMultiplierCounterIncreased;
		}
		
		private void OnMultiplierCounterIncreased(int value)
		{
			
		}
		
		
	}
}

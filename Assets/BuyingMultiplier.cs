namespace IdleClicker
{
	public class BuyingMultiplier
	{
		public static BuyingMultiplier buyingMultiplier1 = new BuyingMultiplier(0, "1", 1);

		public static BuyingMultiplier buyingMultiplier10 = new BuyingMultiplier(1, "10", 10);

		public static BuyingMultiplier buyingMultiplier100 = new BuyingMultiplier(2, "100", 100);

		public int MultiplierCounter { get; private set; }

		public string MultiplierText { get; private set; }

		public int MultiplierValue { get; private set; }

		private BuyingMultiplier(int multiplierCounter, string multiplierText, int multiplierValue)
		{
			MultiplierCounter = multiplierCounter;
			MultiplierText = multiplierText;
			MultiplierValue = multiplierValue;
		}
	}
}

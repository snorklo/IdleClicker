namespace IdleClicker
{
	public static class Initializer
	{
		private static bool isInitialized;

		private static AssistantsController assistantsController;

		static Initializer()
		{
			if (isInitialized) return;
			
			assistantsController = new AssistantsController();
			
		}
	}
}

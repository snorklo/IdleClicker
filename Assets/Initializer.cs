namespace IdleClicker
{
	public static class Initializer
	{
		private static bool isInitialized;

		private static AssistantsController assistantsController;

		public static AssistantsController AssistantsController
		{
			get => assistantsController;
		}

		static Initializer()
		{
			if (isInitialized) return;
			
			assistantsController = new AssistantsController();

			isInitialized = true;
		}
	}
}

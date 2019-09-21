namespace IdleClicker
{
	using System;

	using UnityEngine;

	public class Letter : MonoBehaviour
	{
		
		public static event Action LetterClicked;

		public void LetterClick()
		{
			LetterClicked?.Invoke();
		}
	}
}

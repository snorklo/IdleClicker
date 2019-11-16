namespace IdleClicker
{
	using System;

	using UnityEngine;

	public class Letter : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		public static event Action LetterClicked;

		/// <summary>
		/// 
		/// </summary>
		public void LetterClick()
		{
			LetterClicked?.Invoke();
		}
	}
}

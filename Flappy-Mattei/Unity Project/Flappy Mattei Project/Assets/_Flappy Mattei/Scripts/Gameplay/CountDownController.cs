/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;
using TMPro;

namespace BorysProductions
{
	namespace Gameplay
	{
		public class CountDownController : MonoBehaviour
		{

			/*public static CountDownController instance;

			GameManager GM;

			[Header("CountDown UI")]
			public GameObject CountDownPanel;
			public TMP_Text CountDownText;
			

			[Header("Countdown Settings")]
			public int TimerCountDown = 3;
			public string StartCountdownEndedText = "VIA!";
			public float CountDownDelay = 1f;


			private void Start()
			{
				instance = this;
				GM = FindObjectOfType<GameManager>();
				//StartCountDown();
			}


			private void Update()
			{
				
			}

			#region Metodi CountDown

			public void StartCount()
			{
				StartCountDown();
			}

			public void StartCountDown()
			{
				StartCoroutine(Countdown());
			}

			public virtual void SetCountdownTextStatus(bool status)
			{
				CountDownText.gameObject.SetActive(status);
				CountDownPanel.SetActive(status);
			}


			protected virtual IEnumerator Countdown()
			{
				GM.GameState = GameStates.LevelStart;
				if (TimerCountDown == 0)
				{
					SetCountdownTextStatus(false);
					GM.GameState = GameStates.GameInProgress;
					yield break;
				}

				//SetCountdownTextStatus(false);
				yield return new WaitForSeconds(CountDownDelay);
				SetCountdownTextStatus(true);
				Debug.Log("CountDown Started");
				int countdown = TimerCountDown;
				SetCountdownTextStatus(true);
				while (countdown > 0)
				{
					SetCountdownText(countdown.ToString());
					countdown--;
					Debug.Log("CountDown: " + countdown);
					yield return new WaitForSeconds(CountDownDelay);
				}
				if (countdown == 0)
				{
					SetCountdownText(StartCountdownEndedText);
					yield return new WaitForSeconds(CountDownDelay);
				}
				SetCountdownTextStatus(false);
				GM.GameState = GameStates.GameInProgress;
			}

			public virtual void SetCountdownText(string newText)
			{
				CountDownText.text = newText;
			}

			#endregion
			*/
		}
	}
}

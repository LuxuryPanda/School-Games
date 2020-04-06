/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


using BorysProductions.Data;	
	


namespace BorysProductions
{
	namespace Gameplay
	{
		public class ScoreSystem : MonoBehaviour
		{

			#region Variables

			public static ScoreSystem _instance;

			PlayerData pd;
			
			public int Score { get; set; }
			public int HighScore { get; set; }

			public Text ScoreText;
			public TMP_Text HighScoreText;

			#endregion

			#region Unity Methods

			void Start()
			{
				pd = FindObjectOfType<PlayerData>();
				HighScore = pd.getHighScore();
				if (_instance)
				{
					Destroy(gameObject);
				}
				else
				{
					_instance = this;
				}
				
				ResetScore();
			}
			
			#endregion

			
			#region Score Methods
			
			public void AddScore()
			{
				Score++;
				Debug.Log("Aggiunto 1 punto!!");
				ReportScore();
			}


			public void ResetScore()
			{
				Score = 0;
				ReportScore();
				Debug.Log("Score resetted");
			}

			
			
			#endregion
			
			#region HighScore Methods
			
			
			
			public void SaveHighScore()
			{
				if (Score > HighScore)
				{
					pd.saveHighScore(Score);

					Debug.Log("New HighScore: " + Score + " !!!");
					
					ReportHighScore();
				}
				else
				{
					Debug.Log("The HighScore still unbeaten");
				}
			}

			public void ResetHighScore()
			{
				pd.saveHighScore(0);
				
				Debug.Log("Resetting High Score");
				
				ReportHighScore();
			}
			#endregion
			
			
			#region Score & Highscore Reporters

			/// <summary>
			/// Report on display the current Score and HighScore values
			/// </summary>
			public void ReportScore()
			{
				if (ScoreText.text != null)
				{
					ScoreText.text = Score.ToString();
				}
			}

			public void ReportHighScore()
			{
				if (HighScoreText.text != null)
				{
					HighScoreText.text = pd.getHighScore().ToString();
				}
			}

			#endregion
			

		}
	}
}

/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;


//using BorysProductions.Audio;
using BorysProductions.Core;
using BorysProductions.Currency;
using BorysProductions.Data;
//using BorysProductions.DailyReward;
using BorysProductions.Gameplay;
using BorysProductions.Network;
using BorysProductions.Personaggi;




namespace BorysProductions
{
	namespace UI {
		public class UIManager : MonoBehaviour
		{

			#region Variables

			public static UIManager _instance;

			GameManager GM;

			GameVersion GV;

			FPSCounter FC;

			PlayerData player;

			CharactersManager CM;
			

			[Header("Game Panels")]
			public GameObject HomePanel;
			public GameObject GamePanel;
			public GameObject CountDownPanel;
			public GameObject GameOverPanel;
			public GameObject ShopPanel;
			public GameObject PausePanel;
			public GameObject SettingsPanel;
			public GameObject GDPRPanel;
			public GameObject ChangelogPanel;
			public GameObject StarterUI;
			public GameObject RewardsPanel;
			public GameObject DebugRewardsPanel;
			
			[Space(35)]
			[Header("Settings Stuff")]

			public GameObject BackgroundMusicEnabled;
			public GameObject BackgroundMusicDisabled;

			public GameObject BackgroundSoundEnabled;
			public GameObject BackgroundSoundDisabled;
			[Space(35)]
			public TMP_Text textVersione;

			
			[Header("GameOver Stuff")]
			public TMP_Text GameOverText;

			public string[] FrasiGameOver;

            [Header("Popup Animations Stuff")]
            public GameObject ShopOverlay;
            public GameObject ShopContainer;
            [Space(15f)]
            public GameObject SettingsOverlay;
            public GameObject SettingsContainer;
            [Space(15f)]
            public GameObject PauseOverlay;
            public GameObject PauseContainer;
            [Space(15f)]
            public GameObject ChangelogOverlay;
            public GameObject ChangelogContainer;

            [Header("Dev Add-Ons")] 
			public GameObject DevPanel;

			public Toggle FpsToggle;


			#endregion


			#region Metodi Unity

			// Start is called before the first frame update
			void Start()
			{
				GM = FindObjectOfType<GameManager>();
				GV = FindObjectOfType<GameVersion>();
				FC = FindObjectOfType<FPSCounter>();
				player = FindObjectOfType<PlayerData>();
				CM = FindObjectOfType<CharactersManager>();


				Time.timeScale = 1f;

				#region Panels

				if (!player.GameState.Equals(GameStates.Restarted))
				{
					HomePanel.SetActive(true);
					GamePanel.SetActive(false);
					CountDownPanel.SetActive(false);
					GameOverPanel.SetActive(false);


					PausePanel.SetActive(false);
                    PauseOverlay.SetActive(true);
                    PauseContainer.SetActive(true);


                    ShopOverlay.gameObject.SetActive(false);
                    ShopContainer.gameObject.SetActive(false);
					ShopPanel.SetActive(true);

                    SettingsOverlay.gameObject.SetActive(false);
                    SettingsContainer.gameObject.SetActive(false);
                    SettingsPanel.SetActive(true);


					ChangelogPanel.SetActive(true);
                    ChangelogOverlay.SetActive(false);
                    ChangelogContainer.SetActive(false);


                    DevPanel.SetActive(false);
					StarterUI.SetActive(false);
					RewardsPanel.SetActive(false);
					DebugRewardsPanel.SetActive(false);
				}
				else
				{
					HomePanel.SetActive(false);
					GameOverPanel.SetActive(false);


                    PausePanel.SetActive(false);
                    PauseOverlay.SetActive(true);
                    PauseContainer.SetActive(true);

                    ShopOverlay.gameObject.SetActive(false);
                    ShopContainer.gameObject.SetActive(false);
                    ShopPanel.SetActive(true);

                    SettingsOverlay.gameObject.SetActive(false);
                    SettingsContainer.gameObject.SetActive(false);
                    SettingsPanel.SetActive(true);


                    ChangelogPanel.SetActive(true);
                    ChangelogOverlay.SetActive(false);
                    ChangelogContainer.SetActive(false);



                    DevPanel.SetActive(false);
                    StarterUI.SetActive(false);
					RewardsPanel.SetActive(false);
					DebugRewardsPanel.SetActive(false);
					Play();
				}

				#endregion

				if (player.isFirstTime)
				{
					if (!player.hasSelectedStarter)
					{
						OpenStarterUI();
					}
					else
					{
						CloseStarterUI();
					}
				}

				textVersione.text = "" + GV.projectVersionToString();
				player.GameState = GameStates.HomeScreen;
			}

			// Update is called once per frame
			void Update()
			{

			}

			#endregion



			#region Home

			public void Play()
			{
				if (player.GameState.Equals(GameStates.HomeScreen))
				{
					try
					{
						PlayerPrefs.Save();
					}
					catch (Exception e)
					{
						Debug.Log("Error while saving Daily Reward Time");
						throw;
					}
					
				}
				CM.SpawnPlayer();
				HomePanel.SetActive(false);
				GamePanel.SetActive(true);
				CountDownPanel.SetActive(true);
				GM.StartGame();
				
				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}


			public void OpenSettings()
			{

                SettingsOverlay.SetActive(true);
                SettingsContainer.SetActive(true);

                ChangeSpriteMusic();
                ChangeSpriteSounds();

                try
                {
	                PlayerPrefs.Save();
                }
                catch (Exception e)
                {
	                Debug.Log("Error while saving Daily Reward Time");
	                throw;
                }
			}

			public void CloseSettings()
			{

				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}


			public void OpenShop()
			{
				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}

			public void CloseShop()
			{
				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}

			#endregion

			#region Impostazioni

			#region Panel

			public void ApriImpostazioni()
			{

				ChangeSpriteMusic();
				ChangeSpriteSounds();
                ChangeFpsCheckBox();

                try
                {
	                PlayerPrefs.Save();
                }
                catch (Exception e)
                {
	                Debug.Log("Error while saving Daily Reward Time");
	                throw;
                }
			}

			public void ChiudiImpostazioni()
			{

				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}

			#endregion

			#region Buttons

            public void ChangeFpsCheckBox()
            {
                if (player.canShowFPS)
                {
                    FpsToggle.isOn = true;
                }
                else
                {
                    FpsToggle.isOn = false;
                }
            }


			public void MusicButtonStatus()
			{
				//BorysAudio.instance.fastMusicStatusChanger();
				ChangeSpriteMusic();
			}

			public void ChangeSpriteMusic()
			{
				/*
				if (BorysAudio.instance.isMusicDisabled())
				{
					BackgroundMusicEnabled.SetActive(false);
					BackgroundMusicDisabled.SetActive(true);
				}
				else
				{
					BackgroundMusicEnabled.SetActive(true);
					BackgroundMusicDisabled.SetActive(false);
				}
				*/

			}

			public void SoundButtonStatus()
			{
				//BorysAudio.instance.fastSoundStatusChanger();
				ChangeSpriteSounds();
			}

			public void ChangeSpriteSounds()
			{
				/*
				if (BorysAudio.instance.isSoundDisabled())
				{
					BackgroundSoundEnabled.SetActive(false);
					BackgroundSoundDisabled.SetActive(true);
				}
				else
				{
					BackgroundSoundEnabled.SetActive(true);
					BackgroundSoundDisabled.SetActive(false);
				}
				*/
			}

			public void OpenGDPR()
			{
				GDPRPanel.SetActive(true);
			}


			#endregion

			#endregion

			#region Pausa

			public void OpenPause()
			{
				Time.timeScale = 0f;
				PausePanel.SetActive(true);
				player.GameState = GameStates.Pause;

				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}


			public void ContinueGame()
			{
				PausePanel.SetActive(false);
				Time.timeScale = 1f;
				player.GameState = GameStates.GameInProgress;

				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}

			public void TornaAllaHome()
			{
				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
				
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

			#endregion

			#region GameOver


			public void ShowGameOver()
			{
				Time.timeScale = 0f;
				GameOverPanel.SetActive(true);
				player.GameState = GameStates.GameOverScreen;
				ScoreSystem._instance.ReportHighScore();

				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
			}

			public void RestartGame()
			{
				player.GameState = GameStates.Restarted;
				GM.Restart();

			}

			public void ReturnToHome()
			{
				try
				{
					PlayerPrefs.Save();
				}
				catch (Exception e)
				{
					Debug.Log("Error while saving Daily Reward Time");
					throw;
				}
                
                player.GameState = GameStates.HomeScreen;
                GM.Restart();
			}

			#endregion
			
			#region DevMode

			public void ApriDevMenu()
			{
				DevPanel.SetActive(true);
				SettingsPanel.SetActive(false);
				FpsToggle.isOn = FC.canShowFPS;
			}

			public void ChiudiDevMenu()
			{
				DevPanel.SetActive(false);
				SettingsPanel.SetActive(true);
			}
			
			
			public void ToggleFPS()
			{
				if (FpsToggle.isOn)
				{
					PlayerPrefs.SetInt("canShowFPS", 1);
					FC.canShowFPS = true;
					StartCoroutine(FC.FPS());
				}
				else
				{
					PlayerPrefs.SetInt("canShowFPS", 0);
					FC.canShowFPS = false;
					StopCoroutine(FC.FPS());
				}

			}

			#endregion

			#region Changelog


			public void OpenChangelog()
			{
				//ChangelogPanel.SetActive(true);
				//SettingsPanel.SetActive(false);
			}

			public void CloseChangelog()
			{
				//ChangelogPanel.SetActive(false);
				//SettingsPanel.SetActive(true);
			}

			#endregion

			#region Starter

			public void OpenStarterUI()
			{
				StarterUI.SetActive(true);
			}

			public void CloseStarterUI()
			{
				StarterUI.SetActive(false);
			}

			#endregion

		}
	}
}

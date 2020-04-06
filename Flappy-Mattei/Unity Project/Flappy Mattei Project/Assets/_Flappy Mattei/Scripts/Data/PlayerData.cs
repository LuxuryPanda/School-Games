/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BorysProductions.Gameplay;

namespace BorysProductions
{
	namespace Data
	{
		public class PlayerData : MonoBehaviour
		{
			public static PlayerData _instance;

			#region Variabili

			GameVersion GV;
			
			
			// Stats & Gameplay Stuff

			public GameModes LastGameMode;
			
			public int EndlessGamePlayed { get; set; }
			
			public int LevelGamePlayed { get; set; }
			
			public int DunkGamePlayed { get; set; }
			
			public int CatholicGamePlayed { get; set; }
			
			public int SmasherGamePlayed { get; set; }
			
			
			
			
			public int LastScore { get; set; }
			
			public int EndlessHighScore { get; set; }

			public int DunkHighScore { get; set; }

			public int CatholicHighScore { get; set; }

			public int SmasherHighScore { get; set; }

			public int CurrentLevel { get; set; }


			
			// Currency
			public bool noAds { get; set; }
			public int Coins { get; set; }
			public int Bolt { get; set; }
			
			
			
			// Characters
			public int personaggioSelezionato { get; set; }
			public int starterScelto { get; set; }
			
			
			
			// Settings
			public bool isFirstTime { get; set; }
			public bool hasSelectedStarter { get; set; }

			
			public bool isMusicOff { get; set; }
			private const bool MUSIC_ENABLED = true;
			private const bool MUSIC_DISABLED = false;
			
			public bool isSoundOff { get; set; }
			private const bool SOUND_ENABLED = true;
			private const bool SOUND_DISABLED = false;
			
			public bool canShowFPS { get; set; }

			
			// Game Version
			public string CurrentGameVersion { get; set; }


			
			// GAME STATE
			public GameStates GameState;

			#endregion

			#region PPF Keys

			// Stats Keys

			public static string LAST_GAMEMODE_KEY = "PPF_Last_GameMode";
			
			public static string ENDLESS_GAME_PLAYED_KEY = "PPF_Endless_GamePlayed";
			public static string LEVEL_GAME_PLAYED_KEY = "PPF_Level_GamePlayed";
			public static string DUNK_GAME_PLAYED_KEY = "PPF_Dunk_GamePlayed";
			public static string CATHOLIC_GAME_PLAYED_KEY = "PPF_Catholic_GamePlayed";
			public static string SMASHER_GAME_PLAYED_KEY = "PPF_Smasher_GamePlayed";
			
			
			public static string LAST_SCORE_KEY = "PPF_LastScore";
			
			public static string ENDLESS_HIGHSCORE_KEY = "PPF_Endless_HighScore";
			public static string CURRENT_LEVEL_KEY = "PPF_CurrentLevel";
			public static string DUNK_HIGHSCORE_KEY = "PPF_Dunk_HighScore";
			public static string CATHOLIC_HIGHSCORE_KEY = "PPF_Catholic_HighScore";
			public static string SMASHER_HIGHSCORE_KEY = "PPF_Smasher_HighScore";

			// Currency Keys
			public static string NO_ADS_KEY = "PPF_NOADS";
			public static string COINS_KEY = "PPF_Coins";
			public static string BOLT_KEY = "PPF_Bolts";

			// Characters Keys
			public static string CURRENT_CHARACTER_KEY = "PPF_Selected_Character";
			public static string CHARACTERS_UNLOCKED_KEY = "PPF_Unlocked_Character_";
			public static string STARTER_SELECTED = "PPF_Selected_Starter";
			
			// Settings Keys
			public static string IS_FIRST_TIME_KEY = "PPF_is_First_Time";
			public static string HAS_SELECTED_STARTER = "PPF_has_Selected_Starter";
			public static string MUSIC_STATUS_KEY = "PPF_Music_Status";
			public static string SOUND_STATUS_KEY = "PPF_Sound_Status";
			public static string CAN_SHOW_FPS_KEY = "PPF_can_Show_FPS";
			
			// Game Version Keys
			public static string CURRENT_GAME_VERSION_KEY = "PPF_Game_Version";

			#endregion


			#region Unity Methods

			
			private void Start()
			{
				_instance = this;
				GV = FindObjectOfType<GameVersion>();
			}

			private void Awake()
			{
				if (_instance)
				{
					Destroy(gameObject);
				}
				else
				{
					_instance = this;
					DontDestroyOnLoad(gameObject);
				}

				LoadData();
			}

			private void OnApplicationPause(bool pauseStatus)
			{
				if (pauseStatus)
				{
					SaveData();
				}
			}

			private void OnApplicationQuit()
			{
				SaveData();
			}

			
			#endregion

			#region Data Handler

			public void LoadData()
			{
				
				// Stats

				if (PlayerPrefs.GetString(LAST_GAMEMODE_KEY, GameModes.Endless.ToString()).Equals(GameModes.Endless.ToString()))
				{
					LastGameMode = GameModes.Endless;
				}
				else if (PlayerPrefs.GetString(LAST_GAMEMODE_KEY, GameModes.Endless.ToString()).Equals(GameModes.Levels.ToString()))
				{
					LastGameMode = GameModes.Levels;
				}
				else if (PlayerPrefs.GetString(LAST_GAMEMODE_KEY, GameModes.Endless.ToString()).Equals(GameModes.Dunk.ToString()))
				{
					LastGameMode = GameModes.Dunk;
				}
				else if (PlayerPrefs.GetString(LAST_GAMEMODE_KEY, GameModes.Endless.ToString()).Equals(GameModes.Catholic.ToString()))
				{
					LastGameMode = GameModes.Catholic;
				}
				else if (PlayerPrefs.GetString(LAST_GAMEMODE_KEY, GameModes.Endless.ToString()).Equals(GameModes.Smasher.ToString()))
				{
					LastGameMode = GameModes.Smasher;
				}
				else
				{
					LastGameMode = GameModes.Endless;
				}
				
				
				EndlessGamePlayed = PlayerPrefs.GetInt(ENDLESS_GAME_PLAYED_KEY, 0);
				LastScore = PlayerPrefs.GetInt(LAST_SCORE_KEY, 0);
				EndlessHighScore = PlayerPrefs.GetInt(ENDLESS_HIGHSCORE_KEY, 0);


				// Currency
				noAds = (PlayerPrefs.GetInt(NO_ADS_KEY, 0) == 1);
				Coins = PlayerPrefs.GetInt(COINS_KEY, 100);
				Bolt = PlayerPrefs.GetInt(BOLT_KEY, 100);
				
				
				// Characters
				starterScelto = PlayerPrefs.GetInt(STARTER_SELECTED, 0);
				personaggioSelezionato = PlayerPrefs.GetInt(CURRENT_CHARACTER_KEY, starterScelto);

				
				// Settings
				isFirstTime = (PlayerPrefs.GetInt(IS_FIRST_TIME_KEY, 1) == 1);
				hasSelectedStarter = (PlayerPrefs.GetInt(HAS_SELECTED_STARTER, 0)== 1);
				isMusicOff = (PlayerPrefs.GetInt(MUSIC_STATUS_KEY, 0)== 1);
				isSoundOff = (PlayerPrefs.GetInt(SOUND_STATUS_KEY, 0)== 1);
				canShowFPS = (PlayerPrefs.GetInt(CAN_SHOW_FPS_KEY, 0)== 1);
				
				
				// Game Version
				CurrentGameVersion = PlayerPrefs.GetString(CURRENT_GAME_VERSION_KEY, "2.0.0");
			}


			public void SaveData()
			{
				
				// Stats
				PlayerPrefs.SetInt(ENDLESS_GAME_PLAYED_KEY, EndlessGamePlayed);
				PlayerPrefs.SetInt(LEVEL_GAME_PLAYED_KEY, LevelGamePlayed);
				PlayerPrefs.SetInt(DUNK_GAME_PLAYED_KEY, DunkGamePlayed);
				PlayerPrefs.SetInt(CATHOLIC_GAME_PLAYED_KEY, CatholicGamePlayed);
				PlayerPrefs.SetInt(SMASHER_GAME_PLAYED_KEY, SmasherGamePlayed);
				
				
				PlayerPrefs.SetInt(LAST_SCORE_KEY, LastScore);
				
				PlayerPrefs.SetInt(ENDLESS_HIGHSCORE_KEY, EndlessHighScore);
				PlayerPrefs.SetInt(CURRENT_LEVEL_KEY, CurrentLevel);
				PlayerPrefs.SetInt(DUNK_HIGHSCORE_KEY, DunkHighScore);
				PlayerPrefs.SetInt(CATHOLIC_HIGHSCORE_KEY, CatholicHighScore);
				PlayerPrefs.SetInt(SMASHER_HIGHSCORE_KEY, SmasherHighScore);


				// Currency
				PlayerPrefs.SetInt(NO_ADS_KEY, noAds ? 1 : 0);
				PlayerPrefs.SetInt(COINS_KEY, Coins);
				PlayerPrefs.SetInt(BOLT_KEY, Bolt);
				
				
				// Characters
				PlayerPrefs.SetInt(STARTER_SELECTED, starterScelto);
				PlayerPrefs.SetInt(CURRENT_CHARACTER_KEY, personaggioSelezionato);

				
				// Settings
				PlayerPrefs.SetInt(IS_FIRST_TIME_KEY, isFirstTime ? 1 : 0);
				PlayerPrefs.SetInt(HAS_SELECTED_STARTER, hasSelectedStarter ? 1 : 0);
				PlayerPrefs.SetInt(MUSIC_STATUS_KEY, isMusicOff ? 1 : 0);
				PlayerPrefs.SetInt(SOUND_STATUS_KEY, isSoundOff ? 1 : 0);
				PlayerPrefs.SetInt(CAN_SHOW_FPS_KEY, canShowFPS ? 1 : 0);
				
				
				// Game Version
				PlayerPrefs.SetString(CURRENT_GAME_VERSION_KEY, CurrentGameVersion);
			}
			
			#endregion
			
			
			#region Stats

			// ---------- GAME PLAYED ---------- //
			
			public int getEndlessGamePlayed()
			{
				return EndlessGamePlayed;
			}

			public void addGamePlayed(int num)
			{
				EndlessGamePlayed += num;
				PlayerPrefs.SetInt(ENDLESS_GAME_PLAYED_KEY, EndlessGamePlayed);
				PlayerPrefs.Save();
			}
			
			
			// ---------- LAST SCORE ---------- //

			public int getLastScore()
			{
				return LastScore;
			}

			public void setLastScore(int lastscore)
			{
				LastScore = lastscore;
				PlayerPrefs.SetInt(LAST_SCORE_KEY, LastScore);
				PlayerPrefs.Save();
			}
			
			
			// ---------- HIGHSCORE ---------- //
			
			public int getHighScore()
			{
				return EndlessHighScore;
			}

			public void saveHighScore(int highscoreValue)
			{
				PlayerPrefs.SetInt(ENDLESS_HIGHSCORE_KEY, highscoreValue);
				EndlessHighScore = highscoreValue;
				PlayerPrefs.Save();
			}

			#endregion

			#region Currency

			// ---------- NO ADS ---------- //

			public bool getNoAds()
			{
				return noAds;
			}

			public void setNoAds(bool status)
			{
				noAds = status;
				PlayerPrefs.SetInt(NO_ADS_KEY, status ? 1 : 0);
				PlayerPrefs.Save();
			}


			// ---------- COINS ---------- //

			public int getCoins()
			{
				return Coins;
			}

			public void addCoins(int coins)
			{
				Coins += coins;
				PlayerPrefs.SetInt(COINS_KEY, Coins);
				PlayerPrefs.Save();
			}

			public void removeCoins(int coins)
			{
				Coins -= coins;
				PlayerPrefs.SetInt(COINS_KEY, Coins);
				PlayerPrefs.Save();
			}

			
			// ---------- BOLTS ---------- //
			
			public int getBolts()
			{
				return Bolt;
			}

			public void addBolts(int bolts)
			{
				Bolt += bolts;
				PlayerPrefs.SetInt(BOLT_KEY, Bolt);
				PlayerPrefs.Save();
			}

			public void removeBolts(int bolts)
			{
				Bolt -= bolts;
				PlayerPrefs.SetInt(BOLT_KEY, Bolt);
				PlayerPrefs.Save();
			}

			#endregion

			#region Characters

			public bool isCharacterUnlocked(int index)
			{
				return PlayerPrefs.GetInt(CHARACTERS_UNLOCKED_KEY + index, 0) == 1;
			}

			public void unlockCharacter(int index)
			{
				PlayerPrefs.SetInt(CHARACTERS_UNLOCKED_KEY + index, 1);
				PlayerPrefs.Save();
			}


			public int getSelectedStarter()
			{
				return starterScelto;
			}

			public void setSelectedStarter(int index)
			{
				starterScelto = index;
				PlayerPrefs.SetInt(STARTER_SELECTED, index);
				PlayerPrefs.Save();
			}


			public int getSelectedCharacter()
			{
				return personaggioSelezionato;
			}

			public void setSelectedCharacter(int index)
			{
				personaggioSelezionato = index;
				PlayerPrefs.SetInt(CURRENT_CHARACTER_KEY, index);
				PlayerPrefs.Save();
			}

			#endregion

			#region Settings

			// ---------- IS FIRST TIME ---------- //

			public bool getisFirstTime()
			{
				return isFirstTime;
			}

			public void setisFirstTime(bool value)
			{
				isFirstTime = value;
				PlayerPrefs.SetInt(IS_FIRST_TIME_KEY, value ? 1 : 0);
				PlayerPrefs.Save();
			}

			// ---------- HAS SELECTED STARTER ---------- //

			public bool getHasSelectedStarter()
			{
				return hasSelectedStarter;
			}

			public void setHasSelectedStarter(bool status)
			{
				hasSelectedStarter = status;
				PlayerPrefs.SetInt(HAS_SELECTED_STARTER, status ? 1 : 0);
				PlayerPrefs.Save();
			}

			// ---------- IS MUSIC OFF ---------- //

			public bool isMusicDisabled()
			{
				return PlayerPrefs.GetInt(MUSIC_STATUS_KEY, 1) == 0;
			}
			
			public void setMusicStatus(bool status)
			{
				isMusicOff = status;
				PlayerPrefs.SetInt(MUSIC_STATUS_KEY, isMusicOff ? 1 : 0);
				PlayerPrefs.Save();
			}
			
			// ---------- IS SOUND OFF ---------- //
			
			public bool isSoundDisabled()
			{
				return PlayerPrefs.GetInt(SOUND_STATUS_KEY, 1) == 0;
			}
			
			public void setSoundStatus(bool status)
			{
				isSoundOff = status;
				PlayerPrefs.SetInt(SOUND_STATUS_KEY, isSoundOff ? 1 : 0);
				PlayerPrefs.Save();
			}
			
			
			// ---------- CAN SHOW FPS ---------- //
			#endregion
			
			
			#region Version

			public string getCurrentVersion()
			{
				return CurrentGameVersion;
			}


			public void setCurrentVersion(string version)
			{
				CurrentGameVersion = version;
				PlayerPrefs.SetString(CURRENT_GAME_VERSION_KEY, version);
				PlayerPrefs.Save();
			}
			
			
			#endregion
			
			
		}
	}
}

/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//using BorysProductions.Audio;
using BorysProductions.Data;
using BorysProductions.Personaggi;
using BorysProductions.UI;



namespace BorysProductions
{
	namespace Gameplay {
		public class GameManager : MonoBehaviour
		{

			#region Variabili 

			public static GameManager _instance;

			
			public static ScoreSystem ScoreManager;
			public static UIManager UM;
			public static PlayerData pd;
			public static CharactersManager CM;
			public Player player;


			//-------- GAME SETTINGS --------//
			[Header("Classic Game Config")]
			public Vector3 playerStartPosition;
			public GameObject[] Ostacoli;
			public float spawnTime = 4f;


			//-------- COUNTDOWN SETTINGS --------//
			[Header("CountDown UI")]
			public GameObject CountDownPanel;
			public Text CountDownText;

			[Header("Countdown Settings")]
			public int TimerCountDown = 3;
			public string StartCountdownEndedText = "VIA!";
			public float CountDownDelay = 1f;

			[Space(10f)]

			//-------- CURRENCY STUFF --------//
			[Header("Currency Stuff")]
			public GameObject CoinPrefab;
			public GameObject BoltPrefab;

			[Header("Currency Texts")]
			public GameObject CoinsHolder;
			public GameObject BoltsHolder;
			public Text CoinsText;
			public Text BoltsText;
			public Text MultiplierReporter;

			[Space(5f)]
			public bool allowCreatingCoins;
			public bool allowCreatingBolts;

			[Space(5f)]
			[Range(0f, 1f)]
			public float coinsFrequency = 0.02f;
			[Range(0f, 1f)]
			public float boltsFrequency = 0.2f;

			private GameObject CurrentCoin;
			private GameObject CurrentBolt;


			//-------- GAME STATE --------//
			[HideInInspector]
			public bool isGameStart = false;


			Camera cam;
			Vector3 camPosition, playerPosition;

			//
			private Color OrangeScore = new Color(255, 126, 0);
			private Color RedScore = Color.red;
			#endregion

			#region Metodi Unity

			private void Awake()
			{
				UM = FindObjectOfType<UIManager>();
				ScoreManager = FindObjectOfType<ScoreSystem>();
				pd = FindObjectOfType<PlayerData>();
				CM = FindObjectOfType<CharactersManager>();

				_instance = this;
			}
			void Start()
			{

				cam = Camera.main.GetComponent<Camera>();
				camPosition = cam.transform.position;

				player = FindObjectOfType<Player>();

				if (player)
				{
					playerPosition = player.transform.position;
				}


			}
			void Update()
			{
				if (pd.GameState.Equals(GameStates.GameInProgress) && !pd.GameState.Equals(GameStates.GameOverScreen))
				{
					if (Input.GetMouseButtonDown(0))
					{
						player.OnJump();
					}
				}

				if(player == null)
				{
					try
					{

						FindObjectOfType<Player>();

					}
					catch
					{
						Debug.Log("Player non trovato");
					}
				}

				CoinsText.text = pd.Coins.ToString();
				BoltsText.text = pd.Bolt.ToString();

			}


			#endregion

			#region Altri Metodi Partita
			
			
			public void AddScore()
			{
				ScoreManager.AddScore();
				ScoreManager.ReportScore();

				if(!player.is5X)
				{
					player.MultiplierCounter++;
				}

				if(player.MultiplierCounter == 4)
				{
					player.is2X = true;
					MultiplierReporter.gameObject.SetActive(true);
					MultiplierReporter.text = "x2";
					MultiplierReporter.color = OrangeScore;
				}
				else if(player.MultiplierCounter == 6)
				{
					player.is3X = true;
					player.is2X = false;
					MultiplierReporter.gameObject.SetActive(true);
					MultiplierReporter.text = "x3";
					MultiplierReporter.color = OrangeScore;
				}
                else if (player.MultiplierCounter == 8)
                {
                    player.is4X = true;
                    player.is3X = false;
                    player.is2X = false;
                    MultiplierReporter.gameObject.SetActive(true);
                    MultiplierReporter.text = "x4";
                    MultiplierReporter.color = RedScore;
                }
                else if (player.MultiplierCounter == 10)
                {
                    player.is5X = true;
                    player.is4X = false;
                    player.is3X = false;
                    player.is2X = false;
                    MultiplierReporter.gameObject.SetActive(true);
                    MultiplierReporter.text = "x5";
                    MultiplierReporter.color = RedScore;
                }

				//BorysAudio.PlaySound(player.ObstaclePassingSFX);
			}

			#endregion

			#region Metodi Partita

			public void StartGame()
			{
				StartCountDown();

				player = FindObjectOfType<Player>();

				if (isGameStart)
				{
					return;
				}
				StopCoroutine("SpawnPillar");

				if (player.index != pd.personaggioSelezionato)
				{
					CM.DestroyPlayer();
					CM.SpawnPlayer();
					player = FindObjectOfType<Player>();
				}
			}

			public void Restart()
			{
				StopCoroutine("SpawnPillar");
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

			public void StopGame()
			{
				if (!pd.GameState.Equals(GameStates.GameOverScreen))
				{
					StopCoroutine("SpawnPillar");
					Time.timeScale = 0f;
					ScoreManager.SaveHighScore();
					player.is2X = false;
					player.is3X = false;
                    player.is4X = false;
                    player.is5X = false;
                    
					ShowGameOver();
				}
				pd.GameState = GameStates.GameOverScreen;
			}

			void ShowGameOver()
			{
				UM.ShowGameOver();
			}

			#endregion

			#region Spawner

			IEnumerator SpawnPillar()
			{
				yield return new WaitForSeconds(spawnTime);

				/*
				Transform tr = pool.Spawn(pillarPrefab.transform, Vector3.right * 5f + Vector3.down * Random.Range(1f, 7f), Quaternion.identity);
				Pillar pillar = tr.GetComponent<Pillar>();
				pillar.gameManager = this;
				pillar.ok = false;
				pillar.pool = pool;
				 */

				//GameObject go = Instantiate(Ostacoli[Random.Range(0, Ostacoli.Length)], Vector3.right * 5f + Vector3.down * Random.Range(1f, 7f), Quaternion.identity) as GameObject;
				int rand = Random.Range(0, Ostacoli.Length);
				
				if (rand == 0)
				{
					GameObject go = Instantiate(Ostacoli[0], Vector3.right * 5f + Vector3.down * Random.Range(2, -7), Quaternion.identity) as GameObject;
					Pillar pillar = go.GetComponent<Pillar>();
					pillar.ok = false;

					if (allowCreatingCoins)
					{
						float coinProbability = Random.Range(0f, 1f);
						if (coinProbability <= coinsFrequency)
						{
							CurrentCoin = Instantiate(CoinPrefab, (pillar.transform.position + new Vector3(Random.Range(1, 2), Random.Range(-2, 5), 0)), Quaternion.identity) as GameObject;
						}
					}

					if (allowCreatingBolts)
					{
						float boltsProbability = Random.Range(0f, 1f);
						if (boltsProbability <= boltsFrequency)
						{
							CurrentBolt = Instantiate(BoltPrefab, (pillar.transform.position + new Vector3(Random.Range(1, 2), Random.Range(-2, 5), 0)), Quaternion.identity);
						}
					}

				}
				else if(rand == 1){
					
					GameObject go = Instantiate(Ostacoli[1], Vector3.right * 5f + Vector3.down * Random.Range(-2, -6) , Quaternion.identity) as GameObject;
					Pillar pillar = go.GetComponent<Pillar>();
					pillar.ok = false;

					if (allowCreatingCoins)
					{
						float coinProbability = Random.Range(0f, 1f);
						if (coinProbability <= coinsFrequency)
						{
							CurrentCoin = Instantiate(CoinPrefab, (pillar.transform.position + new Vector3(Random.Range(1f, 2f), Random.Range(-2f, 5f), 0)), Quaternion.identity) as GameObject;
						}
					}

					if (allowCreatingBolts)
					{
						float boltsProbability = Random.Range(0f, 1f);
						if (boltsProbability <= boltsFrequency)
						{
							CurrentBolt = Instantiate(BoltPrefab, (pillar.transform.position + new Vector3(Random.Range(1f, 2f), Random.Range(-2f, 5f), 0)), Quaternion.identity) as GameObject;
						}
					}
				}


				if (pd.GameState.Equals(GameStates.GameInProgress) && !pd.GameState.Equals(GameStates.GameOverScreen))
				{
					StartCoroutine("SpawnPillar");
				}
			}


			#endregion

			#region Metodi CountDown

			public void StartCountDown()
			{
				StartCoroutine(Countdown());
			}

			public virtual void SetCountdownTextStatus(bool status)
			{
				CountDownText.gameObject.SetActive(status);
				CountDownPanel.gameObject.SetActive(status);
			}


			private IEnumerator Countdown()
			{
				pd.GameState = GameStates.LevelStart;
				if (TimerCountDown == 0)
				{
					SetCountdownTextStatus(false);
					pd.GameState = GameStates.GameInProgress;
					yield break;
				}

				SetCountdownTextStatus(true);

				int countdown = TimerCountDown;
				SetCountdownTextStatus(true);
				//BorysAudio.PlayPlaylistSound(1);
				while (countdown > 0)
				{
					SetCountdownText(countdown.ToString());
					countdown--;
					yield return new WaitForSeconds(CountDownDelay);
				}
				if (countdown == 0)
				{
					SetCountdownText(StartCountdownEndedText);
					yield return new WaitForSeconds(CountDownDelay);
				}
				SetCountdownTextStatus(false);

				pd.GameState = GameStates.GameInProgress;
				pd.addGamePlayed(1);
				ScoreManager.ResetScore();
				isGameStart = true;
				player.StartPlayer();
				StartCoroutine("SpawnPillar");
			}

			public virtual void SetCountdownText(string newText)
			{
				CountDownText.text = newText;
			}

			#endregion

		}
	}
}

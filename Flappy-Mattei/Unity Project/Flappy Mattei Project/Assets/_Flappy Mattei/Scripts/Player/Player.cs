/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using UnityEngine.UI;

//using BorysProductions.Audio;
using BorysProductions.Personaggi;
using BorysProductions.Data;
using BorysProductions.Currency;


namespace BorysProductions
{
	namespace Gameplay
	{

		public class Player : MonoBehaviour
		{

			#region Variabili

			GameManager GM;
			ScoreSystem ScoreManager;

			PlayerData pd;

			public static Player instance;

			public float pos = 0f;
			float speed = 0f;
			float direction = 0;

			public bool is2X = false;
			public bool is3X = false;
            public bool is4X = false;
            public bool is5X = false;

			public int MultiplierCounter;


			#endregion

			#region Dati Personaggi
			
			[Header("Info Principali Personaggio")]
			public int index;
			public string Nome;
			
			[Space(10f)]
			
			[Header("Informazioni Generali")]
			public bool Sbloccato;
			public RaritàPersonaggi rarità;
			
			
			[Header("Ostacoli")]
			public GameObject[] Ostacoli;
			
				
			[Header("GFX")]
			public Sprite Skin;
			public SpriteRenderer SkinHolder;
			
			
			#endregion



			#region Metodi Unity

			void Start()
			{
				GM = FindObjectOfType<GameManager>();
				ScoreManager = FindObjectOfType<ScoreSystem>();
				pd = FindObjectOfType<PlayerData>();

				instance = this;

				pos = 0f;
				speed = 0f;
				MultiplierCounter = 0;

				is2X = false;
				is3X = false;
                is4X = false;
                is5X = false;

				GetComponent<Rigidbody2D>().isKinematic = true;

				if (pd.isCharacterUnlocked(index))
				{
					Sbloccato = true;
				}
			}

			void Update()
			{
				if (pd.GameState.Equals(GameStates.GameInProgress))
				{
					UpdateMovement();
				}

				if (transform.position.y < -3.15f)
				{
					transform.eulerAngles = new Vector3(0f, 0f, -55f);
				}
				else
				{
					transform.eulerAngles = new Vector3(0f, 0f, GetComponent<Rigidbody2D>().velocity.y * 2f);
				}
			}

			#endregion


			public void StartPlayer()
			{
				GetComponent<Rigidbody2D>().isKinematic = false;
				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				OnJump();
			}

			void AddSpeed(float delta)
			{
				speed = Mathf.Clamp(speed + delta, -1f, 1f);
			}

			void SetSpeed(float s)
			{
				speed = s;
			}


			public void OnJump()
			{
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;

				if (transform.position.y > 8f)
				{
					return;
				}

				GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
				//BorysAudio.instance.PlaySound(JumpSFX);
			}

			public void OnRight()
			{
				direction = 1;
			}
			public void OnLeft()
			{
				direction = -1;
			}
			public void OnStop()
			{
				direction = 0;
				SetSpeed(0f);
			}

			void UpdateMovement()
			{
				if (direction != 0)
				{
					AddSpeed(direction * 0.005f);
				}

				pos += speed * Time.deltaTime;
			}


			void DeathEffect()
			{
				//BorysAudio.instance.PlaySound(LoseSFX);
			}

			private void OnCollisionEnter2D(Collision2D coll)
			{
				if (coll.gameObject.name == "pillar" || coll.gameObject.CompareTag("Ostacolo") || coll.gameObject.CompareTag("ScreenCollider"))
				{
					Debug.Log("Collision Entered");
					if (!pd.GameState.Equals(GameStates.GameOverScreen))
					{
						DeathEffect();
					}
					ScoreManager.SaveHighScore();
					Debug.Log("GAME OVER!!!!");
					GM.StopGame();
				}
				else if (coll.gameObject.CompareTag("Coin"))
				{
					if (is2X)
					{
						Destroy(coll.gameObject);
						pd.addCoins(2);
					}
					else if (is3X)
					{
						Destroy(coll.gameObject);
						pd.addCoins(3);
					}
                    else if (is4X)
                    {
                        Destroy(coll.gameObject);
                        pd.addCoins(4);
                    }
                    else if (is5X)
                    {
                        Destroy(coll.gameObject);
                        pd.addCoins(5);
                    }
					else
					{
						Destroy(coll.gameObject);
						pd.addCoins(1);
					}
				}
				else if(coll.gameObject.CompareTag("Bolt"))
				{
					if (is2X)
					{
						Destroy(coll.gameObject);
						pd.addBolts(2);
					}
					else if (is3X)
					{
						Destroy(coll.gameObject);
						pd.addBolts(3);
					}
                    else if (is4X)
                    {
                        Destroy(coll.gameObject);
                        pd.addBolts(4);
                    }
                    else if (is5X)
                    {
                        Destroy(coll.gameObject);
                        pd.addBolts(5);
                    }
					else
					{

						Destroy(coll.gameObject);
						pd.addBolts(1);
					}
				}
				else
				{
					OnStop();
					GM.StopGame();
					GetComponent<Rigidbody2D>().isKinematic = true;

				}
			}

		}
	}
}

/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using Random = UnityEngine.Random;


//using BorysProductions.Advertisements;
//using BorysProductions.Audio;
using BorysProductions.Data;
using BorysProductions.Particles;
using BorysProductions.UI;



namespace BorysProductions.Currency
{
	public class ShopController : MonoBehaviour
	{

		#region Variabili

		public static ShopController _instance;

		CoinsManager CM;
		PlayerData player;
		ParticlesManager PM;


		public TMP_Text CoinText;

		public TMP_Text BoltText;

		[Header("Shop Stuff")] public GameObject[] ShopItems;

		public float timeForUnlock = 15;
		public float timeToWait;
		private float currentTimer;
		public bool RandomSystem;
		private bool isUnlockingCharacter = false;

		[Header("Colors")] public Color CellHighlight;
		public Color CellBgColor;
		public Color CellLocked;

		[Header("Buttons")] public GameObject ButtonUnlock_1;
		public GameObject ButtonUnlock_2;
		public GameObject ButtonUnlock_3;
		public GameObject ButtonUnlock_4;



		[Space(10f)] [Header("Images")] public Sprite Locked;
		public Sprite Selected;

		[Header("Characters Index Lists")] [Header("Pagina Comune")]
		public List<int> Unlocked_Comune = new List<int>();

		public List<int> Locked_Comune = new List<int>();

		[Header("Pagina Raro")] public List<int> Unlocked_Raro = new List<int>();
		public List<int> Locked_Raro = new List<int>();

		[Header("Pagina Epico")] public List<int> Unlocked_Epico = new List<int>();
		public List<int> Locked_Epico = new List<int>();

		[Header("Pagina Leggendario")] public List<int> Unlocked_Leggendario = new List<int>();
		public List<int> Locked_Leggendario = new List<int>();

		private int unlockedCounter = 0;
		private int lockedCounter = 0;



		// 
		// STRING PER ACQUISTO IN BASE A RARITA'
		// 
		private const string StrComune = "Comune";

		private const string StrRaro = "Raro";
		private const string StrEpico = "Epico";
		private const string StrLeggendario = "Leggendario";

		#endregion


		// Start is called before the first frame update
		void Start()
		{

			player = FindObjectOfType<PlayerData>();
			_instance = this;
			PM = FindObjectOfType<ParticlesManager>();
			CM = FindObjectOfType<CoinsManager>();

			CheckCharacters();

			CheckButtons();

			SetQtnCurrency();
		}


		private void Update()
		{
			CheckButtons();
		}

		public void SetQtnCurrency()
		{
			CoinText.text = player.Coins.ToString();
			BoltText.text = player.Bolt.ToString();
		}


		#region Check Characters Status

		public void CheckCharacters()
		{
			for (int a = 0; a < 9; a++)
			{
				if (player.isCharacterUnlocked(a))
				{
					Unlocked_Comune.Add(a);
					unlockedCounter++;
				}
				else
				{
					Locked_Comune.Add(a);
					lockedCounter++;
				}
			}

			for (int b = 9; b < 17; b++)
			{
				if (player.isCharacterUnlocked(b))
				{
					Unlocked_Raro.Add(b);
					unlockedCounter++;
				}
				else
				{
					Locked_Raro.Add(b);
					lockedCounter++;
				}
			}

			//
			// CONTROLLO PER L'INDEX 17
			//

			for (int ind = 0; ind < Locked_Raro.Capacity; ind++)
			{
				if (Locked_Raro.Contains(17))
				{

					Locked_Raro.Remove(Locked_Raro.IndexOf(17));
				}
			}


			for (int c = 18; c < 24; c++)
			{
				if (player.isCharacterUnlocked(c))
				{
					Unlocked_Epico.Add(c);
					unlockedCounter++;
				}
				else
				{
					Locked_Epico.Add(c);
					lockedCounter++;
				}
			}





			/*for (int d = 24; d < 29; d++)
			{
				if (player.isCharacterUnlocked(d))
				{
					Unlocked_Leggendario.Add(d);
					unlockedCounter++;
				}
				else
				{
					Locked_Leggendario.Add(d);
					lockedCounter++;
				}
			}*/
		}


		public void CheckButtons()
		{
			if (Locked_Comune.Count == 0)
			{
				ButtonUnlock_1.SetActive(false);
			}

			if (Locked_Raro.Count == 0)
			{
				ButtonUnlock_2.SetActive(false);
			}

			if (Locked_Epico.Count == 0)
			{
				ButtonUnlock_3.SetActive(false);
			}

			/*if (Locked_Leggendario.Count == 0)
			{
				ButtonUnlock_4.SetActive(false);
			}*/
		}

		#endregion


		#region Buy Character Buttons


		/// <summary>
		/// Pulsante sblocco casuale personaggi Pagina Comune
		/// </summary>
		public async void RandomUnlock_Comune()
		{
			if (!isUnlockingCharacter)
			{

				isUnlockingCharacter = true;


				currentTimer = timeForUnlock;
				int UnlockedIndex = 0;

				if (Locked_Comune.Capacity > 0)
				{
					if (player.getBolts() >= 100)
					{

						do
						{
							if (Locked_Comune.Count > 1)
							{
								if (RandomSystem)
								{

									int id = Random.Range(0, Locked_Comune.Count);
									int id2 = Locked_Comune[id];

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellHighlight;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellHighlight;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = Color.white;

									Debug.Log("Changed Obj to Highlight.");

									await Task.Delay(TimeSpan.FromSeconds(timeToWait));

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellLocked;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellBgColor;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = CellLocked;

									Debug.Log("Changed Obj to Default Locked");

									currentTimer--;
									Debug.Log("The current Timer is: " + currentTimer);


									UnlockedIndex = id2;
								}
								else
								{
									for (int i = 0; i < Locked_Comune.Capacity; i++)
									{
										ShopItems[Locked_Comune[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellHighlight;
										ShopItems[Locked_Comune[i]].gameObject.GetComponent<Image>().color =
											CellHighlight;
										ShopItems[Locked_Comune[i]].GetComponent<ShopItem>().Locked_Text.color =
											Color.white;

										Debug.Log("Changed Obj to Highlight");

										await Task.Delay(TimeSpan.FromSeconds(timeToWait));

										ShopItems[Locked_Comune[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellLocked;
										ShopItems[Locked_Comune[i]].gameObject.GetComponent<Image>().color =
											CellBgColor;
										ShopItems[Locked_Comune[i]].GetComponent<ShopItem>().Locked_Text.color =
											CellLocked;

										Debug.Log("Changed Obj to Default Locked");

										currentTimer--;
										Debug.Log("The Current timer is: " + currentTimer);

										if (currentTimer <= 0)
										{
											break;
										}

										UnlockedIndex = Locked_Comune[i];
									}
								}
							}
							else
							{
								currentTimer = 0;
								UnlockedIndex = Locked_Comune[0];
								break;

							}

						} while (currentTimer != 0);


						Debug.Log("Buying Character: " + UnlockedIndex);
						BuyCharacter(StrComune, UnlockedIndex, 100, false);

					}

					else
					{
						Debug.Log("Non hai abbastanza fulmini!");
					}
				}
				else
				{
					Debug.Log("Tutti i personaggi comuni sono stati sbloccati!");
				}
			}
		}




		/// <summary>
		/// Pulsante sblocco casuale personaggi Pagina Raro
		/// </summary>
		public async void RandomUnlock_Raro()
		{
			if (!isUnlockingCharacter)
			{

				isUnlockingCharacter = true;

				currentTimer = timeForUnlock;
				int UnlockedIndex = 0;

				if (Locked_Raro.Capacity > 0)
				{
					if (player.getBolts() >= 500)
					{

						do
						{
							if (Locked_Raro.Count > 1)
							{
								if (RandomSystem)
								{

									int id = Random.Range(0, Locked_Raro.Count);
									int id2 = Locked_Raro[id];

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellHighlight;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellHighlight;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = Color.white;

									Debug.Log("Changed Obj to Highlight.");

									await Task.Delay(TimeSpan.FromSeconds(timeToWait));

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellLocked;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellBgColor;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = CellLocked;

									Debug.Log("Changed Obj to Default Locked");

									currentTimer--;
									Debug.Log("The current Timer is: " + currentTimer);


									UnlockedIndex = id2;
								}
								else
								{
									for (int i = 0; i < Locked_Raro.Capacity; i++)
									{
										ShopItems[Locked_Raro[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellHighlight;
										ShopItems[Locked_Raro[i]].gameObject.GetComponent<Image>().color =
											CellHighlight;
										ShopItems[Locked_Raro[i]].GetComponent<ShopItem>().Locked_Text.color =
											Color.white;

										Debug.Log("Changed Obj to Highlight");

										await Task.Delay(TimeSpan.FromSeconds(timeToWait));

										ShopItems[Locked_Raro[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellLocked;
										ShopItems[Locked_Raro[i]].gameObject.GetComponent<Image>().color = CellBgColor;
										ShopItems[Locked_Raro[i]].GetComponent<ShopItem>().Locked_Text.color =
											CellLocked;

										Debug.Log("Changed Obj to Default Locked");

										currentTimer--;
										Debug.Log("The Current timer is: " + currentTimer);

										if (currentTimer <= 0)
										{
											break;
										}

										UnlockedIndex = Locked_Raro[i];
									}
								}
							}
							else
							{
								currentTimer = 0;
								UnlockedIndex = Locked_Raro[0];
								break;
							}

						} while (currentTimer != 0);


						Debug.Log("Buying Character: " + UnlockedIndex);
						BuyCharacter(StrRaro, UnlockedIndex, 500, false);

					}
					else
					{
						Debug.Log("Non hai abbastanza fulmini!");
					}
				}
				else
				{
					Debug.Log("Tutti i personaggi rari sono stati sbloccati!");
				}
			}
		}


		/// <summary>
		/// Pulsante sblocco casuale personaggi Pagina Epico
		/// </summary>
		public async void RandomUnlock_Epico()
		{
			if (!isUnlockingCharacter)
			{

				isUnlockingCharacter = true;

				currentTimer = timeForUnlock;
				int UnlockedIndex = 0;

				if (Locked_Epico.Capacity > 0)
				{
					if (player.getCoins() >= 250)
					{

						do
						{
							if (Locked_Epico.Count > 1)
							{
								if (RandomSystem)
								{

									int id = Random.Range(0, Locked_Epico.Count);
									int id2 = Locked_Epico[id];

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellHighlight;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellHighlight;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = Color.white;

									Debug.Log("Changed Obj to Highlight.");

									await Task.Delay(TimeSpan.FromSeconds(timeToWait));

									ShopItems[id2].GetComponent<ShopItem>().Locked_Outline.color = CellLocked;
									ShopItems[id2].gameObject.GetComponent<Image>().color = CellBgColor;
									ShopItems[id2].GetComponent<ShopItem>().Locked_Text.color = CellLocked;

									Debug.Log("Changed Obj to Default Locked");

									currentTimer--;
									Debug.Log("The current Timer is: " + currentTimer);


									UnlockedIndex = id2;
								}
								else
								{
									for (int i = 0; i < Locked_Epico.Capacity; i++)
									{
										ShopItems[Locked_Epico[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellHighlight;
										ShopItems[Locked_Epico[i]].gameObject.GetComponent<Image>().color =
											CellHighlight;
										ShopItems[Locked_Epico[i]].GetComponent<ShopItem>().Locked_Text.color =
											Color.white;

										Debug.Log("Changed Obj to Highlight");

										await Task.Delay(TimeSpan.FromSeconds(timeToWait));

										ShopItems[Locked_Epico[i]].GetComponent<ShopItem>().Locked_Outline.color =
											CellLocked;
										ShopItems[Locked_Epico[i]].gameObject.GetComponent<Image>().color = CellBgColor;
										ShopItems[Locked_Epico[i]].GetComponent<ShopItem>().Locked_Text.color =
											CellLocked;

										Debug.Log("Changed Obj to Default Locked");

										currentTimer--;
										Debug.Log("The Current timer is: " + currentTimer);

										if (currentTimer <= 0)
										{
											break;
										}

										UnlockedIndex = Locked_Epico[i];
									}
								}
							}
							else
							{
								currentTimer = 0;
								UnlockedIndex = Locked_Epico[0];
								break;
							}

						} while (currentTimer != 0);


						Debug.Log("Buying Character: " + UnlockedIndex);
						BuyCharacter(StrEpico, UnlockedIndex, 250, true);

					}
					else
					{
						Debug.Log("Non hai abbastanza Monete!");
					}
				}
				else
				{
					Debug.Log("Tutti i personaggi epici sono stati sbloccati!");
				}
			}
		}

		/// <summary>
		/// Pulsante sblocco casuale personaggi Pagina Leggendario
		/// </summary>
		public void RandomUnlock_Leggendari()
		{
			// PULSANTE SBLOCCO CASUALE PERSONAGGI
		}


		#endregion


		private void BuyCharacter(string rarità, int id, int amount, bool isCoins)
		{
			isUnlockingCharacter = false;

			player.unlockCharacter(id);
			player.setSelectedCharacter(id);

			if (rarità.Equals(StrComune))
			{
				Locked_Comune.Remove(id);
				Unlocked_Comune.Add(id);
			}
			else if (rarità.Equals(StrRaro))
			{
				Locked_Raro.Remove(id);
				Unlocked_Raro.Add(id);
			}
			else if (rarità.Equals(StrEpico))
			{
				Locked_Epico.Remove(id);
				Unlocked_Epico.Add(id);
			}
			else if (rarità.Equals(StrLeggendario))
			{
				Locked_Leggendario.Remove(id);
				Unlocked_Leggendario.Add(id);
			}


			if (isCoins)
			{
				CM.RimuoviMonete(amount);
			}
			else
			{
				CM.RimuoviBolts(amount);
			}

			ShopItems[id].GetComponent<ShopItem>().isItemUnlocked = true;
			ShopItems[id].GetComponent<ShopItem>().Selected_Outline.SetActive(true);

			SetQtnCurrency();
		}


		#region Rewarded Buttons

		/// <summary>
		/// Pulsante rewarded Pagina Comune
		/// </summary>
		public void RewardedAdButton_0()
		{
			//BorysAds.ShowGoogleRewarded(false, 100);
		}


		/// <summary>
		/// Pulsante rewarded Pagina Raro
		/// </summary>
		public void RewardedAdButton_1()
		{
			//BorysAds.ShowGoogleRewarded(false, 250);
		}


		/// <summary>
		/// Pulsante rewarded Pagina Epico
		/// </summary>
		public void RewardedAdButton_2()
		{
			//BorysAds.ShowGoogleRewarded(true, 250);
		}


		/// <summary>
		/// Pulsante rewarded Pagina Leggendario
		/// </summary>
		public void RewardedAdButton_3()
		{
			//BorysAds.ShowGoogleRewarded(true, 250);
		}


		#endregion


	}
}


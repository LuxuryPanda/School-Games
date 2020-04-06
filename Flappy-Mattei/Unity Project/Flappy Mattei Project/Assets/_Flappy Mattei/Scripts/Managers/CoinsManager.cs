/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using BorysProductions.Data;


namespace BorysProductions
{
	namespace Currency
	{
		public class CoinsManager : MonoBehaviour
		{


			#region Variabili

			public static CoinsManager _instance;

			PlayerData player;

			#endregion

			#region Metodi Standard

			void Start()
			{
				_instance = this;

				player = FindObjectOfType<PlayerData>();
			}

			#endregion

			#region Metodi Monete

			public void AggiungiMonete(int coins)
			{
				player.addCoins(coins);
				ShopController._instance.CoinText.text = player.Coins.ToString();
			}

			public void RimuoviMonete(int coins)
			{
				player.removeCoins(coins);
				ShopController._instance.CoinText.text = player.Coins.ToString();
			}

			public void AggiungiBolts(int bolts)
			{
				player.addBolts(bolts);
				ShopController._instance.BoltText.text = player.Bolt.ToString();
			}

			public void RimuoviBolts(int bolts)
			{
				player.removeBolts(bolts);
				ShopController._instance.BoltText.text = player.Bolt.ToString();
			}

			#endregion

		}
	}
}

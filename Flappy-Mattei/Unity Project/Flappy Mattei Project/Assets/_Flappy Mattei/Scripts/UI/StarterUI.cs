/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using BorysProductions.Data;
using BorysProductions.Currency;

namespace BorysProductions
{
	namespace UI
	{
		public class StarterUI : MonoBehaviour
		{

			#region Variabili

			UIManager UM;
			PlayerData player;
			ShopController SC;

			[Header("Sprites")]
			public Sprite[] spriteStarters;

			[Header("Images ")]
			public Image Starter1;

			public Image Starter2;

			public Image Starter3;


			public Image RandomStarter;


			int rand1;
			int rand2;
			int rand3;

			#endregion


			// Use this for initialization
			void Start()
			{
				SC = FindObjectOfType<ShopController>();
				UM = FindObjectOfType<UIManager>();
				player = FindObjectOfType<PlayerData>();

				if (player.isFirstTime)
				{
					if (!player.hasSelectedStarter)
					{
						GenerateStarters();
					}
				}
			}

			// Update is called once per frame
			void Update()
			{

			}

			public void GenerateStarters()
			{
				rand1 = Random.Range(0, spriteStarters.Length);

				do
				{
					rand2 = Random.Range(0, spriteStarters.Length);
				} while (rand1 == rand2);

				do
				{
					rand3 = Random.Range(0, spriteStarters.Length);
				} while (rand3 == rand1 || rand3 == rand2 || rand3 == rand2 && rand3 == rand1);

				Starter1.sprite = spriteStarters[rand1];
				Starter2.sprite = spriteStarters[rand2];
				Starter3.sprite = spriteStarters[rand3];
			}

			#region Buttons

			public void SelectStarter1()
			{
				player.unlockCharacter(rand1);
				player.setSelectedCharacter(rand1);
				player.setSelectedStarter(rand1);
				player.setHasSelectedStarter(true);
				player.setisFirstTime(false);
				UM.CloseStarterUI();
			}

			public void SelectStarter2()
			{
				player.unlockCharacter(rand2);
				player.setSelectedCharacter(rand2);
				player.setSelectedStarter(rand2);
				player.setHasSelectedStarter(true);
				player.setisFirstTime(false);
				UM.CloseStarterUI();
			}

			public void SelectStarter3()
			{
				player.unlockCharacter(rand3);
				player.setSelectedCharacter(rand3);
				player.setSelectedStarter(rand3);
				player.setHasSelectedStarter(true);
				player.setisFirstTime(false);
				UM.CloseStarterUI();
			}

			public void SelectRandomStarter()
			{
				int casual = Random.Range(0, spriteStarters.Length);
				player.unlockCharacter(casual);
				player.setSelectedCharacter(casual);
				player.setSelectedStarter(casual);
				player.setHasSelectedStarter(true);
				player.setisFirstTime(false);
				UM.CloseStarterUI();
			}


			#endregion

		}
	}
}

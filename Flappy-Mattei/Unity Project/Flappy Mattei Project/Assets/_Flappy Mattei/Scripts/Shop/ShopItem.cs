/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using BorysProductions.Data;
using BorysProductions.Gameplay;


namespace BorysProductions {
	namespace UI {
		public class ShopItem : MonoBehaviour
		{

			#region Variabili

			PlayerData player;

			[Header("Item Stuff")]
			public int index;

			public GameObject Unlocked_Face;

			public GameObject Unlocked_Outline;

			public Text Locked_Text;

			public Image Locked_Outline;

			public GameObject Selected_Outline;


			public bool isItemUnlocked;

			#endregion

			#region Unity Methods

			private void Start()
			{

				player = PlayerData._instance;

				if(player == null)
				{
					player = FindObjectOfType<PlayerData>();
				}

				InitializeItem();

			}

			private void Update()
			{
				CheckSelected();
			}

			#endregion

			public void InitializeItem()
			{
				if (isUnlocked(index))
				{
					isItemUnlocked = true;

					Unlocked_Face.SetActive(true);
					Unlocked_Outline.SetActive(true);

					Locked_Text.gameObject.SetActive(false);
					Locked_Outline.gameObject.SetActive(false);

					if(player.getSelectedCharacter() == index)
					{
						Selected_Outline.SetActive(true);
						Unlocked_Outline.SetActive(false);
					}
					else
					{
						Selected_Outline.SetActive(false);
						Unlocked_Outline.SetActive(true);
					}
				}
				else
				{
					isItemUnlocked = false;

					Unlocked_Face.SetActive(false);
					Unlocked_Outline.SetActive(false);

					Locked_Text.gameObject.SetActive(true);
					Locked_Outline.gameObject.SetActive(true);

					Selected_Outline.SetActive(false);
				}
			}

			public void OnItemClick()
			{
				if (isUnlocked(index))
				{
					if (player.getSelectedCharacter() != index)
					{
						Selected_Outline.SetActive(true);
						Unlocked_Outline.SetActive(false);
						player.setSelectedCharacter(index);
						return;
					}
					else
					{
						Selected_Outline.SetActive(true);
						Unlocked_Outline.SetActive(false);
						return;
					}
				}
				else
				{
					return;
				}
			}


			public void CheckSelected()
			{
				if (isItemUnlocked || player.isCharacterUnlocked(index))
				{
					isItemUnlocked = true;

					Unlocked_Face.SetActive(true);
					Unlocked_Outline.SetActive(true);

					Locked_Text.gameObject.SetActive(false);
					Locked_Outline.gameObject.SetActive(false);

					if (player.getSelectedCharacter() == index)
					{
						Selected_Outline.SetActive(true);
						Unlocked_Outline.SetActive(false);
						return;
					}
					else
					{
						Selected_Outline.SetActive(false);
						Unlocked_Outline.SetActive(true);
						return;
					}
				}
				else
				{
					Unlocked_Face.SetActive(false);
					Unlocked_Outline.SetActive(false);

					Locked_Outline.gameObject.SetActive(true);
					Locked_Text.gameObject.SetActive(true);
					return;
				}
			}

			public bool isUnlocked(int index)
			{
				return player.isCharacterUnlocked(index);
			}
		}
	}
}

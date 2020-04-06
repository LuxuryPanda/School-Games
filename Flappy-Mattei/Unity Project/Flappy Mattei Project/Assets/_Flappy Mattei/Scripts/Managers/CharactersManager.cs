/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;


using BorysProductions.Data;
using BorysProductions.Gameplay;

namespace BorysProductions
{
	namespace Personaggi
	{
		public class CharactersManager : MonoBehaviour
		{

			#region Variabili

			public static CharactersManager _instance;

			public static readonly string KEY_PERSONAGGIO_SELEZIONATO = "PPF_Selected_Character";

			PlayerData player;
			///GameObject currentCharacter;

			[Header("Lista e Spawn Personaggi")]
			public Vector3 playerStartPosition = new Vector3(-2f, 1.5f, 0);

			public GameObject[] ListaPersonaggi;

			#endregion

			void Awake()
			{
				if (_instance)
				{
					DestroyImmediate(gameObject);
				}
				else
				{
					_instance = this;
					DontDestroyOnLoad(gameObject);
				}
			}

			private void Start()
			{
				player = FindObjectOfType<PlayerData>();

                playerStartPosition = GameManager._instance.playerStartPosition;
			}

			public int IndexPersonaggioAttuale
			{
				get
				{
					return PlayerPrefs.GetInt(KEY_PERSONAGGIO_SELEZIONATO, 0);
				}
				set
				{
					PlayerPrefs.SetInt(KEY_PERSONAGGIO_SELEZIONATO, value);
					PlayerPrefs.Save();
				}
			}


			public void SpawnPlayer()
			{
				GameObject currentCharacter = Instantiate(ListaPersonaggi[player.personaggioSelezionato], playerStartPosition, Quaternion.identity) as GameObject;
				if(currentCharacter != null)
				{
					Debug.Log("Player Spawned");
				}
				else
				{
					Debug.Log("Player not spawned");
				}
				//currentCharacter.transform.position = playerStartPosition;
			}

			public void DestroyPlayer()
			{

				GameObject currentCharacter = FindObjectOfType<Player>().gameObject;
				Destroy(currentCharacter);
				Debug.Log("Player GameObject Destroyed");
			}

		}
	}
}

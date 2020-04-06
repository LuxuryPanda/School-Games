/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//using BorysProductions.DailyReward;


namespace BorysProductions
{
	namespace Core
	{
		public class AppInfoManager : MonoBehaviour
		{

			public static AppInfoManager _instance;
			

			#region Variables
			
			public int TargetFrameRate = 60;

			[Header("Elimina i PlayerPrefs all'avvio dell'app. *UTILIZZARE SOLO IN DEBUG*")]
			public bool rimuoviPlayerPrefs = false;

			#endregion

			#region Standard Methods

			void Awake()
			{
				Application.targetFrameRate = TargetFrameRate;


#if UNITY_EDITOR
				if (rimuoviPlayerPrefs)
				{
					PlayerPrefs.DeleteAll();
					Debug.Log("\n\n\n");
					Debug.Log("***********************************");
					Debug.Log("ATTENZIONE: PlayerPrefs cancellati!!");
					Debug.Log("***********************************");
					Debug.Log("\n\n\n");
				}
#endif
			}
			

			protected void OnApplicationQuit()
			{
				PlayerPrefs.Save();
			}
			
			#endregion

		}
	}
}

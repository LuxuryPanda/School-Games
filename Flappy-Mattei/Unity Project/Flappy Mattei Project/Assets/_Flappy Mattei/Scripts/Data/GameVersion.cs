/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System;
using UnityEngine;



namespace BorysProductions
{
    namespace Data
    {
        public class GameVersion : MonoBehaviour
        {
            public static GameVersion instance;

            private PlayerData player;

            public int Major;

            public int Build;

            public int Patch;

            public string BuildName;

            private string currentVersion;


			public static string CURRENT_GAME_VERSION_KEY = "PPF_Game_Version";


			public bool isNewVer;


			void Awake()
            {
                buildStringVersion();
            }


			#region Metodi Versione


			void buildStringVersion()
            {
                currentVersion = BuildName + " " + Major + "." + Build + "." + Patch;
            }

			public string buildNumericCurrentVersion()
			{
				return "" + Major + "." + Build + "." + Patch;
			}
            
            public string projectVersionToString()
            {
                return currentVersion;
            }
			
			#endregion

		}
    }
}

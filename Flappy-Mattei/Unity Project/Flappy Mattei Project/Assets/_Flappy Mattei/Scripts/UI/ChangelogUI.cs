/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using BorysProductions.Data;


namespace BorysProductions {
	namespace UI {
		public class ChangelogUI : MonoBehaviour
		{

			#region	Variabili

			public static GameVersion GV;

			[Header("Text Stuff")]
			public TMP_Text TitleText;
			public TMP_Text DescriptionText;

			[Header("Changelog")]
			[TextArea]
			public string Changelog;

			#endregion

			private void Awake()
			{

			}

			// Start is called before the first frame update
			void Start()
			{
				GV = FindObjectOfType<GameVersion>();
				InitializeChangelog();
			}


			public void InitializeChangelog()
			{
				TitleText.text = "Changelog v" + GV.buildNumericCurrentVersion();

				DescriptionText.text = Changelog;
			}
		}
	}
}

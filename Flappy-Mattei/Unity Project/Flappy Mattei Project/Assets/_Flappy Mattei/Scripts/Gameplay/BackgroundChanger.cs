/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BorysProductions
{
	namespace Gameplay
	{
		public class BackgroundChanger : MonoBehaviour
		{
			public static BackgroundChanger instance;

			
			[Header("Background Settings")] 
			public Material[] backgroundMaterials;
			[Space(10)]
			public SpriteRenderer backgroundRender;

			private void Start()
			{
				InitializeBackgrounds();
			}
			
			/// <summary>
			/// 
			/// Metodo che imposta il background in modo random
			///
			/// TODO: Aumentare la probabilità di estrazione di Backgorund non usato.
			/// 
			/// </summary>
			public void InitializeBackgrounds()
			{
				backgroundRender.material = backgroundMaterials[Random.Range(0, backgroundMaterials.Length)];
			}
		}
	}
}

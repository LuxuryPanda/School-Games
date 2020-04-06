/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;
using BorysProductions;


namespace BorysProductions
{
	namespace UI
	{
		public class GameOverUI : MonoBehaviour
		{
			public UIManager UM;

			private void Start()
			{
				UM = FindObjectOfType<UIManager>();
			}

			private void OnEnable()
			{
				UM.GameOverText.text = UM.FrasiGameOver[Random.Range(0, UM.FrasiGameOver.Length)];
			}
		}
	}
}

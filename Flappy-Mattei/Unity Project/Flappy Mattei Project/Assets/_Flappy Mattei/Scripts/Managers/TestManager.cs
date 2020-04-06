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
	namespace Test
	{
		public class TestManager : MonoBehaviour
		{

			PlayerData player;

			// Start is called before the first frame update
			void Start()
			{
				player = FindObjectOfType<PlayerData>();
			}

			// Update is called once per frame
			void Update()
			{

			}

			public void Button1()
			{
				Debug.Log("PULSANTE 1 DI PAGINA 1 FUNZIONA!!");
			}

			public void Button2()
			{
				Debug.Log("PULSANTE 2 DI PAGINA 1 FUNZIONA!!");
			}

			public void Button3()
			{
				Debug.Log("PULSANTE 1 DI PAGINA 2 FUNZIONA!!");
			}

			public void Button4()
			{
				Debug.Log("PULSANTE 2 DI PAGINA 2 FUNZIONA!!");
			}

			public void Button5()
			{
				Debug.Log("PULSANTE 1 DI PAGINA 3 FUNZIONA!!");
			}

			public void Button6()
			{
				Debug.Log("PULSANTE 2 DI PAGINA 3 FUNZIONA!!");
			}

			public void Button7()
			{
				Debug.Log("PULSANTE 1 DI PAGINA 4 FUNZIONA!!");
			}

			public void Button8()
			{
				Debug.Log("PULSANTE 2 DI PAGINA 4 FUNZIONA!!");
			}


			public void AddBolts()
			{
				player.addBolts(100);
			}

			public void AddCoins()
			{
				player.addCoins(100);
			}

		}
	}
}

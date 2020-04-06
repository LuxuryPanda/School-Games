/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;

using BorysProductions.Data;

namespace BorysProductions
{
	namespace Gameplay
	{
		public class Pillar : MonoBehaviour
		{

			#region Variabili

			GameManager GM;
			PlayerData PD;
			public float speed = 2f;
			public bool ok = false;

			#endregion


			void Start()
			{
				GM = FindObjectOfType<GameManager>();
				PD = FindObjectOfType <PlayerData>();
			}

			void SetOk()
			{
				ok = true;
				GM.AddScore();
			}

			void Update()
			{
				if (PD.GameState.Equals(GameStates.GameOverScreen))
				{
					return;
				}
				Vector3 pos = transform.position;
				if (!ok && pos.x < -3f) SetOk();
				if (pos.x < -5f)
				{
					Destroy(gameObject);
				}

				//transform.position = Vector3.MoveTowards(transform.position, transform.position + 5f * Vector3.left, step);
				//float step = speed * Time.deltaTime;

				transform.position += Vector3.left * Time.deltaTime * speed;
			}
		}
	}
}

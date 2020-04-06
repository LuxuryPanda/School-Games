/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;


namespace BorysProductions
{
	namespace Gameplay {
		public class Scroll : MonoBehaviour
		{
			public float speed;
			Player player;

			void Start()
			{
				player = FindObjectOfType<Player>();
			}

			void Update()
			{
				float dist = player.pos * speed;

				if (player.pos < -2.3f)
				{
					dist += 10f;
                    player.pos = -2.3f;
				}

				//dist -= ((int)dist / 32) * 32;

				Vector3 pos = transform.position;
				transform.position = new Vector3(dist * -1, pos.y, pos.z);

				if (player == null)
				{
					try
					{

						player = FindObjectOfType<Player>();

					}
					catch
					{
						Debug.Log("Player non trovato");
					}
				}
			}
		}
	}
}
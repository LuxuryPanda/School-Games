/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;

namespace BorysProductions
{
	namespace Gameplay
	{
		public class Column : MonoBehaviour
		{
			private void OnTriggerEnter2D(Collider2D other)
			{
				if (other.tag.Equals("Player"))
				{
					return;
					/// GAME OVER
				}

			}
		}
	}
}

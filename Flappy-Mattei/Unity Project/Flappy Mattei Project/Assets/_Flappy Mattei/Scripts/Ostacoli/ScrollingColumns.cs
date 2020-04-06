/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;

namespace BorysProductions
{
	namespace Gameplay{
		public class ScrollingColumns : MonoBehaviour
		{
			private Rigidbody2D rb2d;
			private float verticalSpeed;

			private void Start()
			{
				if (Random.Range(1, 101) <= 50)
				{
					this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
				}
				else
				{
					this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
					this.verticalSpeed = 0.0f;
				}
				this.rb2d = this.GetComponent<Rigidbody2D>();
				this.rb2d.velocity = new Vector2(2.2f, 1.5f);
			}

			private void Update()
			{
				/*if (GameManager._instance.statoAttuale == GameManager.GameState.gameover)
				{
					this.rb2d.velocity = Vector2.zero;
				}
				else if (GameManager._instance.statoAttuale == GameManager.GameState.ingame)
				{
					if ((double)this.gameObject.transform.position.y <= -2.0 || (double)this.gameObject.transform.position.y >= 2.0)
						this.verticalSpeed = -this.verticalSpeed;
					this.rb2d.velocity = new Vector2(1.5f, 1.5f);
				}
				else
					this.rb2d.velocity = Vector2.zero;*/
			}
		}
	}
}

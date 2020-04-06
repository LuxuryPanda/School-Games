/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;

namespace BorysProductions
{
	public class ScrollingMovingColumns : MonoBehaviour
	{
		public static ScrollingMovingColumns _instance;
		public Rigidbody2D rb2d;
		private float verticalSpeed;
		public bool GameOver, Started;
		public float ScrollSpeed = -3f;

		private void Start()
		{
			if (Random.Range(1, 50) % 2 == 0)
			{
				this.verticalSpeed = Random.Range(1f, 2.7f);
			}
			else
			{
				this.verticalSpeed = Random.Range(-2.7f, -1f);
			}
			this.rb2d = base.GetComponent<Rigidbody2D>();
			if (Started && Random.Range(1, 101) >= 25)
			{
				this.rb2d.velocity = new Vector2(ScrollSpeed, this.verticalSpeed);
			}
		}

		private void Update()
		{
			if (GameOver)
			{
				this.rb2d.velocity = Vector2.zero;
			}
			else
			{
				/*if (ScrollSpeed <= -4.1f)
				{
					if (base.gameObject.transform.position.x >= 5f && base.gameObject.transform.position.x <= 6f)
					{
						base.gameObject.transform.GetChild(1).gameObject.SetActive(true);
					}
				}
				else
				{
					//base.gameObject.transform.GetChild(1).gameObject.SetActive(false);
				}*/
				if (Started)
				{
					if (base.gameObject.transform.position.y <= -3.70f || base.gameObject.transform.position.y >= 5.70f)
					{
						this.verticalSpeed = -this.verticalSpeed;
					}
					this.rb2d.velocity = new Vector2(ScrollSpeed, this.verticalSpeed);
				}
				else
				{
					this.rb2d.velocity = Vector2.zero;
				}
			}
		}
	}
}

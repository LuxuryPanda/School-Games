/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using UnityEngine.UI;


using BorysProductions.Data;

namespace BorysProductions
{
	namespace Currency
	{
		public class CoinsAndGems : MonoBehaviour
		{

			#region Variabili

			PlayerData player;

			private Transform object_transform;

			private Rigidbody2D object_rb;

			private Transform magnetTrans;


			private bool isMagnetOn;

			private bool settedMagnedOn;


			[Header("Coin or Bolt Settings")]

			public bool isCoin = false;

			public bool isBolt = false;

			public float scrollSpeed = 3.5f;

			/*
			public float magnetStrength = 5f;

			public int magnetDir = 1;

			public bool looseMagnet = true;

			public float distanceStretch = 10f;*/

			#endregion

			#region Metodi Unity

			void Start()
			{
				
			}


			void Update()
			{
				Vector3 pos = transform.position;

				if (pos.x < -4.5f)
				{
					Destroy(gameObject);
				}

				transform.position += Vector3.left * Time.deltaTime * scrollSpeed;
			}


			#endregion


		}
	}
}

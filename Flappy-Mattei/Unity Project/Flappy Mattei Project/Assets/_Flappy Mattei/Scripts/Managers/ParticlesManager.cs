/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BorysProductions
{
	namespace Particles
	{
		public class ParticlesManager : MonoBehaviour
		{

			public static ParticlesManager instance;

			#region Variabili

			[Header("General FX")]
			public GameObject explosionUnlock;


			[Header("Level Mode FX")]
			public GameObject confettiRain;
			public GameObject lateralConfettiExplosionLeft;
			public GameObject lateralConfettiExplosionRight;


			[Header("Reward FX")]
			public GameObject ChestFX;
			public GameObject rewardExplosion;

			#endregion


			void Start()
			{
				instance = this;
			}


			#region Spawn Particles

			public void SpawnUnlockFX(Vector3 position)
			{
				GameObject Explosion = Instantiate(explosionUnlock, position, Quaternion.identity) as GameObject;
				Destroy(Explosion, 4f);
			}

			#endregion


		}
	}
}

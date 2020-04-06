/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;

namespace BorysProductions.Network
{
	public class InternetChecker : MonoBehaviour
	{

		#region Variabili

		private const bool allowCarrierDataNetwork = false;
		private const string pingAddress = "8.8.8.8";
		public const float waitingTime = 5.0f;

		public bool isConnected;
		private Ping ping;
		private float pingStartTime;

		public delegate void InternetChecked(bool InternetAvailable);

		public static event InternetChecked hasInternet;

		public static InternetChecker _instance;

		#endregion

		#region Unity Methods
		
		private void Start()
		{
			_instance = new InternetChecker();
			if (_instance != null)
			{
				GameObject.Destroy(_instance);
			}
			else
			{
				_instance = this;
			}
		}

		public void Update()
		{
			if (ping == null) return;
			
			var stopCheck = true;
			if (ping.isDone)
				InternetAvailable();
			else if (Time.time - pingStartTime < waitingTime)
				stopCheck = false;
			else
				InternetIsNotAvailable();
			if (stopCheck)
				ping = null;
		}

		#endregion

		#region Check Methods
		
		
		public void StartInternetCheck()
		{
			bool internetPossiblyAvailable;
			switch (Application.internetReachability)
			{
				case NetworkReachability.ReachableViaLocalAreaNetwork:
					internetPossiblyAvailable = true;
					break;
				case NetworkReachability.ReachableViaCarrierDataNetwork:
					internetPossiblyAvailable = true;
					break;
				default:
					internetPossiblyAvailable = false;
					break;
			}

			if (!internetPossiblyAvailable)
			{
				InternetIsNotAvailable();
				return;
			}

			ping = new Ping(pingAddress);
			pingStartTime = Time.time;
		}

		

		public void InternetIsNotAvailable()
		{
			hasInternet?.Invoke(false);

			isConnected = false;
		}

		public void InternetAvailable()
		{
			hasInternet?.Invoke(true);

			isConnected = true;
		}

		#endregion
	}
}
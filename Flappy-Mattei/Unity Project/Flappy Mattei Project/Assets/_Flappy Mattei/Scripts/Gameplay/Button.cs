/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;


namespace BorysProductions
{
	public class Button : MonoBehaviour
	{
		public GameObject target;
		public string downMessage = "OnClickDown";
		public string upMessage = "OnClickUp";

		void OnMouseDown()
		{
			if (target && downMessage.Length > 0) target.SendMessage(downMessage, SendMessageOptions.DontRequireReceiver);
		}
		void OnMouseUp()
		{
			if (target && upMessage.Length > 0) target.SendMessage(upMessage, SendMessageOptions.DontRequireReceiver);
		}

	}
}

/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using SA.CrossPlatform.Advertisement;

public class GDPRManager : MonoBehaviour
{

	#region Variabili

	public static GDPRManager _instance;

	[Header("Panel")]
	public GameObject GDPR_Panel;

	[Header("Sprites")]
	public Sprite Checkbox_On;
	public Sprite Checkbox_Off;

	[Header("Pulsanti")]
	public Button buttonAccept;
	public Button buttonOk;

	[Header("Testi")]
	public Text TitleText;
	public Text TopText;
	public Text BottomText;

	private bool wasAccepted;

	private static Color colorAccepted = new Color(0.368627459f, 0.5294118f, 0.396078438f, 1f);
	private static Color colorNotAccepted = new Color(0.9529412f, 0.7921569f, 0.321568638f, 1f);



	#endregion

	#region Metodi

	private void Start()
	{
		GDPR_Panel.SetActive(false);
	}

	private void Update()
	{
		
	}

	public static GDPRManager getInstance()
	{
		if (GDPRManager._instance == null)
		{
			GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				if (rootGameObjects[i].GetComponent<GDPRManager>() != null)
				{
					rootGameObjects[i].name = "[PizzaKitUI]";
					Object.DontDestroyOnLoad(rootGameObjects[i]);
					GDPRManager._instance = rootGameObjects[i].GetComponent<GDPRManager>();
					GDPRManager._instance.buttonAccept.onClick.AddListener(new UnityAction(GDPRManager._instance.ClickAccept));
					GDPRManager._instance.buttonOk.onClick.AddListener(new UnityAction(GDPRManager._instance.ClickOk));
					GDPRManager._instance.BottomText.GetComponent<Button>().onClick.AddListener(new UnityAction(GDPRManager._instance.ClickTerms));
					break;
				}
			}
		}
		return GDPRManager._instance;
	}

	public void ShowPopup()
	{
		GDPR_Panel.SetActive(true);
	}


	public void ClickAccept()
	{

		this.wasAccepted = !this.wasAccepted;
		this.Refresh();

	}

	public void ClickOk()
	{
		///var settins = UM_GoogleAdsSettings.Instance;

		if (wasAccepted)
		{

			//settins.NPA = false;
		}
		else
		{
			//settins.NPA = true;
		}
		base.gameObject.SetActive(false);
	}


	public void ClickTerms()
	{
		Debug.Log("---------- TEST GDPR KIT ----------");
		//Application.OpenURL(SayKit.getLocalizedString(SayKitUI.gdpr_privacy_url, null, null, null, null, null));
	}

	private void Refresh()
	{
		this.buttonOk.interactable = this.wasAccepted;
		this.buttonAccept.GetComponentsInChildren<Image>()[1].sprite = (this.wasAccepted ? this.Checkbox_On : this.Checkbox_Off);
		this.buttonAccept.GetComponentsInChildren<Image>()[0].color = (this.wasAccepted ? colorAccepted : colorNotAccepted);
	}


	private void ShowPopupInternal()
	{
		base.gameObject.SetActive(true);
		this.wasAccepted = false;
		//this.textTitle.text = SayKit.getLocalizedString(SayKitUI.gdpr_popup_title, null, null, null, null, null);
		//this.textTop.text = SayKit.getLocalizedString(SayKitUI.gdpr_popup_text_top, null, null, null, null, null);
		//this.textBottom.text = SayKit.getLocalizedString(SayKitUI.gdpr_popup_text_bottom, null, null, null, null, null);
		//this.buttonOk.GetComponentInChildren<Text>().text = SayKit.getLocalizedString(SayKitUI.gdpr_popup_button_ok, null, null, null, null, null);
		//this.buttonAccept.GetComponentInChildren<Text>().text = SayKit.getLocalizedString(SayKitUI.gdpr_popup_button_accept, null, null, null, null, null);
		this.Refresh();
	}

	#endregion



}

/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoaderManager : MonoBehaviour
{

    [Header("Objects")]
    public Slider slider;

	[Header("Impostazioni")]
	public int sceneToLoad;

	bool isFirstTime;

	// Start is called before the first frame update
	void Start()
	{
		isFirstTime = PlayerPrefs.GetInt("PPF_is_First_Time") == 1;

		if (isFirstTime)
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("First time PPF removed");
		}

		LoadScene();
	}

	public void LoadScene()
	{
		StartCoroutine(SceneLoader(sceneToLoad));
	}

	IEnumerator SceneLoader(int indexScene)
	{

		AsyncOperation operation = SceneManager.LoadSceneAsync(indexScene);

		while (!operation.isDone)
		{

            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
			yield return 0;
		}


	}
}

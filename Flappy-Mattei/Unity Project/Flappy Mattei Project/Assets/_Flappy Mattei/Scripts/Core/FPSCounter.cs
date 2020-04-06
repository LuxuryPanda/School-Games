/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;


namespace BorysProductions
{
    namespace Core
    {
        public class FPSCounter : MonoBehaviour
        {
            public TMP_Text fpsText;

            public float frequency = 0.5f;

            public int nbDecimal = 1;

            private float accum;

            private int frames;

            private Color color = Color.white;

            public bool canShowFPS;


            private void Start()
            {

                if (PlayerPrefs.HasKey("canShowFPS"))
                {
                    canShowFPS = PlayerPrefs.GetInt("canShowFPS", 0) == 1;
                }
                else
                {
                    canShowFPS = false;
                }
               
                
                if (canShowFPS)
                {
					
                    StartCoroutine(FPS());
                }
                else
                {
                    StopCoroutine(FPS());
                }
            }

            private void Update()
            {
				showText();
				accum += Time.timeScale / Time.deltaTime;
				frames++;
            }

            public IEnumerator FPS()
            {
                while (canShowFPS)
                {
                    float fps = accum / (float) frames;
                    fpsText.text = fps.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10));
                    fpsText.color = ((fps >= 30f) ? Color.green : ((!(fps > 10f)) ? Color.red : Color.yellow));
                    accum = 0f;
                    frames = 0;
                    yield return new WaitForSeconds(frequency);
                }
            }

            void showText()
            {
                if (canShowFPS)
                {
                    fpsText.gameObject.SetActive(true);
                }
                else
                {
                    fpsText.gameObject.SetActive(false);
                }
            }
        }
    }
}
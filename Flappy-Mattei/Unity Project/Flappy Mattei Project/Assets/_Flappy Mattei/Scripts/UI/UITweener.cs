/***************************************************************************\
Project:      Flappy Mattei
Copyright (c) BorysProductions
Author:       Roman
\***************************************************************************/

using UnityEngine;

using DG.Tweening;

namespace BorysProductions.UI
{

    public enum UIAnimationTypes
    {
        Move,
        MoveX,
        MoveY,
        MoveZ,
        Scale,
        ScaleX,
        ScaleY,
        ScaleZ,
        Fade
    }
    
    
    [AddComponentMenu("FlappyMattei/" + "UITweener")]
    public class UITweener : MonoBehaviour
    {
        
        
        #region Tween Type
        
        
        [Header("Tween Settings")]
        [Tooltip("L'Object To Tween può rimanere vuoto nel caso in cui si volesse animare l'oggetto su" +
                 "cui lo script è attaccato")]
        public GameObject objToTween;
        [Space(15f)]
        
        
        
        [Header("Tween Type")] 
        public UIAnimationTypes animationType = UIAnimationTypes.Move;
        
        public Ease easeType;
        
        
        [Space(10f)]
        [Header("Tween Settings")] 
        public bool showOnEnable;
        public bool hideOnDisable;

        
        #endregion
        
        
        #region Twen Position
        
        [Header("Tween Position")] 
        public bool startPositionOffset;
        
        [Space(5f)]
        public Vector3 tweenFrom;
        
        [Space(5f)]
        public Vector3 tweenTo;
        
        
        #endregion

        
        
        #region Time Settings
        
        [Header("Time Settings")]
        public float showDuration;
        
        public float showDelay;
        
        [Space(10f)]
        public float hideDuration;
        
        public float hideDelay;
        
        
        #endregion
        
        
        
        private bool isShowing;
        private bool isHiding;
        

        
        #region Unity Methods

        
        public void OnEnable()
        {
            if (showOnEnable)
            {
                if (!isHiding)
                {
                    Show();
                }
            }
        }


        public void OnDisable()
        {
            if (hideOnDisable)
            {
                Hide();
            }
        }


        #endregion
        
        
        #region Visibility Methods
        
        
        private void Show()
        {
            if (!gameObject.activeInHierarchy)
            {
                isShowing = true;
                isHiding = false;
                HandleTween();
            }
        }
        

        private void Hide()
        {
            if (gameObject.activeInHierarchy)
            {
                isHiding = true;
                isShowing = false;
                //ChangeDirections();

                HandleTween();
            }
        }

        
        private void EndTweening()
        {
            if (isHiding)
            {
                gameObject.SetActive(false);
                //ChangeDirections();
            }
            
            isShowing = false;
            isHiding = false;
            Debug.Log("[UITweener] - Tween Ended!!");
        }
        
        
        #endregion
        

        public void HandleTween()
        {
            if (objToTween == null)
            {
                objToTween = gameObject;
            }

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }

            switch (animationType)
            {
                case UIAnimationTypes.Fade:
                    Fade();
                    break;
                case UIAnimationTypes.Move:
                    MoveAbsolute();
                    break;
                case UIAnimationTypes.MoveX:
                    MoveX();
                    break;
                case UIAnimationTypes.MoveY:
                    MoveY();
                    break;
                case UIAnimationTypes.MoveZ:
                    MoveZ();
                    break;
                case UIAnimationTypes.Scale:
                    Scale();
                    break;
                case UIAnimationTypes.ScaleX:
                    ScaleX();
                    break;
                case UIAnimationTypes.ScaleY:
                    ScaleY();
                    break;
                case UIAnimationTypes.ScaleZ:
                    ScaleZ();
                    break;
            }
        }


        public void Fade()
        {
            objToTween = gameObject;
            
            if(objToTween.GetComponent<CanvasGroup>() == null)
            {
                objToTween.AddComponent<CanvasGroup>();
            }

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }


            if (startPositionOffset && isShowing)
            {
                objToTween.GetComponent<CanvasGroup>().alpha = tweenFrom.x;
            }

            if (isShowing)
            {
                objToTween.GetComponent<CanvasGroup>().DOFade(tweenTo.x, showDuration).SetDelay(showDelay).OnComplete(EndTweening);
            }
            else if (isHiding)
            {
                objToTween.GetComponent<CanvasGroup>().DOFade(tweenFrom.x, hideDuration).SetDelay(hideDelay).OnComplete(EndTweening);
            }
        }

        
        #region Move

        public void MoveAbsolute()
        {
            if(startPositionOffset && isShowing)
                objToTween.GetComponent<RectTransform>().anchoredPosition = tweenFrom;

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }


            if (isShowing)
            {
                objToTween.transform.DOLocalMove(tweenTo, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);;
            }
            else if (isHiding)
            {
                objToTween.transform.DOLocalMove(tweenFrom, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);;
            }
        }
        
        
        public void MoveX()
        {
            if(startPositionOffset && isShowing)
                objToTween.GetComponent<RectTransform>().anchoredPosition = tweenFrom;

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }


            if (isShowing)
            {
                objToTween.transform.DOLocalMoveX(tweenTo.x, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);;
            }
            else if (isHiding)
            {
                objToTween.transform.DOLocalMoveX(tweenFrom.x, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);;
            }
        }


        public void MoveY()
        {
            if(startPositionOffset && isShowing)
                objToTween.GetComponent<RectTransform>().anchoredPosition = tweenFrom;

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }


            if (isShowing)
            {
                objToTween.transform.DOLocalMoveY(tweenTo.y, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);;
            }
            else if (isHiding)
            {
                objToTween.transform.DOLocalMoveY(tweenFrom.y, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);;
            }
        }


        public void MoveZ()
        {
            if(startPositionOffset && isShowing)
                objToTween.GetComponent<RectTransform>().anchoredPosition = tweenFrom;

            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }


            if (isShowing)
            {
                objToTween.transform.DOLocalMoveZ(tweenTo.z, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);;
            }
            else if (isHiding)
            {
                objToTween.transform.DOLocalMoveZ(tweenFrom.z, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);;
            }
        }
        
        
        #endregion
        
        #region Scale

        public void Scale()
        {
            if (startPositionOffset && isShowing)
            {
                objToTween.GetComponent<RectTransform>().localScale = tweenFrom;
            }


            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }

            

            if (isShowing)
            {
                objToTween.transform.DOScale(tweenTo, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);
            }
            else if (isHiding)
            {
                objToTween.transform.DOScale(tweenFrom, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);
            }
        }

        
        public void ScaleX()
        {
            if (startPositionOffset && isShowing)
            {
                objToTween.GetComponent<RectTransform>().localScale = tweenFrom;
            }


            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }

            

            if (isShowing)
            {
                objToTween.transform.DOScaleX(tweenTo.x, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);
            }
            else if (isHiding)
            {
                objToTween.transform.DOScaleX(tweenFrom.x, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);
            }
        }


        public void ScaleY()
        {
            if (startPositionOffset && isShowing)
            {
                objToTween.GetComponent<RectTransform>().localScale = tweenFrom;
            }


            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }

            

            if (isShowing)
            {
                objToTween.transform.DOScaleY(tweenTo.y, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);
            }
            else if (isHiding)
            {
                objToTween.transform.DOScaleY(tweenFrom.y, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);
            }
        }


        public void ScaleZ()
        {
            if (startPositionOffset && isShowing)
            {
                objToTween.GetComponent<RectTransform>().localScale = tweenFrom;
            }


            if (isShowing && !objToTween.activeInHierarchy)
            {
                objToTween.SetActive(true);
            }

            

            if (isShowing)
            {
                objToTween.transform.DOScaleZ(tweenTo.z, showDuration).SetEase(easeType).SetDelay(showDelay).OnComplete(EndTweening);
            }
            else if (isHiding)
            {
                objToTween.transform.DOScaleZ(tweenFrom.z, hideDuration).SetEase(easeType).SetDelay(hideDelay).OnComplete(EndTweening);
            }
        }
        
        #endregion
        
        
        
        #region Utils
        
        void ChangeDirections()
        {
            var temp = tweenFrom;
            tweenFrom = tweenTo;
            tweenTo = temp;
        }
        
        #endregion
        
    }
}

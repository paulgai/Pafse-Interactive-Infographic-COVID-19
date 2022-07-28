using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Content : MonoBehaviour
{
    public GameObject[] starts = new GameObject[2];
    public GameObject ButtonText;
    public GameObject RestartButton;

    private void OnEnable()
    {
        GetComponent<RectTransform>().transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        this.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        Sequence mySequence = DOTween.Sequence();
        //mySequence.Append(this.GetComponent<Image>().DOColor(new Color(1,1,1,0.8f),2f));
        mySequence.Append(GetComponent<RectTransform>().DOScale(1, 0.5f));
        //Tween myTween = GetComponent<RectTransform>().DOScale(1,0.5f);
        RotateStars();
    }

    private void RotateStars() 
    {
        foreach (GameObject star in starts) 
        {
            Tween myTween = star.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, -90), 0.5f);
            myTween.SetEase(Ease.Linear);
            myTween.SetLoops(-1, LoopType.Incremental);
        }        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInOut : MonoBehaviour
{
    Tween myTween;
    void Start()
    {
        Debug.Log("hi");
        myTween = GetComponent<Image>().DOFade(0.2f, 1.5f);
        myTween.SetEase(Ease.InOutSine);
        myTween.SetLoops(-1, LoopType.Yoyo);
    }

    public void StopAnimation()
    {
        myTween.Kill(false);
        GetComponent<Image>().DOFade(1, 0.1f);
        Debug.Log("StopAnimation");
    }

}

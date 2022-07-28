using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandAnimation : MonoBehaviour
{
    public Vector3 Target = new Vector3(210, 0, 0);
    private void OnEnable()
    {
        Tween myTween = this.transform.DOLocalMove(Target, 1.3f);
        myTween.SetEase(Ease.OutSine);
        myTween.SetLoops(3, LoopType.Restart);
        myTween.OnComplete(Dis);
    }

    public void Dis()
    {
        this.gameObject.SetActive(false);
    }
  

}

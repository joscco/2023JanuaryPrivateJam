using System;
using DG.Tweening;
using UnityEngine;

public class ScalingButton : MonoBehaviour
{

    public void OnPointerEnter()
    {
        Debug.Log("Scaling Out");
        transform.DOScale(1.2f, 0.25f).SetEase(Ease.OutBack);
    }

    public void OnPointerExit()
    {
        Debug.Log("Scaling In");
        transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);
    }
}

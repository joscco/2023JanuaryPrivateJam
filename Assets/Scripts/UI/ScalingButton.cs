using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScalingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.2f, 0.3f).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }
}

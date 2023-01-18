using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameButton : ScalingButton, IPointerClickHandler
{
    public String nextScene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(nextScene);
    }
}
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StartSceneAnimation : MonoBehaviour
{
    public bool startAnimationFinished;
    
    public int initialOffsetY = 1000;
    public float initialDelayInSeconds = 1f;
    public float delayPerLetterInSeconds = 0.1f;
    public float moveTimePerLetterInSeconds = 0.8f;

    public List<GameObject> letters = new List<GameObject>();
    public List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        if (!startAnimationFinished)
        {
            foreach (var letter in letters)
            {
                letter.transform.position -= new Vector3(0, initialOffsetY, 0);
            }
            
            foreach (var button in buttons)
            {
                button.transform.position -= new Vector3(0, initialOffsetY, 0);
            }

            StartCoroutine(BlendIn());
            startAnimationFinished = true;
        }
    }

    IEnumerator BlendIn()
    {
        yield return new WaitForSeconds(initialDelayInSeconds);
        yield return StartCoroutine(BlendInLetters());
        yield return StartCoroutine(BlendInButtons());
    }

    IEnumerator BlendInLetters()
    {
        Tween tween = null;
        for (int i = 0; i < letters.Count; i++)
        {
            Transform letter = letters[i].transform;
            tween = letter.DOMoveY(letter.position.y + initialOffsetY, moveTimePerLetterInSeconds)
                .SetEase(Ease.InOutBack)
                .SetDelay(i * delayPerLetterInSeconds);
        }

        yield return tween.WaitForCompletion();
    }
    
    IEnumerator BlendInButtons()
    {
        Tween tween = null;
        for (int i = 0; i < buttons.Count; i++)
        {
            Transform button = buttons[i].transform;
            tween = button.DOMoveY(button.position.y + initialOffsetY, moveTimePerLetterInSeconds)
                .SetEase(Ease.InOutBack)
                .SetDelay(i * delayPerLetterInSeconds);
        }

        yield return tween.WaitForCompletion();
    }
}
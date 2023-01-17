using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LetterMovement : MonoBehaviour
{
    public int initialOffsetY = 1000;
    public float initialDelayInSeconds = 1f;
    public float delayPerLetterInSeconds = 0.1f;
    public float moveTimePerLetterInSeconds = 0.8f;

    public List<Image> letters = new List<Image>();

    void Start()
    {
        foreach (var letter in letters)
        {
            letter.transform.position -= new Vector3(0, initialOffsetY, 0);
        }

        StartCoroutine(BlendInLetters());
    }

    IEnumerator BlendInLetters()
    {
        yield return new WaitForSeconds(initialDelayInSeconds);
        for (int i = 0; i < letters.Count; i++)
        {
            Transform letter = letters[i].transform;
            letter.DOMoveY(letter.position.y + initialOffsetY, moveTimePerLetterInSeconds)
                .SetEase(Ease.InOutBack)
                .SetDelay(i * delayPerLetterInSeconds);
        }
    }
}
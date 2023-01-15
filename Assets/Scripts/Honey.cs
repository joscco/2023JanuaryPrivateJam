using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : MonoBehaviour
{
    public PlayerItems playerItems;
    public float xpGain = 1;
    public float hpGain = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Effect()
    {
        playerItems.xp += xpGain;
        Vanish();
    }

    void Vanish()
    {
        Destroy(this.gameObject);
    }
}

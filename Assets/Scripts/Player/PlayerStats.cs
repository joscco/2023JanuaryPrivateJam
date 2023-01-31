using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float pickupRange;
    private float xp;

    public void AddXP(float amount)
    {
        xp += amount;
    }
}

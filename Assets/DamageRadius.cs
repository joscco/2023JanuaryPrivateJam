using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRadius : MonoBehaviour
{
    public List<GameObject> enemyInSight = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInSight.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInSight.Remove(collision.gameObject);
        }
    }
}

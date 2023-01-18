using System.Collections.Generic;
using UnityEngine;

public class VisionRadius : MonoBehaviour
{
    public List<GameObject> enemyInSight = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().health -= 1;
            enemyInSight.Add(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Honey"))
        {
            Honey honey = collision.gameObject.GetComponent<Honey>();
            if (honey)
            {
                honey.Effect();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().health -= 1;
            enemyInSight.Remove(collision.gameObject);
        }
    }
}
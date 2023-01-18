using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health = 1;
    public float speed = 1;
    public float attack = 1;

    DropItem _dropItem;

    bool alive = true;

    void Start()
    {
        _dropItem = GetComponent<DropItem>();
    }

    void Update()
    {
        if(health < 0 && alive)
        {
            alive = false;
            _dropItem.Drop();
           Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

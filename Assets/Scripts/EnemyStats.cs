using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health = 1;
    public float speed = 1;
    public float attack = 1;

    DropItem _dropItem;

    // Start is called before the first frame update
    void Start()
    {
        _dropItem = GetComponent<DropItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            _dropItem.drop();
            Invoke("Die",.1f);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}

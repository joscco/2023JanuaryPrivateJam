using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRadius : MonoBehaviour
{

    public List<GameObject> enemyInSight  = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit something");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            collision.gameObject.GetComponent<EnemyStats>().health -= 1;
            enemyInSight.Add(collision.gameObject);
        }
    
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("lost something");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("lost enemy");
            collision.gameObject.GetComponent<EnemyStats>().health -= 1;
            enemyInSight.Remove(collision.gameObject);
        }
    
    }

}

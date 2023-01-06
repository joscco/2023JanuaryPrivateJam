using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRadius : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log('x');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollision2D(Collision2D collision)
    {
        Debug.Log("hit something");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
        }
    
    }

}

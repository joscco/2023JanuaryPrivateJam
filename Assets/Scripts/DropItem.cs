using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DropItem : MonoBehaviour
{

    public GameObject[] items = new GameObject[3];
    public float CurrentHealth; 
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (CurrentHealth <= 0)
         {
             //Die();
 
             Vector3 position = transform.position;
             foreach (GameObject item in items)
             {
                 if (item != null)
                 {
                     
                     Instantiate(item, position, Quaternion.identity);
                 }
 
             }
         }
    }
}


 



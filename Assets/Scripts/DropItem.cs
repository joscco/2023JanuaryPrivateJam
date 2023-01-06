using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DropItem : MonoBehaviour
{

    public GameObject[] items = new GameObject[3];

    public void drop()
    {
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


 



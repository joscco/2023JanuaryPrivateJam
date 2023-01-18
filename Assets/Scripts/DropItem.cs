using UnityEngine;

public class DropItem : MonoBehaviour
{

    public GameObject[] items = new GameObject[3];

    public void Drop()
    {
        Vector3 position = transform.position;
        foreach (GameObject item in items)
        {
            if (item)
            {
                Instantiate(item, position, Quaternion.identity);
            }
        }
    }
}


 



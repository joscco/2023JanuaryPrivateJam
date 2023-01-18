using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Vector3 idlePosition;
    
    void Start()
    {
        idlePosition = transform.position;
    }
}

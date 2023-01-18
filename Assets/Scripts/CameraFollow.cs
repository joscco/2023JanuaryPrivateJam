using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    void FixedUpdate()
    {
        Vector3 aim = followTransform.position;
        transform.position = new Vector3(aim.x, aim.y, transform.position.z);
    }
}

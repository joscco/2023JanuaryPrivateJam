using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
    }
 
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed = 1;

    private Transform playerTF;


 
    private void Awake()
    {
        playerTF = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTF.position, movementSpeed * Time.deltaTime);
    }
 
}
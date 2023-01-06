using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed;
    public SpriteRenderer background;

    private Transform tf;
    
    float[] bounds;

    private Rigidbody2D _playerRigidbody;
 
    private void Awake()
    {
        tf = GetComponent<Transform>();

        bounds = GetSpriteBounds(background);
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }

    void Update() 
    {

        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2(hor,vert);

        Vector2 currentPos = _playerRigidbody.position;
 
        Vector2 adjustedMovement = movement * movementSpeed;
 
        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

        _playerRigidbody.MovePosition(newPos);
       // tf.Translate(hor,vert,0);

        bool outOfBounds = tf.position.x < bounds[0] || tf.position.x > bounds[1] || tf.position.y < bounds[2] || tf.position.y > bounds[3];
        
        if(outOfBounds)
        {
            Debug.Log("OOB");
            float clampedX = Mathf.Clamp(tf.position.x,bounds[0],bounds[1]);
            float clampedY = Mathf.Clamp(tf.position.y,bounds[2],bounds[3]);
            tf.position = new Vector3(clampedX,clampedY,tf.position.z);
        }


    }


    public static float[] GetSpriteBounds(SpriteRenderer renderer)
    {
        float minX = renderer.sprite.bounds.min.x;
        float maxX = renderer.sprite.bounds.max.x;
        float minY = renderer.sprite.bounds.min.y;
        float maxY = renderer.sprite.bounds.max.y;
        return new float[] { minX, maxX, minY, maxY};
    }
 
}
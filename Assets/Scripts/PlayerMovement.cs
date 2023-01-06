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


 
    private void Awake()
    {
        tf = GetComponent<Transform>();

        bounds = GetSpriteBounds(background);
    }

    void Update() 
    {
        float vert = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        tf.Translate(hor,vert,0);

        bool outOfBounds = tf.position.x < bounds[0] || tf.position.x > bounds[1] || tf.position.y < bounds[2] || tf.position.y > bounds[3];
        if(outOfBounds)
        {
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
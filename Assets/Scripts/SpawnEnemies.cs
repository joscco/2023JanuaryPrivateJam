using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public SpriteRenderer background;
    public GameObject enemy;
    public int mobCount = 3;
    float[] bounds;
    bool spawned = true;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetSpriteBounds(background);
        for( int i=0;i<mobCount;i++)
        {
            float randX = Random.Range(bounds[0],bounds[1]);
            float randY = Random.Range(bounds[2],bounds[3]);
            Instantiate(enemy,new Vector2(randX,randY),Quaternion.identity);
        }
    }



    void spawnMore()
    {
        spawned = true;
        mobCount+=1;
        for( int i=0;i<mobCount;i++)
        {
            float randX = Random.Range(bounds[0],bounds[1]);
            float randY = Random.Range(bounds[2],bounds[3]);
            Instantiate(enemy,new Vector2(randX,randY),Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(spawned)
        {
            spawned = false;
            Invoke("spawnMore",5);
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

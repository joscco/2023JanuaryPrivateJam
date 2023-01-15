using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameField : MonoBehaviour
{
    public List<Sprite> fieldDecorationSprites = new List<Sprite>();
    public int numberOfDecorations = 100;
    public int width = 30;
    public int height = 15;

    private SpriteRenderer _spriteRenderer;
    private List<GameObject> _fieldDecorations = new List<GameObject>();
    private float[] _bounds;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bounds = SpriteUtils.GetBounds(_spriteRenderer);
        
        SetSize();
        SprinkleDecoration();
    }

    public Vector2 GetRandomFieldPosition()
    {
        float randX = Random.Range(_bounds[0], _bounds[1]);
        float randY = Random.Range(_bounds[2], _bounds[3]);
        return new Vector2(randX, randY);
    }
    
    public Vector2 ClampToField(Vector2 position)
    {
        float newX = Math.Clamp(position.x, _bounds[0], _bounds[1]);
        float newY = Math.Clamp(position.y, _bounds[2], _bounds[3]);
        return new Vector2(newX, newY);
    }

    private void SprinkleDecoration()
    {
        for (int i = 0; i < numberOfDecorations; i++)
        {
            Sprite randomSprite = fieldDecorationSprites[Random.Range(0, fieldDecorationSprites.Count)];
            Vector2 randomPosition = GetRandomFieldPosition();
            GameObject decor = Instantiate(new GameObject(), randomPosition, Quaternion.identity, transform);
            SpriteRenderer spriteRenderer = decor.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;
            _fieldDecorations.Add(decor);
        }
    }

    private void SetSize()
    {
        _spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        _spriteRenderer.size = new Vector2(width, height);
    }
}
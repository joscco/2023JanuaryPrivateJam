using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;

    private SpriteRenderer _renderer;
    private GameObject _player;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        var position = transform.position;
        var playerPosition = _player.transform.position;
        transform.position = Vector2.MoveTowards(position, playerPosition, movementSpeed * Time.deltaTime);
        
        float verticalDistance = playerPosition.x - position.x;
        SwapFacingDirectionIfNeeded(verticalDistance);
    }

    private void SwapFacingDirectionIfNeeded(float verticalDistanceToPlayer)
    {
        _renderer.transform.localScale = new Vector3(verticalDistanceToPlayer < 0 ? -1 : 1, 1, 0);
    }
}
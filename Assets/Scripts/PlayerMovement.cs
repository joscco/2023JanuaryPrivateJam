using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameField gameField;

    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D _playerRigidbody;

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
 
        Vector2 newPos = currentPos + adjustedMovement * Time.deltaTime;

        _playerRigidbody.MovePosition(newPos);
       // tf.Translate(hor,vert,0);

       transform.position = gameField.ClampToField(transform.position);
    }
}
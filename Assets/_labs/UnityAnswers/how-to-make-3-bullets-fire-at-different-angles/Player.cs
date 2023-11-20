using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 _movePosition;
    Vector2 _moveDirection;

    public Vector2 MovInc = new Vector2(.1f, .1f);
    public float MovSpeed = .5f;

    private void Start()
    {
        _movePosition = transform.position;
    }

    private void Update()
    {
        _moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            _moveDirection = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            _moveDirection = Vector2.right;

        if (Input.GetKey(KeyCode.UpArrow))
            _moveDirection += Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            _moveDirection += Vector2.down;

        _movePosition += MovInc * _moveDirection.normalized;

        transform.position = Vector2.Lerp(transform.position, _movePosition, Time.deltaTime * MovSpeed);
    }  
}

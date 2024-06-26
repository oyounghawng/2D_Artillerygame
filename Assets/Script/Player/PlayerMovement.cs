using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controller controller;
    private Rigidbody2D rigidBody2D;
    private Fuel fuel;

    private Vector2 movementDirection = Vector2.zero;
    private float speed;

    private void Awake()
    {
        controller = GetComponentInParent<Controller>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        fuel = GetComponent<Fuel>();
    }

    private void Start()
    {
        speed = GetComponent<PlayerStats>().speed;
        controller.OnMoveEvent += Move;
    }

    void Update()
    {
        if (!Input.anyKey)
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX |
                RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    private void FixedUpdate()
    {
        if (!fuel.IsEmpty())
        {
            rigidBody2D.velocity = new Vector2(movementDirection.x * speed, rigidBody2D.velocity.y);
            if (movementDirection.x != 0)
            {
                fuel.Decreasefuel(Mathf.Abs(movementDirection.x) * 20f);
            }
        }
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }
}


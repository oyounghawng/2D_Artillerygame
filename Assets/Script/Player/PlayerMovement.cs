using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool myturn = false;

    private Rigidbody2D rigidBody2D;

    private Fuel fuel;
    private float horizontal;
    private float speed = 3f;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        fuel = GetComponent<Fuel>();
    }

    //�̵� �� �Ÿ� ����ؼ� �پ�ߵǴµ� ������ �Է¸��پ �׷���
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
        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!myturn)
            return;

        horizontal = context.ReadValue<Vector2>().x;
        fuel.Decreasefuel(Mathf.Abs(horizontal) * 20f); //����ġ�� �����Ƿ�
    }
}


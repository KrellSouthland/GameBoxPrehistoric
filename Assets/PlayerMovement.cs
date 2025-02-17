using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpModifier;

    private bool onGround;
    private float horizontalInput;
    private Rigidbody2D charBody;

    private void Start()
    {
        charBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (horizontalInput!=0)
        {
            charBody.velocity = new Vector2(horizontalInput * moveSpeed, charBody.velocity.y);
        }
    }

    private void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            onGround = false;
            charBody.velocity = new Vector2(charBody.velocity.x, jumpModifier);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("floor"))
        {
            onGround=true;
        }
    }
}

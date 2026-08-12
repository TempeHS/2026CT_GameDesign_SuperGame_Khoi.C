using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float horizontal = 1f;
    private float speedX = 0f;
    private float maxSpeed = 4f;
    private float jumpPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        speedX += horizontal * 30f * Time.deltaTime; 
        speedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);

        if(IsGrounded()) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        Flip();
    }

    private void FixedUpdate() {
        CheckWall();

        float finalYVelocity = Mathf.Min(rb.linearVelocity.y, 50f);
        rb.linearVelocity = new Vector2(speedX, finalYVelocity);
        if (horizontal == 0f) {
            speedX = Mathf.MoveTowards(speedX, 0f, 20f * Time.fixedDeltaTime);
        }
    }

    private void CheckWall() {
        if (speedX == 0) return;
        
        float direction = Mathf.Sign(speedX);
        Vector2 checkPos = new Vector2(transform.position.x + direction * 0.5f, transform.position.y + 0.5f);

        if (Physics2D.OverlapBox(checkPos, new Vector2(0.1f, 1f), 0f, groundLayer)) {
            if (direction != 0 && horizontal != 0) {
                speedX = 0f;
                horizontal = horizontal * -1;
            }
        }
    }

    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.7f, 0.2f), 0f, groundLayer);
    }
}

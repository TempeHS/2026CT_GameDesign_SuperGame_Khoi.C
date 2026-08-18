using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float horizontal = 1f;
    private float speedX = 0f;
    private float maxSpeed = 4f;
    private float jumpPower = 12f;
    private bool isFacingRight = true;
    private Animator animator;
    private float jumpTimer;

    public ParticleSystem particleFX;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer; 
    [SerializeField] private float jumpInterval = 2f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        jumpTimer = jumpInterval;
    }

    void Update()
    {
        speedX += horizontal * 30f * Time.deltaTime; 
        speedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);

        if (rb.linearVelocity.y < 0f) {
           animator.SetBool("PreJump", false);
        }

        if(IsGrounded()) {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f) {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                jumpTimer = jumpInterval;
            } else if (jumpTimer <= 0.25f) {
                animator.SetBool("PreJump", true);
            }
        }

        

        Flip();

        animator.SetFloat("SpeedY", rb.linearVelocity.y);
        animator.SetBool("InAir", !IsGrounded());
    }

    private void FixedUpdate() {
        CheckWall();

        float finalYVelocity = Mathf.Min(rb.linearVelocity.y, 50f);
        rb.linearVelocity = new Vector2(speedX, finalYVelocity);
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

    public void ParticleFX() {
        particleFX.Play();
        Destroy(gameObject);
    }
}

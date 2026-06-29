using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speedX = 0f;
    private float maxSpeed = 8f;
    private float jumpPower = 16f;
    private bool isFacingRight = true;
    private bool jumpBuffer = false;
    private int airTime = 0;
    private Vector2 groundCheckSize = new Vector2(0.95f, 1f);

    private bool isKB = false;

    public HealthSystem healthSystemRef;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform jumpBufferCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obstacleLayer;

    void Update()
    {
        if (isKB == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            speedX += horizontal * 30f * Time.deltaTime; 
            speedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);
        }

        if (!IsGrounded())
        {
            airTime += 1;
        } else {
            airTime = 0;
            if (rb.linearVelocity.y < 0.1f)
            {
               isKB = false; 
            }
        }

        if (Input.GetButtonDown("Jump") && (IsGrounded() || airTime < 50 && rb.linearVelocity.y < 0f))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (Input.GetButtonDown("Jump") && CanJumpBuffer() && rb.linearVelocity.y < 0f)
        {
            jumpBuffer = true;
        }

        if (jumpBuffer == true && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            jumpBuffer = false;
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            transform.position = new Vector2(0f, 0f);
        }

        Flip();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (DamageCheck() && !isKB)
        {
            healthSystemRef.DealDamage();

            Vector3 contactPoint = collision.GetContact(0).point;
            float horizontalDirection = transform.position.x > contactPoint.x ? 1f : -1f;

            StartCoroutine(KbTimer());

            float kbForceX = horizontalDirection * 15f; 
            speedX = kbForceX; 

            rb.linearVelocity = Vector2.zero;
            Vector2 kbForce = new Vector2(kbForceX, 12f);
            rb.AddForce(kbForce, ForceMode2D.Impulse);
        }
    }

    private IEnumerator KbTimer()
    {
        isKB = true;
        horizontal = 0f;
        
        yield return new WaitForSeconds(0.25f);
        
        isKB = false;
    }

    private void FixedUpdate()
    {
        float finalYVelocity = Mathf.Min(rb.linearVelocity.y, 50f);
        rb.linearVelocity = new Vector2(speedX, finalYVelocity);

        if (isKB)
        {
            speedX = Mathf.MoveTowards(speedX, 0f, 10f * Time.fixedDeltaTime);
        }
        else if (horizontal == 0f)
        {
            speedX = Mathf.MoveTowards(speedX, 0f, 40f * Time.fixedDeltaTime);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);
    }

    private bool CanJumpBuffer()
    {
        return Physics2D.OverlapBox(jumpBufferCheck.position, groundCheckSize, 0f, groundLayer);
    }

    private bool DamageCheck()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(1f, 1f), 0f, obstacleLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
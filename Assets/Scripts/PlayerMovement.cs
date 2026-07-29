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
    private float ySpeed;

    private bool isKB = false;

    public HealthSystem healthSystemRef;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform jumpBufferCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Animator animator;

    void Update()
    {
        ySpeed = rb.linearVelocity.y;

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
            if (ySpeed < 0.1f)
            {
               isKB = false; 
            }
        }

        Debug.Log(Input.GetButton("Jump"));

        if(Input.GetButtonDown("Jump") && (IsGrounded() || (airTime < 25 && ySpeed < 0f)))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (Input.GetButtonDown("Jump") && CanJumpBuffer() && ySpeed < 0f)
        {
            jumpBuffer = true;
        }

        if (Input.GetButtonUp("Jump") && ySpeed > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
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

        animator.SetFloat("PlayerSpeed", Mathf.Abs(speedX));
        animator.SetFloat("PlayerSpeedY", ySpeed);
        if (airTime > 0)
        {
            animator.SetBool("PlayerInAir?", true);
        } else {
            animator.SetBool("PlayerInAir?", false);
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
        float finalYVelocity = Mathf.Min(ySpeed, 50f);
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
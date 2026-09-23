using UnityEngine;

public class AnxietyBehaviour : MonoBehaviour
{
    private float startY;
    private float tick = 0f;

    public Transform player;
    public float viewAngle = 45f;
    public LayerMask obstacleMask;
    public Transform sight;
    public SmoothCameraMovement cameraRef;
    public PlayerMovement playerRef;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float offsetX = player.transform.position.x - transform.position.x;
        float offsetY = player.transform.position.y + 6f - transform.position.y;
        tick += 2.5f * Time.deltaTime;
        if (player.transform.position.x > 235) {
            transform.position = new Vector2(transform.position.x + (offsetX / 30f), transform.position.y + (offsetY / 30f) + Mathf.Sin(tick) * 0.01f);
            cameraRef.OffsetCamera(0f, 3f);
        } else {
            cameraRef.OffsetCamera(0f, 0f);
        }
        if (CheckLineOfSight()) {
            playerRef.DealDamage();
        }
        float currentAngle = Mathf.PingPong(Time.time * 20f, 120f);
        float targetZRotation = currentAngle - (120f / 2f);
        sight.localRotation = Quaternion.Euler(0, 0, targetZRotation + 180);
    }

    private bool CheckLineOfSight()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        directionToPlayer.Normalize();
        float angleToPlayer = Vector3.Angle(sight.up, directionToPlayer);

        if (angleToPlayer > viewAngle / 2f)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask);
        if (hit.collider == null) {
            return true;
        } else {
            return false;
        }
    }
}

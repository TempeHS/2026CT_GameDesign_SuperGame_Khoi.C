using UnityEngine;

public class OrbController : MonoBehaviour
{       
    private float yOffset;
    private float tick = 0f;
    private float y;

    void Start()
    {
        y = transform.position.y;
    }

    void Update()
    {
        tick += 2.5f * Time.deltaTime;
        yOffset = Mathf.Sin(tick);

        transform.position = new Vector2(transform.position.x, y + yOffset * 0.2f); 

        
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
}
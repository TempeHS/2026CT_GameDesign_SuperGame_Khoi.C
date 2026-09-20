using UnityEngine;

public class OrbController : MonoBehaviour
{       
    private float yOffset;
    private float tick = 0f;
    private float startY;
    private bool isVisible = false;
    private GameObject player;
    private Transform playerTransform;

    [SerializeField] private float waveSpacing = 0.3f;

    AudioManager audioManager;
    OrbCounter orbCounterRef;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        orbCounterRef = GameObject.FindGameObjectWithTag("OrbCounter").GetComponent<OrbCounter>();
    }

    void Start()
    {
        startY = transform.position.y;

        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }

    void Update()
    {
        if (isVisible == true) {
            tick += 2.5f * Time.deltaTime;
            float distanceOffset = Mathf.Abs(transform.position.x - playerTransform.position.x) * waveSpacing;
            yOffset = Mathf.Sin(tick - distanceOffset);

            transform.position = new Vector2(transform.position.x, startY + yOffset * 0.2f); 
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
        tick = 0f;
        transform.position = new Vector2(transform.position.x, startY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orbCounterRef.ChangeOrbCount(1);
            audioManager.PlaySFX(audioManager.collect);
            Destroy(gameObject);
        }
    }
}
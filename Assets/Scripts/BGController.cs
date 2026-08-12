using UnityEngine;

public class BGController : MonoBehaviour
{
    private float startX;
    private float startY;
    private float length;

    public GameObject cam;
    public float parallaxEffect;
    public bool affectY = true;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        AdjustToScreen();
    }

    void LateUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffect;
        float distanceY = cam.transform.position.y * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        if (affectY == true) {
            transform.position = new Vector3(startX + distanceX, startY + distanceY, transform.position.z);
        } else {
            transform.position = new Vector3(startX + distanceX, transform.position.y, transform.position.z);
        }
        

        if (movement > startX + length) {
            startX += length;
        } else if (movement < startX - length) {
            startX -= length;
        }
    }

    void AdjustToScreen() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        transform.localScale = Vector3.one;

        float width = sprite.bounds.size.x;
        
        Camera camera = Camera.main;
        float camHeight = camera.orthographicSize * 2f;
        float camWidth = camHeight / Screen.height * Screen.width;

        float scale = camWidth / width;

        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
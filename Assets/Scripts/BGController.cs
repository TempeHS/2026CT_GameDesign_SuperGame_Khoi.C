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
}
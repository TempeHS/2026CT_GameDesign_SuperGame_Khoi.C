using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public GameObject player;
    private float offsetX;
    private float offsetY;
    private float camOffsetX;
    private float camOffsetY;

    void Start() {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }

    void Update() {
        
        offsetX = player.transform.position.x + camOffsetX - transform.position.x;
        offsetY = player.transform.position.y  + camOffsetY - transform.position.y;

        transform.position = new Vector3(transform.position.x + (offsetX / 30f), transform.position.y + (offsetY / 30f), transform.position.z);
    }

    public void OffsetCamera(float x, float y) {
        camOffsetX = x;
        camOffsetY = y;
    }
}
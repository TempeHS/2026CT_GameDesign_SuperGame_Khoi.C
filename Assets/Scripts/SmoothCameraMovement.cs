using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public GameObject player;
    private float offsetX;
    private float offsetY;

    // Update is called once per frame
    void Update() {
        
        offsetX = player.transform.position.x - transform.position.x;
        offsetY = player.transform.position.y - transform.position.y;

        transform.position = new Vector3(transform.position.x + (offsetX / 10f), transform.position.y + (offsetY / 10f), transform.position.z);
    }
}
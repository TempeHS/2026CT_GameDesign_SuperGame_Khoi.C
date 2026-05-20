using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public GameObject player;
    private float offsetX;
    private float offsetY;

    // Update is called once per frame
    void Update()
    {
        offsetX = player.transform.position.x - transform.position.x;
        offsetY = player.transform.position.y - transform.position.y;

        transform.Translate(Vector3.right * offsetX*4 * Time.deltaTime);
        transform.Translate(Vector3.up * offsetY*4 * Time.deltaTime);
    }
}

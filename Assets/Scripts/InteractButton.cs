using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPos;

    void Start() {
        gameObject.SetActive(false);
    }

    void Update()
    {
        playerPos = player.transform.position;
        gameObject.transform.position = new Vector2(playerPos.x, playerPos.y + 1.25f);
    }

    public void ActiveState(bool active) {
        gameObject.SetActive(active);
    }
}

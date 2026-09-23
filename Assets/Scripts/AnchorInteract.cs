using UnityEngine;

public class AnchorInteract : MonoBehaviour
{
    public InteractButton interactRef;
    public AnchorFunction anchorRef;

    private bool isPlayerTouching;

    void Update() {
        if (isPlayerTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anchorRef.Reset(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            isPlayerTouching = true;
            interactRef.ActiveState(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerTouching = false;
            interactRef.ActiveState(false);
        }
    }
}

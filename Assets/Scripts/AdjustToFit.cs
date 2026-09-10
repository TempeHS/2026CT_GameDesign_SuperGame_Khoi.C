using UnityEngine;
using UnityEngine.UI;

public class AdjustToFit : MonoBehaviour
{
    [SerializeField] private float fill = 1f;
    private float updateFill;

    void Start()
    {
        AdjustToScreen();
        updateFill = fill;
    }

    void AdjustToScreen() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Image imageUI = GetComponent<Image>();

        Sprite sprite = null;

        if (spriteRenderer != null) {
            sprite = spriteRenderer.sprite;
        } else if (imageUI != null) {
            sprite = imageUI.sprite;
        }

        transform.localScale = Vector3.one;

        float width = sprite.bounds.size.x;
        
        Camera camera = Camera.main;
        float camHeight = camera.orthographicSize * 2f;
        float camWidth = camHeight / Screen.height * Screen.width;

        float scale = camWidth / width;

        transform.localScale = new Vector3(scale * fill, scale * fill, 1f);
    }

    void Update() {
        if (updateFill != fill) {
            AdjustToScreen();
            updateFill = fill;
        }
    }
}

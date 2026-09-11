using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float startObjectScale;
    private float objectScale;
    private float objectRotation;
    private bool isHovering = false;
    private float time = 0f;

    [SerializeField] private int animType = 1;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        startObjectScale = transform.localScale.x; 
    }

    void Update()
    {
        objectScale = transform.localScale.x; 
        objectRotation = transform.rotation.eulerAngles.z;
        if (objectRotation > 180) objectRotation -= 360;

        if (animType == 1) {
            if (isHovering == true) {
                transform.localScale += new Vector3 ((startObjectScale * 1.2f - objectScale) / 20f, (startObjectScale * 1.2f - objectScale) / 20f, 0f);
                float targetRot = Mathf.Lerp(objectRotation, -3f, 0.1f);
                transform.localRotation = Quaternion.Euler(0, 0, targetRot);
            } else {
                transform.localScale += new Vector3 ((startObjectScale - objectScale) / 20f, (startObjectScale - objectScale) / 20f, 0f);
                float targetRot = Mathf.Lerp(objectRotation, 0f, 0.1f);
                transform.localRotation = Quaternion.Euler(0, 0, targetRot);
            }
        } else if (animType == 2) {
            if (time > 1) {
                time -= Time.deltaTime;
            } else if (time == 1) {
                transform.localScale = new Vector3 (startObjectScale + 0.02f, startObjectScale + 0.02f, 0f);
            } else {
                transform.localScale = new Vector3 (startObjectScale + 0.1f, startObjectScale + 0.1f, 0f);
                time = 2f;
            }
            transform.localScale += new Vector3 ((startObjectScale - objectScale) / 20f, (startObjectScale - objectScale) / 20f, 0f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        audioManager.PlaySFX(audioManager.hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHovering == true && animType == 1) {
            transform.localScale = new Vector3 (startObjectScale * 1.5f, startObjectScale * 1.5f, 0f);
            audioManager.PlaySFX(audioManager.click);
        }
    }

    private void OnDisable()
    {
        isHovering = false;
        
        transform.localScale = new Vector3(startObjectScale, startObjectScale, 1f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

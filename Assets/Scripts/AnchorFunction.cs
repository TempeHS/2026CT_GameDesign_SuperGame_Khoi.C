using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class AnchorFunction : MonoBehaviour
{
    private static int activatedAnchorsCount = 0;
    public Vector3Int[] deletedTilesPos;

    public GameObject wheel;
    public GameObject spinner;
    public Image fill;
    public Sprite[] stages;
    public Tilemap bgTilemap;
    public Tilemap groundTilemap;
    public TileBase greenAnchorTile;

    private float targetPercent;
    private float percent;
    private float wheelRotation;
    private float spinnerRotation;
    private int spinDir;
    private Image wheelImg;
    private GameObject currentAnchor;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        wheelImg = wheel.GetComponent<Image>();
        targetPercent = 0f;
        percent = 0f;
        spinDir = 1;
        gameObject.SetActive(false);
    }

    public void Reset(GameObject anchor) {
        targetPercent = 0f;
        percent = 0f;
        spinDir = 1;
        gameObject.SetActive(true);
        currentAnchor = anchor;
    }

    void Update()
    {
        spinner.transform.Rotate(new Vector3(0, 0, 150 * spinDir) * Time.deltaTime);
        percent += (targetPercent - percent) / 10f;
        fill.fillAmount = percent;
        if (targetPercent >= 0.7f) {
            wheelImg.sprite = stages[2]; 
        } else if (targetPercent >= 0.4f) {
            wheelImg.sprite = stages[1]; 
        } else {
            wheelImg.sprite = stages[0];
        }
        if (percent >= 0.99f) {
            gameObject.SetActive(false);
            Vector3Int cellPosition = bgTilemap.WorldToCell(currentAnchor.transform.position);
            bgTilemap.SetTile(cellPosition, greenAnchorTile);
            AudioManager.instance.SwitchMusic(0);
            Destroy(currentAnchor);
            activatedAnchorsCount += 1;
            if (activatedAnchorsCount >= 3) {
                ClearTilemap();
            }
        }
    }

    public void Lock() {
        if (targetPercent < 1) {
            wheelRotation = wheel.transform.eulerAngles.z;
            spinnerRotation = spinner.transform.eulerAngles.z;
            float angleDifference = Mathf.Abs(Mathf.DeltaAngle(wheelRotation, spinnerRotation));
            if (angleDifference < 50 && targetPercent < 0.4f || angleDifference < 35 && targetPercent < 0.7f || angleDifference < 20 && targetPercent >= 0.7f) {
                targetPercent += 0.1f;
                audioManager.PlaySFX(audioManager.hover);
            } else if (targetPercent > 0f) {
                targetPercent -= 0.1f;
                audioManager.PlaySFX(audioManager.click);
            }
            wheel.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            spinDir = spinDir * -1;
        }
    }

    private void ClearTilemap() {
        foreach (Vector3Int pos in deletedTilesPos) {
            groundTilemap.SetTile(pos, null);
        }
    }
}

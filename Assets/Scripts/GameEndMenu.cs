using UnityEngine;
using TMPro;

public class GameEndMenu : MonoBehaviour
{
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;

    void Start() {
        gameObject.SetActive(false);
    }

    public void DeathScreen() {
        gameObject.SetActive(true);
        header.text = "You died...";
        description.text = "Click RESET to try again.";
    }

    public void WinScreen() {
        gameObject.SetActive(true);
        header.text = "You escaped!";
        description.text = "Congratulations on beating IN=SOMNIA!";
    }
}

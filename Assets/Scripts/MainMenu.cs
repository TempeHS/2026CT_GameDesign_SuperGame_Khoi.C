using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int volume = 3;
    [SerializeField] private GameObject childObject;
    [SerializeField] private Sprite[] volumeSprites;

    public void PlayGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void Home() {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SwitchVol() {
        volume += 1;
        if (volume > 3) {
            volume = 0;
        }
        
        Image image = childObject.GetComponent<Image>();
        image.sprite = volumeSprites[volume];
    }

    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
    }
}

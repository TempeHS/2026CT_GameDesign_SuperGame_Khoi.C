using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int volume;
    [SerializeField] private GameObject childObject;
    [SerializeField] private Sprite[] volumeSprites;

    void Start() {
        volume = PlayerPrefs.GetInt("SavedVolume", 3);
        AdjustVolume();
    }

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

        PlayerPrefs.SetInt("SavedVolume", volume);
        PlayerPrefs.Save();

        AdjustVolume();
    }

    void AdjustVolume() {
        float linearVolume = volume / 3f;
        AudioListener.volume = Mathf.Pow(linearVolume, 2f); 

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

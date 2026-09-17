using UnityEngine;
using UnityEngine.SceneManagement; 

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    

    [Header("Audio Clips")]
    public AudioClip WhitePalace;
    public AudioClip Confined;
    public AudioClip hover;
    public AudioClip click;
    public AudioClip collect;
    public AudioClip splat;

    [Header("Audio In Scene")]
    [SerializeField] private AudioClip music;

    private void Start() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        musicSource.loop = true;
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}

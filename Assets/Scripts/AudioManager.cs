using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    private int track = 0;

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
    public AudioClip deposit;
    public AudioClip text;
    public AudioClip deny;

    [Header("Audio In Scene")]
    [SerializeField] private AudioClip[] music;

    [Header("Audio Fade")]
    [SerializeField] private float fadeDuration = 0.75f;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        } 
    }

    private void Start() {
        track = SceneManager.GetActiveScene().buildIndex;
        SwitchMusic(track);
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    public void SwitchMusic(int trackIndex) {
        if (trackIndex == 0) {
            track += 1;
            trackIndex = track;
        }
        if (musicSource.clip == music[trackIndex] && musicSource.isPlaying)
        {
            return; 
        }

        StartCoroutine(FadeTrackTransition(music[trackIndex]));
    }

    private IEnumerator FadeTrackTransition(AudioClip newClip)
    {
        float startVolume = 1f;

        if (musicSource.isPlaying && musicSource.clip != null)
        {
            while (musicSource.volume > 0f)
            {
                musicSource.volume -= startVolume * (Time.deltaTime / fadeDuration);
                yield return null;
            }
        }

        musicSource.clip = newClip;
        musicSource.loop = true;
        musicSource.volume = 0f;
        
        if (newClip != null)
        {
            musicSource.Play();

            while (musicSource.volume < startVolume)
            {
                musicSource.volume += startVolume * (Time.deltaTime / fadeDuration);
                yield return null;
            }
            
            musicSource.volume = startVolume;
        }
    }
}

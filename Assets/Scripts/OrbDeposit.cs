using UnityEngine;
using TMPro;
using System.Collections;

public class OrbDeposit : MonoBehaviour
{
    public InteractButton interactRef;
    public HealthSystem healthSystemRef;
    public OrbCounter orbCounterRef;
    private bool isPlayerTouching;
    [SerializeField] private int orbCost = 20;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update() {
        if (isPlayerTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int currentOrbs = orbCounterRef.orbs; 
                int currentHealth = healthSystemRef.health;
                if (currentOrbs >= orbCost && currentHealth < 5) {
                    orbCounterRef.ChangeOrbCount(orbCost * -1);
                    healthSystemRef.Heal(); 
                    audioManager.PlaySFX(audioManager.deposit);
                } else {
                    audioManager.PlaySFX(audioManager.deny);
                }
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
            interactRef.ActiveState(false);
        }
    }
}

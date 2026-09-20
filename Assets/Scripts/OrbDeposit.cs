using UnityEngine;
using TMPro;
using System.Collections;

public class OrbDeposit : MonoBehaviour
{
    public InteractButton interactRef;
    public HealthSystem healthSystemRef;
    public OrbCounter orbCounterRef;
    private bool isPlayerTouching;

    void Update() {
        if (isPlayerTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int currentOrbs = orbCounterRef.orbs; 
                int currentHealth = healthSystemRef.health;
                if (currentOrbs >= 25 && currentHealth < 5) {
                   orbCounterRef.ChangeOrbCount(-25);
                    healthSystemRef.Heal(); 
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

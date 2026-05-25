using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;

    public GameObject heart;
    public GameObject healthContainer;

    private void Start()
    {
        health = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartChild = Instantiate(heart);
            heartChild.transform.SetParent(healthContainer);
        }
    }
    
    public void DealDamage()
    {
        if (health > 0)
        {
            health  -= 1;
        }
    }
}
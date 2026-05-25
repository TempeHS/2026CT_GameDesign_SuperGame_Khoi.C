using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    public GameObject heart;
    public GameObject healthContainer;
    
    private float timer = 0f;

    private readonly List<GameObject> hearts = new();

    private void Start()
    {
        health = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartChild = Instantiate(heart);
            heartChild.transform.SetParent(healthContainer.transform);
            hearts.Add(heartChild);
        }

        DisplayHearts();
    }
    
    public void DealDamage()
    {
        if (health > 0)
        {
            if (timer <= 0f) {
                health  -= 1;
                timer = 2f;
                DisplayHearts();
                Debug.Log(health);
            }
        }
    }

    void Update()
    {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        }
    }

    private void DisplayHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            Image img = hearts[i].GetComponent<Image>();

            if (i < health)
            {
                // Full heart → normal color (white)
                img.color = Color.white;
            } else {
                // Empty heart → black
                img.color = new Color32(50, 50, 50, 255);
            }
        }
    }
}
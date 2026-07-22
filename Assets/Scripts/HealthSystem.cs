using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    public GameObject heart;
    public GameObject healthContainer;
    public GameObject healthContainerTrans;
    
    private float timer = 0f;

    private readonly List<GameObject> hearts = new();

    private void Start()
    {
        health = maxHealth;
        
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartChild = Instantiate(heart);
            heartChild.transform.SetParent(healthContainerTrans.transform);
            Image img = heartChild.GetComponent<Image>();
            img.color = new Color32(255, 255, 255, 150);
            hearts.Add(heartChild);
        }
        
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartChild = Instantiate(heart);
            heartChild.transform.SetParent(healthContainer.transform);
            hearts.Add(heartChild);
        }

        DisplayHearts();
    }

    void Update()
    {
        if (timer > 0f) timer -= Time.deltaTime;

        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("you pressed F");
            DealDamage();
        }
    }

    public void DealDamage()
    {
        if (health > 0 && timer <= 0f)
        {
            health -= 1;
            timer = 2f;

            Animator anim = hearts[maxHealth + health].GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("HeartTrigger");

            DisplayHearts();
        }
    }

    private void DisplayHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            Image img = hearts[maxHealth + i].GetComponent<Image>();
        }
    }
}
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
        if (health > 0 && timer <= 0f)
        {
            health -= 1;
            timer = 2f;

            // Play animation on the heart that was just lost
            Animator anim = hearts[health].GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("HeartTrigger"); // make sure this trigger exists in Animator
            }

            DisplayHearts();
        }
    }

    void Update()
    {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("you pressed F");
            DealDamage();
        }
    }

    private void DisplayHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            Image img = hearts[i].GetComponent<Image>();

            if (i < health)
            {
                img.color = Color.white;
            }
            else
            {
                img.color = Color.black;
            }
        }

        if (health >= 0 && health < hearts.Count)
        {
            Animator anim = hearts[health].GetComponent<Animator>();
            anim.SetTrigger("HeartTrigger");
        }
    }
}
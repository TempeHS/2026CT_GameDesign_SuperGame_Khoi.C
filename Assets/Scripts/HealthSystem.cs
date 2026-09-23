using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    public GameObject heart;
    public GameObject healthContainer;
    public GameObject healthContainerTrans;
    public GameEndMenu gameEndMenu;
    public GameObject player;
    
    private float timer = 0f;
    private bool death = false;
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

        if (health == 0 && death == false) {
            StartCoroutine(Death());
            death = true;
        }
    }

    IEnumerator Death()
    {
        Destroy(player);
        yield return new WaitForSeconds(1f);
        gameEndMenu.DeathScreen();
    }

    public void DealDamage()
    {
        if (health > 0 && timer <= 0f)
        {
            health -= 1;
            timer = 2f;

            Animator anim = hearts[maxHealth + health].GetComponent<Animator>();
            if (anim != null) {
                anim.ResetTrigger("HeartTriggerGain");
                anim.SetTrigger("HeartTriggerLoss");
            }

            DisplayHearts();
        }
    }

    public void Heal()
    {
        if (health < maxHealth)
        {
            Animator anim = hearts[maxHealth + health].GetComponent<Animator>();
            if (anim != null) {
                anim.ResetTrigger("HeartTriggerLoss");
                anim.SetTrigger("HeartTriggerGain");
            }
            health += 1;
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
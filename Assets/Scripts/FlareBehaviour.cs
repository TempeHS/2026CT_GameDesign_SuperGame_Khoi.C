using System.Collections.Generic;
using UnityEngine;

public class FlareBehaviour : MonoBehaviour
{
    private ParticleSystem ps;

    public float eruptionDuration = 3f;
    public float dormantDuration = 5f;

    private GameObject player;
    private Collider2D playerCollider;
    private PlayerMovement playerScript;

    private List<ParticleSystem.Particle> enterParticles = new List<ParticleSystem.Particle>();

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var triggerModule = ps.trigger;
        GameObject player = GameObject.FindWithTag("Player");
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        triggerModule.SetCollider(0, playerCollider);
        playerScript = player.GetComponent<PlayerMovement>();
        StartCoroutine(EruptionRoutine());
    }

    System.Collections.IEnumerator EruptionRoutine()
    {
        while (true)
        {
            ps.Play();
            yield return new WaitForSeconds(eruptionDuration);

            ps.Stop();
            yield return new WaitForSeconds(dormantDuration);
        }
    }

    void OnParticleTrigger()
    {
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enterParticles);
        if (numInside > 0)
        {
            playerScript.DealDamage();
        }
    }
}
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class HealthLighting : MonoBehaviour
{
    public HealthSystem healthSystem;
    
    [SerializeField] private Color[] color;

    private Light2D globalLight;
    private int health;
    private Color targetColor;

    void Start() {
        globalLight = GetComponent<Light2D>();
    }

    void Update()
    {
        health = healthSystem.health;
        targetColor = color[health - 1];
        globalLight.color = Color.Lerp(globalLight.color, targetColor, Time.deltaTime * 5f);
    }
}

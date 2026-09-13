using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;

    void Start()
    {
        foreach (GameObject prefab in objectsToSpawn)
        {
            if (prefab != null)
            {
                Instantiate(prefab, transform.position, transform.rotation, transform.parent);
            }
        }
        Destroy(gameObject); 
    }
}
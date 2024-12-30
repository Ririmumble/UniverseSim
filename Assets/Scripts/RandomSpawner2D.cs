using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner2D : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject object1; // The first object (e.g., proton)
    public GameObject object2; // The second object (e.g., electron)

    [Header("Spawn Settings")]
    public int object1Count = 10; // Number of object1 to spawn
    public int object2Count = 10; // Number of object2 to spawn

    [Header("Spawn Area")]
    public Vector2 areaSize = new Vector2(48f, 27f); // Width and height of the spawn area

    private void Start()
    {
        // Spawn both types of objects
        SpawnObjects(object1, object1Count);
        SpawnObjects(object2, object2Count);
    }

    private void SpawnObjects(GameObject obj, int count)
    {
        if (obj == null)
        {
            Debug.LogError("No object assigned for spawning.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            // Generate a random position within the defined area
            Vector2 randomPosition = new Vector2(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                Random.Range(-areaSize.y / 2, areaSize.y / 2)
            );

            // Spawn the object at the random position
            Instantiate(obj, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the spawn area in the editor for visualization
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, areaSize.y, 0));
    }
}
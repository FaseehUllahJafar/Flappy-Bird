using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float spawnRate = 1.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 2.0f;

    private void OnEnable()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // Quaternion.identity is similar to no rotation
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}

using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = .1f;
    public float spawnRange = 1f;
    public Transform pipeSpawn;
    
    private float timer = float.MaxValue;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    /// <summary>
    /// returns that the script may begin spawning pipes
    /// </summary>
    public void StartSpawning()
    {
        enabled = true;
    }

    /// <summary>
    /// Spawns the pipes at random along a negative and positive range, and then waits a certain time before spawning another
    /// </summary>
    void SpawnPipe()
    {
        float yOffset = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = pipeSpawn.position + Vector3.up * yOffset;
        Instantiate(pipe, spawnPosition, Quaternion.identity);
    }
}

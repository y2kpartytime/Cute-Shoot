using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] targets;
    public float spawnTimer;
    public float spawnTimeAmount = 5f;

    void Start()
    {
        spawnTimer = spawnTimeAmount;
        SpawnTarget();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnTarget();
            Debug.Log("spawned new target");
            spawnTimer = spawnTimeAmount;
        }
    }

    public void SpawnTarget()
    {
        int randomTarget = Random.Range(0, targets.Length);
        Instantiate(targets[randomTarget], spawnPoint.position, Quaternion.identity);
    }

}

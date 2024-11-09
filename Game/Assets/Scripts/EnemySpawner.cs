using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public int NumberOfEnemies = 5;
    public float SpawnDelay = 1f;
    public List<Alien> Enemies = new List<Alien>();
    public SpawnMethod EnemySpawn = SpawnMethod.Random;
    NavMeshTriangulation Triangulation;

    private Dictionary<int, ObjectPool> EnemyObjectPools = new Dictionary<int, ObjectPool>();

    private void Awake()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            EnemyObjectPools.Add(i, new ObjectPool(Enemies[i], 0, true, 20));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Triangulation = NavMesh.CalculateTriangulation();
        StartCoroutine(SpawnEnemies());
        player = FindAnyObjectByType<Player>().transform.GetChild(0).transform;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemies()
    {

        int SpawnedEnemies = 0;

        while (SpawnedEnemies < NumberOfEnemies)
        {

            if (EnemySpawn == SpawnMethod.Random)
            {
                SpawnRandom();
            }

            SpawnedEnemies++;
            yield return new WaitForSeconds(SpawnDelay);
        }

    }

    private void SpawnRandom()
    {
        DoSpawnEnemy(Random.Range(0, Enemies.Count));
    }

    private void DoSpawnEnemy(int index)
    {
        Alien alien = (Alien)EnemyObjectPools[index].Get();

        if (alien != null)
        {
            //Alien alien = (Alien)pooleableObject;

            //alien.SetPool(EnemyObjectPools[index]);
            int VertexIndex = Random.Range(0, Triangulation.vertices.Length);

            NavMeshHit Hit;
            if (NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 2f, -1))
            {
                alien.Agent.Warp(Hit.position);
                alien.Agent.enabled = true;
            }
        }
    }

    public enum SpawnMethod
    {
        Sequence,
        Random
    }
}

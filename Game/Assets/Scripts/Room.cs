using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    RunSpawn runSpawn;
    public EnemySpawner spawner;
    public Transform respawn;
    public Transform triggers;
    public Boss boss;
    public Transform bossRespawn;
    int x, y;
    public void Start()
    {
        runSpawn = FindAnyObjectByType<RunSpawn>();
        spawner = GetComponentInChildren<EnemySpawner>();
    }

    public void StartRespawn()
    {
        spawner.StartRespawn();
    }
    public void ChangeRoom(int newX, int newY)
    {
        runSpawn.ActiveRoom(new Vector2Int(x + newX, y + newY));
    }

    public void SetX(int newX)
    {
        x = newX;
    }

    public void SetY(int newY)
    {
        y = newY;
    }

    public int GetEnemies()
    {
        if (spawner != null)
        {
            return spawner.NumberOfEnemies;
        }
        return 0;
    }

    public void ActiveTriggers()
    {
        if (triggers != null)
        {
            triggers.gameObject.SetActive(true);
        }
    }

    public void SetEnemies(int newEnemies)
    {
        if (spawner != null)
        {
            spawner.NumberOfEnemies = newEnemies;
        }
    }
    public void RespawnBoss()
    {
        NavMeshHit Hit;

        if (NavMesh.SamplePosition(bossRespawn.position, out Hit, 2f, -1))
        {
            Boss bossI = Instantiate(boss);
            bossI.agent.Warp(Hit.position);
            bossI.agent.enabled = true;
        }
    }
}

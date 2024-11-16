using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    RunSpawn runSpawn;
    public EnemySpawner spawner;
    public Transform respawn;
    public Transform triggers;
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
        return spawner.NumberOfEnemies;
    }

    public void ActiveTriggers()
    {
        triggers.gameObject.SetActive(true);
    }
}

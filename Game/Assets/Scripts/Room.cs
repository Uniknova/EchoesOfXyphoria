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
    public Transform triggerLeft;
    public Transform triggerRight;
    public Transform triggerUp;
    public Transform triggerDown;

    public GameObject wallLeft;
    public GameObject wallRight;
    public GameObject wallUp;
    public GameObject wallDown;
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
        if (runSpawn.roomsDictionary.ContainsKey(new Vector2Int(x + 1, y)))
        {
            triggerRight.gameObject.SetActive(true);
            //wallRight.SetActive(false);

            wallRight.GetComponent<Outline>().enabled = true;
            //wallRight.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (runSpawn.roomsDictionary.ContainsKey(new Vector2Int(x - 1, y)))
        {
            triggerLeft.gameObject.SetActive(true);
            //wallLeft.SetActive(false);

            wallLeft.GetComponent<Outline>().enabled = true;
            //wallLeft.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (runSpawn.roomsDictionary.ContainsKey(new Vector2Int(x, y + 1)))
        {
            triggerUp.gameObject.SetActive(true);
            //wallUp.SetActive(false);

            wallUp.GetComponent<Outline>().enabled = true;
            //wallUp.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (runSpawn.roomsDictionary.ContainsKey(new Vector2Int(x, y - 1)))
        {
            triggerDown.gameObject.SetActive(true);
            //wallDown.SetActive(false);

            wallDown.GetComponent<Outline>().enabled = true;
            //wallDown.GetComponent<BoxCollider>().isTrigger = true;
        }
        //if (triggers != null)
        //{
        //    triggers.gameObject.SetActive(true);
        //}
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    RunSpawn runSpawn;
    int x, y;
    public void Start()
    {
        runSpawn = FindAnyObjectByType<RunSpawn>();
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
}

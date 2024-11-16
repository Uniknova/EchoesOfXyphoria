using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchInfo : MonoBehaviour
{

    public int score;
    public Player player;
    public int killedEnemies;
    public int remainEnemies;
    public Room actualRoom;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        player = FindObjectOfType<Player>();
        score = 0;
    }

    public void Respawn(Transform respawn)
    {
        player.Respawn(respawn);
    }

    public void AddScore(int scoreEnemy)
    {
        Debug.Log("killed enemies " + killedEnemies);
        score += scoreEnemy;
        killedEnemies++;

        if (killedEnemies >= remainEnemies) actualRoom.ActiveTriggers();
    }

    public void SetRoom(Room room)
    {
        actualRoom = room;
        killedEnemies = 0;
        remainEnemies = room.GetEnemies();
    }


}

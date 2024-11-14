using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchInfo : MonoBehaviour
{

    public int score;
    public Player player;
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
        score += scoreEnemy;
    }


}

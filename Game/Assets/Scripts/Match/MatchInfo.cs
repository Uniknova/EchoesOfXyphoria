using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchInfo : MonoBehaviour
{

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        score = 0;
    }

    public void AddScore(int scoreEnemy)
    {
        score += scoreEnemy;
    }


}

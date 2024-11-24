using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Configuration", menuName = "ScriptableObject/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{

    //Enemy Stats
    public float health = 100;
    public float damage = 1.0f;
    public float speed = 3.5f;
    public float speedDown = 1.5f;
    public float fireDamage = 0.5f;
    public float armor = 0;

    public int score = 1;
    public enum type { Normal, Dash, Poison, Tank };
    public type tipo = type.Normal;

    //Default stats
    public float defaulthealth = 100;
    public float defaultdamage = 1.0f;
    public float defaultspeed = 3.5f;
    public float defaultspeedDown = 1.5f;
    public float defaultfireDamage = 0.5f;
    public float defaultarmor = 0;

    public int defaultscore = 1;

    public void ResetStats()
    {
        health = defaulthealth;
        damage = defaultdamage;
        speed = defaultspeed;
        speedDown = defaultspeedDown;
        fireDamage = defaultfireDamage;
        armor = defaultarmor;
        score = defaultscore;
    }

}

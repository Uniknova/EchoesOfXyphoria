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
    public enum type { Normal, Dash };
    public type tipo = type.Normal;

    //Agent Config

}

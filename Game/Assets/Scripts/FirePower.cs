using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirePower : IPowerEnemy
{
    float umbral = 0.1f;
    float damage = 10f;
    int level = 1;

    public void AddPower()
    {
        Debug.Log("Fuego seleccionado");
        Player.Instance.weapon.AddPowerEnemy(this);
    }

    public void UpdateEnemy(IEnemy enemy)
    {
        float random = Random.Range(0f, 1f);
        if (Player.Instance.weapon != null)
        {
            if (random <= umbral) enemy.Fire(damage);
        }
    }

    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 2:
                umbral += 0.05f;
                damage += 10f;
                break;
            case 3:
                umbral += 0.1f;
                break;
            case 4:
                damage += 20f;
                break;
            case 5:
                umbral += 0.15f;
                damage += 20f;
                break;
        }
    }

    public int Level { get { return level; } }
}

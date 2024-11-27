using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownPower : IPowerEnemy
{
    float umbral = 0.25f;
    float speed = 0.75f;
    int duration = 3;
    int level = 1;
    public void UpdateEnemy(IEnemy enemy)
    {
        float random = Random.Range(0f, 1f);
        if (random <= umbral) enemy.SpeedDown(duration, speed);
    }

    public void AddPower()
    {
        Debug.Log("Speed seleccionado");
        if (Player.Instance.weapon != null)
        {
            Player.Instance.weapon.AddPowerEnemy(this);
        }
    }

    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 2:
                umbral += 0.05f;
                speed -= 0.1f;
                break;
            case 3:
                umbral += 0.1f;
                duration++;
                break;
            case 4:
                speed -= 0.15f;
                break;
            case 5:
                umbral += 0.15f;
                speed -= 0.1f;
                duration++;
                break;
        }
    }

    public int GetLevel()
    {
        return level;
    }

}

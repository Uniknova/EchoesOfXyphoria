using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDeathPower : IDeathPower
{
    float hp = 10;
    float umbral = 0.1f;
    int level = 1;
    public void UpdateDeath()
    {
        float random = Random.Range(0f, 1f);
        if (random <= umbral) Player.Instance.PlayerHealth(hp);

    }

    public void AddPower()
    {
        Debug.Log("Health seleccionado");
        Player.Instance.AddDeathPower(this);
    }

    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 2:
                umbral += 0.05f;
                hp += 10f;
                break;
            case 3:
                umbral += 0.1f;
                hp += 10;
                break;
            case 4:
                umbral += 0.05f;
                hp += 10f;
                break;
            case 5:
                umbral += 0.1f;
                hp += 10f;
                break;
        }
    }

    public int GetLevel()
    {
        return level;
    }
}

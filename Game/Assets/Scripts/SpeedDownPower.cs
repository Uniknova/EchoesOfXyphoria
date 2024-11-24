using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownPower : IPowerEnemy
{
    float umbral = 0.4f;
    public void UpdateEnemy(IEnemy enemy)
    {
        float random = Random.Range(0f, 1f);
        if (random <= umbral) enemy.SpeedDown();
    }

    public void AddPower()
    {
        Debug.Log("Speed seleccionado");
        Player.Instance.weapon.AddPowerEnemy(this);
    }

}

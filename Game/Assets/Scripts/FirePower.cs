using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirePower : IPowerEnemy
{
    float umbral = 0.1f;

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
            if (random <= umbral) enemy.Fire();
        }
    }
}

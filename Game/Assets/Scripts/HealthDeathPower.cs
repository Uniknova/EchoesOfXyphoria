using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDeathPower : IDeathPower
{
    float hp;
    float umbral = 0.5f;
    public HealthDeathPower(float hp)
    {
        this.hp = hp;
    }
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
}

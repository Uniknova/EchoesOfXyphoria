using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDeathPower : IDeathPower
{
    Player player;
    float hp;
    float umbral = 0.5f;
    public HealthDeathPower(Player player, float hp)
    {
        this.player = player;
        this.hp = hp;
    }
    public void UpdateDeath()
    {
        float random = Random.Range(0f, 1f);
        if (random <= umbral) player.PlayerHealth(hp);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void TakeDamage(float damage);

    public void Fire();

    public void SpeedDown();
}

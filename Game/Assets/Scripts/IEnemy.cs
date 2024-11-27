using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy: IPooleableObject
{
    public void TakeDamage(float damage);

    public void Fire(float fire);

    public void SpeedDown(int duration, float downSpeed);
}

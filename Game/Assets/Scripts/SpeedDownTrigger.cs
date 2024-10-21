using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            other.GetComponentInChildren<RaycastWeapon>().AddPowerEnemy(new SpeedDownPower());
            Destroy(gameObject);
        }
    }
}

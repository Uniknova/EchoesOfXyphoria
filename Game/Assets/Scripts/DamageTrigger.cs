using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IEnemy>() != null)
        {
            other.GetComponent<IEnemy>().TakeDamage(10);
        }

    }

}

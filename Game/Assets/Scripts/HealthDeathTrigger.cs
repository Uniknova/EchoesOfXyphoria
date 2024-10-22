using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            other.GetComponentInParent<Player>().AddDeathPower(new HealthDeathPower(other.GetComponentInParent<Player>(), 0.2f));
            Destroy(gameObject);
        }
    }
}

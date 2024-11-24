using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private float damage;
    private void Start()
    {
        damage = GetComponentInParent<Alien>().damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null && other.GetComponent<DamageTrigger>() == null)
        {
            Debug.Log("Dano enemigo");
            other.GetComponentInParent<Player>().TakeDamage(damage);
        }
    }
}

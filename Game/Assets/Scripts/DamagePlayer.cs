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
        if (other.GetComponentInParent<Player>() != null)
        {
            Debug.Log("Dano enemigo");
            other.GetComponentInParent<Player>().TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackRadius : MonoBehaviour
{
    private Player player;
    public int damage = 10;
    public float AttackDelay = 0.5f;
    public delegate void AttackEvent(Player target);
    public AttackEvent OnAttack;
    private Coroutine AttackCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        Player target = other.GetComponentInParent<Player>();

        if (target != null)
        {
            player = target;

            if (AttackCoroutine == null)
            {
                AttackCoroutine = StartCoroutine(Attack());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player target = other.GetComponentInParent<Player>();
        if (target != null)
        {
            player = null;

            StopCoroutine(AttackCoroutine);
            AttackCoroutine = null;
        }
    }

    private IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackDelay);

        yield return Wait;

        while (player != null)
        {
            OnAttack?.Invoke(player);
            player.TakeDamage(damage);

            yield return Wait;
        }

        AttackCoroutine = null;
    }

}

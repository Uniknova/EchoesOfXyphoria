using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, IEnemy
{

    public float hp;
    public float dano;
    public float speed;
    public float speedDown;
    public float fireDamage;
    Coroutine FireC;
    Coroutine SpeedDownC;
    MeshRenderer render;
    Color color;
    Player player;
    RaycastWeapon playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        render = GetComponent<MeshRenderer>();
        player = FindAnyObjectByType<Player>();
        playerWeapon = player.GetComponentInChildren<RaycastWeapon>();
        color = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>())
        {
            other.gameObject.GetComponentInParent<Player>().TakeDamage(dano);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponentInParent<Player>())
    //    {
    //        collision.gameObject.GetComponentInParent<Player>().TakeDamage(dano);
    //    }
    //}

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }

    public void Fire()
    {
        if (FireC != null)
        {
            StopCoroutine(FireC);
        }
        FireC = StartCoroutine(FireCoroutine(fireDamage));
    }

    public void SpeedDown()
    {
        if (SpeedDownC != null)
        {
            StopCoroutine (SpeedDownC);
        }
        SpeedDownC = StartCoroutine(SpeedDownCoroutine());
    }

    IEnumerator FireCoroutine(float damage)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Hola");
            render.material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            render.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpeedDownCoroutine()
    {
        speed = 0.1f;
        render.material.color = Color.cyan;
        yield return new WaitForSeconds(3);
        speed = 1f;
        render.material.color = color;
    }

    public void Death()
    {
        player.UpdateDeathPowers();
    }
}

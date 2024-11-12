using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Alien : MonoBehaviour, IEnemy, IPooleableObject
{

    public float hp;
    public float maxhp;
    public float damage;
    public float speed;
    public float speedDown;
    public float fireDamage;
    public float armor;

    public float dashProb;

    public float dashSpeed;
    public float dashTime;

    public enum type { Normal, Dash, Poison, Tank }
    public type tipo;
    Coroutine FireC;
    Coroutine SpeedDownC;
    Coroutine DashC;
    MeshRenderer render;
    Color color;
    Player player;

    MatchInfo match;

    public EnemyScriptableObject enemyScriptableObject;
    //RaycastWeapon playerWeapon;

    public IObjectPool pool;

    public NavMeshAgent Agent;

    public bool Active
    {
        get
        {
            return gameObject.activeSelf;
        }

        set
        {
            gameObject.SetActive(value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxhp = enemyScriptableObject.health;
        hp = maxhp;
        damage = enemyScriptableObject.damage;
        speed = enemyScriptableObject.speed;
        speedDown = enemyScriptableObject.speedDown;
        fireDamage = enemyScriptableObject.fireDamage;
        armor = enemyScriptableObject.armor;
        tipo = (type)enemyScriptableObject.tipo;



        //hp = 100;
        render = GetComponent<MeshRenderer>();
        player = FindAnyObjectByType<Player>();
        match = FindAnyObjectByType<MatchInfo>();
        //playerWeapon = player.GetComponentInChildren<RaycastWeapon>();
        if (render!=null)
            color = render.material.color;
        Agent = GetComponent<NavMeshAgent>();
        //speed = 3.5f;
        //speedDown = 1.5f;
        Agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Agent.enabled)
            {
                Agent.SetDestination(player.transform.GetChild(0).transform.position);
            }
        }

        else
        {
            player = FindAnyObjectByType<Player>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>())
        {
            other.gameObject.GetComponentInParent<Player>().TakeDamage(damage);

            if (tipo == type.Poison) other.gameObject.GetComponentInParent<Player>().PoisonPlayer(damage);
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


        if (tipo == type.Dash)
        {
            if (Random.Range(0, 1) <= dashProb && DashC == null)
            {
                DashC = StartCoroutine(DashCoroutine());
                return;
            }
        }

        float aux = Mathf.Max(1, damage - armor);
        hp -= aux;
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
            StopCoroutine(SpeedDownC);
        }
        SpeedDownC = StartCoroutine(SpeedDownCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            Debug.Log("Corutina");
            Agent.Move(Agent.transform.forward * dashSpeed * Time.deltaTime);

            yield return null;
        }

        DashC = null;
    }

    IEnumerator FireCoroutine(float fire)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Hola");
            if (render != null)
                render.material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            if (render != null)
                render.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpeedDownCoroutine()
    {
        Agent.speed = speedDown;
        if (render != null)
            render.material.color = Color.cyan;
        yield return new WaitForSeconds(3);
        Agent.speed = speed;
        if (render != null)
            render.material.color = color;
    }

    public void Death()
    {
        pool?.Release(this);
        player.UpdateDeathPowers();
        match.score += enemyScriptableObject.score;

    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        maxhp = enemyScriptableObject.health;
        hp = maxhp;
        damage = enemyScriptableObject.damage;
        speed = enemyScriptableObject.speed;
        speedDown = enemyScriptableObject.speedDown;
        fireDamage = enemyScriptableObject.fireDamage;
        armor = enemyScriptableObject.armor;
        tipo = (type)enemyScriptableObject.tipo;
        Agent.speed = speed;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public IPooleableObject Clone()
    {
        GameObject go;
        go = Instantiate(gameObject);

        Alien alien = go.GetComponent<Alien>();
        //alien.Agent.enabled = false;

        return alien;
    }

    public void SetPool(IObjectPool pool)
    {
        this.pool = pool;
    }

}

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
    //public float speedDown;
    //public float fireDamage;
    public float armor;

    public float dashProb;

    public float dashSpeed;
    public float dashTime;
    public float distanceAttack = 2f;

    public GameObject trigger;

    public enum type { Normal, Dash, Poison, Tank }
    public type tipo;
    Coroutine FireC;
    Coroutine SpeedDownC;
    Coroutine DashC;
    MeshRenderer render;
    Color color;
    Player player;

    public SkinnedMeshRenderer rend;

    MatchInfo match;

    public EnemyScriptableObject enemyScriptableObject;
    //RaycastWeapon playerWeapon;

    public IObjectPool pool;

    public NavMeshAgent Agent;

    public Animator animator;
    public const string animatorAtacar = "Atacar";

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
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        maxhp = enemyScriptableObject.health;
        hp = maxhp;
        damage = enemyScriptableObject.damage;
        speed = enemyScriptableObject.speed;
        //speedDown = enemyScriptableObject.speedDown;
        //fireDamage = enemyScriptableObject.fireDamage;
        armor = enemyScriptableObject.armor;
        tipo = (type)enemyScriptableObject.tipo;



        //hp = 100;
        render = GetComponent<MeshRenderer>();
        player = FindAnyObjectByType<Player>();
        match = FindAnyObjectByType<MatchInfo>();
        //playerWeapon = player.GetComponentInChildren<RaycastWeapon>();
        if (rend != null)
            color = rend.material.color;
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
                if (Vector3.Distance(Agent.transform.position, player.transform.GetChild(0).transform.position) < distanceAttack)
                {
                    Agent.isStopped = true;
                    if (animator != null)
                    {
                        animator.SetBool(animatorAtacar, true);
                    }
                }

                else
                {
                    Agent.isStopped = false;
                    Agent.SetDestination(player.transform.GetChild(0).transform.position);
                }
                if (tipo == type.Dash)
                {
                    //if (Random.Range(0, 10) <= 1 && DashC == null)
                    //{
                    //    DashC = StartCoroutine(DashCoroutine());
                    //}
                }
            }
        }

        else
        {
            player = FindAnyObjectByType<Player>();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponentInParent<Player>() && other.gameObject.GetComponent<DamageTrigger>() == null)
    //    {
    //        other.gameObject.GetComponentInParent<Player>().TakeDamage(damage);

    //        if (tipo == type.Poison) other.gameObject.GetComponentInParent<Player>().PoisonPlayer(damage);
    //    }
    //}
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
            if (Random.Range(0.0f,1) <= dashProb && DashC == null)
            {
                DashC = StartCoroutine(DashCoroutine());
                return;
            }
        }

        float aux = Mathf.Max(5, damage - armor);
        hp -= aux;
        if (hp <= 0)
        {
            //animator.SetBool("Muerte", true);
            Death();
        }
    }

    public void Fire(float fire)
    {
        if (FireC != null)
        {
            StopCoroutine(FireC);
        }
        FireC = StartCoroutine(FireCoroutine(fire));
    }

    public void SpeedDown(int duration, float downSpeed)
    {
        if (SpeedDownC != null)
        {
            StopCoroutine(SpeedDownC);
        }
        SpeedDownC = StartCoroutine(SpeedDownCoroutine(duration, downSpeed));
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            //Debug.Log("Corutina");
            Agent.Move(Agent.transform.forward * dashSpeed * Time.deltaTime);

            yield return null;
        }

        DashC = null;
    }

    IEnumerator FireCoroutine(float fire)
    {
        for (int i = 0; i < 3; i++)
        {
            if (rend != null)
                rend.material.color = Color.red;
            TakeDamage(fire);
            yield return new WaitForSeconds(0.5f);
            if (rend != null)
                rend.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpeedDownCoroutine(int duration, float downSpeed)
    {
        Agent.speed = speed * downSpeed;
        if (rend != null)
            rend.material.color = Color.cyan;
        yield return new WaitForSeconds(duration);
        Agent.speed = speed;
        if (rend != null)
            rend.material.color = color;
    }

    public void Death()
    {
        AudioManager.PlaySound(SoundType.MUERTEA, 2f);
        int coin = Random.Range(enemyScriptableObject.minCoin,enemyScriptableObject.maxCoin + 1);
        Coins.AddCoins(coin);
        float rand = Random.Range(0f, 100f);
        if (rand <= Player.coinProbability)
        {
            coin = Random.Range(enemyScriptableObject.minCoin, enemyScriptableObject.maxCoin + 1);
            Coins.AddCoins(coin);
        }
        pool?.Release(this);
        player.UpdateDeathPowers();
        match.AddScore(enemyScriptableObject.score);
        //match.score += enemyScriptableObject.score;

    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        maxhp = enemyScriptableObject.health;
        hp = maxhp;
        damage = enemyScriptableObject.damage;
        speed = enemyScriptableObject.speed;
        //speedDown = enemyScriptableObject.speedDown;
        //fireDamage = enemyScriptableObject.fireDamage;
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, IEnemy
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

    Coroutine FireC;
    Coroutine SpeedDownC;
    Coroutine DashC;
    MeshRenderer render;
    public SkinnedMeshRenderer rend;
    Color color;

    public EnemyScriptableObject enemyScriptableObject;


    public NavMeshAgent agent;
    public Bullet bulletPrefab;
    public Vector3 BulletSpawnOffset = new Vector3(0, 1, 0);
    public LayerMask Mask;
    private ObjectPool bulletPool;
    [SerializeField]
    private float SpherecastRadius = 0.1f;
    private RaycastHit Hit;
    private Player player;
    public SphereCollider col;
    public Coroutine AttackC;
    public Coroutine LookC;
    public float attackDelay = 1f;
    public MatchInfo matchInfo;
    public Animator animator;

    public float speedRotation = 1f;
    public bool Active { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public IPooleableObject Clone()
    {
        throw new System.NotImplementedException();
    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        return;
        //throw new System.NotImplementedException();
    }

    public void SetPool(IObjectPool pool)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        if (Random.Range(0.0f, 1) <= dashProb && DashC == null)
        {
            DashC = StartCoroutine(DashCoroutine());
            return;
        }

        float aux = Mathf.Max(1, damage - armor);
        hp -= aux;
        if (hp <= 0)
        {
            Death();
        }
    }

    private void Awake()
    {
        maxhp = enemyScriptableObject.health;
        hp = maxhp;
        damage = enemyScriptableObject.damage;
        speed = enemyScriptableObject.speed;
        //speedDown = enemyScriptableObject.speedDown;
        //fireDamage = enemyScriptableObject.fireDamage;
        armor = enemyScriptableObject.armor;
        //render = GetComponent<MeshRenderer>();
        //color = render.material.color;

        bulletPool = new ObjectPool(bulletPrefab, 0, true, 30);
        player = FindAnyObjectByType<Player>();
        col = GetComponent<SphereCollider>();
        if (rend != null)
            color = rend.material.color;
        agent = GetComponent<NavMeshAgent>();
        matchInfo = FindObjectOfType<MatchInfo>();
    }

    private IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(attackDelay);

        yield return Wait;

        while (true)
        {
            //StartRotating();
            //if (HasLineOfSightTo(player.gameObject.transform.GetChild(0).transform))
            //{

            //agent.enabled = false;

            Bullet bullet = (Bullet)bulletPool.Get();

            bullet.transform.position = transform.position + BulletSpawnOffset;
            bullet.transform.rotation = agent.transform.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(agent.transform.forward * bulletPrefab.MoveSpeed, ForceMode.VelocityChange);
            bullet.BulletCoroutine(bullet);
            //}

            //else
            //{
            //    break;
            //}

            yield return Wait;
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

        Vector3 direction;

        int idx = Random.Range(0, 3);

        if (idx == 0) direction = -agent.transform.forward;
        else if (idx == 1) direction = agent.transform.right;
        else direction = -agent.transform.right;

        while (Time.time < startTime + dashTime)
        {
            agent.Move(direction * dashSpeed * Time.deltaTime);

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
        agent.speed = speed * downSpeed;
        if (rend != null)
            rend.material.color = Color.cyan;
        yield return new WaitForSeconds(duration);
        agent.speed = speed;
        if (rend != null)
            rend.material.color = color;
    }

    public void Death()
    {
        AudioManager.PlaySound(SoundType.MUERTEA, 2f);
        player.UpdateDeathPowers();
        matchInfo.AddScore(enemyScriptableObject.score);
        PowerUpsCanvas.Instance.Init();
        Destroy(gameObject);
        //matchInfo.EndLevel();
    }

    public void StartRotating()
    {

        if (LookC == null)
        {
            LookC = StartCoroutine(LookAt());
        }
        //if (LookC != null)
        //{
        //    StopCoroutine(LookC);
        //}

        //LookC = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.transform.GetChild(0).transform.position - transform.position);
        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * speedRotation;

            yield return null;
        }

        LookC = null;
    }


    private bool HasLineOfSightTo(Transform Target)
    {
        if (Physics.SphereCast(transform.position + BulletSpawnOffset, SpherecastRadius, ((Target.position + BulletSpawnOffset) - (transform.position + BulletSpawnOffset).normalized), out Hit, 10, Mask))
        {
            return Hit.collider.GetComponentInParent<Player>() != null;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.GetChild(0).transform.position, agent.transform.position) < (agent.stoppingDistance + 1))
        {
            StartRotating();
            if (AttackC == null)
            {
                animator.SetBool("Atacar", true);
                Debug.Log("Hola");
                AttackC = StartCoroutine(Attack());
            }
        }

        else if (AttackC != null)
        {
            animator.SetBool("Atacar", false);
            StopCoroutine(AttackC);
            AttackC = null;
        }
        if (player != null)
        {
            if (agent.enabled && Vector3.Distance(player.transform.GetChild(0).transform.position, agent.transform.position) < (agent.stoppingDistance - 0.5f))
            {
                Vector3 direction = player.transform.GetChild(0).transform.position - agent.transform.position;
                agent.velocity = Vector3.Lerp(agent.desiredVelocity, -direction.normalized * agent.speed, 1);
            }
            else if (agent.enabled)
            {
                agent.SetDestination(player.transform.GetChild(0).transform.position);
            }
        }

        else
        {
            player = FindAnyObjectByType<Player>();
        }
    }
}

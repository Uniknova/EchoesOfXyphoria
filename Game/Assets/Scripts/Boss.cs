using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, IEnemy
{

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

    public void Fire()
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

    public void SpeedDown()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        bulletPool = new ObjectPool(bulletPrefab, 0, true, 30);
        player = FindAnyObjectByType<Player>();
        col = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
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
            //}

            //else
            //{
            //    break;
            //}

            yield return Wait;
        }
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
                Debug.Log("Hola");
                AttackC = StartCoroutine(Attack());
            }
        }

        else if (AttackC != null)
        {
            StopCoroutine(AttackC);
            AttackC = null;
        }
        if (player != null)
        {
            if (agent.enabled)
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

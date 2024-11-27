using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
        public Transform canon;
    }
    public bool escopeta;
    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000.0f;
    public float damage;
    public float bulletDrop = 0.0f;
    public Transform canon;
    public List<Transform> canons = new List<Transform>();
    public Transform raycastDestination;
    public TrailRenderer tracerEffect;

    public List<IPowerEnemy> powerEnemyList;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    public float reloadTime;
    float acumulatedReloadTime;
    List<Bullet> bullets = new List<Bullet>();
    public float maxLifeTime = 6f;
    public bool entra;

    Vector3 GetPosition(Bullet bullet)
    {
        // p + v * t + 0.5 * g * t * t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    public void SetRaycastDestination(Transform target)
    {
        raycastDestination = target;
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity, Transform can)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.canon = can;
        bullet.tracer = Instantiate(tracerEffect, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }


    private void Start()
    {
        powerEnemyList = new List<IPowerEnemy>();
        acumulatedReloadTime = reloadTime;
        entra = false;

    }

    private void Update()
    {
        acumulatedReloadTime += Time.deltaTime;
    }
    public void StartFiring()
    {
        
        
        if (acumulatedReloadTime >= reloadTime)
        {
            isFiring = true;
            acumulatedReloadTime = 0.0f;
            accumulatedTime = 0.0f;
            FireBullet();
        }
    }

    public void UpdateFiring(float delta)
    {
        //acumulatedReloadTime += delta;
        

        if (acumulatedReloadTime >= reloadTime || entra)
        {
            entra = true;
            accumulatedTime += delta;
            float fireInterval = 1.0f / fireRate;
            while (accumulatedTime >= 0.0f)
            {
                FireBullet();
                accumulatedTime -= fireInterval;
            }
            acumulatedReloadTime = 0.0f;
        }

    }

    public void UpdateBullets(float delta)
    {
        SimulateBullets(delta);
        DestroyBullets();
    }

    void SimulateBullets(float delta)
    {
        foreach (var b in bullets)
        {
            Vector3 p0 = GetPosition(b);
            b.time += delta;
            Vector3 p1 = GetPosition(b);
            RaycastSegment(p0, p1, b);
        }
    }

    public FirePower GetFire()
    {
        foreach(IPowerEnemy e in powerEnemyList)
        {
            if (e.GetType() == typeof(FirePower))
            {
                return (FirePower)e;
            }
        }

        return null;
    }

    void DestroyBullets()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifeTime);
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction;
        direction = end - start;

        if (escopeta)
        {
            direction = bullet.canon.forward;
        }
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = end - start;

        if (escopeta)
        {
            ray.direction = bullet.canon.forward;

        }
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.GetComponent<IEnemy>() != null)
                {
                    hitInfo.collider.GetComponent<IEnemy>().TakeDamage(damage);
                    foreach (IPowerEnemy e in powerEnemyList)
                    {
                        Debug.Log("intento");
                        e.UpdateEnemy(hitInfo.collider.GetComponent<IEnemy>());
                    }
                    //hitInfo.collider.GetComponent<IEnemy>().Fire();
                }
            }
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            if (bullet.tracer != null)
            {
                bullet.tracer.transform.position = hitInfo.point;
            }
            bullet.time = maxLifeTime;
        }

        else
        {
            if (bullet.tracer != null)
            {
                bullet.tracer.transform.position = end;
            }
        }
    }

    private void FireBullet()
    {
        if (escopeta)
        {
            foreach (Transform t in canons)
            {
                Vector3 velocity = (t.forward).normalized * bulletSpeed;
                var bullet = CreateBullet(canon.position, velocity, t);
                bullets.Add(bullet);
            }

        }

        else
        {
            Vector3 velocity = (raycastDestination.position - canon.position).normalized * bulletSpeed;
            var bullet = CreateBullet(canon.position, velocity, canon);
            bullets.Add(bullet);
        }


        //ray.origin = canon.position;
        ////transform.position = raycastDestination.position;
        //ray.direction = raycastDestination.position - canon.position;

        //var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        //tracer.AddPosition(ray.origin);

        //if (Physics.Raycast(ray, out hitInfo))
        //{

        //    //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
        //    tracer.transform.position = hitInfo.point;
        //}
    }

    public void StopFiring()
    {
        isFiring = false;
        entra = false;
        accumulatedTime = 0.0f;
        //acumulatedReloadTime = 0;
    }

    public void AddPowerEnemy(IPowerEnemy powerEnemy)
    {
        powerEnemyList.Add(powerEnemy);
    }

    public void RemoveAllPowers()
    {
        foreach(IPowerEnemy powerEnemy in powerEnemyList)
        {
            powerEnemyList.Remove(powerEnemy);
        }
    }
}

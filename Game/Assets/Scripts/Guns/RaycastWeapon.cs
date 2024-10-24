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
    }
    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000.0f;
    public float damage;
    public float bulletDrop = 0.0f;
    public Transform canon;
    public Transform raycastDestination;
    public TrailRenderer tracerEffect;

    public List<IPowerEnemy> powerEnemyList;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    List<Bullet> bullets = new List<Bullet>();
    float maxLifeTime = 6f;

    Vector3 GetPosition(Bullet bullet)
    {
        // p + v * t + 0.5 * g * t * t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.tracer = Instantiate(tracerEffect, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }


    private void Start()
    {
        powerEnemyList = new List<IPowerEnemy>();
    }
    public void StartFiring()
    {
        isFiring = true;
        accumulatedTime = 0.0f;
        FireBullet();
    }

    public void UpdateFiring(float delta)
    {
        accumulatedTime += delta;
        float fireInterval = 1.0f / fireRate;
        while (accumulatedTime >= 0.0f)
        {
            FireBullet();
            accumulatedTime -= fireInterval;
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

    void DestroyBullets()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifeTime);
    }

    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = end - start;
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
            bullet.tracer.transform.position = hitInfo.point;
            bullet.time = maxLifeTime;
        }

        else
        {
            bullet.tracer.transform.position = end;
        }
    }

    private void FireBullet()
    {
        Vector3 velocity = (raycastDestination.position - canon.position).normalized * bulletSpeed;
        var bullet = CreateBullet(canon.position, velocity);
        bullets.Add(bullet);


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
    }

    public void AddPowerEnemy(IPowerEnemy powerEnemy)
    {
        powerEnemyList.Add(powerEnemy);
    }
}

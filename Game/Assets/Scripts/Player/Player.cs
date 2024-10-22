using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public float hp;
    public float hpMax;
    private bool isTouching;
    public Transform collision;
    public LayerMask collisionMask;
    public float radius = 0.3f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform Hand;
    public List<GameObject> weapons;
    public List<IDeathPower> deathPowers;
    public int indexWeapon;
    public bool lowHp;

    RaycastWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
        weapons = new List<GameObject>();
        deathPowers = new List<IDeathPower>();
        indexWeapon = -1;
        lowHp = false;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        { 
            Vector3 move = transform.right * Input.GetAxis("Horizontal");

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            Vector3 move = transform.forward * Input.GetAxis("Vertical");

            controller.Move(move * speed * Time.deltaTime);
        }
        
        isTouching = Physics.CheckSphere(collision.position, radius, collisionMask);

        if (isTouching && velocity.y < 0)
        {
            velocity.y = -3f;

        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (weapon == null) return;
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFiring();
        }
        if (weapon.isFiring)
        {
            weapon.UpdateFiring(Time.deltaTime);
        }
        weapon.UpdateBullets(Time.deltaTime);
        if (Input.GetButtonUp("Fire1"))
        {
            weapon.StopFiring();
        }
    }

    public void PlayerMathc()
    {
        transform.position = Vector3.zero;
        transform.GetChild(0).transform.localPosition = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        weapon = weapons[indexWeapon].GetComponent<RaycastWeapon>();
        weapon.enabled = true;
    }

    public void PlayerHealth(float health)
    {
        hp = Mathf.Min(100, hp + health);
        if (hp >= (hpMax * 0.2f) && lowHp)
        {
            weapon.fireRate /= 3;
            speed /= 2;
            lowHp = false;
        }
        Debug.Log("Cura");
    }

    public void UpdateDeathPowers()
    {
        foreach (IDeathPower power in deathPowers)
        {
            power.UpdateDeath();
        }
    }

    public void AddDeathPower(IDeathPower power)
    {
        deathPowers.Add(power);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= (hpMax * 0.2f))
        {
            weapon.fireRate *= 3;
            speed *= 2;
            lowHp = true;
        }
    }
}

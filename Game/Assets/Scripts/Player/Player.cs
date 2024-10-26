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

    public bool gravedad;

    private static Player instance;

    RaycastWeapon weapon;

    //public static Player Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {

    //        }
    //    }
    //}

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
        weapons = new List<GameObject>();
        deathPowers = new List<IDeathPower>();
        indexWeapon = -1;
        lowHp = false;
        gravedad = false;
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButton("Horizontal"))
            {
                Vector3 move = transform.right * Input.GetAxis("Horizontal");
                //Debug.Log(move);

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


        //controller.Move(velocity * Time.deltaTime);

    }

    private void LateUpdate()
    {
        if (gravedad)
        {
            controller.Move(velocity * Time.deltaTime);
        }
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

    public void PlayerMathc(Transform respawn)
    {
        controller.enabled = false;
        Debug.Log(controller.transform.localPosition);
        //transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
        //Transform aux = transform;
        //controller.transform.position = Vector3.zero;

        transform.position = Vector3.zero;
        controller.transform.localPosition = respawn.position;
        //transform.position = respawn.position;
        //controller.transform.position = Vector3.zero;
        //transform.position = Vector3.zero;
        //controller.transform.position = new Vector3 (respawn.position.x + aux.position.x, respawn.position.y + aux.position.y, respawn.position.z + aux.position.z);
        //Debug.Log(controller.transform.localPosition);


        if (weapons.Count > 0)
        {
            weapon = weapons[indexWeapon].GetComponent<RaycastWeapon>();
            weapon.enabled = true;
        }
        Debug.Log(controller.transform.localPosition);
        //gravedad = true;
        Debug.Log(controller.transform.localPosition);
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
        if (hp <= (hpMax * 0.2f) && !lowHp)
        {
            weapon.fireRate *= 3;
            speed *= 2;
            lowHp = true;
        }
    }
}

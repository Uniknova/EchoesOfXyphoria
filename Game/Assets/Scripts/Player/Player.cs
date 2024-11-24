using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Color = UnityEngine.Color;

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
    public Transform HandL;
    public List<GameObject> weapons;
    public List<IDeathPower> deathPowers;
    public int indexWeapon;
    public int indexMelee;

    public List<Melee> meleeWeapons;
    public bool lowHp;
    public bool lowPower;
    private bool andar;
    private const string andarAnimator = "Andar";
    private const string meleeAnimator = "Melee";
    private const string armaAnimator = "Arma";
    MeshRenderer render;
    Color color;

    public bool disparoMovil;

    public Transform Target;

    public Animator animatorPlayer;

    Coroutine PoisonC;

    public bool gravedad;

    private static Player instance;

    public RaycastWeapon weapon;

    public Melee melee;

    public SkinnedMeshRenderer playerMaterial;

    public Uivida vidaUi;


    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<Player>("Player"));
                //instance = new Player();
            }

            return instance;
        }
    }

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
        //vidaUi = Uivida.Instance;
        //PowerUpsCanvas.Instance.Init();
        DataInfo.Instance.GetPlatform();
        disparoMovil = false;
        lowPower = false;
        render = GetComponentInChildren<MeshRenderer>();
        if (playerMaterial != null)
            color = playerMaterial.material.color;
        weapon = GetComponentInChildren<RaycastWeapon>();
        weapons = new List<GameObject>();
        meleeWeapons = new List<Melee>();
        deathPowers = new List<IDeathPower>();
        indexWeapon = -1;
        indexMelee = -1;
        lowHp = false;
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        andar = false;
        if (Input.GetButton("Horizontal"))
        {
            andar = true;
            Vector3 move = transform.right * Input.GetAxis("Horizontal");
            //Debug.Log(move);

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            andar = true;
            Vector3 move = transform.forward * Input.GetAxis("Vertical");

            controller.Move(move * speed * Time.deltaTime);
        }


        animatorPlayer.SetBool(andarAnimator, andar);
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
        if (weapon == null && melee == null) return;
        if (Input.GetButtonDown("Fire1") || disparoMovil)
        {
            //if (weapon != null)
            //{
            //    weapon.StartFiring();
            //}

            if (melee != null)
            {
                melee.Attack();
                animatorPlayer.SetTrigger(meleeAnimator);
            }
        }

        if (Input.GetButton("Fire1") || disparoMovil)
        {
            if (weapon != null)
            {
                weapon.UpdateFiring(Time.deltaTime);
                weapon.UpdateBullets(Time.deltaTime);
            }

        }

        //if (weapon != null)
        //{
        //    if (weapon.isFiring)
        //    {
        //        weapon.UpdateFiring(Time.deltaTime);
        //    }
        //    weapon.UpdateBullets(Time.deltaTime);
        //}

        if (Input.GetButtonUp("Fire1"))
        {
            if (weapon != null)
            {
                weapon.StopFiring();
            }

            else
            {
                //animatorPlayer.SetBool(meleeAnimator, false);
            }

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
            if (weapons[indexWeapon].activeSelf == true)
            {
                animatorPlayer.SetBool(armaAnimator, true);
                weapon = weapons[indexWeapon].GetComponentInChildren<RaycastWeapon>();
                weapon.SetRaycastDestination(Target);
                weapon.enabled = true;
            }
        }

        if (meleeWeapons.Count > 0)
        {
            if (meleeWeapons[indexMelee].meleeL.activeSelf == true)
            {
                melee = meleeWeapons[indexMelee];
            }
        }
    }

    public void Respawn(Transform respawn)
    {
        controller.Move(Vector3.zero);
        controller.enabled = false;
        transform.position = Vector3.zero;
        controller.transform.localPosition = respawn.position;

        if (weapons.Count > 0)
        {
            if (weapons[indexWeapon].activeSelf == true)
            {
                animatorPlayer.SetBool(armaAnimator, true);
                weapon = weapons[indexWeapon].GetComponentInChildren<RaycastWeapon>();
                weapon.SetRaycastDestination(Target);
                weapon.enabled = true;
            }
        }

        if (meleeWeapons.Count > 0)
        {
            if (meleeWeapons[indexMelee].meleeL.activeSelf == true)
            {
                melee = meleeWeapons[indexMelee];
            }
        }

        //if (weapons.Count > 0)
        //{
        //    weapon = weapons[indexWeapon].GetComponentInChildren<RaycastWeapon>();
        //    weapon.enabled = true;
        //}
        controller.enabled = true;
    }

    public void PlayerHealth(float health)
    {
        hp = Mathf.Min(100, hp + health);
        if (hp >= (hpMax * 0.2f) && lowHp && lowPower)
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

    public void RemoveAllPowers()
    {
        foreach (var power in deathPowers)
        {
            deathPowers.Remove(power);
        }
        lowPower = false;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
        if (vidaUi != null) vidaUi.fill.fillAmount = hp/hpMax;
        if (hp <= (hpMax * 0.2f) && !lowHp && lowPower)
        {
            weapon.fireRate *= 3;
            speed *= 2;
            lowHp = true;
        }
    }

    public void PoisonPlayer(float damage)
    {
        if (PoisonC != null)
        {
            StopCoroutine(PoisonC);
        }
        PoisonC = StartCoroutine(PoisonCoroutine(damage * 0.2f));
    }

    IEnumerator PoisonCoroutine(float damage)
    {
        for (int i = 0; i < 3; i++)
        {
            TakeDamage(damage);
            playerMaterial.material.color = Color.green;
            yield return new WaitForSeconds(0.5f);
            playerMaterial.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void DeleteWeapons()
    {
        foreach (var weapon in weapons)
        {
            if (weapon != null) Destroy(weapon);
        }

        if (meleeWeapons != null)
        {
            foreach (var me in meleeWeapons)
            {
                if (me != null)
                {
                    //meleeWeapons.Remove(me);
                    Destroy(me.meleeL);
                    Destroy(me.meleeR);

                }
            }
        }

        if (weapon != null) Destroy(weapon);
        if (melee != null)
        {
            Destroy(melee.meleeL);
            Destroy(melee.meleeR);
            melee = null;
        }
    }

    public void RestartPlayer()
    {
        animatorPlayer.SetBool(armaAnimator, false);
        hp = hpMax;
        
        DeleteWeapons();
        lowPower = false;
        render = GetComponentInChildren<MeshRenderer>();
        if (render != null)
            color = render.material.color;
        weapon = GetComponentInChildren<RaycastWeapon>();
        weapons = new List<GameObject>();
        meleeWeapons = new List<Melee>();
        deathPowers = new List<IDeathPower>();
        indexWeapon = -1;
        indexMelee = -1;
        lowHp = false;
    }

    public void Death()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY);
    }

    public void SetMaterial(Material material)
    {
        playerMaterial.material = material;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using Color = UnityEngine.Color;

public class Player : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public float hp;
    public static float hpMax = 100;
    public static float extraDamage = 0;
    public static float coinProbability = 0;
    [SerializeField] private static float armor = 0;
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

    public float damageMultiplier;
    public float speedMultiplier;
    public float hpMultiplier;
    public int level;

    private float defaultspeed;
    private float defaultdamage;

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

    public int movil;


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

    public static void SetArmor()
    {
        armor = DataInfo.GetArmor();
        Debug.Log(armor);
    }

    public static float GetArmor()
    {
        return armor;
    }

    public static void SetHp()
    {
        hpMax = 100 + DataInfo.GetHp();
        instance.hp = hpMax;
        Debug.Log(hpMax);
    }

    public static void SetDamage()
    {
        extraDamage = DataInfo.GetDamage();
        Debug.Log(extraDamage);
    }

    public static void SetCoin()
    {
        coinProbability = DataInfo.GetCoin();
        Debug.Log(coinProbability);
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
        //armor = DataInfo.GetArmor();
        MiniMap.Instance.Init();
        defaultspeed = speed;
        movil = DataInfo.Instance.GetPlatform();
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
        level = 1;
        damageMultiplier = 1.5f;
        speedMultiplier = 1.2f;
        hpMultiplier = 0.15f;
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        andar = false;
        if (Input.GetButton("Horizontal"))
        {
            andar = true;
            Vector3 move = -transform.forward * Input.GetAxis("Horizontal");
            //Debug.Log(move);

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            andar = true;
            Vector3 move = transform.right * Input.GetAxis("Vertical");

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

        if (movil == 1)
        {
            if (Input.GetButtonDown("Fire1"))
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

            if (Input.GetButton("Fire1"))
            {
                if (weapon != null)
                {
                    weapon.UpdateFiring(Time.deltaTime);
                    //weapon.UpdateBullets(Time.deltaTime);
                }

            }

        }

        else
        {
            if (disparoMovil)
            {
                if (melee != null)
                {
                    melee.Attack();
                    animatorPlayer.SetTrigger(meleeAnimator);
                }

                if (weapon != null)
                {
                    weapon.UpdateFiring(Time.deltaTime);
                    //weapon.UpdateBullets(Time.deltaTime);
                }
            }
        }

        if (weapon != null) weapon.UpdateBullets(Time.deltaTime);

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
                weapon.totalDamage = weapon.damage + weapon.damage * extraDamage;
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
                weapon.totalDamage = weapon.damage + weapon.damage * (extraDamage/100f);
                defaultdamage = weapon.totalDamage;
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
        if (vidaUi != null)
        {
            vidaUi.fill.fillAmount = hp / hpMax;
            vidaUi.Text.text = hp.ToString() + "/" + hpMax.ToString();
        }
        if (hp >= (hpMax * hpMultiplier) && lowHp && lowPower)
        {
            weapon.totalDamage = defaultdamage;
            speed = defaultspeed;
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
        float aux = Mathf.Max(2, damage - armor);
        hp -= aux;
        //hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
        if (vidaUi != null)
        {
            vidaUi.fill.fillAmount = hp / hpMax;
            vidaUi.Text.text = hp.ToString() + "/" + hpMax.ToString();
        }
        if (hp <= (hpMax * hpMultiplier) && !lowHp && lowPower)
        {
            weapon.totalDamage = defaultdamage * damageMultiplier;
            speed = defaultspeed * speedMultiplier;
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
        damageMultiplier = 1.5f;
        speedMultiplier = 1.2f;
        hpMultiplier = 0.15f;

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
        AudioManager.PlaySound(SoundType.MUERTEPJ, 2f);
        MatchInfo.Instance.SetGameOver();
        gameObject.SetActive(false);
        
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY);
    }

    public void SetMaterial(Material material)
    {
        playerMaterial.material = material;
    }

    public void LevelUp()
    {
        level++;
        switch (level)
        {
            case 2:
                hpMultiplier += 0.05f;
                damageMultiplier += 0.2f;
                speedMultiplier += 0.1f;
                break;
            case 3:
                damageMultiplier += 0.3f;
                speedMultiplier += 0.15f;
                break;
            case 4:
                hpMultiplier += 0.05f;
                damageMultiplier += 0.1f;
                speedMultiplier += 0.15f;
                break;
            case 5:
                hpMultiplier += 0.1f;
                damageMultiplier += 0.3f;
                speedMultiplier += 0.15f;
                break;
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public HealthDeathPower GetHealthDeath()
    {
        foreach (IDeathPower h in deathPowers)
        {
            if (h.GetType() == typeof(HealthDeathPower)) return (HealthDeathPower)h;
        }

        return null;
    }
}

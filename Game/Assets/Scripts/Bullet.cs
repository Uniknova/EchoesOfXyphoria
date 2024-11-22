using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IPooleableObject
{
    IObjectPool pool;

    public float AutoDestroyTime = 5f;
    public float MoveSpeed = 2f;
    public int damage = 5;
    public Rigidbody rigidbod;


    private void Awake()
    {
        rigidbod = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null)
        {
            pool?.Release(this);
            player.TakeDamage(damage);
        }

        
        //Disable();
    }

    private void Disable()
    {
        rigidbod.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

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

    public IPooleableObject Clone()
    {
        GameObject go;
        go = Instantiate(gameObject);

        Bullet bullet = go.GetComponent<Bullet>();

        return bullet;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Reset()
    {
        rigidbod.velocity = Vector3.zero;
    }

    public void SetPool(IObjectPool pool)
    {
        this.pool = pool;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator BulletCoroutine(Bullet b)
    {
        yield return new WaitForSeconds(5f);

        b.pool?.Release(b);
    }
}

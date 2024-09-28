using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    private bool isTouching;
    public Transform collision;
    public LayerMask collisionMask;
    public float radius = 0.3f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Vector3 move;

    RaycastWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveH = transform.right * Input.GetAxis("Horizontal");
        Vector3 moveV = transform.forward * Input.GetAxis("Vertical");

        move = (moveH) + (moveV);   // Calculamos el vector resultante

        // Normalizamos el vector de movimiento para evitar ventaja en diagonal
        if (move.magnitude > 1)
        {
            move.Normalize();
        }
        // Una vez normalizado aplicamos la velodidad de movimiento
        move = move * speed;

        isTouching = Physics.CheckSphere(collision.position, radius, collisionMask);

        if (isTouching && velocity.y < 0)
        {
            velocity.y = -3f;   // Que significa esto ???
        }

        velocity.y += gravity * Time.deltaTime;

        move.y = velocity.y;

        controller.Move(move * Time.deltaTime);
    }

    private void LateUpdate()
    {
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
}

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

    RaycastWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        // Comento los ifs porque es innecesario comprobar si el boton esta pulsado
        //if (Input.GetButton("Horizontal"))
        //{
            Vector3 moveX = transform.right * Input.GetAxis("Horizontal");

            controller.Move(moveX * speed * Time.deltaTime);
        //}

        //if (Input.GetButton("Vertical"))
        //{
            Vector3 moveY = transform.forward * Input.GetAxis("Vertical");

            controller.Move(moveY * speed * Time.deltaTime);
        //}

        isTouching = Physics.CheckSphere(collision.position, radius, collisionMask);

        if (isTouching && velocity.y < 0)
        {
            velocity.y = -3f;   // Que significa esto ???

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
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

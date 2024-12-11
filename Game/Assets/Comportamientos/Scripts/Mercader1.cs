using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Mercader1 : MonoBehaviour
{
    public NavMeshAgent agent;

    // Puntos a caminar
    //public Transform cajonPlano;
    public Transform hacerPlanos;
    public Transform lookAtPlanos;
    public Transform mostrador; 
    public GameObject planoPintar; 

    // Interfaz
    public GameObject interfaz;
    private bool pulsar;
    public GameObject boton;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StopAllCoroutines();
        pulsar = false;

    }

    // Update is called once per frame
    void Update()
    {

       

    }

    // Botones

    public void pulsarBotonClick()
    {
        AudioManager.PlaySound(SoundType.CAMPANA, 1);
        pulsar = true;
    }

    // Acciones


    public void mostrarInterfaz()
    {
        DesactivarAnimaciones();
        animator.SetBool("Conversar", true);
        //pensamientoInterfaz.SetActive(false);
        interfaz.SetActive(true);
        boton.SetActive(false);
    }

    public void volver()
    {
        //pensamientoInterfaz.SetActive(true);
        boton.SetActive(true);
        interfaz.SetActive(false);
        pulsar = false;
    }

    // Acciones Plano

    public bool llegado()
    {
        return Vector3.Distance(this.transform.position, hacerPlanos.position) < 0.9f;
    }

    public void MoveHacerPlanos()
    {
       // DesactivarAnimaciones();
        //animator.SetBool("Andar", true);
        if (agent.enabled == false) agent.enabled = true;
        agent.SetDestination(hacerPlanos.position);
        reproducirPintarPlanos();
    }

   

    //Percepciones 

    public bool interactuarMercader()
    {
        return pulsar;
    }

    public void MoveMosrador()
    {
        DesactivarAnimaciones();
        animator.SetBool("Andar", true);
        pulsar = false;
        boton.SetActive(false);
        agent.SetDestination(mostrador.position);
    }

    public void reproducirPintarPlanos()
    {
        planoPintar.SetActive(true); 
        DesactivarAnimaciones();
        animator.SetBool("Dibujar", true);
        
        //transform.LookAt(lookAtPlanos);
        //Transform aux = transform;
        //transform.rotation = new Quaternion(aux.rotation.x, transform.rotation.y, aux.rotation.z, aux.rotation.w);
        agent.SetDestination(hacerPlanos.position);
       // AudioManager.PlaySound(SoundType.DIBUJAR, 0.5f);
        
    }

    public void StopSound()
    {
        AudioManager.StopLoopSound(0);
    }

    public void StopSoundWithoutFade()
    {
        AudioManager.StopSound(0);
    }

    public void DesactivarAnimaciones()
    {
        animator.SetBool("Andar", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Coger", false);
        animator.SetBool("Buscar", false);
        animator.SetBool("Conversar", false);
        animator.SetBool("Rezar", false);
        animator.SetBool("Dormir", false);
        animator.SetBool("Dibujar", false);
        animator.SetBool("Leer", false);
        animator.SetBool("Limpiar", false);
    }


    public void PlayFootStepSound()
    {
        AudioManager.PlaySound(SoundType.PASOS, 0.1f);
    }

    public void ActiveAsset(GameObject g)
    {
        g.SetActive(true);
        g.GetComponent<Animator>().SetBool("Activar", true);
    }

    public void DeActiveAsset(GameObject g)
    {
        if (!g.activeSelf) return;
        g.GetComponent<Animator>().SetBool("Activar", false);
        g.SetActive(false);
    }
}

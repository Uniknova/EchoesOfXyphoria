using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Aprendiz1 : MonoBehaviour
{
    public Transform posMercader;
    public NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(posMercader.position, transform.position) < 0.6f)
        {
            Idle();
        }
        else
        {
            seguirMercader();
        }
    }

   
    public bool CercaMercader()
    {
        return Vector3.Distance(posMercader.position, transform.position) < 0.6f;
    }

    public void Idle()
    {
        DesactivarAnimaciones();
        animator.SetBool("Idle", true);

    }

    public void seguirMercader()
    {
        if (agent.enabled == false) agent.enabled = true; 
        DesactivarAnimaciones();
        animator.SetBool("Andar", true);
        agent.SetDestination(posMercader.position);
    }

    public void DesactivarAnimaciones()
    {
        animator.SetBool("Andar", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Coger", false);
        animator.SetBool("Saltar", false);
        animator.SetBool("Rodar", false);
        animator.SetBool("Sentar", false);
        animator.SetBool("Levantar", false);
    }

    public void PlayFootStepSound()
    {
        AudioManager.PlaySound(SoundType.PASOS2, 0.1f);
    }

    public void StopSound()
    {
        AudioManager.StopSound(1);
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

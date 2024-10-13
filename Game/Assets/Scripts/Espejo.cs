using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Espejo : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;
    public CinemachineVirtualCamera targetCamera;
    public CinemachineVirtualCamera previousCamera;
    public Image prefabUi;
    private Image uiUse;
    private bool enter;
    private Player player;
    private MouseRotation mouse;
    public bool espejo;

    private void Start()
    {
        enter = false;
        espejo = false;
        uiUse = Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        uiUse.enabled = false;
        player = FindObjectOfType<Player>();
        mouse = FindObjectOfType<MouseRotation>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!enter)
        {
            uiUse.enabled = true;
            enter = true;
        }
        

        //currentCamera.Priority--;
        //currentCamera = targetCamera;
        //currentCamera.Priority++;
    }


    private void OnTriggerExit(Collider other)
    {

        uiUse.enabled = false;
        enter = false;
        //currentCamera.Priority--;
        //currentCamera = previousCamera;
        //currentCamera.Priority++;
    }

    private void Update()
    {
        if (enter && !espejo)
        {
            uiUse.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Hola");
                player.enabled = false;
                mouse.enabled = false;
                //mouse.transform.rotation = new Quaternion(mouse.transform.rotation.x, 180, mouse.transform.rotation.z, mouse.transform.rotation.w);
                mouse.transform.Rotate(0, 180, 0);
                uiUse.enabled = false;
                
                currentCamera.Priority--;
                currentCamera = targetCamera;
                currentCamera.Priority++;
                espejo = true;
            }
        }

        if (espejo && Input.GetKeyDown(KeyCode.R))
        {
            espejo = false;
            uiUse.enabled = true;
            player.enabled = true;
            mouse.enabled = true;
            currentCamera.Priority--;
            currentCamera = previousCamera;
            currentCamera.Priority++;
        }
    }
}

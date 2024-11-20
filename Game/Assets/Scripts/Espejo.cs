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
    public GameObject UiSkin;
    private bool enter;
    private Player player;
    private MouseRotation mouse;
    public bool espejo;
    public Transform playerPosition;
    public Transform Head;
    public List<GameObject> skinsList;
    GameObject skin;
    public int indexSkin;
    public Transform TargetLookAt;

    private void Start()
    {
        enter = false;
        espejo = false;
        uiUse = Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        uiUse.enabled = false;
        player = FindObjectOfType<Player>();
        mouse = FindObjectOfType<MouseRotation>();
        indexSkin = 0;
        skinsList.Add(new GameObject());

        if (Application.platform == RuntimePlatform.Android)
        {
            UiSkin.GetComponent<Animator>().SetBool("Show", true);
        }

        foreach(Transform t in transform.GetChild(0).transform)
        {
            skinsList.Add(t.gameObject);
        }
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
                UiSkin.GetComponent<Animator>().SetBool("Show", true);
                foreach(Transform t in UiSkin.transform)
                {
                    t.GetComponent<Button>().enabled = true;
                }

                StartCoroutine(MovePlayer(playerPosition, mouse.transform));
                //mouse.transform.rotation = new Quaternion(mouse.transform.rotation.x, 180, mouse.transform.rotation.z, mouse.transform.rotation.w);
                //mouse.transform.Rotate(0, 180, 0);
                uiUse.enabled = false;
                
                currentCamera.Priority--;
                currentCamera = targetCamera;
                currentCamera.Priority++;
                espejo = true;
            }
        }

        if (espejo && Input.GetKeyDown(KeyCode.R))
        {
            UiSkin.GetComponent<Animator>().SetBool("Show", false);
            foreach (Transform t in UiSkin.transform)
            {
                t.GetComponent<Button>().enabled = false;
            }
            skin = Instantiate(skinsList[indexSkin], Head.position, Head.rotation);
            //skin.transform.localScale = new Vector3(skin.transform.localScale.x * transform.parent.localScale.x, skin.transform.localScale.y * transform.parent.localScale.y, skin.transform.localScale.z * transform.parent.localScale.z);
            skin.transform.localScale = skin.transform.lossyScale;
            skin.transform.SetParent(Head);
            if (skinsList[indexSkin].GetComponent<MeshRenderer>()) skinsList[indexSkin].GetComponent<MeshRenderer>().enabled = false;
            espejo = false;
            uiUse.enabled = true;
            player.enabled = true;
            mouse.enabled = true;
            currentCamera.Priority--;
            currentCamera = previousCamera;
            currentCamera.Priority++;
        }
    }

    IEnumerator MovePlayer(Transform target, Transform previous)
    {
        while (!previous.position.Equals(target.position))
        {
            previous.position = Vector3.MoveTowards(previous.position, target.position, 2 * Time.deltaTime);
            yield return null;
        }
        Destroy(skin);
        skinsList[indexSkin].transform.position = Head.position;
        float x = previous.rotation.x;
        float z = previous.rotation.x;
        previous.LookAt(TargetLookAt);
        previous.rotation = new Quaternion(x, previous.rotation.y, z, previous.rotation.w);
        if (skinsList[indexSkin].GetComponent<MeshRenderer>()) skinsList[indexSkin].GetComponent<MeshRenderer>().enabled = true;

    }

    public void ChangeSkin(int i)
    {
        if (skinsList[indexSkin].GetComponent<MeshRenderer>()) skinsList[indexSkin].GetComponent<MeshRenderer>().enabled = false;
        indexSkin = (indexSkin + i + skinsList.Count) % skinsList.Count;
        skinsList[indexSkin].transform.position = Head.position;
        if (skinsList[indexSkin].GetComponent<MeshRenderer>()) skinsList[indexSkin].GetComponent<MeshRenderer>().enabled = true;
    }
}

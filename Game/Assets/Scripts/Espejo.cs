using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Espejo : MonoBehaviour,IPointerClickHandler
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
    //public List<GameObject> skinsList;

    public List<Material> skinList;
    GameObject skin;
    public int indexSkin;
    public Transform TargetLookAt;

    private void Start()
    {
        enter = false;
        espejo = false;
        uiUse = Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        uiUse.enabled = false;
        //player = FindObjectOfType<Player>();
        player = Player.Instance;
        mouse = FindObjectOfType<MouseRotation>();
        indexSkin = 0;


        //skinsList.Add(new GameObject());

        //foreach(Transform t in transform.GetChild(0).transform)
        //{
        //    skinsList.Add(t.gameObject);
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        if (!enter)
        {
            enter = true;
        }
       
    }


    private void OnTriggerExit(Collider other)
    {

        uiUse.enabled = false;
        enter = false;
    }

    private void Update()
    {

    }

    IEnumerator MovePlayer(Transform target, Transform previous)
    {
        while (Vector3.Distance(previous.position, target.position) >0.2f)
        {
            
            previous.position = Vector3.Lerp(previous.position, target.position, 1.6f * Time.deltaTime);
            yield return null;
            previous.rotation = Quaternion.Lerp(previous.rotation, target.rotation, 2 * Time.deltaTime);

        }
        previous.position = target.position;

        
        float x = previous.rotation.x;
        float z = previous.rotation.z;
        previous.LookAt(TargetLookAt);
        previous.rotation = new Quaternion(x, previous.rotation.y, z, previous.rotation.w);

    }

    public void ChangeSkin(int i)
    {

        indexSkin = (indexSkin + i + skinList.Count) % skinList.Count;
        player.SetMaterial(skinList[indexSkin]);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        player.enabled = false;
        mouse.enabled = false;
        UiSkin.GetComponent<Animator>().SetBool("Show", true);
        foreach (Transform t in UiSkin.transform)
        {
            t.GetComponent<Button>().enabled = true;
        }

        StartCoroutine(MovePlayer(playerPosition, mouse.transform));

        uiUse.enabled = false;


        ChangeCamera(targetCamera);
        espejo = true;
    }

    public void ChangeCamera(CinemachineVirtualCamera camara)
    {
        currentCamera.Priority--;
        currentCamera = camara;
        currentCamera.Priority++;
    }

    public void ExitCanvas()
    {
        UiSkin.GetComponent<Animator>().SetBool("Show", false);
        foreach (Transform t in UiSkin.transform)
        {
            t.GetComponent<Button>().enabled = false;
        }
        espejo = false;
        player.enabled = true;
        mouse.enabled = true;
        ChangeCamera(previousCamera);
    }
}

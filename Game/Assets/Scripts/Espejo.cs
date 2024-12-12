using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject candado;
    public GameObject UiSkin;
    private bool enter;
    private Player player;
    private MouseRotation mouse;
    public bool espejo;
    public Transform playerPosition;
    public Transform Head;
    //public List<GameObject> skinsList;

    public List<Material> skinList;
    [SerializeField] private List<Material> lockedSkinList;
    [SerializeField] private List<bool> unlockedSkin;
    [SerializeField, Range(20,500)] private List<int> precios;
    GameObject skin;
    public int indexSkin;
    public Transform TargetLookAt;
    private int lastindex;

    public GameObject pauseButton; 

    private void Start()
    {
        unlockedSkin = DataInfo.GetDesbloqueado();
        enter = false;
        espejo = false;
        uiUse = Instantiate(prefabUi, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        uiUse.enabled = false;
        //player = FindObjectOfType<Player>();
        player = Player.Instance;
        mouse = FindObjectOfType<MouseRotation>();
        indexSkin = 0;
        lastindex = 0;


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
        Material mat;
        if (unlockedSkin[indexSkin] == false)
        {
            mat = lockedSkinList[indexSkin];
            candado.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = precios[indexSkin].ToString();
            Debug.Log(candado.transform.GetChild(1).GetComponent<TextMeshProUGUI>().preferredWidth + 58.11f);
            candado.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(candado.transform.GetChild(1).GetComponent<TextMeshProUGUI>().preferredWidth + 58.11f
                , candado.transform.GetChild(2).GetComponent<RectTransform>().localPosition.y, candado.transform.GetChild(2).GetComponent<RectTransform>().localPosition.z);
            candado.SetActive(true);
        }

        else
        {
            lastindex = indexSkin;
            mat = skinList[indexSkin];
            candado.SetActive(false);
        }
        player.SetMaterial(mat);
        //player.SetMaterial(skinList[indexSkin]);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        pauseButton.SetActive(false);
        player.enabled = false;
        player.animatorPlayer.SetBool("Andar", false);
        mouse.enabled = false;
        UiSkin.GetComponent<Animator>().SetBool("Show", true);
        foreach (Transform t in UiSkin.transform.GetChild(0))
        {
            if (t.GetComponent<Button>() != null)
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
        player.SetMaterial(skinList[lastindex]);
        indexSkin = lastindex;
        candado.SetActive(false);
        UiSkin.GetComponent<Animator>().SetBool("Show", false);
        foreach (Transform t in UiSkin.transform.GetChild(0))
        {
            t.GetComponent<Button>().enabled = false;
        }
        espejo = false;
        player.enabled = true;
        mouse.enabled = true;
        ChangeCamera(previousCamera);
    }

    public void Comprar()
    {
        if (DataInfo.GetMoney() >= precios[indexSkin])
        {
            AudioManager.PlaySound(SoundType.COMPRAR, 1f);
            lastindex = indexSkin;
            unlockedSkin[indexSkin] = true;
            player.SetMaterial(skinList[indexSkin]);
            candado.SetActive(false);
            Monedas.AddMoney(-precios[indexSkin]);
            DataInfo.SetUnlocked(indexSkin);
        }

        else
        {
            AudioManager.PlaySound(SoundType.ERROR, 1f);
        }
    }
}

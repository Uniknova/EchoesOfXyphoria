using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TransitionManager : MonoBehaviour
{
    private static TransitionManager instance;
    public CinemachineVirtualCamera currentCamera;
    public Camera virtualCamera;
    private Player player;

    public static TransitionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<TransitionManager>("TransitionManager"));
                instance.Init();
            }


            return instance;
        }
    }

    public const string SCENE_LOBBY = "Lobby";
    public const string SCENE_GAME = "SampleScene";
    //public const string SCENE_GAME = "Procedural";
    public const string SCENE_MENU = "Menu";
    public const string SCENE_NEXT = "Proximamente";

    public Slider progressSlider;
    public TextMeshProUGUI progressLabel;
    [Multiline]
    public string[] gameInformation = new string[0];


    private Animator m_Anim;
    private int HashShowAnim = Animator.StringToHash("Show");

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        m_Anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            currentCamera = GameObject.FindGameObjectWithTag("CameraPlayer").GetComponent<CinemachineVirtualCamera>();
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadCoroutine(sceneName));
    }

    public void DestroyObjects()
    {
        Debug.Log("hola");
        if (virtualCamera != null) Destroy(virtualCamera.gameObject);
        if (currentCamera != null) Destroy(currentCamera.gameObject);
        if (player != null) Destroy(player.gameObject);
    }

    IEnumerator LoadCoroutine(string sceneName)
    {
        m_Anim.SetBool("Show", true);
        player = FindObjectOfType<Player>();

        if (player != null)
        {
            player.enabled = false;
            player.controller.enabled = false;
            player.gravedad = false;
        }
        
        

        UpdateProgressValue(0);

        

        yield return new WaitForSeconds(2f);
        var sceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!sceneAsync.isDone)
        {
            UpdateProgressValue(sceneAsync.progress);

            yield return null;
        }
        if (sceneName != SCENE_GAME && sceneName != SCENE_LOBBY) DestroyObjects();


        if (sceneName == SCENE_GAME || sceneName == SCENE_LOBBY)
        {
            if (player == null) player = FindObjectOfType<Player>();

            Transform respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
            Debug.Log(respawn.position);
            player.PlayerMathc(respawn);
            virtualCamera = Camera.main;
            if (currentCamera == null) currentCamera = GameObject.FindGameObjectWithTag("CameraPlayer").GetComponent<CinemachineVirtualCamera>();
            currentCamera.transform.position = new Vector3(currentCamera.transform.position.x, player.transform.GetChild(0).transform.position.y + 6, currentCamera.gameObject.transform.position.z);
        }
        //if (currentCamera != null)
        //{
        //    currentCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f, player.transform.localScale.x);

        //}
        UpdateProgressValue(1);

        //if (currentCamera != null)
        //{
        //    currentCamera.transform.position = new Vector3(currentCamera.transform.position.x, player.transform.position.y + 6, currentCamera.gameObject.transform.position.z);

        //}

        if (sceneName == SCENE_GAME || sceneName == SCENE_LOBBY)
        {
            player.enabled = true;
            player.controller.enabled = true;
            
            player.gravedad = true;
        }
        
        m_Anim.SetBool("Show", false);

    }

    public void UpdateProgressValue(float progressValue)
    {
        if (progressSlider != null)
        {
            progressSlider.value = progressValue;
        }
        if (progressLabel.text != null)
        {
            progressLabel.text = $"{progressValue * 100}%";
        }
    }

    //public void UpdateCamera(CinemachineVirtualCamera target)
    //{

    //}

}

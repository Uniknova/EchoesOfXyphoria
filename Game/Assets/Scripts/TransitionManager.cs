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
    //public const string SCENE_GAME = "SampleScene";
    public const string SCENE_GAME = "Procedural";
    public const string SCENE_MENU = "Menu3D";
    public const string SCENE_NEXT = "Proximamente";
    public const string SCENE_TUTORIAL = "Tutorial";

    public Image imageProgress;
    public Slider progressSlider;
    public TextMeshProUGUI progressLabel;
    [Multiline]
    public string[] gameInformation = new string[0];


    private Animator m_Anim;
    private PowerUpsCanvas _PowerUpsCanvas;
    private int HashShowAnim = Animator.StringToHash("Show");

    private UICanvasControllerInput _UICanvasControllerInput;

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
        gameObject.SetActive(true);
        StartCoroutine(LoadCoroutine(sceneName));
        //gameObject.SetActive(false);
    }

    public void DestroyObjects()
    {
        Debug.Log("hola");
        if (virtualCamera != null) Destroy(virtualCamera.gameObject);
        if (currentCamera != null) Destroy(currentCamera.gameObject);
        if (player != null) Destroy(player.gameObject);
        if (_UICanvasControllerInput != null) Destroy(_UICanvasControllerInput.gameObject);
    }

    IEnumerator LoadCoroutine(string sceneName)
    {
        m_Anim.SetBool("Show", true);
        player = Player.Instance;
        //player = FindObjectOfType<Player>();

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


        if (sceneName == SCENE_LOBBY)
        {
            MatchInfo match = MatchInfo.Instance;
            if (_UICanvasControllerInput == null)
            {
                _UICanvasControllerInput = UICanvasControllerInput.Instance;
            }
            match.ResetEnemies();
            Destroy(match.gameObject);
            Player.Instance.RestartPlayer();
            if (_PowerUpsCanvas != null) Destroy(_PowerUpsCanvas.gameObject);
            MiniMap.Instance.SetLobbySize();
        }

        if (sceneName == SCENE_GAME)
        {
            player.vidaUi = Uivida.Instance;
            player.vidaUi.fill.fillAmount = player.hp / player.hpMax;
            _PowerUpsCanvas = PowerUpsCanvas.Instance;
            MiniMap.Instance.SetMatchSize();
        }
        if (sceneName == SCENE_GAME || sceneName == SCENE_LOBBY)
        {
            if (player == null) player = Player.Instance;

            Transform respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
            Debug.Log(respawn.position);
            player.Respawn(respawn);
            //player.PlayerMathc(respawn);
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
        if (imageProgress != null)
        {
            imageProgress.fillAmount = progressValue;
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

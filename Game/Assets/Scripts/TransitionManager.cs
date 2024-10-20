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

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadCoroutine(sceneName));
    }

    IEnumerator LoadCoroutine(string sceneName)
    {
        m_Anim.SetBool("Show", true);
        player.enabled = false;
        player.PlayerMathc();

        UpdateProgressValue(0);

        yield return new WaitForSeconds(2f);
        var sceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while(!sceneAsync.isDone)
        {
            UpdateProgressValue(sceneAsync.progress);

            yield return null;
        }

        UpdateProgressValue(1);
        player.enabled = true;
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

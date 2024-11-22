using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseBotton; 
    [SerializeField] private GameObject pauseMenu; 
    //[SerializeField] private GameObject moreCoins; 
    //[SerializeField] private GameObject coinShopInterface; 
    [SerializeField] private GameObject settingsInGame; 
    [SerializeField] private GameObject screenSettings; 
    [SerializeField] private GameObject soundSettings; 
    [SerializeField] private GameObject creditSettings; 

    [SerializeField] private AudioMixer generalSound;

    [SerializeField] private Slider sound;
    [SerializeField] private Toggle full;
    [SerializeField] private TMP_Dropdown quality;



    public void Start()
    {
        QualitySettings.SetQualityLevel( PlayerPrefs.GetInt("Quality"));
        generalSound.SetFloat("GeneralSound", PlayerPrefs.GetFloat("General"));
        sound.value = PlayerPrefs.GetFloat("General");

        if ( PlayerPrefs.GetInt("FullScreen") == 0)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;

        full.isOn = Screen.fullScreen;

        quality.value = PlayerPrefs.GetInt("Quality");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseMenu();
        }
    }

    public void ScreenSettings()
    {
        soundSettings.SetActive(false);
        creditSettings.SetActive(false);
        screenSettings.SetActive(true);
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

        if (fullScreen == false)
            PlayerPrefs.SetInt("FullScreen",0);
        else
            PlayerPrefs.SetInt("FullScreen", 1);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("Quality", index);
    }

    public void SoundSettings()
    {
        screenSettings.SetActive(false);
        creditSettings.SetActive(false);
        soundSettings.SetActive(true);
    }

    public void CambiarVolumen(float volum)
    {
        generalSound.SetFloat("GeneralSound", volum);
        PlayerPrefs.SetFloat("General", volum);
    }

    public void CreditSettings()
    {
        screenSettings.SetActive(false);
        creditSettings.SetActive(true);
        soundSettings.SetActive(false);
    }

    public void LoadGame()
    {
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_GAME);
        Time.timeScale = 1f;
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY);
        //SceneManager.LoadScene(1);
    }

    public void LoadProximamente()
    {
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_NEXT);
        SceneManager.LoadScene(3);
    }

    public void LoadTutorial()
    {
        Time.timeScale = 1f;
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_TUTORIAL);

    }

    public void LoadMenu ()
    {
        pauseMenu.SetActive(false);
        pauseBotton.SetActive(true);
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        Time.timeScale = 1f;
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        SceneManager.LoadScene(0);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        pauseBotton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseBotton.SetActive(true);
        //moreCoins.SetActive(true);
        //coinShopInterface.SetActive(false);
    }

    public void SettingsInGame()
    {
        pauseMenu.SetActive(false);
        settingsInGame.SetActive(true);
    }

    public void backPause()
    {
        pauseMenu.SetActive(true);
        settingsInGame.SetActive(false);
        screenSettings.SetActive(false);
        creditSettings.SetActive(false);
        soundSettings.SetActive(false);
    }

    public void coinShop()
    {
        //coinShopInterface.SetActive(true);
        pauseBotton.SetActive(false);
        //moreCoins.SetActive(false);
        
    }
    public void closeGame()
    {

        Application.OpenURL("https://unknova.itch.io/echoes-of-xyphoria");

    }

    public void buy5Coins ()
    {
        //variableCoins  = variableCoins +5


    }

    public void buy50Coins()
    {
        //variableCoins  = variableCoins +5


    }

    public void buy100Coins()
    {
        //variableCoins  = variableCoins +5


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
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
    [SerializeField] private GameObject languageSettings;

    [SerializeField] public AudioMixer generalSound;

    [SerializeField] private Slider sound;
    [SerializeField] public Toggle full;
    [SerializeField] private TMP_Dropdown quality;


    [SerializeField] private GameObject high;
    [SerializeField] private GameObject medium;
    [SerializeField] private GameObject low;


    [SerializeField] private GameObject spanish;
    [SerializeField] private GameObject english;




    private bool active = false;



    public void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        loadQuality(PlayerPrefs.GetInt("Quality"));
        generalSound.SetFloat("GeneralSound", PlayerPrefs.GetFloat("General"));
        sound.value = PlayerPrefs.GetFloat("General");

        if (PlayerPrefs.GetInt("FullScreen") == 0)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;

        full.isOn = Screen.fullScreen;

        ChangeLanguage(PlayerPrefs.GetInt("Language"));
        LoadLanguage(PlayerPrefs.GetInt("Language"));
    }



    // Settings 

    public void ScreenSettings()
    {
        soundSettings.SetActive(false);
        creditSettings.SetActive(false);
        screenSettings.SetActive(true);
        languageSettings.SetActive(false);
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

        if (fullScreen == false)
            PlayerPrefs.SetInt("FullScreen", 0);
        else
            PlayerPrefs.SetInt("FullScreen", 1);
    }

    public void ChangeQuality(int index)
    {
        PlayerPrefs.SetInt("Quality", index);
        QualitySettings.SetQualityLevel(index);

        loadQuality(index);

    }

    public void loadQuality(int index)
    {
        if (index == 0)
        {
            low.SetActive(true);
            high.SetActive(false);
            medium.SetActive(false);
        }
        else if (index == 1)
        {
            low.SetActive(false);
            high.SetActive(false);
            medium.SetActive(true);
        }
        else
        {
            low.SetActive(false);
            high.SetActive(true);
            medium.SetActive(false);
        }
    }


    public void SoundSettings()
    {
        screenSettings.SetActive(false);
        creditSettings.SetActive(false);
        soundSettings.SetActive(true);
        languageSettings.SetActive(false);
    }


    public void CambiarVolumen(float volum)
    {
        generalSound.SetFloat("GeneralSound", volum);
        PlayerPrefs.SetFloat("General", volum);
    }

    public void LanguageSettings()
    {
        screenSettings.SetActive(false);
        creditSettings.SetActive(false);
        soundSettings.SetActive(false);
        languageSettings.SetActive(true);
    }

    public void ChangeLanguage(int language)
    {
        if (active)
            return;

        StartCoroutine(SetLanguage(language));

    }

    private IEnumerator SetLanguage(int language)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
        PlayerPrefs.SetInt("Language", language);
        LoadLanguage(language);
        active = false;

    }

    public void LoadLanguage(int index)
    {
        if (index == 0)
        {
            spanish.SetActive(false);
            english.SetActive(true);
        }
        else
        {
            spanish.SetActive(true);
            english.SetActive(false);
        }
    }

    public void CreditSettings()
    {
        screenSettings.SetActive(false);
        creditSettings.SetActive(true);
        soundSettings.SetActive(false);
        languageSettings.SetActive(false);
    }

    // Change Scene

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
        SceneManager.LoadScene(3);
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_TUTORIAL);

    }

    public void LoadMenu()
    {
        pauseMenu.SetActive(false);
        pauseBotton.SetActive(true);
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        Time.timeScale = 1f;
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        //SceneManager.LoadScene(TransitionManager.SCENE_MENU);
    }

    public void PauseMenu()
    {
        if (DataInfo.Instance.GetPlatform() == 0)
        {
            UICanvasControllerInput.Instance.gameObject.SetActive(false);
        }
        Time.timeScale = 0f;
        pauseBotton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        if (DataInfo.Instance.GetPlatform() == 0)
        {
            UICanvasControllerInput.Instance.gameObject.SetActive(true);
        }
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

    public void buy5Coins()
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

    public void loadMenu()
    {

        SceneManager.LoadScene(0);
    }
}

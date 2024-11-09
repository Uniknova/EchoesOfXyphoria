using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseBotton; 
    [SerializeField] private GameObject pauseMenu; 
    [SerializeField] private GameObject settingsInGame; 
    [SerializeField] private GameObject coinShopInterface; 
    [SerializeField] private GameObject moreCoins; 



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
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_NEXT);
        Time.timeScale = 1f;
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_TUTORIAL);

    }

    public void LoadMenu ()
    {
        //TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        Time.timeScale = 1f;
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_MENU);
        //SceneManager.LoadScene(0);
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
        moreCoins.SetActive(true);
        coinShopInterface.SetActive(false);
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
    }

    public void coinShop()
    {
        coinShopInterface.SetActive(true);
        pauseBotton.SetActive(false);
        moreCoins.SetActive(false);
        
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

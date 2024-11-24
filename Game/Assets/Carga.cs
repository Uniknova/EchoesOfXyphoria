using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

public class Carga : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public AudioMixer generalSound;
    // Start is called before the first frame update
    public void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        generalSound.SetFloat("GeneralSound", PlayerPrefs.GetFloat("General"));


        if (PlayerPrefs.GetInt("FullScreen") == 0)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("Language")];
        //ChangeLanguage(PlayerPrefs.GetInt("Language"));

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

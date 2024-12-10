using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad (audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySonido(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

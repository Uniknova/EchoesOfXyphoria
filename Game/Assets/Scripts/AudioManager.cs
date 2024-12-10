using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundType
{
    MUERTE,
    ESCOPETA,
    RIFLE,
    PISTOLA,
    FRANCOTIRADOR
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceLoopMercader;
    [SerializeField] private AudioSource audioSourceLoopNimby;
    [SerializeField] private AudioSource audioAmbiente;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void PlaySound(SoundType sound, float volume)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    } 
    
    public static void PlaySoundLoop(int idx, SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];

        if (idx == 0)
        {
            instance.audioSourceLoopMercader.clip = randomClip;
            //instance.StopCoroutine(instance.Fade());
            instance.StartCoroutine(instance.Fade(true, instance.audioSourceLoopMercader, 2f, volume));

            instance.audioSourceLoopMercader.Play();

        }

        else
        {
            instance.audioSourceLoopNimby.clip = randomClip;
            instance.StartCoroutine(instance.Fade(true, instance.audioSourceLoopNimby, 2f, volume));

            instance.audioSourceLoopNimby.Play();
        }
    }

    public static void StopSound(int idx)
    {
        if (idx == 0)
        {
            instance.audioSourceLoopMercader.Stop();
        }

        else
        {
            instance.audioSourceLoopNimby.Stop();
        }
        
    }

    //public static void PlayDia()
    //{
    //    AudioClip[] clips = instance.soundList[(int)SoundType.FONDO_DIA].Sounds;
    //    AudioClip randomClip = clips[Random.Range(0, clips.Length)];
    //    instance.audioAmbiente.clip = randomClip;
    //    instance.audioAmbiente.Play();
    //    instance.StartCoroutine(instance.Fade(true, instance.audioAmbiente, 2f, 0.5f));
    //}

    //public static void PlayNoche()
    //{
    //    AudioClip[] clips = instance.soundList[(int)SoundType.FONDO_NOCHE].Sounds;
    //    AudioClip randomClip = clips[Random.Range(0, clips.Length)];
    //    instance.audioAmbiente.clip = randomClip;
    //    instance.audioAmbiente.Play();
    //    instance.StartCoroutine(instance.Fade(true, instance.audioAmbiente, 2f, 0.2f));
    //}

    public static void StopAmbientSound()
    {
        instance.Fade(false, instance.audioAmbiente, 2f, 0f);
    }

    public static void StopLoopSound(int idx)
    {
        if (idx == 0)
        {
            instance.StartCoroutine(instance.Fade(false, instance.audioSourceLoopMercader, 0.5f, 0f));
        }

        else
        {
            instance.StartCoroutine(instance.Fade(false, instance.audioSourceLoopNimby, 0.5f, 0f));
        }
        
    }

    private IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        //if (!fadeIn)
        //{
        //    double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
        //    yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));
        //    source.Stop();
        //}

        float time = 0f;
        float startVol = source.volume;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time/duration);
            yield return null;
        }

        if (!fadeIn) source.Stop();

        yield break;
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static AudioSource audioSource;
    public static float volume = 0.05f;

    static List<AudioClip> audioClips = new List<AudioClip>();
    void Awake()
    {
        for (int i = 0; i < Resources.LoadAll<AudioClip>("SoundEffects").Length; i++)
        {
            audioClips.Add(Resources.LoadAll<AudioClip>("SoundEffects")[i]);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string SoundName)
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i] != null)
            {
                if (SoundName == audioClips[i].name)
                {
                    audioSource.volume = volume;
                    audioSource.PlayOneShot(audioClips[i]);
                }
            }
        }
    }

    public static void PlaySound(string SoundName, float vol)
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i] != null)
            {
                if (SoundName == audioClips[i].name)
                {
                    audioSource.volume = vol;
                    audioSource.PlayOneShot(audioClips[i]);
                }
            }
        }
    }

    public static void PlaySoundWaitOnComplete(string SoundName, float Volume)
    {
        if (!audioSource.isPlaying)
        {
            for (int i = 0; i < audioClips.Count; i++)
            {
                if (SoundName == audioClips[i].name)
                {
                    audioSource.volume = Volume;
                    audioSource.PlayOneShot(audioClips[i]);
                }
            }
        }
    }
}

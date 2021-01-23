using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static float Music_Volume = 0.2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Music_Volume;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

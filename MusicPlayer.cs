using UnityEngine;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instanse;
    [SerializeField] private List<AudioClip> allMusic;
    [SerializeField] private AudioSource audioSource;
    public AudioSource Source => audioSource;

    private void Awake()
    {
        if (Instanse != null)
        {
            Destroy(this);
            return;
        }
        Instanse = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        audioSource.clip = allMusic[Random.Range(0, allMusic.Count)];
        audioSource.Play();
    }
    private void Update()
    {
        if (audioSource.isPlaying != true)
        {
            audioSource.clip = allMusic[Random.Range(0, allMusic.Count)];
            audioSource.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

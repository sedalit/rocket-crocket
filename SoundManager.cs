using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instanse;

    [SerializeField] private AudioClip countdownSound;
    [SerializeField] private AudioClip countdownFinishSound;
    [SerializeField] private AudioClip rocketFlySound;
    [SerializeField] private AudioClip finishLevelSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip powerUpCollectSound;

    private AudioSource audioSource;

    public AudioSource Source => audioSource;
    public AudioClip CountdownSound => countdownSound;
    public AudioClip CountdownFinishSound => countdownFinishSound;
    public AudioClip Fly => rocketFlySound;
    public AudioClip FinishLevel => finishLevelSound;
    public AudioClip Death => deathSound;
    public AudioClip CollectPowerUp => powerUpCollectSound;

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
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audio)
    {
        audioSource.loop = false;
        if (audio == rocketFlySound)
        {
            audioSource.loop = true;
        }
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void PlayOneShot(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

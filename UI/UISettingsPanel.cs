using UnityEngine;
using UnityEngine.UI;

public class UISettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider soundsVolume;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        musicVolume.value = MusicPlayer.Instanse.Source.volume;
        soundsVolume.value = 0.5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            Time.timeScale = pausePanel.activeSelf ? 0 : 1;
        }
    }

    public void OnMusicVolumeSlider()
    {
        MusicPlayer.Instanse.SetMusicVolume(musicVolume.value);
    }
    public void OnSoundsVolumeSlider()
    {
        SoundManager.Instanse.SetVolume(soundsVolume.value);
    }
}

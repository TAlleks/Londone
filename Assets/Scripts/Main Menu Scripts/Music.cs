using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [Header("Audio Mixer References")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Volume Sliders")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;

    [Header("Volume Parameters")]
    [SerializeField] private string musicVolumeParam = "Music";
    [SerializeField] private string effectsVolumeParam = "Effects";

    private void Awake()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    private void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat(musicVolumeParam, 0.75f);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat(effectsVolumeParam, 0.75f);
    }

    private void SetMusicVolume(float value)
    {
        SetVolume(musicVolumeParam, value);
    }

    private void SetEffectsVolume(float value)
    {
        SetVolume(effectsVolumeParam, value);
    }

    private void SetVolume(string parameter, float value)
    {
        float volume = value * 100 - 80;
        audioMixer.SetFloat(parameter, volume);

        PlayerPrefs.SetFloat(parameter, value);
    }

    private void OnDestroy()
    {
        musicVolumeSlider.onValueChanged.RemoveListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.RemoveListener(SetEffectsVolume);
    }
}
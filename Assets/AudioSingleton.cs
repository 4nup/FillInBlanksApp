using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSingleton : MonoBehaviour
{
    private static AudioSingleton _instance;

    [SerializeField] RectTransform settingsPanel;

    public static AudioSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Singleton is null");
            }
            return _instance;
        }
    }

    static Slider musicSlider;
    static Slider sfxSlider;

    static AudioSource musicAudioSource;
    static AudioSource sfxAudioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        settingsPanel.gameObject.SetActive(true);
        _instance = this;
        musicSlider = GameObject.Find("MusicSlider12").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider12").GetComponent<Slider>();
        musicAudioSource = GetComponent<AudioSource>();
        sfxAudioSource = GameObject.Find("SFXAudioSource").GetComponent<AudioSource>();
        GameObject.Find("SettingsPanel").SetActive(false);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;
    }

    static float musicValue = 1.0f;
    public static void MusicValueChanged()
    {
        musicValue = musicSlider.value;
        musicAudioSource.volume = musicValue;
    }

    static float sfxValue = 0.7f;
    public static void SFXValueChanged()
    {
        sfxValue = sfxSlider.value;
        sfxAudioSource.volume = sfxValue;
    }

    [SerializeField] AudioClip placeSuccessAudioClip;
    public void PlayPlaceSuccessSound()
    {
        sfxAudioSource.clip = placeSuccessAudioClip;
        sfxAudioSource.Play();
    }

    [SerializeField] AudioClip placeFailAudioClip;
    public void PlayPlaceFailSound()
    {
        sfxAudioSource.clip = placeFailAudioClip;
        sfxAudioSource.Play();
    }

    [SerializeField] AudioClip placeNextAudioClip;
    public void PlayNextSound()
    {
        sfxAudioSource.clip = placeNextAudioClip;
        sfxAudioSource.Play();
    }

    [SerializeField] AudioClip placeWinAudioClip;
    public void PlayWinSound()
    {
        sfxAudioSource.clip = placeWinAudioClip;
        sfxAudioSource.Play();
    }
}

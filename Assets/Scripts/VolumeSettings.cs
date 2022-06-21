using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private Slider slider;
    [SerializeField] private string volumeMixerParam;
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 0;
        slider.minValue = -80;
        slider.onValueChanged.AddListener(AdjustVolume);
    }

    void Start()
    {
        GetSavedValue();
    }

    void GetSavedValue()
    {
        slider.value = PlayerPrefs.GetFloat(volumeMixerParam, 0f);
    }
    
    private void AdjustVolume(float vol)
    {
        mixer.SetFloat(volumeMixerParam, vol);
        PlayerPrefs.SetFloat(volumeMixerParam, vol);
    }
}

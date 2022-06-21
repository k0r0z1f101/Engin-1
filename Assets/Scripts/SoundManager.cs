using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup uiMixerGroup;
    private AudioSource uiAudioSource;
    void Awake()
    {
        uiAudioSource = GetComponent<AudioSource>();
        uiAudioSource.outputAudioMixerGroup = uiMixerGroup;
    }

    public void PlayUISound(AudioClip clip)
    {
        uiAudioSource.clip = clip;
        uiAudioSource.Play();
    }
}

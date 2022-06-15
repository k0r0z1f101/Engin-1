using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
  [SerializeField] private AudioClip[] myAudioClips;
  private Button playButton;
  private Button pauseButton;
  private Button stopButton;
  private Toggle loopToggle;
  private Slider volumeSlider;
  private TMP_Text volumeDisplay;
  private TMP_Text timeDisplay;
  private TMP_Dropdown m_SoundOptions;
  private AudioSource myAudioSource;
  private List<string> theSounds = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
      playButton = transform.Find("Play").GetComponent<Button>();
      pauseButton = transform.Find("Pause").GetComponent<Button>();
      stopButton = transform.Find("Stop").GetComponent<Button>();
      loopToggle = transform.Find("Loop").GetComponent<Toggle>();
      volumeSlider = transform.Find("VolumeSlider").GetComponent<Slider>();
      volumeDisplay = transform.Find("VolumeText").GetComponent<TMP_Text>();
      timeDisplay = transform.Find("TimeText").GetComponent<TMP_Text>();
      m_SoundOptions = transform.Find("SoundSelection").GetComponent<TMP_Dropdown>();
      myAudioSource = GetComponent<AudioSource>();
      playButton.onClick.AddListener(PlaySound);
      pauseButton.onClick.AddListener(PauseSound);
      stopButton.onClick.AddListener(StopSound);
      m_SoundOptions.onValueChanged.AddListener(ChooseSound);
      loopToggle.onValueChanged.AddListener(OnLoop);
      volumeSlider.onValueChanged.AddListener(AdjustVolume);

      AddSoundsToDropDown();
      AdjustVolume(0.5f);
      volumeSlider.value = 0.5f;
    }

    void AddSoundsToDropDown()
    {
      m_SoundOptions.ClearOptions();
      for(int i = 0; i < myAudioClips.Length; ++i)
      {
        theSounds.Add(myAudioClips[i].name);
      }
      m_SoundOptions.AddOptions(theSounds);
      myAudioSource.clip = myAudioClips[0];
    }

    void PlaySound()
    {
      if(!myAudioSource.isPlaying)
      {
        myAudioSource.Play();
        StartCoroutine("WaitForSoundToEnd");
      }
    }

    void StopSound()
    {
      AdjustTime();
      myAudioSource.Stop();
    }

    void PauseSound()
    {
      myAudioSource.Pause();
    }

    void ChooseSound(int value)
    {
      // Debug.Log(m_SoundOptions.options[value].text);
      myAudioSource.clip = myAudioClips[value];
    }

    void OnLoop(bool value)
    {
      myAudioSource.loop = value;
    }

    void AdjustVolume(float vol)
    {
      myAudioSource.volume = vol;
      volumeDisplay.text = "Volume: " + Mathf.Round(vol * 100);
    }

    void AdjustTime()
    {
        timeDisplay.text = "Time: " + myAudioSource.time;
    }

    private IEnumerator WaitForSoundToEnd()
    {
      while(myAudioSource.isPlaying)
      {
        AdjustTime();
        yield return null;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

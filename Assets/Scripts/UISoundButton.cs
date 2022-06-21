using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UISoundButton : MonoBehaviour
{
  [SerializeField] private AudioClip clip;
  private SoundManager soundManager;
  private Button button;

    // Start is called before the first frame update
    void Awake()
    {
      
      soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
      button = GetComponent<Button>();
      button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
      soundManager.PlayUISound(clip);
    }
}

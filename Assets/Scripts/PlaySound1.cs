using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound1 : MonoBehaviour
{
  [SerializeField] private AudioClip[] myAudioClips;
  private Button theButton;
  private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
      myAudioSource = GetComponent<AudioSource>();
      theButton = GetComponent<Button>();
      theButton.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
      Debug.Log("play!");
      myAudioSource.PlayOneShot(myAudioClips[Random.Range(0,myAudioClips.Length)]);
      theButton.onClick.RemoveListener(PlaySound);
      theButton.onClick.AddListener(PlaySoundAtLocation);
    }

    void PlaySoundAtLocation()
    {
      AudioSource.PlayClipAtPoint(myAudioClips[Random.Range(0,myAudioClips.Length)], new Vector3(0, Random.Range(0,100), 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

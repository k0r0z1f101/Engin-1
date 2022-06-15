using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundButton : MonoBehaviour
{
  // [SerializeField] private SoundManager soundManager;
  private Button button;

    // Start is called before the first frame update
    void Awake()
    {
      // soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
      button = GetComponent<Button>();
      button.onClick.AddListener(PlaySound);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlaySound()
    {
      // SoundManager.PlayUISound(myClip);
    }
}

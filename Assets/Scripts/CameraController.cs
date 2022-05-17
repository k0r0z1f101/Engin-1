using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField]
  private GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
      transform.position = player.transform.position;
    }
}

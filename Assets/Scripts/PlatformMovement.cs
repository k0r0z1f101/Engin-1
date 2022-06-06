using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
  [SerializeField]
  private GameObject StartPosObject;
  [SerializeField]
  private GameObject EndPosObject;
  [SerializeField]
  private bool isActive;

  [Range(0, 10)]
  [SerializeField]
  private float platformSpeed;

    private void OnTriggerEnter(Collider other)
    {
      other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
      other.transform.SetParent(null);
    }

    void FixedUpdate()
    {
      if(isActive)
        transform.position = Vector3.Lerp(StartPosObject.transform.position, EndPosObject.transform.position, Mathf.PingPong(Time.time * platformSpeed, 1));
    }
}

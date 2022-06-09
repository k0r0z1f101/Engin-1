using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayerMaskTest : MonoBehaviour
{
  [SerializeField] private LayerMask layerMask;

  void Start()
  {
    Debug.Log(Convert.ToString(layerMask,2).PadLeft(32,'0'));
  }
}

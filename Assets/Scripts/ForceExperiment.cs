using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ForceExperiment : MonoBehaviour
{
  [SerializeField]
  ForceMode fm;

  [SerializeField]
  Vector3 direction;

  [SerializeField]
  float appliedForce;

  Rigidbody m_Rigidbody;

  void Awake()
  {
    m_Rigidbody = GetComponent<Rigidbody>();
    // Time.fixedDeltaTime = 0.02f;
    InvokeRepeating("ChangeGravity", 0, 1.0f);
  }

  void ChangeGravity()
  {
    Physics.gravity = new Vector3(0, 0, Random.Range(0, 5));
  }

  void Update()
  {
    Debug.Log("Update: " + Time.deltaTime);
    Debug.Log("Update: " + Time.fixedDeltaTime);
  }

  void FixedUpdate()
  {
    Debug.Log("Fixed: " + Time.fixedDeltaTime);
    m_Rigidbody.AddForce(direction * appliedForce, fm);
  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicRotation : MonoBehaviour
{
  private Rigidbody rb;
  [SerializeField]
  private ForceMode fm;
  [SerializeField]
  private float torque;
    // Start is called before the first frame update
    void Awake()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float rotDelta = maxRotation - rb.angularVelocity.magnitude;
        // float adjustSpeed = Mathf.InverseLerp(0, maxRotation, rotDelta);
        //
        // rb.AddTorque(Vector3.up * torque * adjustSpeed, fm);


      rb.AddTorque(Vector3.up * torque, fm);
    }

    void Update()
    {
      Debug.Log(rb.velocity);
    }
}

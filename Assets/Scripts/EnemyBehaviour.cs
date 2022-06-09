using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
  void Start()
  {
    
  }

  void OnControllerColliderHit(ControllerColliderHit hit)
  {
    Debug.Log("Controller " + hit.gameObject.name);
  }

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log("Collision " + collision.gameObject.name);
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Trigger " + other.gameObject.name);
  }

  void OnCollisionStay(Collision collision)
  {
    Debug.Log("Collision stay " + collision.gameObject.name);
  }

  void OnTriggerStay(Collider other)
  {
    Debug.Log("Trigger stay " + other.gameObject.name);
    Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    Debug.DrawRay(transform.position, other.gameObject.transform.position, Color.green);
  }

  void OnCollisionExit(Collision collision)
  {
    Debug.Log("Collision exit " + collision.gameObject.name);
  }

  void OnTriggerExit(Collider other)
  {
    Debug.Log("Trigger exit " + other.gameObject.name);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour
{
  private Rigidbody rb;
  private Vector3 moveDirection;
  [SerializeField]
  private int appliedForce;
  [SerializeField]
  private bool playerDetected;
  [SerializeField]
  private bool playerInSight;
  private GameObject target;
  private Vector3 targetDirection;
  [SerializeField]
  private int maxDistanceForDetection;
  [SerializeField]
  private LayerMask layerMask;

  void OnDrawGizmosSelected()
  {
      Gizmos.color = Color.white;
      Gizmos.DrawWireSphere(transform.position, maxDistanceForDetection);
  }

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      target = other.gameObject;
      playerDetected = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      playerDetected = false;
      playerInSight = false;
    }
  }

  void Start()
  {
    // layerMask = ~(1 << 9); BITWISE COMPLEMENT OPERATOR (invert selector)
    layerMask = 1 << 9;
    rb = GetComponent<Rigidbody>();
    Debug.Log(Convert.ToString(layerMask,2).PadLeft(32,'0'));
  }

  void LookForPlayer()
  {
    targetDirection = Vector3.Normalize(target.transform.position - transform.position);
    RaycastHit hit;

    if(Physics.Raycast(transform.position, targetDirection, out hit, Mathf.Infinity, layerMask.value))
    {
      if(hit.collider.tag == "Player")
      {
        playerInSight = true;
      }
      else
      {
        playerInSight = false;
      }
      Debug.DrawLine(transform.position, hit.point, Color.yellow);
    }
  }

  void Move()
  {
    rb.AddForce(targetDirection * appliedForce, ForceMode.Force);
  }

  void FixedUpdate()
  {
    if(playerDetected)
    {
      LookForPlayer();
    }
    if(playerInSight)
    {
      Move();
    }
  }

  // void OnTriggerStay(Collider other)
  // {
  //   Debug.Log("Trigger stay " + other.gameObject.name);
  //   if(other.tag == "Player")
  //   {
  //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
  //     Debug.DrawRay(transform.position, other.gameObject.transform.position, Color.green);
  //     Debug.DrawLine(transform.position, other.gameObject.transform.position, Color.red, Time.deltaTime);
  //   }
  // }

  // void OnControllerColliderHit(ControllerColliderHit hit)
  // {
  //   Debug.Log("Controller " + hit.gameObject.name);
  // }

  // void OnCollisionEnter(Collision collision)
  // {
  //   Debug.Log("Collision " + collision.gameObject.name);
  // }

  // void OnTriggerEnter(Collider other)
  // {
  //   Debug.Log("Trigger " + other.gameObject.name);
  // }

  // void OnCollisionStay(Collision collision)
  // {
  //   Debug.Log("Collision stay " + collision.gameObject.name);
  // }

  // void OnCollisionExit(Collision collision)
  // {
  //   Debug.Log("Collision exit " + collision.gameObject.name);
  // }

  // void OnTriggerExit(Collider other)
  // {
  //   Debug.Log("Trigger exit " + other.gameObject.name);
  // }
}

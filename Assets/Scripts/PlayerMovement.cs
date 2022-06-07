using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody rigid;
  private Vector3 moveDirection;
  private bool isMoving;
  [SerializeField]
  private int appliedForce;

  public void ReceiveMoveInput(InputAction.CallbackContext context)
  {
    // Debug.Log(context.phase);
    Vector2 inputValues = context.ReadValue<Vector2>();
    moveDirection = new Vector3(inputValues.x, 0, inputValues.y);

    if(moveDirection.sqrMagnitude ==0)
    {
      isMoving = false;
    }
    else
    {
      isMoving = true;
    }
  }

  void Move()
  {
    rigid.AddForce(moveDirection * appliedForce, ForceMode.Acceleration);
  }

  void Awake()
  {
    rigid = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    if(isMoving)
      Move();
  }
}

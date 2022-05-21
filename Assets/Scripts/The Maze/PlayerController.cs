using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  //character parent gameobject
  private CharacterController controller;

  //inputs for character movements
  private PlayerInput playerInput;
  private InputAction walkAction;

  //animations for character movements
  private Animator animator;

  //Walk
  [Header("Vitesse de marche")]
  [SerializeField]
  private int walkSpeed;
  private Vector2 walkValue;
  private bool isWalking;
  private bool isMoving;

  //Turning
  [SerializeField]
  private int rotSpeed;

  //Run
  private InputAction runAction;
  private float runValue;
  private bool isRunning;

  //Jump Idle
  private InputAction jumpAction;
  private float jumpValue;
  [SerializeField]
  private bool isJumping;

  //Jump Running
  private InputAction jumpRunAction;
  private float jumpRunValue;

    // Start is called before the first frame update
    void Awake()
    {
      controller = GetComponent<CharacterController>();
      playerInput = GetComponent<PlayerInput>();
      animator = transform.GetChild(0).GetComponent<Animator>();
      walkAction = playerInput.actions["Walk"];
      runAction = playerInput.actions["Run"];
      jumpAction = playerInput.actions["Jump Idle"];
      jumpRunAction = playerInput.actions["Jump Running"];
    }

    void Update()
    {
      GetInputValues();
      SetRotation();
      Move();
      Jump();
      SetStates();
    }

    void Move()
    {
      controller.SimpleMove(new Vector3(walkValue.x, transform.position.y, walkValue.y) * walkSpeed * (isRunning ? 5.0f : 1.0f));
    }

    void SetStates()
    {
      if(isMoving)
        animator.SetBool("IsWalking", true);
      else
        animator.SetBool("IsWalking", false);

      if(isRunning)
        animator.SetBool("IsRunning", true);
      else
        animator.SetBool("IsRunning", false);
    }

    void GetInputValues()
    {
      walkValue = walkAction.ReadValue<Vector2>();

      if(walkValue.magnitude > 0)
        isMoving = true;
      else
        isMoving = false;

      runValue = runAction.ReadValue<float>();
      if(runValue == 1)
        isRunning = true;
      else
        isRunning = false;

      jumpValue = jumpAction.ReadValue<float>();
      if(jumpValue == 1)
        isJumping = true;
      else
        isJumping = false;
    }

    void SetRotation()
    {
      if(isMoving)
      {
        Quaternion rot = Quaternion.LookRotation(new Vector3(walkValue.x, 0, walkValue.y));
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed * Time.deltaTime * (isRunning ? 5.0f : 1.0f));
      }
    }

    void Jump()
    {
      if(isJumping && !isMoving)
      {
        animator.SetBool("isJumpingIdle", true);
      }
      else if(!isJumping) {
        animator.SetBool("isJumpingIdle", false);
        animator.SetBool("isJumpingRunning", false);
        animator.SetBool("isJumpingWalking", false);
      }

      if(isJumping && isRunning)
      {
        animator.SetBool("isJumpingRunning", true);
      }

      if(isJumping && isMoving && !isRunning)
      {
        animator.SetBool("isJumpingWalking", true);
      }
    }
}

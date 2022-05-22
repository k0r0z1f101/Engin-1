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
  private bool jumpTrigger;
  private bool isJumping;

  //Jump Running
  private InputAction jumpRunAction;
  private float jumpRunValue;
  [Header("Force du saut")]
  [SerializeField]
  private float jumpStrength = 1.0f;

  //Gravity
  [Header("Force de Gravité")]
  [SerializeField]
  private float gravity;
  private float currentFallingSpeed = 0.0f;
  private float maxFallingSpeed = 0.9f;

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
      Debug.Log(controller.isGrounded);
      Debug.Log(currentFallingSpeed);
      Debug.Log(Time.time);
      if(controller.isGrounded)
      {
        currentFallingSpeed = 0.0f;
        isJumping = false;
      }
      else
        ApplyGravity();
      Jump();
      Move();
      SetStates();
    }

    void Move()
    {
      controller.Move(new Vector3(walkValue.x, isJumping ? jumpStrength : 0.0f, walkValue.y) * walkSpeed * (isRunning ? 2.5f : 1.0f) * Time.deltaTime);
      controller.SimpleMove(new Vector3(0.0f, 0.0f, 0.0f));
    }

    void ApplyGravity()
    {
      currentFallingSpeed += gravity * Time.deltaTime;
      currentFallingSpeed = currentFallingSpeed > maxFallingSpeed ? maxFallingSpeed : currentFallingSpeed;
      controller.Move(new Vector3(0.0f, -currentFallingSpeed, 0.0f));
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
      isMoving = walkValue.magnitude > 0 ? true : false;

      runValue = runAction.ReadValue<float>();
      isRunning = runValue == 1 ? true : false;

      jumpValue = jumpAction.ReadValue<float>();
      jumpTrigger = jumpValue == 1 ? true : false;
    }

    void SetRotation()
    {
      if(isMoving)
      {
        Quaternion rot = Quaternion.LookRotation(new Vector3(walkValue.x, 0, walkValue.y));
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed * Time.deltaTime * (isRunning ? 2.5f : 1.0f));
      }
    }

    void Jump()
    {
      if(jumpTrigger && isMoving && !isRunning)
      {
        animator.SetTrigger("jumpTrigger");
        isJumping = true;
        jumpTrigger = false;
      }
    }
}

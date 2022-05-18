using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private CharacterController controller;
  private PlayerInput playerInput;
  private InputAction walkAction;
  private Animator animator;
  [SerializeField]
  private int walkSpeed;
  private Vector2 v2;
  private bool isWalking;
  private bool isMoving;
  [SerializeField]
  private int rotSpeed;
  private InputAction runAction;
  private float runValue;
  private bool isRunning;
    // Start is called before the first frame update
    void Awake()
    {
      controller = GetComponent<CharacterController>();
      playerInput = GetComponent<PlayerInput>();
      animator = transform.GetChild(0).GetComponent<Animator>();
      walkAction = playerInput.actions["Walk"];
      runAction = playerInput.actions["Run"];
    }

    // Update is called once per frame
    void Update()
    {
      // Debug.Log(walkAction.ReadValue<Vector2>());
      GetInputValues();
      SetRotation();
      Move();
      SetStates();
    }

    void Move()
    {
      if(runValue == 1)
        controller.SimpleMove(new Vector3(v2.x, transform.position.y, v2.y) * walkSpeed * 5.0f);
      else
        controller.SimpleMove(new Vector3(v2.x, transform.position.y, v2.y) * walkSpeed);
    }

    void SetStates()
    {
      // animator.SetBool("IsWalking", true);
      // Debug.Log(animator.GetBool("IsWalking"));
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
      v2 = walkAction.ReadValue<Vector2>();
      // if(v2 != Vector2.zero)
      //   Debug.Log("Je bouge");
      if(v2.magnitude > 0)
        isMoving = true;
      else
        isMoving = false;

      runValue = runAction.ReadValue<float>();
      if(runValue == 1)
        isRunning = true;
      else
        isRunning = false;
    }

    void SetRotation()
    {
      if(isMoving)
      {
        // transform.rotation = Quaternion.LookRotation(new Vector3(v2.x, 0, v2.y));
        Quaternion rot = Quaternion.LookRotation(new Vector3(v2.x, 0, v2.y));
        if(isRunning)
          transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed * Time.deltaTime * 5.0f);
        else
          transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
      }
    }
}

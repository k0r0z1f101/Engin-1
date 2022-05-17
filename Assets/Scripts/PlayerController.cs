using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private CharacterController controller;
  private PlayerInput playerInput;
  private InputAction walkAction;
  [SerializeField]
  private int walkSpeed;
    // Start is called before the first frame update
    void Awake()
    {
      controller = GetComponent<CharacterController>();
      playerInput = GetComponent<PlayerInput>();
      walkAction = playerInput.actions["Walk"];
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(walkAction.ReadValue<Vector2>());
      Move();
    }

    void Move()
    {
      Vector2 v2 = walkAction.ReadValue<Vector2>();
      controller.SimpleMove(new Vector3(v2.x, transform.position.y, v2.y) * walkSpeed);
    }
}

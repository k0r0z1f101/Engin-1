using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
  [SerializeField] private InputActionAsset playerInputs;
  [SerializeField] private InputAction leftClick;
  private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
      // cam = GameObject.Find("Main Camera").GetComponent<Camera>();
      cam = Camera.main;
      var aMap = playerInputs.FindActionMap("Player Interactions");
      leftClick = aMap.FindAction("LeftClick");
      leftClick.started += OnLeftClick;
    }

    void OnEnable()
    {
      leftClick.Enable();
    }

    void OnLeftClick(InputAction.CallbackContext context)
    {
      Debug.Log("Clicked!");
      Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
      RaycastHit hit;
      if(Physics.Raycast(ray, out hit))
      {
        Debug.DrawLine(ray.origin, hit.point);
        if(hit.transform.CompareTag("Cube"))
        {
          Debug.Log("cube!");
          hit.rigidbody.AddExplosionForce(20, hit.point, 100, 3.0f, ForceMode.Impulse);
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Mouse.current.leftButton.isPressed)
        //   Debug.Log("Clicked!");
    }
}

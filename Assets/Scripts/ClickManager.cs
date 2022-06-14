using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
  [SerializeField] private InputActionAsset playerInputs;
  [SerializeField] private InputAction leftClick;
  [SerializeField] private Camera cam;
    
    void Awake()
    {
       var aMap = playerInputs.FindActionMap("PlayerInteractions");
       leftClick = aMap.FindAction("LeftClick");
       //Avec cette ligne nous inscrivons notre méthode OnLeftClick à l'évenement leftClick.started.
       leftClick.started += OnLeftClick;  
    }

    private void OnEnable() {
      //Activation de l'évenement.
      leftClick.Enable();  
    }

    void OnLeftClick(InputAction.CallbackContext context){
       Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
       RaycastHit hit;
       if (Physics.Raycast(ray, out hit)){
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.transform.CompareTag("Clickable")){
                Debug.Log("ok");
                hit.rigidbody.AddExplosionForce(20,hit.point,100,3.0f,ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Mouse.current.leftButton.isPressed) {
            Debug.Log("ok");
        }*/

    }
}

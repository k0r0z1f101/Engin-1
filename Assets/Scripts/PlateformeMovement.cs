using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject StartPosObject;
    [SerializeField]
    private GameObject EndPosObject;
    [SerializeField]
    private bool isActive;

    [Range(0, 10)]
    [SerializeField]
    private float speed;
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
     private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position = Vector3.Lerp(StartPosObject.transform.position, EndPosObject.transform.position, Mathf.PingPong(Time.time * speed, 1)); 
    }
}

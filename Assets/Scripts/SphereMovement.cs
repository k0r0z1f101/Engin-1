using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
  private Vector2 m_Move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
      m_Move = value.Get<Vector2>();
      Debug.Log(m_Move);
    }
}

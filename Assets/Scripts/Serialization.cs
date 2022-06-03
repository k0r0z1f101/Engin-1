using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serialization : MonoBehaviour
{
    [System.NonSerialized]
    public int myPublicVar = 10;
    [SerializeField]
    // int myMysteryVar = 20; //private by default
    [HideInInspector]
    public int myPublicVar2;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("pub: "+ myPublicVar);
        // Debug.Log("myst: "+ myMysteryVar);
        Debug.Log("pub var2: "+ myPublicVar2);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
    }
}

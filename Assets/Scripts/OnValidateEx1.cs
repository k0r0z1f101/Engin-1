using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValidateEx1 : MonoBehaviour
{
    [SerializeField]
    private int numberOfCubes;
    private GameObject cubesParent;

    void Start()
    {

    }

    void OnValidate()
    {
            // numberOfCubes = numberOfCubes < 20 ? 20 : numberOfCubes > 40 ? 40 : numberOfCubes;
            numberOfCubes = Mathf.Clamp(numberOfCubes, 0 , 20);
            DestroyCubesParent();
            CreateCubes();
    }

    void CreateCubes()
    {
        cubesParent = new GameObject("CubesParent");
        for(int i = 0; i < numberOfCubes; ++i)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0,i,0);
            cube.transform.localScale = new Vector3(2*(i + 1),-1.0f,2*(i + 1));
            cube.transform.SetParent(cubesParent.transform);

        }
    }

    void DestroyCubesParent()
    {
        if(cubesParent != null)
        {
            Destroy(cubesParent);
            cubesParent = null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValidateEx : MonoBehaviour
{
    [SerializeField]
    private int numberOfCubes;
    private List<GameObject> cubesToDestroy;

    void Awake()
    {
        cubesToDestroy = new List<GameObject>();
    }
    void OnValidate()
    {
            // numberOfCubes = numberOfCubes < 20 ? 20 : numberOfCubes > 40 ? 40 : numberOfCubes;
            numberOfCubes = Mathf.Clamp(numberOfCubes, 0 , 20);
            if (Application.isPlaying){
                DestroyCubes();
                CreateCubes();
            }
    }

    void CreateCubes()
    {
        for(int i = 0; i < numberOfCubes; ++i)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0,i,0);
            cube.transform.localScale = new Vector3(2*i,1.0f,2*i);
            cubesToDestroy.Add(cube);
        }
    }

    void DestroyCubes()
    {
        if(cubesToDestroy != null)
        {
            for(int i = 0; i < cubesToDestroy.Count; ++i)
            {
                Destroy(cubesToDestroy[i]);
            }
        }
    }

}

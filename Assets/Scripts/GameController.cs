using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //asset: list vector2
    //level plane/grid, 
    //walls height, private/serialized
    
    //ConvPixToVec(); //only black pixels are stored
    //DrawLevel(); //render the level with width and height of image (x, z in unity; x, y in image)
    //PlaceWalls(); //iterate list vector2 and place each block at the right position (1:1, image to object pos)

    private List<Vector2> convertedPix;
    [Header("height of the walls")]
    [SerializeField]
    private int wallsHeight;
    [Header("image object")]
    [SerializeField]
    private Object img;


    //convpixtovec method
    void ConvPixToVec()
    {
        Debug.Log(img.name);        
    }

    void Start()
    {
        
    }
    void Awake()
    {
        Debug.Log("assasas");
        ConvPixToVec();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Reflection;

public class GameController : MonoBehaviour
{
    //asset: list vector2
    //level plane/grid, 
    //walls height, private/serialized
    
    //CreateCanvas(); //create parent object for the walls objects
    //ConvPixToVec(); //only black pixels are stored
    //DrawLevel(); //render the level with width and height of image (x, z in unity; x, y in image)
    //PlaceWalls(); //iterate list vector2 and place each block at the right position (1:1, image to object pos)

    private List<Vector2> convertedPix;
    [Header("height of the walls")]
    [SerializeField]
    private int wallsHeight;
    private GameObject canvasParent;
    private Canvas canvasObj;
    private Texture2D levelImg;
    

    void CreateCanvas()
    {
        canvasParent = new GameObject();
        canvasParent.name = "Canvas";
        canvasParent.AddComponent<Canvas>();
        canvasObj = canvasParent.GetComponent<Canvas>();
        canvasObj.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasParent.AddComponent<CanvasScaler>();
        canvasParent.AddComponent<GraphicRaycaster>();
    }

    //convpixtovec method
    void ConvPixToVec()
    {
        Debug.Log(canvasParent.name);
        levelImg = new Texture2D(128, 128);
        // Renderer renderer = levelImg.GetComponent<Renderer>();
        // renderer.material.mainTexture = levelImg;
        levelImg = Resources.Load("imageToConvert", typeof(Texture2D)) as Texture2D;
        Debug.Log(levelImg.width);

        // TextAsset imageAsset = ;
        // tex.LoadImage(imageAsset.bytes);
        // GetComponent<Renderer>().material.mainTexture = tex;
    }

    void Start()
    {
        
    }
    void Awake()
    {
        CreateCanvas();
        // Debug.Log("assasas");
    }

    void Update()
    {

    }

    void OnValidate()
    {
        if(!canvasParent) return;

        wallsHeight = Mathf.Clamp(wallsHeight,0,10);

        foreach (Transform child in canvasParent.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        ConvPixToVec();
    }

    static bool GetImageSize(Texture2D asset, out int width, out int height) {
        if (asset != null) {
            string assetPath = AssetDatabase.GetAssetPath(asset);
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
    
            if (importer != null) {
                object[] args = new object[2] { 0, 0 };
                MethodInfo mi = typeof(TextureImporter).GetMethod("GetWidthAndHeight", BindingFlags.NonPublic | BindingFlags.Instance);
                mi.Invoke(importer, args);
    
                width = (int)args[0];
                height = (int)args[1];
    
                return true;
            }
        }
    
        height = width = 0;
        return false;
    }


}

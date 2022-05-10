using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2 : MonoBehaviour
{
    public Magician2 charac;
    // Start is called before the first frame update
    void Start()
    {
        charac = new Magician2();
        charac.DisplayStats();
    }
}

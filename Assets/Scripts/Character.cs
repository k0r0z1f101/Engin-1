using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Magician charac;
    // Start is called before the first frame update
    void Start()
    {
        charac = new Magician(10, "roger", 12);
        charac.DisplayStats();
    }
}

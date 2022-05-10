using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human2 : LivingBeing2
{
    [SerializeField]
    private string _name;

    public string getName()
    {
        return _name;
    }
}

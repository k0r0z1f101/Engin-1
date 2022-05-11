using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Magician2 : Human2
{
    [SerializeField]
    protected int _mana;

    public void DisplayStats()
    {
        Debug.Log(getName());
        Debug.Log(getLife());
        Debug.Log(_mana);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : Human
{
    private int _mana;

    public Magician(int life, string name, int mana) : base(name, life)
    {
        _mana = mana;
    }

    public void DisplayStats()
    {
        Debug.Log(getName());
        Debug.Log(getLife());
        Debug.Log(_mana);
    }
}

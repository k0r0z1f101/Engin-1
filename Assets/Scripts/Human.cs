using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : LivingBeing
{
    private string _name;

    public Human(string name, int life) : base(life)
    {
        _name = name;
    }

    public string getName()
    {
        return _name;
    }
}

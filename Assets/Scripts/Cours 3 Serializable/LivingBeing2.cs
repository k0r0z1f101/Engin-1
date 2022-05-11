using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LivingBeing2 : Character2
{
    [SerializeField]
    protected int _lifePoint;

    public int getLife()
    {
        return _lifePoint;
    }
}

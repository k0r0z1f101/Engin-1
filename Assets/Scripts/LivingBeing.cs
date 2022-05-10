using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBeing : Character
{
    private int _lifePoint;

    public LivingBeing(int life)
    {
        _lifePoint = life;
    }

    public int getLife()
    {
        return _lifePoint;
    }
}

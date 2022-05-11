using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Magician _charac;
    [SerializeField]
    private Weapon _weapon;
    // Start is called before the first frame update
    void Start()
    {
        _charac = new Magician(10, "roger", 12);
        _charac.DisplayStats();
        // _weapon = new Weapon("Magic Staff", 100);
        _weapon.PrintWeaponStats();
    }
}

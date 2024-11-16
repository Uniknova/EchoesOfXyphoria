using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee
{
    public GameObject meleeL;
    public GameObject meleeR;

    public Melee(GameObject meleeL, GameObject meleeR)
    {
        this.meleeL = meleeL;
        this.meleeR = meleeR;
    }

    public GameObject GetMeleeL()
    {
        return meleeL;
    }
    public GameObject GetMeleeR()
    {
        return meleeR;
    }
}

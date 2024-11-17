using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee
{
    public GameObject meleeL;
    public GameObject meleeR;
    public bool isAttacking;

    public Melee(GameObject meleeL, GameObject meleeR)
    {
        this.meleeL = meleeL;
        this.meleeR = meleeR;
        isAttacking = false;
    }

    public GameObject GetMeleeL()
    {
        return meleeL;
    }
    public GameObject GetMeleeR()
    {
        return meleeR;
    }

    public void Attack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    public bool GetAttack()
    {
        return isAttacking;
    }
}

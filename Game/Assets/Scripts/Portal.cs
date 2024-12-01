using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null && (other.GetComponentInParent<Player>().weapons.Count > 0 || other.GetComponentInParent<Player>().meleeWeapons.Count>0))
        {
            LoadGameScene();
        }


        
    }
    public void LoadGameScene()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_GAME);
    }
}

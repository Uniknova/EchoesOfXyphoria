using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraS : MonoBehaviour
{

    private static MainCameraS instance;

    public static MainCameraS Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

}

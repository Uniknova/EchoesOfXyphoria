using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraS : MonoBehaviour
{

    private static VirtualCameraS instance;

    public static VirtualCameraS Instance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            //gameObject.transform.SetParent(Player.Instance.transform);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}

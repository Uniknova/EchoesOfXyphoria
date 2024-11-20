using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo
{

    private static DataInfo instance;
    private GameObject go = new GameObject();
    private static RuntimePlatform platform;


    public static DataInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataInfo();
                instance.Init();
            }

            return instance;
        }

    }

    private void Init()
    {
        platform = Application.platform;
    }
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (Application.platform == RuntimePlatform.Android ||
    //        Application.platform == RuntimePlatform.IPhonePlayer)
    //    {
    //        Debug.Log("Android");

    //    }

    //    else
    //    {
    //        Debug.Log("Pc");
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public int GetPlatform()
    {
        Debug.Log(Application.platform);
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Android");
            return 0;
        }

        else
        {
            Debug.Log("Pc");
            return 1;
        }
    }
}

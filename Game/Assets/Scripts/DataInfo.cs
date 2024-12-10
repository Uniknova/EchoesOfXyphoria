using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo
{

    private static DataInfo instance;
    private GameObject go = new GameObject();
    private static RuntimePlatform platform;
    private static int dinero = 0;


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

    public static void AddMoney(int money)
    {
        dinero += money;
        Debug.Log(dinero);
    }

    public static int GetMoney()
    {
        return dinero;
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
        Debug.Log(Application.isMobilePlatform);

        if (Application.isMobilePlatform)
        {
            Debug.Log("Estás jugando en un dispositivo móvil.");
            return 0;
        }
        else
        {
            Debug.Log("Estás jugando en una PC.");
            return 1;
        }
        //if (Application.platform == RuntimePlatform.Android ||
        //    Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    Debug.Log("Android");
        //    return 0;
        //}

        //else
        //{
        //    Debug.Log("Pc");
        //    return 1;
        //}
    }

   
}

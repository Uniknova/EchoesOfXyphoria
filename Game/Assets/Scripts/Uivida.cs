using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uivida : MonoBehaviour
{

    private static Uivida instance;
    public Image fill;

    public static Uivida Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<Uivida>("Uivida"));
                //instance.gameObject.SetActive(false);
                //DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    public void Active(bool act)
    {
        instance.gameObject.SetActive(act);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

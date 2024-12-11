using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDia : MonoBehaviour
{

    public int cicleSpeed = 10;
    float i;
    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(cicleSpeed * Time.deltaTime,0,0);
        i = transform.rotation.eulerAngles.x;
        
        if (i > 0 && i < 90)
        {
            GetComponent<Light>().intensity = 1;
        }

        else if (i > 270 && i < 360)
        {
            GetComponent<Light>().intensity = 0;
        }


    }
}

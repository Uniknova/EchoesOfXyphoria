using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    [SerializeField] GameObject rbutton; 
    [SerializeField] GameObject ibutton; 
    [SerializeField] GameObject pbutton; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pausaButtonDesactivate()
    {
        pbutton.SetActive(false);
    }

    public void pausaButtonActivate()
    {
        pbutton.SetActive(true);
    }

    public void buttonsActivate()
    {
        ibutton.SetActive(true);
        rbutton.SetActive(true);
    }

    public void buttonsDesactivate()
    {
        ibutton.SetActive(false);
        rbutton.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    TextMeshProUGUI Text;
    private static Monedas instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Text = GetComponent<TextMeshProUGUI>();
        Text.text = DataInfo.GetMoney().ToString();
        Debug.Log(DataInfo.GetMoney().ToString());
    }

    public static void AddMoney(int money)
    {
        DataInfo.AddMoney(money);
        instance.Text.text = DataInfo.GetMoney().ToString();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

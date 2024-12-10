using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{

    [SerializeField]private List<Button> buttons = new List<Button>();
    [SerializeField]private List<int> precios = new List<int>();


    private void Start()
    {
        int i = 0;
        foreach (Button button in buttons)
        {
            int aux = i;
            Debug.Log(i);
            button.onClick.AddListener(() => DataInfo.AddMoney(precios[aux]));
            i++;
        }
    }
    public void AddMoney(int money)
    {
        DataInfo.AddMoney(money);
    }

//#if UNITY_EDITOR
//    private void OnEnable()
//    {
//        foreach (Button button in buttons)
//        {
//            precios.Add(0);
//        }
//    }
//#endif
}

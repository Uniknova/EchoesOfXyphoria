using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    private static Coins instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Text = GetComponent<TextMeshProUGUI>();
        Text.text = DataInfo.GetCoins().ToString();
    }

    public static void AddCoins(int coin)
    {
        DataInfo.AddCoins(coin);
        instance.Text.text = DataInfo.GetCoins().ToString();
    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{

    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject hp;
    [SerializeField] private GameObject damage;
    [SerializeField] private GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        armor.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetArmorLevel()/3) + 1) * 20).ToString();
        armor.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetArmor().ToString();

        hp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetHpLevel() / 3) + 1) * 20).ToString();
        hp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetHp().ToString();

        damage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetDamageLevel() / 3) + 1) * 20).ToString();
        damage.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetDamage().ToString();

        coin.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetCoinLevel() / 3) + 1) * 20).ToString();
        coin.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetCoin().ToString();
    }

    public void AddArmor()
    {
        //Player.SetArmor();
        if (DataInfo.GetCoins() >= (Mathf.Max(1, (DataInfo.GetArmorLevel() / 3) + 1) * 20))
        {
            Coins.AddCoins(-(Mathf.Max(1, (DataInfo.GetArmorLevel() / 3) + 1) * 20));
            DataInfo.AddArmorLevel();
            armor.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetArmorLevel() / 3) + 1) * 20).ToString();
            armor.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetArmor().ToString();
        }
    }

    public void AddHp()
    {
        if (DataInfo.GetCoins() >= (Mathf.Max(1, (DataInfo.GetHpLevel() / 3) + 1) * 20))
        {
            Coins.AddCoins(-(Mathf.Max(1, (DataInfo.GetHpLevel() / 3) + 1) * 20));
            DataInfo.AddHpLevel();
            hp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetHpLevel() / 3) + 1) * 20).ToString();
            hp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetHp().ToString();
        }
    }

    public void AddDamage()
    {
        if (DataInfo.GetCoins() >= (Mathf.Max(1, (DataInfo.GetDamageLevel() / 3) + 1) * 20))
        {
            Coins.AddCoins(-(Mathf.Max(1, (DataInfo.GetDamageLevel() / 3) + 1) * 20));
            DataInfo.AddDamageLevel();
            damage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetDamageLevel() / 3) + 1) * 20).ToString();
            damage.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetDamage().ToString();
        }
    }

    public void AddCoin()
    {
        if (DataInfo.GetCoins() >= (Mathf.Max(1, (DataInfo.GetCoinLevel() / 3) + 1) * 20))
        {
            Coins.AddCoins(-(Mathf.Max(1, (DataInfo.GetCoinLevel() / 3) + 1) * 20));
            DataInfo.AddCoinLevel();
            coin.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (Mathf.Max(1, (DataInfo.GetCoinLevel() / 3) + 1) * 20).ToString();
            coin.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataInfo.GetCoin().ToString();
        }
    }

    public void Volver()
    {
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY);
    }
}

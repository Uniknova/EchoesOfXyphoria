using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo
{

    private static DataInfo instance;
    private GameObject go = new GameObject();
    private static RuntimePlatform platform;
    private static int dinero = 0;
    private static int coin = 500;
    private static List<bool> desbloqueado = new List<bool>();
    private static List<Ranking> rankings = new List<Ranking>();
    private static int armorLevel = 1;
    private static int damageLevel = 1;
    private static int hpLevel = 1;
    private static int coinLevel = 1;

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

    public static void AddRank(Ranking ranking)
    {
        rankings.Add(ranking);
        SortRanking();
    }

    public static List<Ranking> GetRanking()
    {
        return rankings;
    }

    public static void SortRanking()
    {
        List<int> orden = new List<int>();
        foreach (Ranking ranking in rankings)
        {
            orden.Add(ranking.score);
        }
        orden.Sort();
        List<Ranking> rank = new List<Ranking>();


        for (int i = orden.Count - 1; i >= orden.Count - 5 && i>= 0; i--)
        {
            int o = orden[i];
            rank.Add(rankings.Find((x) => x.score == o));
        }
        //foreach (int o in orden)
        //{

        //    rank.Add(rankings.Find((x) => x.score == o));
        //}

        rankings = rank;
    }

    public static void AddMoney(int money)
    {
        dinero += money;
        Debug.Log(dinero);
    }

    public static void AddCoins(int money)
    {
        coin += money;
        Debug.Log(coin);
    }

    public static int GetMoney()
    {
        return dinero;
    }

    public static int GetCoins()
    {
        return coin;
    }

    private void Init()
    {
        Ranking primero = new Ranking("Cris", 1, 200, 24);
        Ranking segundo = new Ranking("Rodrigo", 1, 100, 15);
        Ranking tercero = new Ranking("Navarro", 1, 50, 6);

        rankings.Add(segundo);
        rankings.Add(tercero);
        rankings.Add(primero);

        SortRanking();
        foreach (Ranking ranking in rankings)
        {
            Debug.Log("nombre " + ranking.name + " puntuacion " + ranking.score);
        }
        

        platform = Application.platform;
        desbloqueado.Add(true);

        for (int i = 0; i < 5; i++)
        {
            desbloqueado.Add(false);
        }
    }

    public static List<bool> GetDesbloqueado()
    {
        return desbloqueado;
    }

    public static void SetUnlocked(int idx)
    {
        desbloqueado[idx] = true;
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

    public static int GetArmorLevel()
    {
        return armorLevel;
    }

    public static int GetDamageLevel()
    {
        return damageLevel;
    }

    public static int GetHpLevel()
    {
        return hpLevel;
    }

    public static int GetCoinLevel()
    {
        return coinLevel;
    }

    public static void AddArmorLevel()
    {
        Player.SetArmor();
        armorLevel++;
    }

    public static void AddDamageLevel()
    {
        Player.SetDamage();
        damageLevel++;
    }

    public static void AddHpLevel()
    {
        Player.SetHp();
        hpLevel++;
    }

    public static void AddCoinLevel()
    {
        Player.SetCoin();
        coinLevel++;
    }

    public static float GetArmor()
    {
        return 0.5f * armorLevel;
    }

    public static float GetDamage()
    {
        return (float)damageLevel;
    }

    public static float GetHp()
    {
        return 10f * hpLevel;
    }

    public static float GetCoin()
    {
        return 10f * coinLevel;
    }

    public struct Ranking
    {
        public Ranking(string n, int sa, int s, int e)
        {
            name = n;
            salas = sa;
            score = s;
            enemigos = e;
        }
        public string name;
        public int salas;
        public int score;
        public int enemigos;
    }


}

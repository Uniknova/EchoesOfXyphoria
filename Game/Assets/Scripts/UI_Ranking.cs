using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataInfo;

public class UI_Ranking : MonoBehaviour
{
    [SerializeField] private GameObject fondo;
    [SerializeField] private GameObject terry;
    [SerializeField] private GameObject estrella;
    [SerializeField] private GameObject primero;
    [SerializeField] private GameObject segundo;
    [SerializeField] private GameObject tercero;

    private float posCasilla;
    private float posCasillaX = 3.4f;
    private float posTerryX = -577.99f;

    private static UI_Ranking instance;

    public static UI_Ranking Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<UI_Ranking>("Ranking"));
            }

            return instance;
        }
    }

    public void ShowRank()
    {
        posCasilla = 283.25f;

        DataInfo d = DataInfo.Instance;
        List<Ranking> ranks = DataInfo.GetRanking();
        Debug.Log(ranks.Count);

        foreach (Ranking rank in ranks)
        {
            Debug.Log("si");
            GameObject go = Instantiate(fondo);
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(posCasillaX, posCasilla, 0);
            go = Instantiate(terry);
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(posTerryX, posCasilla, 0);
            posCasilla -= 170f;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("fdsafsa");
        ShowRank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

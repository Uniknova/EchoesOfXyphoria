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
        List<Ranking> ranks = DataInfo.GetRanking();


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

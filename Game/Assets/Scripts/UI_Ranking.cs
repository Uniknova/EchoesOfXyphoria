using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataInfo;

public class UI_Ranking : MonoBehaviour
{
    [SerializeField] private GameObject fondo;
    [SerializeField] private Sprite fondoImage;
    [SerializeField] private GameObject terry;
    [SerializeField] private Sprite terryImage;
    [SerializeField] private GameObject estrella;
    [SerializeField] private Sprite estrellaImage;
    [SerializeField] private GameObject primero;
    [SerializeField] private Sprite primeroImage;
    [SerializeField] private GameObject segundo;
    [SerializeField] private Sprite segundoImage;
    [SerializeField] private GameObject tercero;
    [SerializeField] private Sprite terceroImage;
    [SerializeField] private GameObject texto;
    [SerializeField] private Button volver;
    [SerializeField] private List<GameObject> casillas;

    private float posCasilla;
    private float posCasillaX = 3.4f;
    private float posTerryX = -577.99f;
    private float posEstrellaX = -736.97f;
    private float posTextoX = 156.1826f;
    private float posTexto = 253.94f;

    private static UI_Ranking instance;

    public static UI_Ranking Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<UI_Ranking>("Ranking"));
                instance.volver.onClick.AddListener(() => { TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY); });
            }

            return instance;
        }
    }

    public void ShowRank()
    {
        int i = 0;

        foreach (Ranking rank in DataInfo.GetRanking())
        {
            casillas[i].GetComponent<Image>().sprite = fondoImage;
            casillas[i].transform.GetChild(0).GetComponent<Image>().sprite = terryImage;

            if (i == 0)
            {
                casillas[i].transform.GetChild(1).GetComponent<Image>().sprite = primeroImage;
            }

            else if (i == 1)
            {
                casillas[i].transform.GetChild(1).GetComponent<Image>().sprite = segundoImage;
            }

            else if(i == 2)
            {
                casillas[i].transform.GetChild(1).GetComponent<Image>().sprite = terceroImage;
            }

            else
            {
                casillas[i].transform.GetChild(1).GetComponent<Image>().sprite = estrellaImage;
            }

            casillas[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = rank.name + "  puntuacion: " + rank.score + "  salas: " + rank.salas;

            i++;
        }

        while (i < 5)
        {
            casillas[i].SetActive(false);
            i++;
        }
    }

    //public void ShowRank()
    //{
    //    posCasilla = 283.25f;
    //    int i = 0;

    //    DataInfo d = DataInfo.Instance;
    //    List<Ranking> ranks = DataInfo.GetRanking();
    //    Debug.Log(ranks.Count);

    //    foreach (Ranking rank in ranks)
    //    {
    //        Debug.Log("si");
    //        GameObject go = Instantiate(fondo);
    //        go.transform.SetParent(transform);
    //        go.transform.localPosition = new Vector3(posCasillaX, posCasilla, 0);
    //        go = Instantiate(terry);
    //        go.transform.SetParent(transform);
    //        go.transform.localPosition = new Vector3(posTerryX, posCasilla, 0);

    //        if (i == 0)
    //        {
    //            go = Instantiate(primero);
    //            go.transform.SetParent(transform);
    //            go.transform.localPosition = new Vector3(posEstrellaX, posCasilla, 0);
    //        }

    //        else if (i == 1)
    //        {
    //            go = Instantiate(segundo);
    //            go.transform.SetParent(transform);
    //            go.transform.localPosition = new Vector3(posEstrellaX, posCasilla, 0);
    //        }

    //        else if (i == 2)
    //        {
    //            go = Instantiate(tercero);
    //            go.transform.SetParent(transform);
    //            go.transform.localPosition = new Vector3(posEstrellaX, posCasilla, 0);
    //        }

    //        else
    //        {
    //            go = Instantiate(estrella);
    //            go.transform.SetParent(transform);
    //            go.transform.localPosition = new Vector3(posEstrellaX, posCasilla, 0);
    //        }

    //        go = Instantiate(texto);
    //        go.transform.SetParent(transform);
    //        go.transform.localPosition = new Vector3(posTextoX, posTexto, 0);
    //        go.GetComponent<TextMeshProUGUI>().text = rank.name + "  puntuacion: " + rank.score + "  salas: " + rank.salas;
    //        posCasilla -= 170f;
    //        posTexto -= 170f;
    //        i++;
    //    }




    //}
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("fdsafsa");
        //ShowRank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

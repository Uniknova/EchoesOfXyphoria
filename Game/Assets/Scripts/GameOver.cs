using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private static GameOver instance;
    public TextMeshProUGUI score;
    public TextMeshProUGUI enemies;
    public TextMeshProUGUI rooms;
    public TextMeshProUGUI nombre;
    public Button boton;
    public Animator animator;
    private int salas;
    private int puntuacion;
    private int enemigos;

    public static GameOver Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<GameOver>("GameOver"));
                instance.boton.onClick.AddListener(instance.SetRank);
                //instance.boton.onClick.AddListener(() => { TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY); });
            }

            return instance;
        }
    }

    public void SetStats(int s, int e, int r)
    {
        salas = r;
        puntuacion = s;
        enemigos = e;
        score.text = s.ToString();
        enemies.text = e.ToString();
        rooms.text = r.ToString();
        animator.SetTrigger("Open");
        
    }

    public void SetRank()
    {
        DataInfo.AddRank(new DataInfo.Ranking(nombre.text, salas, puntuacion, enemigos));
        UI_Ranking.Instance.ShowRank();
    }
}

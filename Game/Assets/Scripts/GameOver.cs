using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private static GameOver instance;
    public TextMeshProUGUI score;
    public TextMeshProUGUI enemies;
    public TextMeshProUGUI rooms;
    public Button boton;
    public Animator animator;

    public static GameOver Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<GameOver>("GameOver"));
                instance.boton.onClick.AddListener(() => { TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LOBBY); });
            }

            return instance;
        }
    }

    public void SetStats(int s, int e, int r)
    {
        score.text = s.ToString();
        enemies.text = e.ToString();
        rooms.text = r.ToString();
        animator.SetTrigger("Open");
        
    }
}

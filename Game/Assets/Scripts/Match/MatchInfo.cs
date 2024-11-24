using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchInfo : MonoBehaviour
{

    public int score;
    public Player player;
    public int killedEnemies;
    public int remainEnemies;
    public int enemiesToSpawn;
    public int salasSuperadas;
    public int instanciaSalas;
    public Room actualRoom;
    private static MatchInfo instance;
    public RunSpawn runSpawn;
    public EnemyScriptableObject normalEnemy;
    public EnemyScriptableObject poisonEnemy;
    public EnemyScriptableObject dashEnemy;
    public EnemyScriptableObject tankEnemy;
    // Start is called before the first frame update


    public static MatchInfo Instance
    {
        get
        {
            if ( instance == null)
            {
                instance = Instantiate(Resources.Load<MatchInfo>("MatchManager"));
                instance.salasSuperadas = 0;
                instance.enemiesToSpawn = 5;
                instance.instanciaSalas = 3;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instanciaSalas = 3;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        salasSuperadas = 0;
        enemiesToSpawn = 5;
        instanciaSalas = 3;
        Init();
    }

    public void Init()
    {
        player = FindObjectOfType<Player>();
        score = 0;
    }

    public void Respawn(Transform respawn)
    {
        if (respawn != null && player != null)
        {
            player.Respawn(respawn);
        }
    }

    public void AddScore(int scoreEnemy)
    {
        Debug.Log("killed enemies " + killedEnemies);
        score += scoreEnemy;
        killedEnemies++;

        if (killedEnemies >= remainEnemies)
        {
            salasSuperadas++;
            enemiesToSpawn++;
            actualRoom.ActiveTriggers();
        }
    }

    public void SetRoom(Room room)
    {
        actualRoom = room;
        killedEnemies = 0;
        actualRoom.SetEnemies(enemiesToSpawn);
        remainEnemies = room.GetEnemies();
    }

    public void EndLevel()
    {
        instanciaSalas++;
        LevelStats(normalEnemy);
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_GAME);
    }

    public void LevelStats(EnemyScriptableObject enemy)
    {
        enemy.health += 20;
        enemy.damage += 5;
        enemy.speed += 0.1f;
        enemy.armor += 0.5f;
        enemy.score += 10;
    }

    public void ResetEnemies()
    {
        normalEnemy.ResetStats();
        poisonEnemy.ResetStats();
        dashEnemy.ResetStats();
        tankEnemy.ResetStats();
    }

    public int GetSalas()
    {
        return instanciaSalas;
    }


}

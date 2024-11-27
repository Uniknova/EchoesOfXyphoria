using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
    public int totalEnemies;
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
                instance.totalEnemies = 0;
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
        totalEnemies++;

        if (killedEnemies >= remainEnemies)
        {
            salasSuperadas++;
            enemiesToSpawn++;
            if (actualRoom.bossRespawn != null) return;
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
        LevelStats(normalEnemy, 20, 2, 0.2f, 0.5f, 10);
        LevelStats(poisonEnemy, 20, 3, 0.2f, 0.5f, 10);
        LevelStats(dashEnemy, 10, 2, 0.3f, 0.2f, 15);
        LevelStats(tankEnemy, 30, 4, 0.1f, 0.7f, 20);
        Player.Instance.PlayerHealth(Player.Instance.hpMax / 2);
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_GAME);
    }

    public void LevelStats(EnemyScriptableObject enemy, float health, float damage, float speed, float armor, int score)
    {
        enemy.health += health;
        enemy.damage += damage;
        enemy.speed += speed;
        enemy.armor += armor;
        enemy.score += score;
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

    public void SetGameOver()
    {
        GameOver.Instance.SetStats(score, totalEnemies, salasSuperadas);
    }


}

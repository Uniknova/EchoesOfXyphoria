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
    public int surprassedRooms;
    public int instancerooms;
    public int totalEnemies;
    public int moreEnemiesPerRoom;
    public int moreRoomsPerLevel;
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
                instance.surprassedRooms = 0;
                instance.enemiesToSpawn = 5;
                instance.instancerooms = 10;
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
            instancerooms = 3;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        surprassedRooms = 0;
        enemiesToSpawn = 5;
        instancerooms = 10;
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
            surprassedRooms++;
            enemiesToSpawn += moreEnemiesPerRoom;
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
        instancerooms += moreRoomsPerLevel;
        LevelStats(normalEnemy, 20, 2, 0.2f, 0.5f, 10);
        LevelStats(poisonEnemy, 20, 3, 0.2f, 0.5f, 10);
        LevelStats(dashEnemy, 10, 2, 0.3f, 0.2f, 15);
        LevelStats(tankEnemy, 30, 4, 0.1f, 0.7f, 20);
        Player.Instance.PlayerHealth(Player.hpMax / 2);
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
        return instancerooms;
    }

    public void SetGameOver()
    {
        GameOver.Instance.SetStats(score, totalEnemies, surprassedRooms);
    }


}

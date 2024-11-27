using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSpeedSelect : IPowerSelect
{
    public IPowerEnemy powerEnemy = new SpeedDownPower();
    // Start is called before the first frame update
    void Start()
    {
        powerEnemy = new SpeedDownPower();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        powerEnemy = new SpeedDownPower();
    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        SpeedDownPower power = Player.Instance.weapon.GetSpeed();
        if (power == null)
        {
            button.onClick.AddListener(powerEnemy.AddPower);
            button.onClick.AddListener(() =>
            {
                p.Restart();
            });
        }

        else
        {
            button.onClick.AddListener(power.LevelUp);

            if (power.GetLevel() >= 2)
            {

                button.onClick.AddListener(() =>
                {
                    select[idx] = true;
                    p.Restart();
                });
            }

            else
            {
                button.onClick.AddListener(() =>
                {
                    p.Restart();
                });
            }
        }
    }
}

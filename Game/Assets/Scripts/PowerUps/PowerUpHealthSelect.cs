using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHealthSelect : IPowerSelect
{
    public HealthDeathPower powerEnemy = new HealthDeathPower();
    // Start is called before the first frame update
    void Start()
    {
        powerEnemy = new HealthDeathPower();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        powerEnemy = new HealthDeathPower();
    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        HealthDeathPower power = Player.Instance.GetHealthDeath();
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

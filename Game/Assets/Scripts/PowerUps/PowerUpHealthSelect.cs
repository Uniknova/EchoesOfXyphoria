using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHealthSelect : IPowerSelect
{
    public HealthDeathPower powerEnemy = new HealthDeathPower(10);
    // Start is called before the first frame update
    void Start()
    {
        powerEnemy = new HealthDeathPower( 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        button.onClick.AddListener(powerEnemy.AddPower);
        button.onClick.AddListener(() =>
        {
            select[idx] = true;
            p.Restart();
        });
    }
}

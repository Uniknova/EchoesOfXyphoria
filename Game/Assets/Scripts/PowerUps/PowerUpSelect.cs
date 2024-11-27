using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSelect : IPowerSelect
{
    public IPowerEnemy powerEnemy = new FirePower();

    // Start is called before the first frame update
    void Start()
    {
        powerEnemy = new FirePower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        powerEnemy = new FirePower();
    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        FirePower firepower = Player.Instance.weapon.GetFire();
        if (firepower == null)
        {
            button.onClick.AddListener(powerEnemy.AddPower);
            button.onClick.AddListener(() =>
            {
                p.Restart();
            });
        }

        else
        {
            button.onClick.AddListener(firepower.LevelUp);

            if (firepower.Level >= 2)
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

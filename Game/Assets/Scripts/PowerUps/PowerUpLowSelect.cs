using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpLowSelect : IPowerSelect
{
    
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        level = 1;
    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        if (!Player.Instance.lowPower)
        {
            button.onClick.AddListener(() => Player.Instance.lowPower = true);

            button.onClick.AddListener(() =>
            {
                level++;
                p.Restart();
            });
        }

        else
        {
            button.onClick.AddListener(Player.Instance.LevelUp);

            if (Player.Instance.GetLevel() >= 2)
            {

                button.onClick.AddListener(() =>
                {
                    level++;
                    select[idx] = true;
                    p.Restart();
                });
            }

            else
            {
                button.onClick.AddListener(() =>
                {
                    level++;
                    p.Restart();
                });
            }
        }
        
    }
}

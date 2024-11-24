using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpLowSelect : IPowerSelect
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {
        button.onClick.AddListener(() => Player.Instance.lowPower = true);
        button.onClick.AddListener(() =>
        {
            select[idx] = true;
            p.Restart();
        });
    }
}

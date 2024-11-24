using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IPowerSelect : MonoBehaviour
{
    public Sprite sprite;

    public virtual void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {

    }
}

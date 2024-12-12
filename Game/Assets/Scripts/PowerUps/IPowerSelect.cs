using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class IPowerSelect : MonoBehaviour
{
    public Sprite sprite;
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI descripcion;
    public int level;
    public List<string> levels = new List<string>();

    public virtual void SetButt(Button button, List<bool> select, int idx, PowerUpsCanvas p)
    {

    }

    public virtual void Init()
    {

    }
}

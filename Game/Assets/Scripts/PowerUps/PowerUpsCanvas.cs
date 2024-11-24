using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsCanvas : MonoBehaviour
{

    public List<IPowerSelect> powerUpsTexture;
    public List<ImagenPowerUp> powerUpsImage;
    public List<bool> powerSelected;
    public List<IPowerSelect> allPowers;
    private Animator animator;

    private static PowerUpsCanvas instance;

    public static PowerUpsCanvas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<PowerUpsCanvas>("Power Ups"));
                DontDestroyOnLoad(instance);
                instance.InitStats();
                instance.gameObject.SetActive(false);
            }

            return instance;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //powerSelected = new List<bool>();
        //for (int i = 0; i < powerUpsTexture.Count; i++)
        //{
        //    powerSelected.Add(false);
        //}

        //for (int i = 0; i < powerUpsTexture.Count; i++)
        //{
        //    allPowers.Add(powerUpsTexture[i]);
        //}
        //int idx;
        //for (int i = 0; i < 3; i++)
        //{
        //    idx = Random.Range(0,powerUpsTexture.Count);
        //    powerUpsImage[i].sprite = powerUpsTexture[idx].sprite;
        //    powerUpsTexture[idx].SetButt(powerUpsImage[i].GetComponent<Button>(), powerSelected, allPowers.IndexOf(powerUpsTexture[idx]), this);
        //    powerUpsTexture.RemoveAt(idx);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitStats()
    {
        animator = GetComponent<Animator>();
        powerSelected = new List<bool>();
        for (int i = 0; i < powerUpsTexture.Count; i++)
        {
            powerSelected.Add(false);
            powerUpsTexture[i].Init();
        }

        for (int i = 0; i < powerUpsTexture.Count; i++)
        {
            allPowers.Add(powerUpsTexture[i]);
        }
    }

    public void Init()
    {
        if (powerUpsTexture.Count <= 0)
        {
            MatchInfo.Instance.EndLevel();
            return;
        }
        gameObject.SetActive(true);
        int idx;
        for (int i = 0; i < 3; i++)
        {
            if (powerUpsTexture.Count > 0)
            {
                idx = Random.Range(0, powerUpsTexture.Count);
                powerUpsImage[i].imagen.sprite = powerUpsTexture[idx].sprite;
                powerUpsImage[i].titulo.text = powerUpsTexture[idx].titulo.text;
                powerUpsImage[i].descripcion.text = powerUpsTexture[idx].descripcion.text;
                powerUpsTexture[idx].SetButt(powerUpsImage[i].GetComponent<Button>(), powerSelected, allPowers.IndexOf(powerUpsTexture[idx]), this);
                powerUpsTexture.RemoveAt(idx);
            }
            else
            {
                powerUpsImage[i].gameObject.SetActive(false);
            }
        }
        animator.SetBool("Open", true);
    }

    public void Restart()
    {
        animator.SetBool("Open", false);
        gameObject.SetActive(false);
        MatchInfo.Instance.EndLevel();
        for (int i = 0; i < 3; i++)
        {
            powerUpsImage[i].gameObject.SetActive(true);
            powerUpsImage[i].imagen.sprite = null;
            powerUpsImage[i].titulo.text = null;
            powerUpsImage[i].descripcion.text = null;
            powerUpsImage[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }

        powerUpsTexture = new List<IPowerSelect>();
        for (int i = 0;i < allPowers.Count; i++)
        {
            if (powerSelected[i] == false) powerUpsTexture.Add(allPowers[i]);
        }

        allPowers.RemoveAt(powerSelected.IndexOf(true));
        powerSelected.RemoveAt(powerSelected.IndexOf(true));

        
    }
}

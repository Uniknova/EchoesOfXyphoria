using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{

    public List<GameObject> planos = new List<GameObject>();

    //Dia y noche
    public GameObject luz;
    public GameObject diaImagen;
    public GameObject nocheImagen;
    public GameObject suciedadAsset;

    public int materiales = 2;
    public List<Transform> listaOcupado;
    public List<Transform> listaArmas;
    public List<Transform> listaSuciedad;
    public List<Transform> listaTotal;
    public List<string> prioridades;
    public Transform huecosT;

    //Musica
    public AudioSource canto;
    public AudioSource pintar;
    public AudioSource crearArmas;
    public AudioSource buscar;
    public AudioSource colocar;

    public float ciclo;
    public bool diab = false;


    public float timer = 1;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in huecosT)
        {
            listaArmas.Add(t);
            listaTotal.Add(t);
        }

        prioridades.Add("Pistola");
        prioridades.Add("Rifle");
        prioridades.Add("Escopeta");
        prioridades.Add("Franco");
        prioridades.Add("Garras");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;
        ciclo = luz.GetComponent<CicloDia>().transform.rotation.eulerAngles.x;

        if (ciclo > 0 && ciclo < 90 && !diab)
        {
            diab = true;
            StartCoroutine(AmbienteCoroutine(0));
        }

        if (ciclo > 270 && ciclo < 360 && diab)
        {
            diab = false;
            StartCoroutine(AmbienteCoroutine(1));
        }
    }

    private IEnumerator AmbienteCoroutine(int idx)
    {
        AudioManager.StopAmbientSound();

        yield return new WaitForSeconds(2f);

        if (idx == 0) AudioManager.PlayDia();

        else AudioManager.PlayNoche();
    }

    public bool Hayplanos()
    {
        return planos.Count > 0;
    }

    public bool dia()
    {
        diaImagen.SetActive(false);
        nocheImagen.SetActive(true);
        float i = luz.GetComponent<CicloDia>().transform.rotation.eulerAngles.x;

        if (i > 0 && i < 90)
            return true;
        else return false;

    }
    public bool noche()
    {
        diaImagen.SetActive(true);
        nocheImagen.SetActive(false);
        float i = luz.GetComponent<CicloDia>().transform.rotation.eulerAngles.x;

        if (i > 270 && i < 360)
            return true;
        else return false;
    }

    public void Sucio(Transform t)
    {
        GameObject go = Instantiate(suciedadAsset);
        go.transform.SetParent(null);
        go.transform.position = new Vector3(t.position.x, t.position.y +0.05f, t.position.z);
        listaSuciedad.Add(go.transform);
    }

    public void Limpiar(int idx)
    {
        GameObject go = listaSuciedad[idx].gameObject;
        
        //listaSuciedad[idx].gameObject.SetActive(false);
        listaSuciedad.RemoveAt(idx);
        Destroy(go);
    }
}

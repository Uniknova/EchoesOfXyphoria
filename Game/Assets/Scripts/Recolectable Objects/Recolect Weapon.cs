using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectWeapon : MonoBehaviour
{
    public int index = -1;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<Player>() != null)
        {
            GameObject weaponL;
            if (index == -1)
            {
                if (other.GetComponentInParent<Player>().indexWeapon != -1)
                {
                    other.GetComponentInParent<Player>().weapons[other.GetComponentInParent<Player>().indexWeapon].SetActive(false);
                }
                index = other.GetComponentInParent<Player>().weapons.Count;
                weaponL = Instantiate(gameObject);
                weaponL.GetComponent<Animator>().enabled = false;
                weaponL.GetComponent<RecolectWeapon>().enabled = false;
                weaponL.transform.position = other.GetComponentInParent<Player>().Hand.transform.position;
                weaponL.transform.SetParent(other.transform);
                other.GetComponentInParent<Player>().weapons.Add(weaponL);
                other.GetComponentInParent<Player>().indexWeapon = index;

            }

            else if (other.GetComponentInParent<Player>().weapons[index].activeSelf == false)
            {
                other.GetComponentInParent<Player>().weapons[other.GetComponentInParent<Player>().indexWeapon].SetActive(false);
                other.GetComponentInParent<Player>().weapons[index].SetActive(true);
                other.GetComponentInParent<Player>().indexWeapon = index;
            }
            Debug.Log("hola");
            //GameObject weaponL = Instantiate(gameObject);
            
            
            //other.GetComponentInParent<Player>().weaponLobby = this.gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

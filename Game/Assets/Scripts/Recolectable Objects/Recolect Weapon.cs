using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectWeapon : MonoBehaviour
{
    public int index = -1;
    private bool entrar = false;
    public GameObject weapon;
    public GameObject weaponLeft;
    public bool garras;
    private void OnTriggerEnter(Collider other)
    {
        if (!entrar)
        {
            entrar = true;
            if (other.GetComponentInParent<Player>() != null)
            {
                //if (other.GetComponentInParent<Player>().animatorPlayer.GetBool("Coger") == false)
                if (garras)
                {

                    other.GetComponentInParent<Player>().animatorPlayer.SetTrigger("Garras");

                }
                else other.GetComponentInParent<Player>().animatorPlayer.SetBool("Coger", true);
                GameObject weaponL;
                if (index == -1)
                {
                    if (other.GetComponentInParent<Player>().indexWeapon != -1)
                    {
                        other.GetComponentInParent<Player>().weapons[other.GetComponentInParent<Player>().indexWeapon].SetActive(false);
                    }

                    if (other.GetComponentInParent<Player>().indexMelee != -1)
                    {
                        //Debug.Log(other.GetComponentInParent<Player>().meleeWeapons[0]);
                        //if (other.GetComponentInParent<Player>().meleeWeapons[other.GetComponent<Player>().indexMelee] != null) Debug.Log("Cuerpo");
                        
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].meleeL.SetActive(false);
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].meleeR.SetActive(false);
                    }

                    if (garras)
                    {

                        index = other.GetComponentInParent<Player>().meleeWeapons.Count;
                        weaponL = Instantiate(weapon);
                        GameObject weaponL2 = Instantiate(weaponLeft);
                        weaponL2.transform.position = other.GetComponentInParent<Player>().HandL.transform.position;
                        weaponL2.transform.rotation = other.GetComponentInParent<Player>().HandL.transform.rotation;
                        weaponL2.transform.SetParent(other.GetComponentInParent<Player>().HandL);
                        weaponL.transform.position = other.GetComponentInParent<Player>().Hand.transform.position;
                        weaponL.transform.rotation = other.GetComponentInParent<Player>().Hand.transform.rotation;
                        weaponL.transform.SetParent(other.GetComponentInParent<Player>().Hand);
                        Melee meleeWeapon = new Melee(weaponL2, weaponL);
                        other.GetComponentInParent<Player>().meleeWeapons.Add(meleeWeapon);
                        Debug.Log("Si");
                        other.GetComponentInParent<Player>().indexMelee = index;

                    }
                    //else index = other.GetComponentInParent<Player>().weapons.Count;
                    //weaponL = Instantiate(weapon);
                    //if (garras)
                    //{
                    //    GameObject weaponL2 = Instantiate(weaponLeft);
                    //    weaponL2.transform.position = other.GetComponentInParent<Player>().HandL.transform.position;
                    //    weaponL2.transform.rotation = other.GetComponentInParent<Player>().HandL.transform.rotation;
                    //    weaponL2.transform.SetParent(other.GetComponentInParent<Player>().HandL);
                    //}

                    else
                    {
                        index = other.GetComponentInParent<Player>().weapons.Count;
                        weaponL = Instantiate(weapon);
                        if (weaponL.GetComponent<Animator>()) weaponL.GetComponent<Animator>().enabled = false;
                        weaponL.GetComponentInChildren<RecolectWeapon>().enabled = false;
                        weaponL.transform.position = other.GetComponentInParent<Player>().Hand.transform.position;
                        weaponL.transform.rotation = other.GetComponentInParent<Player>().Hand.transform.rotation;
                        weaponL.transform.SetParent(other.GetComponentInParent<Player>().Hand);
                        other.GetComponentInParent<Player>().weapons.Add(weaponL);
                        other.GetComponentInParent<Player>().indexWeapon = index;

                    }

                }

                else if (!garras && other.GetComponentInParent<Player>().weapons[index].activeSelf == false)
                {
                    if (other.GetComponentInParent<Player>().indexWeapon != -1)
                    {
                        other.GetComponentInParent<Player>().weapons[other.GetComponentInParent<Player>().indexWeapon].SetActive(false);
                    }

                    if (other.GetComponentInParent<Player>().indexMelee != -1)
                    {
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].GetMeleeL().SetActive(false);
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].GetMeleeR().SetActive(false);
                    }
                    other.GetComponentInParent<Player>().weapons[index].SetActive(true);
                    other.GetComponentInParent<Player>().indexWeapon = index;
                }

                else if (garras && other.GetComponentInParent<Player>().meleeWeapons[index].GetMeleeL().activeSelf == false)
                {
                    if (other.GetComponentInParent<Player>().indexWeapon != -1)
                    {
                        other.GetComponentInParent<Player>().weapons[other.GetComponentInParent<Player>().indexWeapon].SetActive(false);
                    }

                    if (other.GetComponentInParent<Player>().indexMelee != -1)
                    {
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].GetMeleeL().SetActive(false);
                        other.GetComponentInParent<Player>().meleeWeapons[other.GetComponentInParent<Player>().indexMelee].GetMeleeR().SetActive(false);
                    }
                    other.GetComponentInParent<Player>().meleeWeapons[index].GetMeleeL().SetActive(true);
                    other.GetComponentInParent<Player>().meleeWeapons[index].GetMeleeR().SetActive(true);
                    other.GetComponentInParent<Player>().indexMelee = index;
                }
                //GameObject weaponL = Instantiate(gameObject);


                //other.GetComponentInParent<Player>().weaponLobby = this.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entrar = false;
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

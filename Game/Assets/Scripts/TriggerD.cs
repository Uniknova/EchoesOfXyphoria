using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerD : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
    }
}

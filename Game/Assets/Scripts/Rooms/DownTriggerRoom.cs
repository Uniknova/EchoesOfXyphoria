using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTriggerRoom : MonoBehaviour
{
    int x = 0;
    int y = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>()) GetComponentInParent<Room>().ChangeRoom(x, y);
    }
}

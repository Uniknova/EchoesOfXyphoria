using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTriggerRoom : MonoBehaviour
{
    int x = 1;
    int y = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>()) GetComponentInParent<Room>().ChangeRoom(x, y);
    }
}

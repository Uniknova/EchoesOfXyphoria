using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;

    public void Start()
    {
        player = Player.Instance.transform.GetChild(0).transform;
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {

        Vector3 newPosition = player.position;
        //newPosition.y = transform.position.y;
        newPosition.y += 21f;
        
        newPosition.x = newPosition.x - 20f;

        transform.position = newPosition;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    private static MiniMap instance;
    private static Transform target;
    [SerializeField] private Camera miniMapCamera;

    public static MiniMap Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<MiniMap>("MiniMapPrefab"));
                instance.SetLobbySize();
            }

            return instance;
        }
    }

    public void Init()
    {
        target = Player.Instance.gameObject.transform.GetChild(0);
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position;
            newPosition.y = miniMapCamera.transform.position.y;

            miniMapCamera.transform.position = newPosition;

        }

        else
        {
            target = Player.Instance.gameObject.transform.GetChild(0);
        }
    }

    public void SetMatchSize()
    {
        miniMapCamera.orthographicSize = 143.9f;
    }

    public void SetLobbySize()
    {
        miniMapCamera.orthographicSize = 50f;
    }
}

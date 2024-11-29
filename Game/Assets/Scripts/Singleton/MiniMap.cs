using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    private static MiniMap instance;
    private Transform target;
    [SerializeField] private Camera miniMapCamera;

    public static MiniMap Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<MiniMap>("MiniMapPrefab"));
                
            }

            return instance;
        }
    }

    public void Init()
    {
        instance.target = Player.Instance.gameObject.transform.GetChild(0);
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.y = miniMapCamera.transform.position.y;

        miniMapCamera.transform.position = newPosition;
    }
}

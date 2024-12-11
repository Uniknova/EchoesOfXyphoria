using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public Camera VirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        VirtualCamera = VirtualCameraS.Instance.GetComponent<Camera>();
        if (DataInfo.Instance.GetPlatform() == 0) this.enabled = false;
        else this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (VirtualCamera != null)
        {
            Vector3 positionOnScreen = VirtualCamera.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)VirtualCamera.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f;

            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

        }

        else if (VirtualCameraS.Instance != null)
        {
            VirtualCamera = VirtualCameraS.Instance.GetComponent<Camera>();
        }

        //ray.origin = ma
    }
}

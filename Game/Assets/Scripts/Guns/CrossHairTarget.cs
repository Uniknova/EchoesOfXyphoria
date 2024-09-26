using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    public Camera Camera;

    Ray ray;
    RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = Camera.transform.position;
        ray.direction = Camera.transform.forward;

        Physics.Raycast(ray, out hitInfo);
        transform.position = hitInfo.point;
    }
}

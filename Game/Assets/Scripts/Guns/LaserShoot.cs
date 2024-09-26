using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{

    public Camera playerCamera;
    public Transform cannon;
    public float gunRange = 1f;
    public float duration = 0.05f;

    LineRenderer laserLine;

    private RaycastHit rayHit;
    private Ray ray;

    public LayerMask layerMask;

    private Coroutine coroutine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ray = new(transform.position, transform.forward);

            if (Physics.Raycast(ray, out rayHit, gunRange, layerMask))
            {

            }

            else
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);

                }
                
                Vector3 forward = transform.forward;
                laserLine.SetPosition(0, cannon.position);
                laserLine.SetPosition(1, cannon.position + forward * gunRange);
                coroutine = StartCoroutine(LaserCoroutine(laserLine, forward));
            }
            
            //Vector3 rayOrigin = 
        }
    }

    private IEnumerator LaserCoroutine(LineRenderer line, Vector3 forward)
    {
        for (int i = 0; i < 1500; i++)
        {
            Vector3 origin = line.GetPosition(0);
            Vector3 end = line.GetPosition(1);
            line.SetPosition(0, origin + forward * 0.1f);
            line.SetPosition(1, end + forward * 0.1f);
            yield return new WaitForSeconds(0.001f);
        }
    }
}

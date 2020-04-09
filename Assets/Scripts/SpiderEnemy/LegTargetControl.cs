using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegTargetControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        foreach (GameObject item in targets)
        {
            RaycastHit hit;
            if (Physics.Raycast(item.transform.position, item.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
            {
                item.transform.GetChild(0).transform.position = hit.point;
            }
        }
    }
}

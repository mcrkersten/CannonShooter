using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + .015f);
    }
}

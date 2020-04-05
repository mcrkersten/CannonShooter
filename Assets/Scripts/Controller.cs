using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector2 maxAngle;
    public GameObject dome;
    public GameObject cannon;
    public float moveSpeedY;
    public float moveSpeedX;

    // Update is called once per frame
    void Update()
    {
        float rotationC = cannon.transform.localEulerAngles.z;
        float rotationD = dome.transform.eulerAngles.y;

        #region YRotation
        rotationD += (Input.GetAxis("Horizontal") * moveSpeedY);
        dome.transform.eulerAngles = new Vector3(0, rotationD, 0);
        #endregion

        #region XRotation
        if (cannon.transform.eulerAngles.z >= maxAngle.x) {
            rotationC += (Input.GetAxis("Mouse Y") * moveSpeedX);
        }
        else {
            rotationC = maxAngle.x;
        }

        if (cannon.transform.eulerAngles.z <= maxAngle.y) {
            rotationC += (Input.GetAxis("Mouse Y") * moveSpeedX);
        }
        else {
            rotationC = maxAngle.y;
        }
        cannon.transform.localEulerAngles = new Vector3(0, 0, rotationC);
        #endregion
    }

    void FireCannon()
    {

    }
}

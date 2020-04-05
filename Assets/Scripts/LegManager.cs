using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{
    public float distance;
    public float speed = 3f;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> legs = new List<GameObject>();
    private bool[] moveLeg = new bool[4];
    private float[] stepDistance = new float[4];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int index01 = 0;
        foreach(GameObject x in targets)
        {
            if(Vector3.Distance(x.transform.position, legs[index01].transform.position) > distance)
            {
                stepDistance[index01] = Vector3.Distance(x.transform.position, legs[index01].transform.position);
                moveLeg[index01] = true;
            }
            index01++;
        }

        int index02 = 0;
        foreach (GameObject x in targets)
        {
            if (moveLeg[index02])
            {
                float step = speed * Time.deltaTime;
                

                if (Vector3.Distance(x.transform.position, legs[index02].transform.position) > stepDistance[index02]/2)
                {
                    legs[index02].transform.position = Vector3.MoveTowards(legs[index02].transform.position, new Vector3(x.transform.position.x, x.transform.position.y + .1f, x.transform.position.z), step);
                }
                else
                {
                    legs[index02].transform.position = Vector3.MoveTowards(legs[index02].transform.position, x.transform.position, step);
                }

                if (Vector3.Distance(x.transform.position, legs[index02].transform.position) < 0.01f)
                {
                    moveLeg[index02] = false;
                }
            }
            index02++;
        }
    }

    private IEnumerator MoveLeg(float time, Vector3 position, GameObject leg)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            leg.transform.position = Vector3.Lerp(leg.transform.position, position, .1f + elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}

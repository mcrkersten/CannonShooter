using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{
    public float distance;
    public float speed = 3f;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> legs = new List<GameObject>();
    private List<Leg> legClass = new List<Leg>();
    public GameObject body;
    public float bodyHeight;

    // Update is called once per frame
    private void Start()
    {
        int i = 0;
        foreach (GameObject item in legs)
        {
            legClass.Add(new Leg(item, targets[i], i));
            i++;
        }
    }
    void Update()
    {
        foreach(Leg x in legClass)
        {
            if (Vector3.Distance(x.leg.transform.position, x.target.transform.position) > distance && legClass[x.mirrorLeg].isWalking == false)
            {
                x.stepDistance = Vector3.Distance(x.leg.transform.position, x.target.transform.position);
                x.isWalking = true;
            }
        }
        foreach (Leg x in legClass)
        {
            if (x.isWalking)
            {
                float step = speed * Time.deltaTime;

                if (Vector3.Distance(x.leg.transform.position, x.target.transform.position) > x.stepDistance / 2)
                {
                    x.leg.transform.position = Vector3.MoveTowards(x.leg.transform.position, new Vector3(x.target.transform.position.x, x.target.transform.position.y + .1f, x.target.transform.position.z), step);
                }
                else
                {
                    x.leg.transform.position = Vector3.MoveTowards(x.leg.transform.position, new Vector3(x.target.transform.position.x, x.target.transform.position.y, x.target.transform.position.z), step);
                }

                if (Vector3.Distance(x.leg.transform.position, x.target.transform.position) < 0.01f)
                {
                    x.isWalking = false;
                }
            }
        }

        body.transform.position = new Vector3(body.transform.position.x, GetAvarageLegHight() + bodyHeight, body.transform.position.z);
    }

    float GetAvarageLegHight()
    {
        float sum = 0;
        foreach (GameObject leg in legs)
        {
            sum += leg.transform.position.y;
        }
        return sum / legs.Count;
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

public class Leg{
    public int index;
    public int mirrorLeg;
    public GameObject leg;
    public GameObject target;
    public float stepDistance = 0;
    public bool isWalking = false;

    public Leg(GameObject leg, GameObject target, int index)
    {
        this.leg = leg;
        this.target = target;
        this.index = index;
        setMirrorLeg();
    }

    private void setMirrorLeg()
    {
        switch (index)
        {
            case 0:
                mirrorLeg = 2;
                return;
            case 1:
                mirrorLeg = 3;
                return;
            case 2:
                mirrorLeg = 0;
                return;
            case 3:
                mirrorLeg = 1;
                return;
        }
    }
}

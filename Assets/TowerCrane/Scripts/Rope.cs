using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public SpringJoint springJoint;
    public LineRenderer line;
    public float distanceOfRope, minDistance = 3f, maxDistance = 15f;


    //Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();

    }

    void Update()
    {


    }

    private void OnEnable()
    {
        Events.onRopeValueChange += SetLengthOfRope;

    }
    private void OnDisable()
    {
        Events.onRopeValueChange -= SetLengthOfRope;

    }



    void SetLengthOfRope(float ropeValue)
    {


        line.SetPosition(0, transform.position);
        line.SetPosition(1, springJoint.connectedBody.transform.position);

       

        if (ropeValue > 0)
        {
            if (ropeValue < 15)
            {
                springJoint.maxDistance = distanceOfRope += 0.01f;
                //print("Gear 1= ");
            }
            else if (ropeValue < 30)
            {
                springJoint.maxDistance = distanceOfRope += 0.03f;
                //print("Gear 2 " );
            }
            else if (ropeValue <= 45)
            {
                springJoint.maxDistance = distanceOfRope += 0.5f;
                //print("Gear 3  ");
            }
        }
        else if (ropeValue < 0)
        {
            if (ropeValue > -15)
            {
                springJoint.maxDistance = distanceOfRope -= 0.01f;
                //print("ReverceGear 1");
            }
            else if (ropeValue > -30)
            {
                springJoint.maxDistance = distanceOfRope -= 0.03f;
                //print("ReverceGear 2");
            }
            else if (ropeValue >= -45)
            {
                springJoint.maxDistance = distanceOfRope -= 0.05f;
                //print("ReverceGear 3");
            }
        }



        distanceOfRope = Mathf.Clamp(springJoint.maxDistance, minDistance, maxDistance);

    }

}
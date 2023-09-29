using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    ConfigurableJoint configurableJoint;
    public LineRenderer line;
    public float distanceOfRope, minLowDistance;
    public float maxHighDistance;
    public SoftJointLimit limits = new SoftJointLimit();

    private float ropeValue = 0;
    //Rigidbody rb;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        configurableJoint = GetComponent<ConfigurableJoint>(); ;

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
        line.SetPosition(1, configurableJoint.connectedBody.transform.position);
        //line.SetPosition(1, springJoint.connectedBody.transform.position);



        if (ropeValue > 0 && distanceOfRope < maxHighDistance)
        {
            if (ropeValue < 15)
            {
                distanceOfRope += 0.001f;
                //print("Gear 1= ");
            }
            else if (ropeValue < 30)
            {
                distanceOfRope += 0.003f;
                //print("Gear 2 " );
            }
            else if (ropeValue <= 45)
            {
                distanceOfRope += 0.005f;
                //print("Gear 3  ");
            }
        }
        else if (ropeValue < 0 && distanceOfRope > minLowDistance)
        {
            if (ropeValue > -15)
            {
                distanceOfRope -= 0.001f;
                //print("ReverceGear 1");
            }
            else if (ropeValue > -30)
            {
                distanceOfRope -= 0.003f;
                //print("ReverceGear 2");
            }
            else if (ropeValue >= -45)
            {
                distanceOfRope -= 0.005f;
                //print("ReverceGear 3");
            }
        }



        limits.limit = distanceOfRope;
        configurableJoint.linearLimit = limits;

    }

    //IEnumerator UpdateRopeLimit()
    //{
    //    while (ropeValue != 0)
    //    {
    //        Debug.Log("UpdateRopeLimit");
    //        //print(ropeValue);
    //        if (ropeValue > 0 && distanceOfRope < maxHighDistance)
    //        {
    //            if (ropeValue < 15)
    //            {
    //                distanceOfRope += 0.01f;
    //                //print("Gear 1= ");
    //            }
    //            else if (ropeValue < 30)
    //            {
    //                distanceOfRope += 0.03f;
    //                //print("Gear 2 " );
    //            }
    //            else if (ropeValue <= 45)
    //            {
    //                distanceOfRope += 0.05f;
    //                //print("Gear 3  ");
    //            }

    //            // Debug.Log("distanceOfRope ++++ =" + distanceOfRope);
    //        }
    //        else if (ropeValue < 0 && distanceOfRope > minLowDistance)
    //        {
    //            if (ropeValue > -15)
    //            {
    //                distanceOfRope -= 0.01f;
    //                //print("ReverceGear 1");
    //            }
    //            else if (ropeValue > -30)
    //            {
    //                distanceOfRope -= 0.03f;
    //                //print("ReverceGear 2");
    //            }
    //            else if (ropeValue >= -45)
    //            {
    //                distanceOfRope -= 0.05f;
    //                //print("ReverceGear 3");
    //            }
    //            //  Debug.Log("distanceOfRope ----- =" + distanceOfRope);

    //        }

    //        // if (ropeValue != 0)
    //        {
    //            limits.limit = distanceOfRope;


    //            configurableJoint.linearLimit = limits;

    //            line.SetPosition(0, transform.position);

    //            line.SetPosition(1, configurableJoint.connectedBody.transform.position);

    //        }
    //        yield return null;
    //        //yield return new WaitForSeconds(0.005f);
    //    }
    //}

    //void SetLengthOfRope(float ropeValue)
    //{




    //    if (this.ropeValue != ropeValue)
    //    {
    //        this.ropeValue = ropeValue;
    //        //StartCoroutine(UpdateRopeLimit());
    //    }



    //}

}
    
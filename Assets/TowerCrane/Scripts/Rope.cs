using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    #region PUBLIC_VARS
    public LineRenderer line;
    public float distanceOfRope, minLowDistance;
    public float maxHighDistance;
    public SoftJointLimit limits = new SoftJointLimit();
    public GameObject ropePosition;
    #endregion

    #region PRIVATE_VARS
    ConfigurableJoint configurableJoint;

    #endregion


    #region UNITY_CALLBACKS
    void Start()
    {
        line = GetComponent<LineRenderer>();
        configurableJoint = GetComponent<ConfigurableJoint>();
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, ropePosition.transform.position);
        //Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;
    }

   

    private void OnEnable()
    {
        Events.onRopeValueChange += SetLengthOfRope;

    }
    private void OnDisable()
    {
        Events.onRopeValueChange -= SetLengthOfRope;

    }

    private void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, ropePosition.transform.position);

    }

    #endregion


    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS

    void SetLengthOfRope(float ropeValue)
    {


        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, configurableJoint.connectedBody.transform.position);
        //line.SetPosition(1, ropePosition.transform.position);



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
    #endregion




}
    
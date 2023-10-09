using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    #region PUBLIC_VARS
    public Rigidbody rb;
    #endregion
    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        rb.WakeUp();
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion


    //void BodyIsDetached(bool detached)
    //{
    //    //print(detached);

    //    //if (detached!)
    //    //{
    //    //    detached = true;
    //    //    fixedJoint.connectedBody = null;

    //    //}
    //}



}

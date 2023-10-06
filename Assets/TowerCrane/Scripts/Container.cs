using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    
    public Rigidbody rb;
    private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        rb.WakeUp();
    }

   

    void BodyIsDetached(bool detached)
    {
        //print(detached);

        //if (detached!)
        //{
        //    detached = true;
        //    fixedJoint.connectedBody = null;

        //}
    }


   
}

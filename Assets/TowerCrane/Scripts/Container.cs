using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    //[SerializeField] private float radius;
    //public Transform hoockConnect;
    //private FixedJoint fixedJoint;
    public Rigidbody rb;
    private bool isHooked = false;

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

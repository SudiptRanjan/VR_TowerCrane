using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private float radius;
    public Transform hoockConnect;
    public FixedJoint fixedJoint;
    public Rigidbody rb;

    private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        rb.WakeUp();
    }

    private void OnEnable()
    {
        Events.onHookAttachToObject += CheckingOfPhysicsBody;
        Events.onHookDetachedToObject += BodyIsDetached;
    }

    private void OnDisable()
    {
        Events.onHookAttachToObject -= CheckingOfPhysicsBody;
        Events.onHookDetachedToObject -= BodyIsDetached;
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


    void CheckingOfPhysicsBody(bool attached)
    {

        if (attached)
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            print("attached");
            foreach (Collider grabableObject in hitColliders)
            {

                Hoock grabableContainer = grabableObject.gameObject.GetComponent<Hoock>();
                //print(grabableContainer);
                if (grabableContainer != null)
                {
                    transform.position = hoockConnect.transform.position;
                    fixedJoint.connectedBody = grabableContainer.rb;


                }
            }

            rb.velocity = Vector3.zero;

        }
        else
        {
            fixedJoint.connectedBody = null;
            //print("detached");
        }


    }
}

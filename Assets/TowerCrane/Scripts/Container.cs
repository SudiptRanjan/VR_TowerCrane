using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private float radius;
    public Transform hoockConnect;
    private FixedJoint fixedJoint;
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
            foreach (Collider grabableObject in hitColliders)
            {

                Hoock grabableContainer = grabableObject.gameObject.GetComponent<Hoock>();
                //print(grabableContainer);
                if (grabableContainer != null && !isHooked)
                {
                    isHooked = true;

                    transform.position = hoockConnect.transform.position;
                    fixedJoint = gameObject.AddComponent<FixedJoint>();
                    fixedJoint.connectedBody = grabableContainer.rb;
                    print("attached");


                }
            }

            //rb.velocity = Vector3.zero;

        }
        else
        {
            if(fixedJoint != null )
            {
                isHooked = false;
                //fixedJoint.connectedBody = null;
                Destroy(fixedJoint);
                print("detached");
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{
   
    [SerializeField] private float radius;
    public Transform hoockConnect;
    public FixedJoint fixedJoint;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
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
        Events.onHookDetachedToObject -=  BodyIsDetached;
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

        if (attached )
        {
            
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            print("attached");
            foreach (Collider grabableObject in hitColliders)
            {
               
                Container grabableContainer = grabableObject.gameObject.GetComponent<Container>();
                //print(grabableContainer);
                if (grabableContainer != null )
                {
                    grabableContainer.transform.position = hoockConnect.transform.position;
                    fixedJoint.connectedBody = grabableContainer.rb;
                    

                }
            }

        }
        else
        {
            fixedJoint.connectedBody = null;
            print("detached");
        }

        //if (attached!)
        //{
            
        //    fixedJoint.connectedBody = null;
        //    print("detached");

        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 6 && attached)
    //    {
    //        Debug.Log("block");
    //        //other.transform.SetParent(this.transform);
    //        other.transform.position = hoockConnect.transform.position;
    //        fixedJoint.connectedBody = other.attachedRigidbody;



    //    }
    //}
}

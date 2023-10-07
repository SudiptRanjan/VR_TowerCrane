using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{

    [SerializeField] private float radius;
    public Transform hoockConnect;
    private FixedJoint fixedJoint;
    public float decelerationForce = 1f;
    private bool isHooked = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Events.onHookAttachToObject += CheckingOfPhysicsBody;
    }

    private void OnDisable()
    {
        Events.onHookAttachToObject -= CheckingOfPhysicsBody;
    }

    private bool isMoving = false;

    void Update()
    {
        rb.WakeUp();
        float movementInput = Input.GetAxis("Vertical");

        isMoving = Mathf.Abs(movementInput) > 0.1f;

        if (!isMoving)
        {
            movementInput = Input.GetAxis("Horizontal");

            isMoving = Mathf.Abs(movementInput) > 0.1f;

        }

        if (!isMoving)
        {
            ApplyDecelerationForce();
        }
        //else
        //{

        //}
    }

    void ApplyDecelerationForce()
    {

        Vector3 deceleration = -rb.velocity.normalized * decelerationForce;

        rb.AddForce(deceleration, ForceMode.Acceleration);
    }
    void CheckingOfPhysicsBody(bool attached)
    {

        if (attached)
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider grabableObject in hitColliders)
            {

                Container grabableContainer = grabableObject.gameObject.GetComponent<Container>();
                if (grabableContainer != null && !isHooked)
                {
                  
                    isHooked = true;

                    grabableContainer.transform.position = hoockConnect.transform.position;
                    fixedJoint = gameObject.AddComponent<FixedJoint>();
                    fixedJoint.connectedBody = grabableContainer.rb;
                    print("attached");
                    //grabableContainer.GetComponent<Rigidbody>().mass = 10;
                  

                }
               
               
            }


        }
        else
        {
            if (fixedJoint != null)
            {
                isHooked = false;
                //fixedJoint.connectedBody = null;
                Destroy(fixedJoint);
                print("detached");
            }

        }

    }


}

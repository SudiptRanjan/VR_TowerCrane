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
        //Events.onHookDetachedToObject += BodyIsDetached;
    }

    private void OnDisable()
    {
        Events.onHookAttachToObject -= CheckingOfPhysicsBody;
        //Events.onHookDetachedToObject -= BodyIsDetached;
    }




    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();
        // Check for input to move the hook
        float movementInput = Input.GetAxis("Vertical"); // Adjust based on your input method

        // Determine if the hook is moving
        isMoving = Mathf.Abs(movementInput) > 0.1f;

        if (!isMoving)
        {
            movementInput = Input.GetAxis("Horizontal"); // Adjust based on your input method

            // Determine if the hook is moving
            isMoving = Mathf.Abs(movementInput) > 0.1f;

        }

        // Apply force to decelerate when input is released
        if (!isMoving)
        {
            ApplyDecelerationForce();
        }
        else
        {
            //Debug.Log("velocity :" + rb.velocity);
        }
    }

    void ApplyDecelerationForce()
    {
        //Debug.Log("ApplyDecelerationForce :" + rb.velocity);

        // Calculate the opposite force to decelerate the hook
        Vector3 deceleration = -rb.velocity.normalized * decelerationForce;

        // Apply the deceleration force to the Rigidbody
        rb.AddForce(deceleration, ForceMode.Acceleration);
    }
    void CheckingOfPhysicsBody(bool attached)
    {
        float massOfContainer;

        if (attached)
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider grabableObject in hitColliders)
            {

                Container grabableContainer = grabableObject.gameObject.GetComponent<Container>();
                //print(grabableContainer);
                if (grabableContainer != null && !isHooked)
                {
                     massOfContainer = grabableContainer.GetComponent<Rigidbody>().mass;
                    print(" grabableContainer.GetComponent<Rigidbody>().mass==" + massOfContainer);
                    isHooked = true;

                    grabableContainer.transform.position = hoockConnect.transform.position;
                    fixedJoint = gameObject.AddComponent<FixedJoint>();
                    fixedJoint.connectedBody = grabableContainer.rb;
                    print("attached");
                    // grabableContainer.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //grabableContainer.GetComponent<Rigidbody>().mass = 25;
                  

                }
               
            }

            //rb.velocity = Vector3.zero;

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

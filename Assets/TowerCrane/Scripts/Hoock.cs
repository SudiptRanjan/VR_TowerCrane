using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{

    //[SerializeField] private float radius;
    //public Transform hoockConnect;
    //public FixedJoint fixedJoint;
    public float decelerationForce = 0.5f;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //private void FixedUpdate()
    //{
    //    rb.WakeUp();
    //}


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


}

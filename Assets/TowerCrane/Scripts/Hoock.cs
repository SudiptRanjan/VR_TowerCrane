using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoock : MonoBehaviour
{
    #region PUBLIC_VARS
    public Transform hoockConnect;
    public float decelerationForce = 1f;
    #endregion

    #region PRIVATE_VARS
    [SerializeField] private float radius;
    private FixedJoint fixedJoint;
    private bool isHooked = false;
    private Rigidbody rb;
    #endregion

    #region UNITY_CALLBACKS

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
        //float movementInput = Input.GetAxis("Vertical");

        //isMoving = Mathf.Abs(movementInput) > 0.1f;

        //if (!isMoving)
        //{
        //    movementInput = Input.GetAxis("Horizontal");

        //    isMoving = Mathf.Abs(movementInput) > 0.1f;

        //}

        //if (!isMoving)
        //{
        //    ApplyDecelerationForce();
        //}
        deacelarationForce();
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTION

    void deacelarationForce()
    {
        //rb.WakeUp();
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
    #endregion


}

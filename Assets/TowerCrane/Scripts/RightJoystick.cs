using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class RightJoystick : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS        
    [SerializeField] Transform playerController;
    [SerializeField] Transform playerStick;

    [SerializeField] XRSimpleInteractable xrHandsRopes;
    bool isTriggered;

    [SerializeField] Vector2 gunControlXPos;
    [SerializeField] Vector2 gunControlYPos;

    float  ropeLengthValue;

    float clampedX;
    float clampedZ;



    [SerializeField] IXRSelectInteractor currentInteractorRope;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHandsRopes.selectEntered.AddListener(Grab);
        xrHandsRopes.selectExited.AddListener(UnGrab);

    }

    private void OnDisable()
    {
        xrHandsRopes.selectEntered.RemoveListener(Grab);
        xrHandsRopes.selectExited.RemoveListener(UnGrab);

    }

    private void Update()
    {


        if (currentInteractorRope != null)
        {
            TopBallMovement();
        }

        Events.onRopeValueChange(ropeLengthValue);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player Got Hit");
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        //Debug.Log("Grab Entered");
        currentInteractorRope = args0.interactorObject;
        isTriggered = true;     //For Bullet Firing when grabbing the handle
        //Debug.Log("Hand Position " + currentInteractor.transform.position);
    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        //Debug.Log("UnGrabbing");
        ResetPosition();
        ropeLengthValue = 0;
        currentInteractorRope = null;
        isTriggered = false;
    }


    //private void StopFiring(CallbackContext obj)
    //{
    //    isTriggered = false;
    //}



    private void TopBallMovement()
    {
        Vector3 stickDirection = currentInteractorRope.transform.position - playerStick.position;
        Vector3 direction = stickDirection;
        Quaternion stickForward = Quaternion.LookRotation(direction, transform.forward);



        playerStick.rotation = stickForward;

        //Debug.Log("local Rotation " + playerStick.localEulerAngles);
        //Debug.Log("Rotation " + playerStick.eulerAngles);
        float stickXRot = playerStick.localRotation.eulerAngles.x;
        float stickYRot = playerStick.localRotation.eulerAngles.y;


        if (!(stickXRot > 0 && stickXRot < 180) && !(stickXRot < 0 && stickXRot > -180))
        {
            stickXRot = stickXRot - 360;
            //Debug.Log("Converted Value of X " + stickXRot);
        }
        if (!(stickYRot > 0 && stickYRot < 180) && !(stickYRot < 0 && stickYRot > -180))
        {
            stickYRot = stickYRot - 360;
            //Debug.Log("Converted Valye of Y " + stickYRot);
        }

        clampedX = Mathf.Clamp(stickXRot, gunControlXPos.x, gunControlXPos.y);
        clampedZ = Mathf.Clamp(stickYRot, gunControlYPos.x, gunControlYPos.y);
        ropeLengthValue = clampedX;
      
        //print("clampedX == "+ clampedX);
        playerStick.localRotation = Quaternion.Euler(clampedX, clampedZ, 0);


    }


    private void ResetPosition()
    {
        playerStick.localRotation = Quaternion.Euler(0, 0, 0);
    }
    #endregion
}

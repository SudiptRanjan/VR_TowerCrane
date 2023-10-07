using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System.Collections;

public class RightJoystick : MonoBehaviour
{
    #region PUBLIC_VARS
    public GreenAlertButton greenAlert;
    public RedStartButton redStartButton;
    #endregion

    #region PRIVATE_VARS        
    [SerializeField] Transform playerController;
    [SerializeField] Transform playerStick;

    [SerializeField] XRSimpleInteractable xrHandsRopes;

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
            //Events.onRopeValueChange(ropeLengthValue);

        }
    }

    
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion
    bool isgrabed = false;
    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        isgrabed = true;
        Debug.Log("Grab Entered");
        currentInteractorRope = args0.interactorObject;
        //StartCoroutine(UpdateRopeLimit());
    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        isgrabed = false;
        Debug.Log("UnGrabbing");
        ResetPosition();
        ropeLengthValue = 0;
        currentInteractorRope = null;
        //StopCoroutine(UpdateRopeLimit());
        
    }

    //IEnumerator UpdateRopeLimit()
    //{
    //    //while(ropeLengthValue != 0)
    //    while (isgrabed)
    //    {

    //        yield return new WaitForSeconds(0.0001f);
    //        Events.onRopeValueChange(ropeLengthValue);
    //        //Debug.Log("UpdateRopeLimit");
    //    }

    //}
    private void FixedUpdate()
    {
        if (isgrabed)
        {
            Events.onRopeValueChange(ropeLengthValue);

        }

    }

    private void TopBallMovement()
    {


        Vector3 stickDirection = currentInteractorRope.transform.position - playerStick.position;
        Vector3 direction = stickDirection;
        Quaternion stickForward = Quaternion.LookRotation(direction, transform.forward);



        playerStick.rotation = stickForward;

        float stickXRot = playerStick.localRotation.eulerAngles.x;
        float stickYRot = playerStick.localRotation.eulerAngles.y;


        if (!(stickXRot > 0 && stickXRot < 180) && !(stickXRot < 0 && stickXRot > -180))
        {
            stickXRot = stickXRot - 360;
        }
        if (!(stickYRot > 0 && stickYRot < 180) && !(stickYRot < 0 && stickYRot > -180))
        {
            stickYRot = stickYRot - 360;
        }

        clampedX = Mathf.Clamp(stickXRot, gunControlXPos.x, gunControlXPos.y);
        clampedZ = Mathf.Clamp(stickYRot, gunControlYPos.x, gunControlYPos.y);

        if (redStartButton.alert && greenAlert.engineStartButton)
        {
           
            
                ropeLengthValue = -clampedX;

            

        }
      
        playerStick.localRotation = Quaternion.Euler(clampedX, clampedZ, 0);


    }


    private void ResetPosition()
    {
        playerStick.localRotation = Quaternion.Euler(0, 0, 0);
    }
    #endregion
}

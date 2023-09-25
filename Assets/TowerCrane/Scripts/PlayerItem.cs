using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PlayerItem : MonoBehaviour
{
    #region PUBLIC_VARS
    public JibMovement jibMovement;
    #endregion

    #region PRIVATE_VARS        
    [SerializeField] Transform playerController;
    [SerializeField] Transform playerStick;

    [SerializeField] XRSimpleInteractable xrHands;
    //bool isTriggered;

    [SerializeField] Vector2 gunControlXPos;
    [SerializeField] Vector2 gunControlYPos;

    float rotateValue, movementValue;

    float clampedX;
    float clampedZ;

   

    [SerializeField] IXRSelectInteractor currentInteractor;

   
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);

    }
    private void OnEnable()
    {
        //Events.onClickRedButton += TopBallMovement;
    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);
        //Events.onClickRedButton -= TopBallMovement;

    }

    private void Update()
    {


        if (currentInteractor != null)
        {
            TopBallMovement();
        }

        Events.onPlayerMoves(movementValue);
        Events.onPlayerRotate(rotateValue);
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
        currentInteractor = args0.interactorObject;
        //isTriggered = true;     //For Bullet Firing when grabbing the handle
        //Debug.Log("Hand Position " + currentInteractor.transform.position);
    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        //Debug.Log("UnGrabbing");
        ResetPosition();
        rotateValue = 0;
        movementValue = 0;
        currentInteractor = null;
        //isTriggered = false;
    }

    
   
  

    private void TopBallMovement( )
    {
        //Debug.Log("currentInteractor.transform.positio =" + currentInteractor.transform.position);
        //Debug.Log("playerStick.position = " + playerStick.position);
        Vector3 stickDirection = currentInteractor.transform.position - playerStick.position;
        
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


        if (jibMovement.isalerted  && jibMovement.isEngineStarted)
        {
            rotateValue = -clampedZ;
            movementValue = clampedX;
            print(" Alert");
        }

        //rotateValue = -clampedZ;
        //movementValue = clampedX;
        //print("clampedX == " + clampedX);
        playerStick.localRotation = Quaternion.Euler(clampedX, clampedZ, 0);


    }


    private void ResetPosition()
    {
        playerStick.localRotation = Quaternion.Euler(0, 0, 0);
    }
    #endregion

}


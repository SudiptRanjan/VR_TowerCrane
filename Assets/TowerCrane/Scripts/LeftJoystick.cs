using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System.Collections;

public class LeftJoystick : MonoBehaviour
{
    #region PUBLIC_VARS
    //public JibMovement jibMovement;
    public GreenAlertButton greenAlert;
    public RedStartButton redStartButton;
    #endregion

    #region PRIVATE_VARS        
    [SerializeField] Transform playerController;
    [SerializeField] Transform playerStick;

    [SerializeField] XRSimpleInteractable xrHands;

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
    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);

    }

    private void Update()
    {


        if (currentInteractor != null)
        {
            TopBallMovement();
            Events.onPlayerMoves(movementValue);
            Events.onPlayerRotate(rotateValue);
        }

       
    }

    //IEnumerator UpdateMovement()
    //{
    //    while(true)
    //    {
    //        if (currentInteractor != null)
    //        {
    //            TopBallMovement();
    //        }

    //        Events.onPlayerMoves(movementValue);
    //        Events.onPlayerRotate(rotateValue);
    //        yield return null;

    //    }

    //}

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

        currentInteractor = args0.interactorObject;
        //StartCoroutine(UpdateMovement());
    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        //Debug.Log("UnGrabbing");
        ResetPosition();
        rotateValue = 0;
        movementValue = 0;
        //StopCoroutine(UpdateMovement());
        currentInteractor = null;
    }

    
   
  

    private void TopBallMovement( )
    {
        Vector3 stickDirection = currentInteractor.transform.position - playerStick.position;
        
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


        if(redStartButton.alert  && greenAlert.engineStartButton)
        {

           
            
                rotateValue = -clampedZ;
                movementValue = clampedX;
                //print(" Alert");
            

        }

       
        playerStick.localRotation = Quaternion.Euler(clampedX, clampedZ, 0);


    }


    private void ResetPosition()
    {
        playerStick.localRotation = Quaternion.Euler(0, 0, 0);
    }
    #endregion

}


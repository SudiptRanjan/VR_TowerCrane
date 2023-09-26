using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class RightRedButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool isalertRightButton = false;

    public Material rendererls;
    //public JibMovement jibMovement;

    #endregion

    #region PRIVATE_VARS        


    [SerializeField] XRSimpleInteractable xrHands;



    [SerializeField] IXRSelectInteractor redCurrentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);



        rendererls.color = Color.red;

        //alert = true;

    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);


    }

    


    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Grab(SelectEnterEventArgs args0)
    {
        redCurrentInteractor = args0.interactorObject;
        Debug.Log("Grab Entered red button");
        //jibMovement.isalerted = true;
        //jibMovement.isEngineStarted = true;
        //alert = true;

        if (isalertRightButton == false)
        {
            isalertRightButton = true;
            rendererls.color = Color.blue;
        }
        else
        {
            isalertRightButton = false;
            rendererls.color = Color.red;
        }

      

    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing red button");
        //ropeLengthValue = 0;
        redCurrentInteractor = null;

        //isTriggered = false;
    }
    #endregion
}





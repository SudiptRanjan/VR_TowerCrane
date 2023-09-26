

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class GreenAlertButton : MonoBehaviour
{
    #region PUBLIC_VARS
    public bool engineStartButton = false;
    public Material rendererls;
    //public JibMovement jibMovement;

    #endregion

    #region PRIVATE_VARS        


    [SerializeField] XRSimpleInteractable xrHands;



    [SerializeField] IXRSelectInteractor currentInteractor;


    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        xrHands.selectEntered.AddListener(Grab);
        xrHands.selectExited.AddListener(UnGrab);
        rendererls.color = Color.green;

        //alert = true;

    }

    private void OnDisable()
    {
        xrHands.selectEntered.RemoveListener(Grab);
        xrHands.selectExited.RemoveListener(UnGrab);

    }

    private void Update()
    {


        //if (currentInteractorRope != null)
        //{

        //}
        //Events.onClickRedButton(grabed);



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
        Debug.Log("Grab Entered red button");
        //jibMovement.isalerted = true;
        //jibMovement.isEngineStarted = true;
        //alert = true;

        if (engineStartButton == false)
        {
            engineStartButton = true;
            rendererls.color = Color.blue;
        }
        else
        {
            engineStartButton = false;
            rendererls.color = Color.green;
        }

    }



    private void UnGrab(SelectExitEventArgs args0)
    {
        Debug.Log("UnGrabbing red button");
        //ropeLengthValue = 0;
        currentInteractor = null;
        //isTriggered = false;
    }
    #endregion
}



